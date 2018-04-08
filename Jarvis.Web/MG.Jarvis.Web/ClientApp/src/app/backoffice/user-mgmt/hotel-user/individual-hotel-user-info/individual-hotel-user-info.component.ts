import { Component, OnInit, Output } from '@angular/core';
import { DesignationViewModel } from '../../../viewmodel/usersviewmodel/designationviewmodel';
import { MgRoleViewModel } from '../../../viewmodel/usersviewmodel/mgrolelistviewmodel';
import { CONSTANTS } from '../../../../common/constants';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BackofficeLookupService } from '../../../common/backoffice-shared/services/backoffice-lookup';
import { ActivatedRoute, Router } from '@angular/router';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';
import { MatSnackBar } from '@angular/material';
import { HotelUserViewModel } from '../../../viewmodel/usersviewmodel/hoteluserinfoviewmodel';
import { HotelNameViewModel } from '../../../viewmodel/usersviewmodel/hotelnameviewmodel';
import { UserProfileService } from '../../../../common/shared/services/user-profile.service';

@Component({
  selector: 'app-individual-hotel-user-info',
  templateUrl: './individual-hotel-user-info.component.html',
  styleUrls: ['./individual-hotel-user-info.component.css']
})
export class IndividualHotelUserInfoComponent implements OnInit {

  designationList: DesignationViewModel[];
  hotelList: HotelNameViewModel[];
  roleList: MgRoleViewModel[];
  individualHotelForm: FormGroup;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  mgHotelViewModel: HotelUserViewModel= <HotelUserViewModel>{};
  todaysDate = new Date();
  minDate: string;
  userId: string;
  @Output()
  Checked: boolean;


  constructor(private backOfficeLookUpService: BackofficeLookupService,
              private activatedRoute: ActivatedRoute,
              private userDataService: UserDataService,
              private snackBar: MatSnackBar,
              private router: Router,
              private userProfileService: UserProfileService) { }

  ngOnInit() {

    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.userId = this.activatedRoute.snapshot.params['id'];
    this.individualHotelForm = new FormGroup({
      hotelId: new FormControl('', Validators.required),
      userName: new FormControl('', Validators.required),
      designationId: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      extranetRoleId: new FormControl('', Validators.required),
      activationDate: new FormControl('', Validators.required),
    });

    if (this.operation.toLowerCase().trim() === this.edit) {
        this.Checked = true;
        this.getIndividualHotelUser(this.userId);
     }

    this.getDesignations();
    this.getRoles();
    this.getHotels();

  }

  getDesignations() {
    this.designationList = this.activatedRoute.snapshot.data['designations'];
  }

  getRoles() {
    this.roleList = this.activatedRoute.snapshot.data['roles'];
  }

  getHotels() {
      this.hotelList = this.activatedRoute.snapshot.data['hotels'];
  }

  saveIndividualHotelUserDetails() {

    const individualHotelUser = Object.assign({}, this.mgHotelViewModel, this.individualHotelForm.value);

    if (individualHotelUser.activationDate.toISOString() > this.todaysDate.toISOString()) {
      individualHotelUser.isActive = false;
    } else {
      individualHotelUser.isActive = true;
    }
    individualHotelUser.createdBy = this.userProfileService.GetBasicUserInfo().FirstName + ' ' +
                                    this.userProfileService.GetBasicUserInfo().LastName;
    individualHotelUser.updatedBy = this.userProfileService.GetBasicUserInfo().FirstName + ' ' +
                                    this.userProfileService.GetBasicUserInfo().LastName;
    individualHotelUser.userName = individualHotelUser.email;

      if (this.operation === this.create) {
      this.userDataService.createHotelUser(individualHotelUser as HotelUserViewModel)
      .subscribe(data => {
        window.scrollTo(0, 0);
        this.snackBar.open('New user is created successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
        this.router.navigate(['/usermgmt/hoteluserslist']);
      });
     }
  }

  cancel() {
    window.scrollTo(0, 0);
    this.router.navigate(['/usermgmt/hoteluserslist']);
  }

  getIndividualHotelUser(userId) {
    this.userDataService.getHotelUserById(userId).subscribe(
      (individualHotelUserData) => {
          this.individualHotelForm.get('userName').setValue(individualHotelUserData.userName);
          this.individualHotelForm.get('email').setValue(individualHotelUserData.email);
          this.individualHotelForm.get('extranetRoleId').setValue(individualHotelUserData.extranetRoleId);
          this.individualHotelForm.get('designationId').setValue(individualHotelUserData.designationId);
          this.individualHotelForm.get('activationDate').setValue(individualHotelUserData.activationDate);
          this.individualHotelForm.get('hotelId').setValue(individualHotelUserData.hotelId);
      }
    );
  }

}
