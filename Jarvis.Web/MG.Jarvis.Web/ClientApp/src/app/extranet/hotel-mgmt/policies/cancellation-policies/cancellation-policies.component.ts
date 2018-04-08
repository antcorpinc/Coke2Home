/* tslint:disable */
import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { CONSTANTS } from '../../../../common/constants';
import { PoliciesDataService } from './../../../common/extranet-shared/services/policies-data.service';

import { ObjectState } from '../../../../common/enums';
import { CancellationClausetypemasterviewmodel } from '../../../viewmodel/policiesviewmodel/cancellationclausetypemasterviewmodel';
import { CancellationClausechargesmasterviewmodel } from '../../../viewmodel/policiesviewmodel/cancellationclausechargesmasterviewmodel';
import { CancellationPolicyViewModel } from '../../../viewmodel/policiesviewmodel/cancellationpolicyviewmodel';
import { MatSnackBar } from '@angular/material';
import { DialogsService } from '../../../common/extranet-shared/dialogs/dialogs.service';
import { validateConfig } from '@angular/router/src/config';
import { VALID } from '@angular/forms/src/model';

const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;

@Component({
  selector: 'app-cancellation-policies',
  templateUrl: './cancellation-policies.component.html',
  styleUrls: ['./cancellation-policies.component.css']
})
export class CancellationPoliciesComponent implements OnInit {
  cancellationPolicyForm: FormGroup;
  cancellationClauseType: CancellationClausetypemasterviewmodel;
  cancellationClauseCharges: CancellationClausechargesmasterviewmodel;
  cancellationPolicyViewModel: CancellationPolicyViewModel;
  cancellationPolicyViewModelSave: CancellationPolicyViewModel;
  hotelId: number;
  cancellationPolicyId: number;
  cancellationPolicyName: string;
  clauseTypeId: number;
  noShowToggle: boolean;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  cancellationPolicyOperation: string;
  cancellationPolicyList: CancellationPolicyViewModel[];
  noShowCancellationChargesIdEdit: any;
  cancellationPolicyNameOrg: string;
  dialogResult: any;
  dialogActions: string;
  flexibleClauses: any;
  policyHeaderName: string;

  constructor(private router: Router,
    private policiesDataService: PoliciesDataService,
    private activatedRoute: ActivatedRoute, private snackBar: MatSnackBar,
    private dialogsService: DialogsService) { }

  ngOnInit() {
    this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.cancellationPolicyOperation = this.activatedRoute.snapshot.params['operation'];
    this.cancellationPolicyId = this.activatedRoute.snapshot.params['id'];
    this.cancellationPolicyForm = new FormGroup({
      isActive: new FormControl(true),
      cancellationPolicyId: new FormControl(),
      cancellationPolicyTypeId: new FormControl(),
      isNoShowCharges: new FormControl(false),
      noShowCancellationChargesId: new FormControl(),
      name: new FormControl('', Validators.required),
      hotelId: new FormControl(),
      isDeleted: new FormControl(false),
      cancellationPolicyClausesViewModelList: new FormArray([this.buildCancellationPolicyClauses()]),
      objectState: new FormControl(ObjectState.Unchanged)
    });
    this.getCancellationPolicyType();
    this.getCancellationCharges();
    if (this.cancellationPolicyOperation === create) {
      this.policyHeaderName = "Create New Cancellation Policy";
      this.cancellationPolicyForm.get('cancellationPolicyTypeId').setValue(1);
      this.cancellationPolicyForm.controls.cancellationPolicyClausesViewModelList['controls'].forEach((clauseControl => {
        clauseControl.get('daysBeforeArrival').disable();
        clauseControl.get('percentageCharge').disable();
        clauseControl.get('cancellationChargesId').disable();

        clauseControl.get('daysBeforeArrival').setValue(null);
        clauseControl.get('percentageCharge').setValue(null);
        clauseControl.get('cancellationChargesId').setValue(null);
      }));   
    }

    if (this.cancellationPolicyOperation === edit) {
      this.policyHeaderName = "Edit Cancellation Policy"
      this.getCancellationPolicyDetails(this.cancellationPolicyId);
      this.cancellationPolicyNameOrg = this.cancellationPolicyForm.get('name').value;
      if (this.cancellationPolicyForm.get('cancellationPolicyTypeId').value === 1 || this.cancellationPolicyForm.get('cancellationPolicyTypeId').value === 11 ) {
        this.cancellationPolicyForm.controls.cancellationPolicyClausesViewModelList['controls'].forEach((clauseControl => {
          clauseControl.get('daysBeforeArrival').disable();
          clauseControl.get('percentageCharge').disable();
          clauseControl.get('cancellationChargesId').disable();

          clauseControl.get('daysBeforeArrival').setValue(null);
          clauseControl.get('percentageCharge').setValue(null);
          clauseControl.get('cancellationChargesId').setValue(null);
        }));
      }
    }
  }

