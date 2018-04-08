import { Component, OnInit } from '@angular/core';
import { DesignationViewModel } from '../../../viewmodel/usersviewmodel/designationviewmodel';
import { MgRoleViewModel } from '../../../viewmodel/usersviewmodel/mgrolelistviewmodel';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CONSTANTS } from '../../../../common/constants';
import { BackofficeLookupService } from '../../../common/backoffice-shared/services/backoffice-lookup';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-supplier-user-info',
  templateUrl: './supplier-user-info.component.html',
  styleUrls: ['./supplier-user-info.component.css']
})
export class SupplierUserInfoComponent implements OnInit {

  designationList: DesignationViewModel[];
  roleList: MgRoleViewModel[];  
  individualHotelForm : FormGroup;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  
  constructor(private backOfficeLookUpService: BackofficeLookupService,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.individualHotelForm = new FormGroup({
      hotelNameId: new FormControl,
      userName: new FormControl('', Validators.required),
      designation: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      role: new FormControl('', Validators.required),
      activationDate: new FormControl('', Validators.required),
    });

    this.getDesignations();
    this.getRoles();
  }

  getDesignations() {
    this.designationList = this.activatedRoute.snapshot.data['designations'];
  }

  getRoles() {
    this.roleList = this.activatedRoute.snapshot.data['roles'];    
  }
}
