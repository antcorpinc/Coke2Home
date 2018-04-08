import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource } from '@angular/material';
import { FormGroup, Validators, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { ChildAndExtraBedPolicyViewModel } from './../../../viewmodel/policiesviewmodel/childandextrabedpolicyviewmodel';
import { HotelCurrencyViewModel } from './../../../viewmodel/common/hotelcurrencyviewmodel';
import { PoliciesDataService } from './../../../common/extranet-shared/services/policies-data.service';
import { ExtranetLookupService } from './../../../common/extranet-shared/services/extranet-lookup';
import { RoomTypeViewModel } from './../../../viewmodel/policiesviewmodel/roomtypeviewmodel';
import { CONSTANTS } from '../../../../common/constants';
import { EXTRANETCONSTANTS } from '../../../common/constants';
import { DialogsService } from '../../../common/extranet-shared/dialogs/dialogs.service';

import { ObjectState } from '../../../../common/enums';

function ValidateChildAndExtraBedPolicyForm(control: AbstractControl): { [key: string]: boolean } | null {
  const minAge = control.get('minChildAge');
  const maxAge = control.get('maxChildAge');
  if (minAge.value && maxAge.value && minAge.value >= maxAge.value) {
    return {
      'isGreater': true
    };
  } return null;
}
function ValidateRoomList(control: AbstractControl): { [key: string]: boolean } | null {
  const maxChildren = control.get('maxChildren');
  const noOfGuest = control.get('noOfGuest');
  if (maxChildren.value && noOfGuest.value && maxChildren.value >= noOfGuest.value) {
    return {
      'isGreater': true,
    };
  }
  return null;
}

@Component({
  selector: 'app-child-and-extra-bed-policy',
  templateUrl: './child-and-extra-bed-policy.component.html',
  styleUrls: ['./child-and-extra-bed-policy.component.css']
})
export class ChildAndExtraBedPolicyComponent implements OnInit {
  hotelId: number;
  operation: string;
  childAndExtrabedPolicyArray: ChildAndExtraBedPolicyViewModel;
  childAndExtraBedPolicyInfo: ChildAndExtraBedPolicyViewModel = <ChildAndExtraBedPolicyViewModel>{};
  childAndExtrabedPolicyForm: FormGroup;
  hotelCurrency: HotelCurrencyViewModel[];
  minMaxAge: Array<number> = [2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18];
  bedsAndChildrenPerRoom: Array<number> = [];
  policyId: number;
  policyOperation: string;
  currencyCode: string;
  result: any;
  contentChanged: boolean;
  edit = CONSTANTS.operation.edit;
  read = CONSTANTS.operation.read;
  create = CONSTANTS.operation.create;
  isFree = EXTRANETCONSTANTS.policies.isFree;
  isPaid = EXTRANETCONSTANTS.policies.isPaid;

  constructor(private router: Router,
    private policiesDataService: PoliciesDataService,
    private extranetLookupService: ExtranetLookupService,
    private dialogsService: DialogsService,
    private activatedRoute: ActivatedRoute,
    public snackBar: MatSnackBar) { }

  ngOnInit() {
    window.scrollTo(0, 0);
    this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.policyOperation = this.activatedRoute.snapshot.params['operation'];
    this.policyId = this.activatedRoute.snapshot.params['id'];
    this.getChildAndExtraBedpolicyDetails();
    this.bedsAndChildrenPerRoom = Array(6).fill('').map((x, i) => i);
    this.childAndExtrabedPolicyForm = new FormGroup({
      isChildrenAllowed: new FormControl(true),
      minChildAge: new FormControl('', Validators.required),
      maxChildAge: new FormControl('', Validators.required),
      isExtraCotAllowed: new FormControl(true),
      maxInfantAge: new FormControl('', Validators.required),
      cotPrice: new FormControl('', Validators.required),
      isExtraBedAllowed: new FormControl(true),
      cotPriceTypeId: new FormControl('', Validators.required),
      maxChildAndExtraBedPerRoomList: (this.buildRoomListGroupsForm(this.childAndExtrabedPolicyArray[0].maxChildAndExtraBedPerRoomList))
    }, ValidateChildAndExtraBedPolicyForm);

    this.childAndExtraBedPolicyInfo.id = 0;
    this.childAndExtraBedPolicyInfo.hotelId = this.hotelId;
    this.childAndExtraBedPolicyInfo.minInfantAge = 0;

    if (this.policyOperation.toLowerCase().trim() === this.create) {
      this.childAndExtraBedPolicyInfo.objectState = ObjectState.Added;
    }

    if (this.policyOperation.toLowerCase().trim() === this.edit) {
      this.getPolicyDetails(this.hotelId);
    }
  }

  buildRoomListGroupsForm(roomList: RoomTypeViewModel[]): FormArray {
    let roomGroup: FormGroup;
    let roomArray: FormArray;
    roomList.forEach(room => {
      roomGroup = new FormGroup({
        roomId: new FormControl(room.roomId),
        roomName: new FormControl(room.roomName),
        noOfGuest: new FormControl(room.noOfGuest),
        bedCount: new FormControl(room.bedCount),
        maxChildren: new FormControl('', Validators.required),
        extraBedCount: new FormControl('', Validators.required),
        objectState: new FormControl(),
      }, ValidateRoomList);
      if (roomArray === null || roomArray === undefined) {
        roomArray = new FormArray([roomGroup]);
      } else {
        roomArray.push(roomGroup);
      }
    });
    return roomArray;
  }

  get maxChildAndExtraBedPerRoomList(): FormArray {
    return <FormArray>this.childAndExtrabedPolicyForm.get('maxChildAndExtraBedPerRoomList');
  }

  getChildAndExtraBedpolicyDetails() {
    this.childAndExtrabedPolicyArray = this.activatedRoute.snapshot.data['childAndExtraBedPolicyData'];
    this.getCurrencyByHotelId(this.hotelId);
  }

  getCurrencyByHotelId(hotelId: number) {
    this.extranetLookupService.getCurrencyByHotelId(hotelId).subscribe((hotelCurrency) => {
      this.hotelCurrency = hotelCurrency;
      this.currencyCode = this.hotelCurrency[0].currencyCode;
    });
  }

  saveChildAndExtraBedPolicy() {
    if (this.childAndExtrabedPolicyForm.valid) {
      const childAndExtrabedPolicy = Object.assign({}, this.childAndExtraBedPolicyInfo, this.childAndExtrabedPolicyForm.value);
      if (this.policyOperation.toLowerCase().trim() === this.create) {
        childAndExtrabedPolicy.maxChildAndExtraBedPerRoomList.forEach((room) => {
          room.objectState = ObjectState.Modified;
        });
      }
      if (this.childAndExtrabedPolicyForm.get('isExtraBedAllowed').value === false) {
        childAndExtrabedPolicy.maxChildAndExtraBedPerRoomList.forEach((room) => {
          room.maxChildren = null;
          room.extraBedCount = null;
          room.objectState = ObjectState.Modified;
        });
      }
      if (this.childAndExtrabedPolicyForm.get('cotPriceTypeId').value === this.isFree) {
        childAndExtrabedPolicy.cotPrice = 0;
      }
      if (this.childAndExtrabedPolicyForm.get('isChildrenAllowed').value === false) {
        childAndExtrabedPolicy.minChildAge = null;
        childAndExtrabedPolicy.minChildAge = null;
      }
      if (this.childAndExtrabedPolicyForm.get('isExtraCotAllowed').value === false) {
        childAndExtrabedPolicy.maxInfantAge = null;
        childAndExtrabedPolicy.cotPriceTypeId = null;
        childAndExtrabedPolicy.cotPrice = null;
      }
      this.policiesDataService.addChildAndExtrabedPolicy(childAndExtrabedPolicy as ChildAndExtraBedPolicyViewModel)
        .subscribe(data => {
          this.snackBar.open('Policy Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
          this.router.navigate(['/hotelmgmt/hotel', this.hotelId, this.operation, 'policieslist']);
        });
    }
  }

  getPolicyDetails(hotelId) {
    this.getCurrencyByHotelId(this.hotelId);
    this.policiesDataService.getChildAndExtraBedpolicyDetails(+hotelId).subscribe(
      (policyData) => {
        this.policiesDataService.childAndExtraBedPolicyDetails = policyData;
        if (this.policyOperation.toLowerCase().trim() === this.edit) {
          this.childAndExtrabedPolicyForm.get('isChildrenAllowed').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].isChildrenAllowed);
          this.childAndExtrabedPolicyForm.get('minChildAge').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].minChildAge);
          this.childAndExtrabedPolicyForm.get('maxChildAge').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].maxChildAge);
          this.childAndExtrabedPolicyForm.get('isExtraCotAllowed').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].isExtraCotAllowed);
          this.childAndExtrabedPolicyForm.get('maxInfantAge').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].maxInfantAge);
          this.childAndExtrabedPolicyForm.get('cotPrice').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].cotPrice);
          this.childAndExtrabedPolicyForm.get('isExtraBedAllowed').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].isExtraBedAllowed);
          this.childAndExtrabedPolicyForm.get('cotPriceTypeId').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].cotPriceTypeId);
          this.maxChildAndExtraBedPerRoomList.controls.forEach((control, index) => {
            control.get('roomId').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].maxChildAndExtraBedPerRoomList[index].roomId);
            control.get('roomName').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].maxChildAndExtraBedPerRoomList[index].roomName);
            control.get('noOfGuest').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].maxChildAndExtraBedPerRoomList[index].noOfGuest);
            control.get('bedCount').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].maxChildAndExtraBedPerRoomList[index].bedCount);
            control.get('maxChildren').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].maxChildAndExtraBedPerRoomList[index].maxChildren);
            control.get('extraBedCount').setValue(this.policiesDataService.childAndExtraBedPolicyDetails[0].maxChildAndExtraBedPerRoomList[index].extraBedCount);
            control.get('objectState').setValue(ObjectState.Modified);
          });
          this.onChildAgeSelect();
          this.onCotSelect();
          this.onExtraBedSelect();
          this.childAndExtraBedPolicyInfo.objectState = ObjectState.Unchanged;
          this.childAndExtraBedPolicyInfo.id = this.policyId;
        }
      });
  }

  flagPolicyAsEdited() {
    this.contentChanged = true;
    if (this.childAndExtraBedPolicyInfo.objectState !== ObjectState.Added) {
      this.childAndExtraBedPolicyInfo.objectState = ObjectState.Modified;
    }
  }

  cancelPolicy() {
    if (this.contentChanged) {
      this.dialogsService
        .confirm('Confirm', 'If you cancel, the current data will be lost').subscribe(res => {
          this.result = res;
          if (this.result) {
            this.router.navigate(['/hotelmgmt/hotel', this.hotelId, this.operation.trim().toLowerCase(), 'policieslist']);
          }
        });
    } else{
      this.router.navigate(['/hotelmgmt/hotel', this.hotelId, this.operation.trim().toLowerCase(), 'policieslist']);
    }
  }

  onChildAgeSelect() {
    if (this.childAndExtrabedPolicyForm.get('isChildrenAllowed').value === false) {
      this.childAndExtrabedPolicyForm.get('minChildAge').disable();
      this.childAndExtrabedPolicyForm.get('maxChildAge').disable();
      this.childAndExtrabedPolicyForm.get('minChildAge').setValue('');
      this.childAndExtrabedPolicyForm.get('maxChildAge').setValue('');
      this.childAndExtraBedPolicyInfo.minChildAge = null;
      this.childAndExtraBedPolicyInfo.maxChildAge = null;
    }
    if (this.childAndExtrabedPolicyForm.get('isChildrenAllowed').value === true) {
      this.childAndExtrabedPolicyForm.get('minChildAge').enable();
      this.childAndExtrabedPolicyForm.get('maxChildAge').enable();
    }
  }

  onCotSelect() {
    if (this.childAndExtrabedPolicyForm.get('isExtraCotAllowed').value === false) {
      this.childAndExtrabedPolicyForm.get('maxInfantAge').disable();
      this.childAndExtrabedPolicyForm.get('cotPriceTypeId').disable();
      this.childAndExtrabedPolicyForm.get('cotPrice').disable();
      this.childAndExtrabedPolicyForm.get('maxInfantAge').setValue('');
      this.childAndExtrabedPolicyForm.get('cotPriceTypeId').setValue('');
      this.childAndExtrabedPolicyForm.get('cotPrice').setValue('');
      this.childAndExtraBedPolicyInfo.maxInfantAge = null;
      this.childAndExtraBedPolicyInfo.cotPriceTypeId = null;
      this.childAndExtraBedPolicyInfo.cotPrice = null;
    }
    if (this.childAndExtrabedPolicyForm.get('isExtraCotAllowed').value === true) {
      this.childAndExtrabedPolicyForm.get('maxInfantAge').enable();
      this.childAndExtrabedPolicyForm.get('cotPriceTypeId').enable();
      this.childAndExtrabedPolicyForm.get('cotPrice').enable();
    }
  }

  onExtraBedSelect() {
    if (this.childAndExtrabedPolicyForm.get('isExtraBedAllowed').value === false) {
      console.log(this.childAndExtrabedPolicyForm);
      this.childAndExtrabedPolicyForm.controls.maxChildAndExtraBedPerRoomList['controls'].forEach((control) => {
        control.get('maxChildren').disable();
        control.get('extraBedCount').disable();
        control.get('maxChildren').setValue('');
        control.get('extraBedCount').setValue('');
      });
    }
    if (this.childAndExtrabedPolicyForm.get('isExtraBedAllowed').value === true) {
      this.childAndExtrabedPolicyForm.controls.maxChildAndExtraBedPerRoomList['controls'].forEach((control) => {
        control.get('maxChildren').enable();
        control.get('extraBedCount').enable();
      });
    }
  }

  isFreeOrPaid() {
    if (this.childAndExtrabedPolicyForm.get('cotPriceTypeId').value === this.isFree) {
      this.childAndExtrabedPolicyForm.get('cotPrice').disable();
      this.childAndExtrabedPolicyForm.get('cotPrice').setValue('');
    }
    if (this.childAndExtrabedPolicyForm.get('cotPriceTypeId').value === this.isPaid) {
      this.childAndExtrabedPolicyForm.get('cotPrice').enable();
    }
  }
}