  buildCancellationPolicyClauses() {
    let clausesGroup: FormGroup;
    clausesGroup = new FormGroup({
      daysBeforeArrival: new FormControl('', Validators.required),
      percentageCharge: new FormControl('', Validators.required),
      cancellationChargesId: new FormControl('', Validators.required),
      objectState: new FormControl(ObjectState.Added),
      cancellationPolicyClausesId: new FormControl(0)
    });
    return clausesGroup;
  }

  getCancellationPolicyType() {
    this.policiesDataService.getCancellationPolicyTypedto().
      subscribe(cancellationClauseTypeDto => {
        this.cancellationClauseType = cancellationClauseTypeDto;
    });
  }

  getCancellationCharges() {
    this.policiesDataService.getCancellationChargesdto().subscribe(cancellationClauseChargesDto => {
      this.cancellationClauseCharges = cancellationClauseChargesDto;
    });
  }

  get cancellationPolicyClausesViewModelList(): FormArray{
    return <FormArray> this.cancellationPolicyForm.get('cancellationPolicyClausesViewModelList');
  }
  addCancellationPolicyClause() {
    this.cancellationPolicyClausesViewModelList.push(this.buildCancellationPolicyClauses());
  }

  deleteCancellationPreference(index: number) {
   const cancellationPolicyClauseIdDelete =  this.cancellationPolicyClausesViewModelList.value[index].cancellationPolicyClausesId;
   this.dialogsService
      .confirm('Confirm', 'Are you sure you want to delete this clause?').subscribe(res => {
        this.dialogResult = res;
        if (this.dialogResult) {
         if (cancellationPolicyClauseIdDelete > 0 && cancellationPolicyClauseIdDelete != null) {
            this.policiesDataService.deletePolicyClause(cancellationPolicyClauseIdDelete)
              .subscribe(policyClauseDeletedDto => {
            });
         }
          this.cancellationPolicyClausesViewModelList.removeAt(index);
        } else {
          this.dialogActions = null;
        }
      });
    }

