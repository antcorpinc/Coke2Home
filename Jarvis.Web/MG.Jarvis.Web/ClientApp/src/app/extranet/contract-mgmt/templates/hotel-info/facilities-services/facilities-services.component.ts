import { Component, OnInit } from '@angular/core';
import { FacilityGroupViewModel } from '../../../../viewmodel/facilitiesservicesviewmodel/facilitygroupviewmodel';
import { ActivatedRoute, Router } from '@angular/router';
import { FormArray, FormGroup, Validators, FormControl } from '@angular/forms';
import { FacilityTypeViewModel } from '../../../../viewmodel/facilitiesservicesviewmodel/facilitytypeviewmodel';
import { EXTRANETCONSTANTS } from '../../../../common/constants';
import { TemplateFacilitiesDataService } from '../../../../common/extranet-shared/services/templates/template-facilities-data.service';
import { ObjectState } from '../../../../../common/enums';
import { CONSTANTS } from '../../../../../common/constants';
import { TemplateUrlNotificationService } from '../../../../common/extranet-shared/services/templates/template-url-notification.service';
import { MatSnackBar } from '@angular/material';

const facilities = EXTRANETCONSTANTS.facilities;
const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;

@Component({
  selector: 'app-facilities-services',
  templateUrl: './facilities-services.component.html',
  styleUrls: ['./facilities-services.component.css']
})
export class FacilitiesServicesComponent implements OnInit {

  templateFacilityGroupList: FacilityGroupViewModel[];
  templateFacilitiesList: FacilityGroupViewModel[];
  facilitiesForm: FormGroup;

  internetGroupId = facilities.facilitiesGroupIds.internetGroupId;
  parkingGroupId = facilities.facilitiesGroupIds.parkingGroupId;
  petsGroupId = facilities.facilitiesGroupIds.petsGroupId;
  languagesGroupId = facilities.facilitiesGroupIds.languagesGroupId;
  activitiesGroupId = facilities.facilitiesGroupIds.activitiesGroupId;
  foodAndDrinkGroupId = facilities.facilitiesGroupIds.foodAndDrinkGroupId;
  poolAndWellnessGroupId = facilities.facilitiesGroupIds.poolAndWellnessGroupId;
  receptionServicesGroupId = facilities.facilitiesGroupIds.receptionServicesGroupId;
  transportGroupId = facilities.facilitiesGroupIds.transportGroupId;
  commonAreasGroupId = facilities.facilitiesGroupIds.commonAreasGroupId;
  entertainmentGroupId = facilities.facilitiesGroupIds.entertainmentGroupId;
  cleaningGroupId = facilities.facilitiesGroupIds.cleaningGroupId;
  businessGroupId = facilities.facilitiesGroupIds.businessGroupId;
  shopsGroupId = facilities.facilitiesGroupIds.shopsGroupId;
  miscellaneousGroupId = facilities.facilitiesGroupIds.miscellaneousGroupId;

  constructor(private route: ActivatedRoute,
              private templateFacilitiesDataService: TemplateFacilitiesDataService,
              public snackBar: MatSnackBar,
              private router: Router,
              private templateUrlNotificationService: TemplateUrlNotificationService) {
              templateUrlNotificationService.changeURLRoute(route.snapshot.url[0].path);
               }

  templateId = this.route.parent.snapshot.params['id'];
  ngOnInit() {
    window.scrollTo(0, 0);
    this.getTemplateFacilitiesServices();
  }

  getTemplateFacilitiesServices() {
    this.templateFacilityGroupList = this.route.snapshot.data['facilityData'];

    this.facilitiesForm = new FormGroup({
      facilitiesGroupArray: this.buildFacilityGroupsForm(this.templateFacilityGroupList)
    });
  }

  get facilitiesGroupArray(): FormArray{
    return <FormArray>this.facilitiesForm.get('facilitiesGroupArray');
  }

  getTypeArrayForGroup(groupIndex: number): FormArray {
      return <FormArray>this.facilitiesGroupArray.controls[groupIndex].get('hotelFacilityTypes');
  }

  getFacilityArrayForGroupAndType(groupIndex: number , typeIndex: number) {
    return <FormArray> this.getTypeArrayForGroup(groupIndex).controls[typeIndex].get('facilityList');
  }

