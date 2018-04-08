import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TemplateUrlNotificationService } from '../../../../common/extranet-shared/services/templates/template-url-notification.service';
import { CONSTANTS } from '../../../../../common/constants';
import { AmenitiesGroupViewModel } from '../../../../viewmodel/templates/amenities/amenitiesgroupviewmodel';
import { FormArray, FormGroup, Validators, FormControl } from '@angular/forms';
import { AmenitiesTypeViewModel } from '../../../../viewmodel/templates/amenities/amenitiestypeviewmodel';
import { ObjectState } from '../../../../../common/enums';
import { TemplateAmenitiesDataService } from '../../../../common/extranet-shared/services/templates/template-amenities-data.service';
import { MatSnackBar } from '@angular/material';

const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;

@Component({
  selector: 'app-amenities',
  templateUrl: './amenities.component.html',
  styleUrls: ['./amenities.component.css']
})
export class AmenitiesComponent implements OnInit {

  templateAmenitiesGroupList: AmenitiesGroupViewModel[];
  templateAmenitiesList: AmenitiesGroupViewModel[];
  amenitiesForm: FormGroup;

  constructor(
    private router: Router,
    public snackBar: MatSnackBar,
    private activatedRoute: ActivatedRoute,
    private templateUrlNotificationService: TemplateUrlNotificationService,
    private templateAmenitiesDataService: TemplateAmenitiesDataService
  ) {
      templateUrlNotificationService.changeURLRoute(activatedRoute.snapshot.url[0].path);
  }

  templateId = this.activatedRoute.parent.snapshot.params['id'];

  ngOnInit() {
    window.scrollTo(0, 0);
    this.getTemplateAmenitiesServices();
  }

  getTemplateAmenitiesServices() {
    this.templateAmenitiesGroupList = this.activatedRoute.snapshot.data['amenitiesData'];

    this.amenitiesForm = new FormGroup({
      amenitiesGroupArray: this.buildAmenityGroupsForm(this.templateAmenitiesGroupList)
    });
  }

  get amenitiesGroupArray(): FormArray{
    return <FormArray>this.amenitiesForm.get('amenitiesGroupArray');
  }

  getTypeArrayForGroup(groupIndex: number): FormArray {
      return <FormArray>this.amenitiesGroupArray.controls[groupIndex].get('roomFacilityTypes');
  }

  getAmenityArrayForGroupAndType(groupIndex: number , typeIndex: number) {
    return <FormArray> this.getTypeArrayForGroup(groupIndex).controls[typeIndex].get('facilityList');
  }

  buildAmenityGroupsForm(amenityGroups: AmenitiesGroupViewModel[]): FormArray {
    let groupFormGroup: FormGroup;
    let groupFormArray: FormArray;

    amenityGroups.forEach(amenityGroup => {
      groupFormGroup = new FormGroup({
        facilityGroupName: new FormControl(amenityGroup.facilityGroupName),
        roomFacilityTypes: this.buildAmenityTypesForm(amenityGroup),
        id: new FormControl(amenityGroup.id),
        facilityGroupId: new FormControl(amenityGroup.facilityGroupId),
        code: new FormControl(amenityGroup.code),
        isSelected: new FormControl(amenityGroup.isSelected),
        isConfigurable: new FormControl(amenityGroup.isConfigurable),
        status: new FormControl(amenityGroup.status)
      });
      if (groupFormArray === null || groupFormArray === undefined) {
        groupFormArray = new FormArray([groupFormGroup]);
      } else {
        groupFormArray.push(groupFormGroup);
      }
    });

    return groupFormArray;
  }

  buildAmenityTypesForm(amenityGroup: AmenitiesGroupViewModel): FormArray {
    let typeFormGroup: FormGroup;
    let typeFormArray: FormArray;

    amenityGroup.roomFacilityTypes.forEach(amenityType => {
      typeFormGroup = new FormGroup({
        facilityTypeId: new FormControl(amenityType.facilityTypeId),
        facilityTypeName: new FormControl(amenityType.facilityTypeName),
        facilityGroupId: new FormControl(amenityType.facilityGroupId),
        facilityList : this.buildAmenitiesForm(amenityType)
      });
      if (typeFormArray === null || typeFormArray === undefined) {
        typeFormArray = new FormArray([typeFormGroup]);
      } else {
        typeFormArray.push(typeFormGroup);
      }
    });

    return typeFormArray;
  }

  buildAmenitiesForm(amenityType: AmenitiesTypeViewModel): FormArray {
    let amenityFormGroup: FormGroup;
    let amenityFormArray: FormArray;

    amenityType.facilityList.forEach(amenity => {
      amenityFormGroup = new FormGroup({
        id: new FormControl(amenity.id),
        name: new FormControl(amenity.name),
        facilityTypeId: new FormControl(amenity.facilityTypeId),
        facilityGroupId: new FormControl(amenity.facilityGroupId)
      });
      if (amenityFormArray === null || amenityFormArray === undefined) {
        amenityFormArray = new FormArray([amenityFormGroup]);
      } else {
        amenityFormArray.push(amenityFormGroup);
      }

    });

    return amenityFormArray;
  }

  saveAmenities() {

    this.templateAmenitiesList = Object.assign([], this.templateAmenitiesGroupList, this.amenitiesForm.value.amenitiesGroupArray);

    this.updateObjectState();

    this.templateAmenitiesDataService.addAmenities(this.templateAmenitiesList as AmenitiesGroupViewModel[], this.templateId)
        .subscribe(data => {
          this.router.navigate(['/templatemgmt/templates']);
          this.snackBar.open('Amenities Template Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
  }

  saveandContinue() {
    this.templateAmenitiesList = Object.assign([], this.templateAmenitiesGroupList, this.amenitiesForm.value.amenitiesGroupArray);

    this.updateObjectState();

    this.templateAmenitiesDataService.addAmenities(this.templateAmenitiesList as AmenitiesGroupViewModel[], this.templateId)
        .subscribe(data => {
          this.router.navigate(['/templatemgmt/template', this.templateId, edit, 'mealplan']);
          this.snackBar.open('Amenities Template Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
  }

  updateObjectState() {
    this.templateAmenitiesList.forEach ((amenityGroup, amenityGroupIndex) => {
      if (amenityGroup.status === 0) {
        if (amenityGroup.isSelected === true) {
          amenityGroup.objectState = ObjectState.Added;
        } else {
          amenityGroup.objectState = ObjectState.Unchanged;
        }
      } else {
        if (amenityGroup.isSelected !== this.checkOriginalObjectState(amenityGroupIndex)) {
          amenityGroup.objectState = ObjectState.Modified;
        } else {
          amenityGroup.objectState = ObjectState.Unchanged;
        }
      }
    });
  }

  checkOriginalObjectState(amenityGroupIndex) {
    return this.templateAmenitiesGroupList[amenityGroupIndex].isSelected;
  }

  backToList() {
    this.router.navigate(['/templatemgmt/templates']);
 }
}