  changeClauseType(event) {
    this.clauseTypeId = event.value;
    if (this.clauseTypeId === 2) {
      this.cancellationPolicyForm.controls.cancellationPolicyClausesViewModelList['controls'].forEach((clauseControl => {
        clauseControl.get('daysBeforeArrival').enable();
        clauseControl.get('percentageCharge').enable();
        clauseControl.get('cancellationChargesId').enable();
      }));
    }
    else {
      this.cancellationPolicyForm.controls.cancellationPolicyClausesViewModelList['controls'].forEach((clauseControl => {
        clauseControl.get('daysBeforeArrival').disable();
        clauseControl.get('percentageCharge').disable();
        clauseControl.get('cancellationChargesId').disable();

        clauseControl.get('daysBeforeArrival').setValue(null);
        clauseControl.get('percentageCharge').setValue(null);
        clauseControl.get('cancellationChargesId').setValue(null);
      }));
    }

    if(this.clauseTypeId === 2 && this.cancellationPolicyOperation === edit){
      this.cancellationPolicyClausesViewModelList.controls.forEach((control, index) => {
        control.get('cancellationPolicyClausesId').setValue(this.flexibleClauses[index].cancellationPolicyClausesId);
        control.get('daysBeforeArrival').setValue(this.flexibleClauses[index].daysBeforeArrival );
        control.get('percentageCharge').setValue(this.flexibleClauses[index].percentageCharge);
        control.get('cancellationChargesId').setValue(this.flexibleClauses[index].cancellationChargesId );
        control.get('objectState').setValue(this.flexibleClauses[index].objectState);
     });
    }
  }
  checkPolicyName() {
    this.cancellationPolicyName =  this.cancellationPolicyForm.get('name').value;
    this.cancellationPolicyList = this.policiesDataService.cancellationPolicyViewModelDtoList;
    if (this.cancellationPolicyList !== null) {
      // const count = this.cancellationPolicyList.length;
      for (let i = 0; i < this.cancellationPolicyList.length; i++) {
         if (this.cancellationPolicyList[i].name.toLowerCase() === this.cancellationPolicyName.trim().toLowerCase()) {          
            if (this.cancellationPolicyOperation === edit) {
              this.cancellationPolicyForm.get('name').setValue(this.cancellationPolicyNameOrg);
              // this.cancellationPolicyForm.disable();
            }
            else{
              this.snackBar.open('Policy already exists with this name.', 'Close', {duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
              this.cancellationPolicyForm.get('name').setValue('');
            }
          }
      }
  }
}
  changeNoShowToggle(event) {
    this.noShowToggle = event.value;
    if (this.cancellationPolicyForm.get('isNoShowCharges').value === true) {
      this.cancellationPolicyForm.get('noShowCancellationChargesId').setValue(1);
    }
  }
  checkDaysRange() {
     this.cancellationPolicyForm.controls.cancellationPolicyClausesViewModelList['controls'].forEach((clauseControl => {
     const clauseDays =  clauseControl.get('daysBeforeArrival').value;
     if (clauseDays < 1 || clauseDays > 365) {
      this.snackBar.open('Please enter days between 1 and 366!', 'Close', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
      clauseControl.get('daysBeforeArrival').setValue('');
      }
    }));
  }
  checkPercentageRange() {
    this.cancellationPolicyForm.controls.cancellationPolicyClausesViewModelList['controls'].forEach((clauseControl => {
      const clausePercentage =  clauseControl.get('percentageCharge').value;
      if (clausePercentage < 1 || clausePercentage > 100) {
       this.snackBar.open('Please enter percentage between 1 and 100!', 'Close', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
       clauseControl.get('percentageCharge').setValue('');
       }
     }));
  }

  saveCancellationPolicy() {
    if (this.cancellationPolicyForm.valid) {
      this.cancellationPolicyViewModelSave = Object.assign({}, this.cancellationPolicyViewModel, this.cancellationPolicyForm.value);
      this.cancellationPolicyViewModelSave.hotelId = this.hotelId;
      if (this.cancellationPolicyForm.get('cancellationPolicyTypeId').value === 1 ||
      this.cancellationPolicyForm.get('cancellationPolicyTypeId').value === 11 ) {
      this.cancellationPolicyViewModelSave.cancellationPolicyClausesViewModelList = [];
    }
      if (this.cancellationPolicyForm.get('isNoShowCharges').value === false) {
        this.cancellationPolicyViewModelSave.noShowCancellationChargesId = null ;
      }
      if (this.cancellationPolicyOperation === create) {
        this.cancellationPolicyViewModelSave.objectState = ObjectState.Added;
        this.cancellationPolicyViewModelSave.cancellationPolicyId = 0;
      }
      if (this.cancellationPolicyOperation === edit) {
        this.cancellationPolicyViewModelSave.cancellationPolicyId = this.cancellationPolicyId;
        this.cancellationPolicyViewModelSave.objectState = ObjectState.Modified;
        this.cancellationPolicyViewModelSave.cancellationPolicyClausesViewModelList.forEach(control => {
           if (control.objectState === null) {
             control.objectState = ObjectState.Unchanged;
          }
        });
      }
    }
     this.policiesDataService.saveAndUpdateCancellationPolicydto(this.cancellationPolicyViewModelSave)
     .subscribe(data => {
        data = 'success';
       /* in case of success */
       if (data === 'success') {
         if (this.cancellationPolicyOperation === create) {
            this.snackBar.open('Policy Created Successfully', 'Close', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
         }
         else if (this.cancellationPolicyOperation === edit) {
            this.snackBar.open('Policy Updated Successfully', 'Close', {duration : 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
         }
       }
       else{
          if (this.cancellationPolicyOperation === create) {
            this.snackBar.open('Policy Creation Failed', 'Close', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
        }
        else {
            this.snackBar.open('Policy Updation Failed', 'Close', {duration : 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          }
        }
        this.router.navigate(['/hotelmgmt/hotel', this.hotelId, this.operation,
            'policieslist']);
     });
  }
  /* Edit Cancellation Policy section */
  private getCancellationPolicyDetails(cancellationPolicyId) {
    const cancellationPolicyIdParse = parseInt(cancellationPolicyId, 10);
    this.cancellationPolicyList = this.policiesDataService.cancellationPolicyViewModelDtoList;
    for (let i = 0; i < this.cancellationPolicyList.length; i++) {
      if (this.cancellationPolicyList[i].cancellationPolicyId === cancellationPolicyIdParse) {
        this.flexibleClauses = this.cancellationPolicyList[i].cancellationPolicyClausesViewModelList;
        for (let k = 0; k < this.flexibleClauses.length - 1; k++) {
          this.addCancellationPolicyClause();
        }
        this.cancellationPolicyForm.get('isActive').setValue(this.cancellationPolicyList[i].isActive);
        this.cancellationPolicyForm.get('name').setValue(this.cancellationPolicyList[i].name);
        if (this.cancellationPolicyList[i].cancellationPolicyTypeId === 1) {
          this.cancellationPolicyForm.get('cancellationPolicyTypeId').setValue(1);
        }
        else if (this.cancellationPolicyList[i].cancellationPolicyTypeId === 2) {
          this.clauseTypeId = 2;
          this.cancellationPolicyForm.get('cancellationPolicyTypeId').setValue(2);
          this.cancellationPolicyClausesViewModelList.controls.forEach((control, index) => {
            control.get('cancellationPolicyClausesId').setValue(this.flexibleClauses[index].cancellationPolicyClausesId);
            control.get('daysBeforeArrival').setValue(this.flexibleClauses[index].daysBeforeArrival );
            control.get('percentageCharge').setValue(this.flexibleClauses[index].percentageCharge);
            control.get('cancellationChargesId').setValue(this.flexibleClauses[index].cancellationChargesId );
            control.get('objectState').setValue(this.flexibleClauses[index].objectState);
         });
        }
        else{
          this.cancellationPolicyForm.get('cancellationPolicyTypeId').setValue(11);
        }
        if (this.cancellationPolicyList[i].isNoShowCharges === true) {
          this.noShowToggle = true;
          this.cancellationPolicyForm.get('isNoShowCharges').setValue(true);
          this.noShowCancellationChargesIdEdit = this.cancellationPolicyList[i].noShowCancellationChargesId;
          this.cancellationPolicyForm.get('noShowCancellationChargesId').setValue(this.noShowCancellationChargesIdEdit);
        }
        else{
          this.cancellationPolicyForm.get('isNoShowCharges').setValue(false);
        }
      }
    }
  }

  flagCancellationPolicyAsEdited() {
    if (this.cancellationPolicyOperation === edit) {
      this.cancellationPolicyForm.get('objectState').setValue(ObjectState.Modified);
    }
  }

  flagCancellationPolicyClauseAsEdited(index: number) {
    if (this.cancellationPolicyOperation === edit) {
      if (this.cancellationPolicyClausesViewModelList.controls[index].get('objectState').value !== ObjectState.Added) {
        this.cancellationPolicyClausesViewModelList.controls[index].get('objectState').setValue(ObjectState.Modified);
      }
    }
  }
  cancelPolicy() {
    this.dialogsService
      .confirm('Confirm', 'If you cancel, the current data will be lost.').subscribe(res => {
        this.dialogResult = res;
        if (this.dialogResult) {
          this.router.navigate(['/hotelmgmt/hotel', this.hotelId, this.operation, 'policieslist']);
        } else {
          this.dialogActions = null;
        }
      });
  }
}