  buildFacilityGroupsForm(facilityGroups: FacilityGroupViewModel[]): FormArray {
    let groupFormGroup: FormGroup;
    let groupFormArray: FormArray;

    facilityGroups.forEach(facilityGroup => {
      groupFormGroup = new FormGroup({
        facilityGroupId: new FormControl(facilityGroup.facilityGroupId),
        facilityGroupName: new FormControl(facilityGroup.facilityGroupName),
        hotelFacilityTypes : this.buildFacilityTypesForm(facilityGroup),
        isConfigurable: new FormControl(facilityGroup.isConfigurable),
        isSelected: new FormControl(facilityGroup.isSelected),
        id: new FormControl(facilityGroup.id),
        status: new FormControl(facilityGroup.status)
      });
      if (groupFormArray === null || groupFormArray === undefined) {
        groupFormArray = new FormArray([groupFormGroup]);
      } else {
        groupFormArray.push(groupFormGroup);
      }
    });

    return groupFormArray;
  }

  buildFacilityTypesForm(facilityGroup: FacilityGroupViewModel): FormArray {
    let typeFormGroup: FormGroup;
    let typeFormArray: FormArray;

    facilityGroup.hotelFacilityTypes.forEach(facilityType => {
      typeFormGroup = new FormGroup({
        facilityTypeId: new FormControl(facilityType.facilityTypeId),
        facilityGroupId: new FormControl(facilityType.facilityGroupId),
        facilityTypeName: new FormControl(facilityType.facilityTypeName),
        facilityList : this.buildFacilitiesForm(facilityType)
      });
      if (typeFormArray === null || typeFormArray === undefined) {
        typeFormArray = new FormArray([typeFormGroup]);
      } else {
        typeFormArray.push(typeFormGroup);
      }
    });

    return typeFormArray;
  }

  buildFacilitiesForm(facilityType: FacilityTypeViewModel): FormArray {
    let facilityFormGroup: FormGroup;
    let facilityFormArray: FormArray;

    facilityType.facilityList.forEach(facility => {
      facilityFormGroup = new FormGroup({
        hotelFacilityRelationId: new FormControl(facility.hotelFacilityRelationId),
        id: new FormControl(facility.id),
        name: new FormControl(facility.name),
        facilityTypeId: new FormControl(facility.facilityTypeId),
        facilityGroupId: new FormControl(facility.facilityGroupId),
        isSelected: new FormControl(facility.isSelected)
      });
      if (facilityFormArray === null || facilityFormArray === undefined) {
        facilityFormArray = new FormArray([facilityFormGroup]);
      } else {
        facilityFormArray.push(facilityFormGroup);
      }

    });

    return facilityFormArray;
  }

  saveFacilities() {

    this.templateFacilitiesList = Object.assign([], this.templateFacilityGroupList, this.facilitiesForm.value.facilitiesGroupArray);

    this.updateObjectState();

    this.templateFacilitiesDataService.addFacilities(this.templateFacilitiesList as FacilityGroupViewModel[], this.templateId)
        .subscribe(data => {
          this.router.navigate(['/templatemgmt/templates']);
          this.snackBar.open('Facilities & Services Template Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
  }

  saveAndContinueFacilities() {

    this.templateFacilitiesList = Object.assign([], this.templateFacilityGroupList, this.facilitiesForm.value.facilitiesGroupArray);

    this.updateObjectState();

    this.templateFacilitiesDataService.addFacilities(this.templateFacilitiesList as FacilityGroupViewModel[], this.templateId)
      .subscribe(data => {
        this.router.navigate(['/templatemgmt/template', this.templateId, edit, 'roomtype']);
        this.snackBar.open('Facilities & Services Template Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
        window.scrollTo(0, 0);
      }
      );
  }

  updateObjectState() {
    this.templateFacilitiesList.forEach ((facilityGroup, facilityGroupIndex) => {
      if (facilityGroup.status === 0) {
        if (facilityGroup.isSelected === true) {
          facilityGroup.objectState = ObjectState.Added;
        } else {
          facilityGroup.objectState = ObjectState.Unchanged;
        }
      } else {
        if (facilityGroup.isSelected !== this.checkOriginalObjectState(facilityGroupIndex)) {
          facilityGroup.objectState = ObjectState.Modified;
        } else {
          facilityGroup.objectState = ObjectState.Unchanged;
        }
      }
    });
  }

  checkOriginalObjectState(facilityGroupIndex) {
    return this.templateFacilityGroupList[facilityGroupIndex].isSelected;
  }

  backToList() {
     this.router.navigate(['/templatemgmt/templates']);
  }

}
