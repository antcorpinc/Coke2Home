import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HotelBrandViewModel } from '../../../../common/viewmodels/hotelbrandviewmodel';
import { HotelChainViewModel } from '../../../../common/viewmodels/hotelchainviewmodel';
import { CONSTANTS } from '../../../../common/constants';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { HotelUserViewModel } from '../../../viewmodel/usersviewmodel/hoteluserinfoviewmodel';
import { HotelNameViewModel } from '../../../viewmodel/usersviewmodel/hotelnameviewmodel';
import { DesignationViewModel } from '../../../viewmodel/usersviewmodel/designationviewmodel';
import { MgRoleViewModel } from '../../../viewmodel/usersviewmodel/mgrolelistviewmodel';
import { BackofficeLookupService } from '../../../common/backoffice-shared/services/backoffice-lookup';
import { LookupService } from '../../../../common/shared/services/lookup.service';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';

@Component({
  selector: 'app-hotel-user-info',
  templateUrl: './hotel-user-info.component.html',
  styleUrls: ['./hotel-user-info.component.css']
})
export class HotelUserInfoComponent implements OnInit {

  HotelchainList: HotelChainViewModel[];
  HotelbrandList: HotelBrandViewModel[];
  hotelNameList: HotelNameViewModel[];
  designationList: DesignationViewModel[];
  roleList: MgRoleViewModel[];
  public todaysDate = new Date();
  hotelUser: HotelUserViewModel;
  minDate: string;
  userId: string;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  hotelUserDetails: HotelUserViewModel = <HotelUserViewModel>{};
  hotelUserForm: FormGroup;
  allBrandIds: number[];
  allHotelIds: string[];
  isHotelList: boolean;
  isBrandList: boolean;
  operation: string;

  constructor(private router: Router,
    private activatedRoute: ActivatedRoute,
    private cd: ChangeDetectorRef,
    private snackBar: MatSnackBar,
    private lookupService: LookupService,
    private userDataService: UserDataService,
  private backOfficeLookUpService: BackofficeLookupService) { }

  ngOnInit() {
    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.userId = this.activatedRoute.snapshot.params['userId'];
    this.getHotelChainList();
    this.getDesignations();
    this.getRoles();
    this.allBrandIds = [0];
    this.allHotelIds = [''];
    this.isHotelList = false;
    this.isBrandList = false;
    this.hotelUserForm = new FormGroup({
      chainId: new FormControl('', Validators.required),
      brandIds: new FormControl('', Validators.required),
      hotelId: new FormControl('', Validators.required),
      firstName: new FormControl('', Validators.required),
      designationId: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      extranetRoleId: new FormControl('', Validators.required),
      activationDate: new FormControl('', Validators.required),
    });

    if (this.operation === 'edit') {
      this.userDataService.getHotelUserById(this.userId).subscribe((hotelUser) => {
        this.hotelUser = hotelUser;
      });
    }
  }

  getHotelChainList() {
    this.lookupService.getHotelChains().subscribe((mghotelchainList) => {
      this.HotelchainList = mghotelchainList;
    });
  }

  getHotelBrands(chainId) {
    this.lookupService.getHotelBrands(chainId).subscribe((mghotelbrandList) => {
      this.HotelbrandList = mghotelbrandList;
      this.isBrandList = true;
    });

  }

  getDesignations() {
    this.backOfficeLookUpService.getDesignationByType(CONSTANTS.userType.hoteluser).subscribe(designationData =>
      this.designationList = designationData
    );
  }

  getRoles() {
    this.backOfficeLookUpService.getRolesByApplicationName(CONSTANTS.application.extranet).subscribe(data =>
      this.roleList = data
    );
  }
  selectAllHotels() {
    // fetch all hotelIds from hotelsList
    if (this.hotelNameList !== null) {
      this.allHotelIds.splice(0 , this.allHotelIds.length);
      for (let b = 0; b < this.hotelNameList.length; b++) {
        this.allHotelIds[b] = this.hotelNameList[b].hotelId;
      }
      // select/deselect all hotels
      if (this.hotelUserForm.value.hotelId.length !== 0) {
        if (this.hotelUserForm.value.hotelId[0] == null && this.hotelUserForm.value.hotelId.length !== (this.allHotelIds.length + 1)) {
            this.hotelUserForm.patchValue({hotelId: this.allHotelIds});
        } else if (this.hotelUserForm.value.hotelId.length === (this.allHotelIds.length + 1)) {
          this.hotelUserForm.patchValue({hotelId: null});
        }
     }
    }
 }

  getHotels(brandIds) {
    // fetch all brandIds from brandsList
    this.allBrandIds.splice(0 , this.allBrandIds.length);
    for (let b = 0; b < this.HotelbrandList.length; b++) {
      this.allBrandIds[b] = this.HotelbrandList[b].hotelBrandId;
    }
    // select/deselect all brands
    if (brandIds.length !== (this.allBrandIds.length + 1) && brandIds.length !== 0) {
        if (brandIds[0] == null) {
          for (let b = 0; b < this.HotelbrandList.length; b++) {
            brandIds[b] = this.HotelbrandList[b].hotelBrandId;
            this.hotelUserForm.value.brandIds[b] = this.HotelbrandList[b].hotelBrandId;
          }
          this.hotelUserForm.patchValue({brandIds: brandIds});
        }
    } else if (brandIds.length === (this.allBrandIds.length + 1) && this.hotelNameList != null) {
      this.hotelUserForm.patchValue({brandIds: null});
      this.hotelNameList = null;
      this.isHotelList = false;
    }
    // fetch hotels according to brandIds
     if (brandIds.length >= 1 && brandIds[0] !== null) {
       this.isHotelList = true;
      this.backOfficeLookUpService.getHotelsByBrandIds(brandIds).subscribe(data =>
      this.hotelNameList = data
      );
     }

  }

  saveHotelUserDetails() {
    const hotelUser = Object.assign({}, this.hotelUserDetails, this.hotelUserForm.value);
    hotelUser.userName = hotelUser.email;
    if (hotelUser.activationDate === this.todaysDate.toISOString()) {
      hotelUser.isActive = true;
    } else {
      hotelUser.isActive = false;
    }
    // hotelUser.deActivationDate = '';
    hotelUser.createdBy = 'sa';
    hotelUser.updatedBy = 'sa';
    this.userDataService.createHotelUser(hotelUser as HotelUserViewModel)
    .subscribe(data => {
      this.snackBar.open('Hotel User Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
      this.router.navigate(['/usermgmt/hoteluserslist']);
    });

  }

  cancel() {
    window.scrollTo(0, 0);
    this.router.navigate(['/usermgmt/hoteluserslist']);
  }
}
