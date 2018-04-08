import { Component, OnInit } from '@angular/core';
import { HotelNavMenuComponent } from '../../hotel-mgmt/hotel-nav-menu/hotel-nav-menu.component';
import { FacilitiesServicesService } from '../../common/extranet-shared/services/facilities-services.service';
import { FacilityGroupViewModel } from '../../viewmodel/facilitiesservicesviewmodel/facilitygroupviewmodel';
import { FacilitiesServicesViewModel } from '../../viewmodel/facilitiesservicesviewmodel/facilitiesservicesviewmodel';
import { FacilityTypeViewModel } from '../../viewmodel/facilitiesservicesviewmodel/facilitytypeviewmodel';
import { FormArray, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { forEach } from '@angular/router/src/utils/collection';
import { EXTRANETCONSTANTS } from '../../common/constants';
import { CONSTANTS } from '../../../common/constants';
import { ObjectState } from '../../../common/enums';
import { MatSnackBar } from '@angular/material';

const facilities = EXTRANETCONSTANTS.facilities;

@Component({
  selector: 'app-facilities-services',
  templateUrl: './facilities-services.component.html',
  styleUrls: ['./facilities-services.component.css']
})
export class FacilitiesServicesComponent implements OnInit {

  facilityGroupList: FacilityGroupViewModel[];
  facilitiesList: FacilityGroupViewModel[];
  facilityOperation: string;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  hotelId = this.route.parent.snapshot.params['id'];

  facilitiesForm: FormGroup;
  groupIndexOfInternet = 0;

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

 isInternetAvailableTypeId = facilities.facilitiesTypeId.isInternetAvailableTypeId;
 connectionTypeTypeId = facilities.facilitiesTypeId.connectionTypeTypeId;
 connectionLocationTypeId = facilities.facilitiesTypeId.connectionLocationTypeId;
 isParkingAvailableTypeId = facilities.facilitiesTypeId.isParkingAvailableTypeId;
 reserveParkingTypeId = facilities.facilitiesTypeId.reserveParkingTypeId;
 petsAllowedTypeId = facilities.facilitiesTypeId.petsAllowedTypeId;

  isFacilityExits: boolean;

  constructor(private facilitiesServicesService: FacilitiesServicesService,
              private route: ActivatedRoute, private router: Router, public snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.getFacilitiesServices();
    window.scrollTo(0, 0);

    this.facilitiesServicesService.isFacilityExits().subscribe( isFacilityExits => {
      this.isFacilityExits = isFacilityExits.result;
      if (this.isFacilityExits === false) {
        this.facilityOperation = 'create';
      } else {
        this.facilityOperation = 'edit';
      }
    });
  }

  getFacilitiesServices() {
    this.facilityGroupList = this.route.snapshot.data['facilityData'];

    this.facilitiesForm = new FormGroup({
      facilitiesGroupArray: this.buildFacilityGroupsForm(this.facilityGroupList)
    });

    // To disable dropdown if internet connection is NO
    let isInternet = null;
    this.getTypeArrayForGroup(this.groupIndexOfInternet).controls.forEach(facilityTypeControl => {
      if (facilityTypeControl.value.facilityTypeId === 1) {
        const facilitySelected = facilityTypeControl.value.selectedFacilityId;
        facilityTypeControl.value.facilityList.forEach(facility => {
          if (facility.id === +(facilitySelected)) {
            if (facility.name === 'No') {
              isInternet = 'No';
            } else {
              isInternet = 'Yes';
            }
          }
        });
      }
      if (isInternet === 'No') {
        if (facilityTypeControl.value.facilityTypeId === this.connectionTypeTypeId ||
                      facilityTypeControl.value.facilityTypeId === this.connectionLocationTypeId) {
          facilityTypeControl.disable();
        }
      }
    });
    // To disable dropdown if internet connection is NO Ends
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
        hotelFacilityTypes : this.buildFacilityTypesForm(facilityGroup)
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
        selectedAll: new FormControl(false),
        selectedFacilityId: new FormControl,
        multiSelectedFacilityIds: new FormControl,
        facilityList : this.buildFacilitiesForm(facilityType)
      });


      // for single select dropdowns
      if (facilityType.facilityTypeId === this.isInternetAvailableTypeId ||
          facilityType.facilityTypeId === this.connectionTypeTypeId ||
          facilityType.facilityTypeId === this.connectionLocationTypeId ||
          facilityType.facilityTypeId === this.isParkingAvailableTypeId ||
          facilityType.facilityTypeId === this.reserveParkingTypeId ||
          facilityType.facilityTypeId === this.petsAllowedTypeId) {
        facilityType.facilityList.forEach(facility => {
          if (facility.isSelected === true) {
            typeFormGroup.patchValue({
              selectedFacilityId: String(facility.id)
            });
          }
        });
      }

      const selectedAll = facilityType.facilityList.every(function (item: any){
        return item.isSelected === true;
      });
      typeFormGroup.patchValue({
        selectedAll: selectedAll
      });

      // for multi select dropdown
      if (facilityGroup.facilityGroupId === this.languagesGroupId) {
        const multiselectedFacilityIds = [];
        facilityType.facilityList.forEach(facility => {
          if (facility.isSelected === true) {
            multiselectedFacilityIds.push(String(facility.id));
            typeFormGroup.patchValue({
              multiSelectedFacilityIds: multiselectedFacilityIds
            });
          }
        });
      }

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

  selectAll(facilityGroupIndex, facilityTypeIndex) {
      this.getFacilityArrayForGroupAndType(facilityGroupIndex, facilityTypeIndex).controls.forEach
      ( facility => {
        facility.patchValue({
          isSelected: this.facilitiesForm.value.facilitiesGroupArray[facilityGroupIndex].
                              hotelFacilityTypes[facilityTypeIndex].selectedAll
        });
      });
  }
  checkIfAllSelected(facilityGroupIndex, facilityTypeIndex) {
    this.getTypeArrayForGroup(facilityGroupIndex).controls.forEach((facilityType, i) => {
      if (facilityTypeIndex === i) {
        facilityType.patchValue({
          selectedAll: this.facilitiesForm.value.facilitiesGroupArray[facilityGroupIndex].
                    hotelFacilityTypes[facilityTypeIndex].facilityList.every(function (item: any) {
                        return item.isSelected === true;
                         })
        });
      }
    });
  }

  saveFacilities() {

    // to convert dropdown facilities in true or false
    this.facilitiesForm.value.facilitiesGroupArray.forEach(facilityGroup => {
      facilityGroup.hotelFacilityTypes.forEach(facilityType => {
        if (facilityType.selectedFacilityId != null) {
          facilityType.facilityList.forEach(facility => {
            if (facility.id === +(facilityType.selectedFacilityId)) {
              facility.isSelected = true;
            } else {
              facility.isSelected = false;
            }
          });
        } else if (facilityType.multiSelectedFacilityIds != null) {
          facilityType.multiSelectedFacilityIds.forEach(selectedId => {
            facilityType.facilityList.forEach(facility => {
              if (facility.id === +(selectedId)) {
                facility.isSelected = true;
              }
            });
          });
        }
      });
    });

    this.facilitiesList = Object.assign([], this.facilityGroupList, this.facilitiesForm.value.facilitiesGroupArray);

    this.updateObjectState();

    const allUnchangedType = [];
    const allUnchangedGroup = [];
    this.facilitiesList.forEach((facilityGroup, j) => {
      facilityGroup.hotelFacilityTypes.forEach((facilityType, i) => {
        allUnchangedType[i] = facilityType.facilityList.every(function (facility: any){
          return facility.objectState === ObjectState.Unchanged;
        });
        allUnchangedGroup.push(allUnchangedType[i]);
      });
    });

    const x = allUnchangedGroup.every(function (item: any){
      return item === true;
    });
    if (x === true) {
      // this.router.navigate(['/hotelmgmt/hotels']);
      this.router.navigate(['hotelmgmt/hotel', this.hotelId, this.edit, 'profilecompl']);
      window.scrollTo(0, 0);
    } else {
      this.facilitiesServicesService.addFacilities(this.facilitiesList as FacilityGroupViewModel[])
        .subscribe(data => {
          // this.router.navigate(['/hotelmgmt/hotels']);
          this.router.navigate(['hotelmgmt/hotel', this.hotelId, this.edit, 'profilecompl']);
          this.snackBar.open('Facilities & Services Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
    }
  }

  updateObjectState() {
    if (this.facilityOperation === CONSTANTS.operation.create) {
      this.facilitiesList.forEach(grp => {
        grp.hotelFacilityTypes.forEach(type => {
          type.facilityList.forEach(facility => {
            if (facility.isSelected) {
              facility.objectState = ObjectState.Added;
            } else {
              facility.objectState = ObjectState.Unchanged;
            }
          });
        });
      });
    } else if (this.facilityOperation === CONSTANTS.operation.edit) {
      this.facilitiesList.forEach((grp, i) => {
        grp.hotelFacilityTypes.forEach((type, j) => {
          type.facilityList.forEach((facility, k) => {
            if (facility.isSelected !== this.checkOriginalObjectState(i, j, k)) {
              if (facility.isSelected) {
                facility.objectState = ObjectState.Added;
              } else {
                facility.objectState = ObjectState.Deleted;
              }
            } else {
              facility.objectState = ObjectState.Unchanged;
            }
          });
        });
      });
    }
  }

  checkOriginalObjectState(grpindex: number, typeindex: number, facilityindex: number): boolean {
    return this.facilityGroupList[grpindex].hotelFacilityTypes[typeindex].
    facilityList[facilityindex].isSelected;
  }

  cancelFacilities() {
    // this.router.navigate(['/hotelmgmt/hotels']);
    this.router.navigate(['hotelmgmt/hotel', this.hotelId, this.edit, 'profilecompl']);
    window.scrollTo(0, 0);
  }

  isInternetDropdownChange(event) {
      // 2 is for 'NO'
      if (+(event.value) === 2) {
          this.getTypeArrayForGroup(this.groupIndexOfInternet).controls.forEach(facilityTypeControl => {
            if (facilityTypeControl.value.facilityTypeId === this.connectionTypeTypeId ||
                                  facilityTypeControl.value.facilityTypeId === this.connectionLocationTypeId) {
              facilityTypeControl.disable();
              facilityTypeControl.patchValue({
                selectedFacilityId : null
              });
            }
          });
      } else {
        this.getTypeArrayForGroup(this.groupIndexOfInternet).controls.forEach(facilityTypeControl => {
            if (facilityTypeControl.value.facilityTypeId === this.connectionTypeTypeId ||
                               facilityTypeControl.value.facilityTypeId === this.connectionLocationTypeId) {
              facilityTypeControl.enable();
            }
        });
      }
  }

}
