import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MgApplicationViewModel } from '../../../viewmodel/usersviewmodel/mgapplicationlistviewmodel';
import { DepartmentViewModel } from '../../../viewmodel/usersviewmodel/departmentviewmodel';
import { CONSTANTS } from '../../../../common/constants';
import { FormGroup, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';
import { MgUserViewModel } from '../../../viewmodel/usersviewmodel/mguserviewmodel';
import { Observable } from 'rxjs/Observable';
import { MgRoleViewModel } from '../../../viewmodel/usersviewmodel/mgrolelistviewmodel';
import { BackofficeLookupService } from '../../../common/backoffice-shared/services/backoffice-lookup';
import {UserProfileService} from '../../../../common/shared/services/user-profile.service';
import { ApplicationRoleIdViewModel } from '../../../viewmodel/usersviewmodel/applicationroleidviewmodel';

function ValidateAppRole(control: AbstractControl): { [key: string]: boolean } | null {
  const appRoleList = control;
  if ((appRoleList.value !== undefined) && (appRoleList.value !== null) &&
    (appRoleList.value.length > 0)) {

    const appList = [];

    const appRoleArray = [];
    appRoleList.value.forEach(element => {
      appList.push(element.applicationId);
      appRoleArray.push({applicationId: element.applicationId, roleId: element.roleId});
    });
    const sorterAppList = appList.sort();
    const duplicateApp = false;
    for (let i = 0; i < sorterAppList.length - 1; i++) {
      if (sorterAppList[i + 1] != null && sorterAppList[i] != null) {
        if (sorterAppList[i + 1] === sorterAppList[i]) {
          return { 'ValidateAppRole': true };
        }
      }
    }

    for (let i = 0; i < appRoleArray.length; i++) {
      if ( appRoleArray[i] != null) {
        if (appRoleArray[i].applicationId !== null &&  appRoleArray[i].roleId === null ) {
          return { 'ValidateAppRoleNotNull': true };
        }
      }
    }

  }
  return null;
}

@Component({
  selector: 'app-mg-user-info',
  templateUrl: './mg-user-info.component.html',
  styleUrls: ['./mg-user-info.component.css']
})
export class MgUserInfoComponent implements OnInit {

  departmentList: DepartmentViewModel[];
  applicationList: MgApplicationViewModel[];
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  // id: string;
  userId: string;
  operation: string;
  mgUserForm: FormGroup;
  mgUserViewModel: MgUserViewModel = <MgUserViewModel>{};
  appRolesListArray = Array<MgRoleViewModel[]>();
  appRoles: Observable<MgRoleViewModel[]>;
  isMaxLength: boolean;

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute,
              private cd: ChangeDetectorRef,
              private snackBar: MatSnackBar,
              private userDataService: UserDataService,
              private backofficeLookupService: BackofficeLookupService,
              private userProfileService: UserProfileService) { }

  ngOnInit() {
    // Get the id from the activated route
    this.userId = this.activatedRoute.snapshot.params['id'];
    this.operation = this.activatedRoute.snapshot.params['operation'];
    // Get all the master data
    this.getDepartments();
    this.getApplications();

    // Create the Form Model
    this.mgUserForm = new FormGroup({
      userName: new FormControl(),
      employeeId: new FormControl(),
      email: new FormControl(),
      // multiSelectedDepartmentIds: new FormControl(['a7140da7-b28b-4f6d-cbbc-08d58a2490fd']),
      departments: new FormControl(),
      activationDate: new FormControl(),
      userApplicationRole: new FormArray([], ValidateAppRole),
    });

    if (this.operation.toLowerCase().trim() === this.create) {
      this.addAppRole();
    } else if (this.operation.toLocaleLowerCase().trim() === this.edit) {
      // Get Roles for the application ;
      this.getMGUser(this.userId);
    }
  }

   getMGUser(userId) {
    this.userDataService.getMGUserById(userId).subscribe(
      (mgUserData) => {
        if (this.operation.toLowerCase().trim() === this.edit) {
          this.mgUserViewModel = mgUserData;
          this.mgUserForm.get('userName').setValue(mgUserData.userName);
          this.mgUserForm.get('employeeId').setValue(mgUserData.employeeId);
          this.mgUserForm.get('email').setValue(mgUserData.email);
          const departmentIds = [];
          for (const departmentId of mgUserData.departments) {
            departmentIds.push(departmentId);
          }
          this.mgUserForm.get('departments').setValue(departmentIds);
          // this.mgUserForm.get('userApplicationRole').setValue(mgUserData.userApplicationRole);
          this.mgUserForm.get('activationDate').setValue(mgUserData.activationDate);
          const applicationRoleIdArray: ApplicationRoleIdViewModel[] = [];
          const appRoleValue = mgUserData.userApplicationRole;
          for (let i = 0; i < appRoleValue.length; i++) {
            this.addAppRole();
          }
          this.userApplicationRole.controls.forEach((control , index) => {
            control.get('applicationId').setValue(appRoleValue[index].applicationId);
            this.getRolesForApplication(index);
            control.get('roleId').setValue(appRoleValue[index].roleId);
          });
        }
      }
    );
  }

  getDepartments() {
    this.departmentList = this.activatedRoute.snapshot.data['departments'];
   }

   getApplications() {
    this.applicationList = this.activatedRoute.snapshot.data['applications'];
  }

   get userApplicationRole():  FormArray {
    return <FormArray>this.mgUserForm.get('userApplicationRole');
   }

   buildAppRole(): FormGroup {
      let appRoleFormGroup: FormGroup;
      appRoleFormGroup = new FormGroup({
        applicationId: new FormControl(),
        roleId: new FormControl()
    });
    return appRoleFormGroup;
   }

   addAppRole() {
    this.userApplicationRole.push(this.buildAppRole());
    if (this.appRolesListArray === null || this.appRolesListArray === undefined) {
      this.appRolesListArray = new Array<MgRoleViewModel[]>();
    } else {
      this.appRolesListArray.push([]);
    }

    if (this.userApplicationRole.length === this.applicationList.length) {

      this.isMaxLength = true;
    }
    this.cd.detectChanges();
  }
  deleteAppRole(index: number) {
    this.isMaxLength = false;
    this.userApplicationRole.removeAt(index);

    this.appRolesListArray.splice(index, 1);
    this.cd.detectChanges();
  }

  getRolesForApplication(applicationIndex: number) {
    const applicationId = this.userApplicationRole.controls[applicationIndex].get('applicationId').value;
    this.appRoles = this.backofficeLookupService.getRolesByApplicationId(applicationId);
    this.appRoles.subscribe(data => {
      this.appRolesListArray[applicationIndex] = data;
    });
  }



   saveUser() {
    const savedMGUser: MgUserViewModel = Object.assign({}, this.mgUserViewModel, this.mgUserForm.value);
    savedMGUser.updatedBy = this.userProfileService.GetBasicUserInfo().FirstName + ' ' +
                            this.userProfileService.GetBasicUserInfo().LastName;
    if (this.operation === this.create) {
      savedMGUser.createdBy = this.userProfileService.GetBasicUserInfo().FirstName + ' ' +
                            this.userProfileService.GetBasicUserInfo().LastName;
      this.userDataService.createMGUser(savedMGUser)
      .subscribe(data => {
        window.scrollTo(0, 0);
        this.snackBar.open('New user is created successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
        this.router.navigate(['/usermgmt/mgusers']);
      });
    }  else if (this.operation === this.edit) {
      savedMGUser.createdBy = this.mgUserViewModel.createdBy;
      this.userDataService.updateMGUser(this.userId, savedMGUser)
      .subscribe(data => {
        window.scrollTo(0, 0);
        this.snackBar.open('The user is updated successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
        this.router.navigate(['/usermgmt/mgusers']);
      });
    }
  }

  cancel() {
    window.scrollTo(0, 0);
    this.router.navigate(['/usermgmt/mgusers']);
  }

}
