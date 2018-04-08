import { Component, OnInit, Input } from '@angular/core';
import { AmenitiesDataService } from '../../common/extranet-shared/services/amenities-data.service';
import { AmenitiesGroupViewModel } from '../../viewmodel/amenitiesviewmodel/amenitiesgroupviewmodel';
import { RoomTypeViewModel } from '../../viewmodel/amenitiesviewmodel/roomtypeviewmodel';
import { FormControl, FormGroup, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { AmenitiesTypeViewModel } from '../../viewmodel/amenitiesviewmodel/amenitiestypeviewmodel';
import { AmenitiesViewModel } from '../../viewmodel/amenitiesviewmodel/amenitiesviewmodel';
import { ObjectState } from '../../../common/enums';
import { CONSTANTS } from '../../../common/constants';

@Component({
  selector: 'app-amenities',
  templateUrl: './amenities.component.html',
  styleUrls: ['./amenities.component.css']
})


export class AmenitiesComponent implements OnInit {

  imgPath = 'assets/AmenitiesIcon/';
  amenitiesGroupList: AmenitiesGroupViewModel[];
  amenitiesList: AmenitiesGroupViewModel[];
  roomList: RoomTypeViewModel[];
  amenitiesForm: FormGroup;
  edit = CONSTANTS.operation.edit;
  hotelId = this.route.parent.snapshot.params['id'];
  isAmenitiesExits: boolean;
  amenityOperation: string;
  roomCountForAll = 0;
  isRoomForHotel: boolean;
  isDisable: boolean;

  constructor(private amenitiesService: AmenitiesDataService,
    private route: ActivatedRoute, private router: Router, public snackBar: MatSnackBar) { }

  ngOnInit() {
    window.scrollTo(0, 0);

    this.roomList = this.route.snapshot.data['roomData'];
    if (this.roomList.length === 0) {
      this.isRoomForHotel = false;
    } else {
      this.isRoomForHotel = true;
      this.getAmenities();
    }

    this.amenitiesService.isAmenitiesExits().subscribe(isAmenitiesExits => {
      this.isAmenitiesExits = isAmenitiesExits.result;
      if (this.isAmenitiesExits === false) {
        this.amenityOperation = CONSTANTS.operation.create;
      } else {
        this.amenityOperation = CONSTANTS.operation.edit;
      }
    });
  }

  getAmenities() {

    this.amenitiesGroupList = this.route.snapshot.data['amenitiesData'];

    this.amenitiesForm = new FormGroup({
      amenitiesGroupArray: this.buildAmenitiesGroupsForm(this.amenitiesGroupList)
    });
  }

  get amenitiesGroupArray(): FormArray {
    return <FormArray>this.amenitiesForm.get('amenitiesGroupArray');
  }

  getTypeArrayForGroup(groupIndex: number): FormArray {
    return <FormArray>this.amenitiesGroupArray.controls[groupIndex].get('roomFacilityTypes');
  }

  getAmenitiesArrayForGroupAndType(groupIndex: number, typeIndex: number) {
    return <FormArray>this.getTypeArrayForGroup(groupIndex).controls[typeIndex].get('facilityList');
  }

  getRoomArrayForAmenities(groupIndex: number, typeIndex: number, facilityindex: number) {
    return <FormArray>this.getAmenitiesArrayForGroupAndType(groupIndex, typeIndex).controls[facilityindex].get('facilitiesRoomList');
  }

  buildAmenitiesGroupsForm(amenitiesGroups: AmenitiesGroupViewModel[]): FormArray {
    let groupFormGroup: FormGroup;
    let groupFormArray: FormArray;

    amenitiesGroups.forEach(amenitiesGroup => {
      groupFormGroup = new FormGroup({
        id: new FormControl(amenitiesGroup.id),
        name: new FormControl(amenitiesGroup.name),
        iconPath: new FormControl(amenitiesGroup.iconPath),
        roomFacilityTypes: this.buildAmenitiesTypesForm(amenitiesGroup)
      });
      if (groupFormArray === null || groupFormArray === undefined) {
        groupFormArray = new FormArray([groupFormGroup]);
      } else {
        groupFormArray.push(groupFormGroup);
      }
    });
    return groupFormArray;
  }

  buildAmenitiesTypesForm(amenitiesGroup: AmenitiesGroupViewModel): FormArray {
    let typeFormGroup: FormGroup;
    let typeFormArray: FormArray;

    amenitiesGroup.roomFacilityTypes.forEach(amenitiesType => {
      typeFormGroup = new FormGroup({
        id: new FormControl(amenitiesType.id),
        name: new FormControl(amenitiesType.name),
        isSelected: new FormControl(false),
        selectedAll: new FormControl(false),
        roomMessageForAll: new FormControl(false),
        disableSaveForError: new FormControl(false),
        facilityList: this.buildFacilitiesForm(amenitiesType)
      });

      if (typeFormArray === null || typeFormArray === undefined) {
        typeFormArray = new FormArray([typeFormGroup]);
      } else {
        typeFormArray.push(typeFormGroup);
      }
    });
    return typeFormArray;

  }

  buildFacilitiesForm(amenitiesType: AmenitiesTypeViewModel): FormArray {
    let amenityFormGroup: FormGroup;
    let amenityFormArray: FormArray;

    amenitiesType.facilityList.forEach(facility => {
      amenityFormGroup = new FormGroup({
        facilityGroupId: new FormControl(facility.facilityGroupId),
        facitilyTypeId: new FormControl(facility.facilityTypeId),
        id: new FormControl(facility.id),
        name: new FormControl(facility.name),
        isSelected: new FormControl(facility.isSelected),
        roomMessageForAmenity: new FormControl(false),
        disableSaveIfRoomMsg: new FormControl(false),
        facilitiesRoomList: this.buildRoomsForm(facility)
      });
      if (amenityFormArray === null || amenityFormArray === undefined) {
        amenityFormArray = new FormArray([amenityFormGroup]);
      } else {
        amenityFormArray.push(amenityFormGroup);
      }

    });
    return amenityFormArray;
  }

  buildRoomsForm(facility: AmenitiesViewModel): FormArray {
    let roomFormGroup: FormGroup;
    let roomFormArray: FormArray;

    facility.facilitiesRoomList.forEach(room => {
      roomFormGroup = new FormGroup({
        roomFacilityRelationId: new FormControl(room.roomFacilityRelationId),
        roomTypeId: new FormControl(room.roomTypeId),
        roomName: new FormControl(room.roomName),
        isSelected: new FormControl(room.isSelected)
      });
      if (roomFormArray === null || roomFormArray === undefined) {
        roomFormArray = new FormArray([roomFormGroup]);
      } else {
        roomFormArray.push(roomFormGroup);
      }

    });
    return roomFormArray;
  }

  saveAmenities() {
    this.amenitiesList = Object.assign([], this.amenitiesGroupList, this.amenitiesForm.value.amenitiesGroupArray);
    this.updateObjectState();
    this.amenitiesList.forEach(group => {
      group.roomFacilityTypes.forEach(type => {
        type.facilityList.forEach(facility => {
          facility.facilitiesRoomList.forEach(room => {
            if (facility.isSelected === false) {
              room.isSelected = false;
            }
          });
        });
      });
    });

    if (this.checkIfAllUnchanged()) {
      this.router.navigate(['hotelmgmt/hotel', this.hotelId, this.edit, 'profilecompl']);
      window.scrollTo(0, 0);
    } else {
      this.amenitiesService.addAmenities(this.amenitiesList as AmenitiesGroupViewModel[])
        .subscribe(data => {
          this.router.navigate(['hotelmgmt/hotel', this.hotelId, this.edit, 'profilecompl']);
          this.snackBar.open('Amenities Saved Successfully', '',
            { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
          window.scrollTo(0, 0);
        });
    }
  }

  updateObjectState() {
    if (this.amenityOperation === CONSTANTS.operation.create) {
      this.amenitiesList.forEach(group => {
        group.roomFacilityTypes.forEach(type => {
          type.facilityList.forEach(facility => {
            facility.facilitiesRoomList.forEach(room => {
              if (facility.isSelected) {
                facility.objectState = ObjectState.Added;
                if (room.isSelected) {
                  room.objectState = ObjectState.Added;
                }
              } else {
                facility.objectState = ObjectState.Unchanged;
                room.objectState = ObjectState.Unchanged;
              }
            });
          });
        });
      });
    } else if (this.amenityOperation === CONSTANTS.operation.edit) {
      this.amenitiesList.forEach((group, i) => {
        group.roomFacilityTypes.forEach((type, j) => {
          type.facilityList.forEach((facility, k) => {
            facility.facilitiesRoomList.forEach((room, l) => {
              if (facility.isSelected !== this.checkFacilityOriginalObjectState(i, j, k)) {
                if (facility.isSelected) {
                  facility.objectState = ObjectState.Added;
                  if (room.isSelected) {
                    room.objectState = ObjectState.Added;
                  }
                } else {
                  facility.objectState = ObjectState.Deleted;
                  room.objectState = ObjectState.Deleted;
                }
              } else {
                facility.objectState = ObjectState.Unchanged;
                if (room.isSelected !== this.checkRoomOriginalObjectState(i, j, k, l)) {
                  if (room.isSelected) {
                    room.objectState = ObjectState.Added;
                  } else {
                    room.objectState = ObjectState.Deleted;
                  }
                } else {
                  room.objectState = ObjectState.Unchanged;
                }
              }
            });
          });
        });
      });
    }
  }

  checkFacilityOriginalObjectState(groupindex: number, typeindex: number, facilityindex: number): boolean {
    return this.amenitiesGroupList[groupindex].roomFacilityTypes[typeindex].
      facilityList[facilityindex].isSelected;
  }

  checkRoomOriginalObjectState(groupindex: number, typeindex: number, facilityindex: number, roomindex: number): boolean {
    return this.amenitiesGroupList[groupindex].roomFacilityTypes[typeindex].
      facilityList[facilityindex].facilitiesRoomList[roomindex].isSelected;

  }

  cancelAmenities() {
    this.router.navigate(['hotelmgmt/hotel', this.hotelId, this.edit, 'profilecompl']);
    window.scrollTo(0, 0);
  }


  selectAllAmenities(event, amenityGroupIndex, amenityTypeIndex) {

    if (event.checked === true) {
      this.getTypeArrayForGroup(amenityGroupIndex).controls.forEach
        (type => {
          type.patchValue({
            roomMessageForAll: true,
            disableSaveForError: true
          });
        });
      this.getAmenitiesArrayForGroupAndType(amenityGroupIndex, amenityTypeIndex).controls.forEach
        ((amenity) => {
          amenity.patchValue({
            isSelected: true,
            roomMessageForAmenity: false,
          });
        });
    } else {
      this.getTypeArrayForGroup(amenityGroupIndex).controls.forEach
        (type => {
          type.patchValue({
            roomMessageForAll: false,
            disableSaveForError: false
          });
        });

      this.getAmenitiesArrayForGroupAndType(amenityGroupIndex, amenityTypeIndex).controls.forEach
        ((amenity, amenityIndex) => {
          amenity.patchValue({
            isSelected: false,
          });
          this.getRoomArrayForAmenities(amenityGroupIndex, amenityTypeIndex, amenityIndex).controls.forEach(room => {
            room.get('isSelected').setValue(false);
          });
        });
    }
    this.disableSaveOnError();
  }

  selectAmenities(event, groupindex, typeindex, facilityindex) {

    const allFacility = [];
    const allFacilityArray = [];

    if (event.checked === false) {
      this.amenitiesGroupArray.controls.forEach((group, groupIndex) => {
        if (groupindex === groupIndex) {
          this.getTypeArrayForGroup(groupIndex).controls.forEach((type, typeIndex) => {
            this.getAmenitiesArrayForGroupAndType(groupIndex, typeIndex).controls.forEach((facility, facilityIndex) => {
              if (facilityIndex === facilityindex) {
                this.getRoomArrayForAmenities(groupIndex, typeIndex, facilityIndex).controls.forEach((room) => {
                  facility.get('disableSaveIfRoomMsg').setValue(false);
                  facility.get('roomMessageForAmenity').setValue(false);
                  facility.get('isSelected').setValue(false);
                  room.get('isSelected').setValue(false);
                });
              }
              // Uncheck 'All' if all amenity is unselected
              if (facility.get('isSelected').value) {
                allFacility[facilityIndex] = true;
              } else {
                allFacility[facilityIndex] = false;
              }
              allFacilityArray.push(allFacility[facilityIndex]);
            });
            const x = allFacilityArray.every(function (item: any) {
              return item === false;
            });
            if (x === true) {
              type.get('selectedAll').setValue(false);
              type.get('roomMessageForAll').setValue(false);
              type.get('disableSaveForError').setValue(false);
            }
          });
        }
      });
    } else if (event.checked === true) {
      this.amenitiesGroupArray.controls.forEach((group, groupIndex) => {
        if (groupindex === groupIndex) {
          this.getTypeArrayForGroup(groupIndex).controls.forEach((type, typeIndex) => {
            this.getAmenitiesArrayForGroupAndType(groupIndex, typeIndex).controls.forEach((facility, facilityIndex) => {
              if (type.get('selectedAll').value) {
                facility.get('disableSaveIfRoomMsg').setValue(false);
                facility.get('roomMessageForAmenity').setValue(false);
              } else {
                if (facilityIndex === facilityindex) {
                  facility.get('isSelected').setValue(true);
                  facility.get('disableSaveIfRoomMsg').setValue(true);
                  facility.get('roomMessageForAmenity').setValue(true);
                }
              }
            });
          });
        }
      });
    }
    this.disableSaveOnError();
  }


  selectRoom(event, groupindex, typeindex, facilityindex, roomindex) {
    const allRoomUnselectedArray = [];
    let allRoomUnselected;

    // Remove error message on new room selection
    if (event.checked === true) {
      this.amenitiesGroupArray.controls.forEach((group, groupIndex) => {
        if (groupindex === groupIndex) {
          this.getTypeArrayForGroup(groupIndex).controls.forEach((type, typeIndex) => {
            this.getAmenitiesArrayForGroupAndType(groupIndex, typeIndex).controls.forEach((facility, facilityIndex) => {
              if (facilityIndex === facilityindex) {
                facility.get('disableSaveIfRoomMsg').setValue(false);
                facility.get('roomMessageForAmenity').setValue(false);
                this.getRoomArrayForAmenities(groupIndex, typeIndex, facilityIndex).controls.forEach((room, roomIndex) => {
                  if (roomIndex === roomindex) {
                    room.get('isSelected').setValue(true);
                  }
                });
              }
            });
          });
        }
      });
    } else if (event.checked === false) {      // add error message if all room are unselected
      this.amenitiesGroupArray.controls.forEach((group, groupIndex) => {
        if (groupindex === groupIndex) {
          this.getTypeArrayForGroup(groupIndex).controls.forEach((type, typeIndex) => {
            this.getAmenitiesArrayForGroupAndType(groupIndex, typeIndex).controls.forEach((facility, facilityIndex) => {
              if (facilityIndex === facilityindex) {
                this.getRoomArrayForAmenities(groupIndex, typeIndex, facilityIndex).controls.forEach((room, roomIndex) => {
                  if (roomindex === roomIndex) {
                    room.get('isSelected').setValue(false);
                  }
                  if (!(room.get('isSelected').value)) {
                    allRoomUnselectedArray[roomIndex] = false;
                  } else {
                    allRoomUnselectedArray[roomIndex] = true;
                  }
                });
                allRoomUnselected = allRoomUnselectedArray.every(function (room: any) {
                  return room === false;
                });
                if (allRoomUnselected) {
                  facility.get('disableSaveIfRoomMsg').setValue(true);
                  facility.get('roomMessageForAmenity').setValue(true);
                }
              }
            });
          });
        }
      });
    }
    this.disableSaveOnError();
  }

  selectRoomForAllAmenities(event, roomId, groupindex) {
    this.amenitiesGroupArray.controls.forEach((group, groupIndex) => {
      if (groupIndex === groupindex) {
        this.getTypeArrayForGroup(groupIndex).controls.forEach((type, typeIndex) => {
          this.getAmenitiesArrayForGroupAndType(groupIndex, typeIndex).controls.forEach((facility, facilityIndex) => {
            this.getRoomArrayForAmenities(groupIndex, typeIndex, facilityIndex).controls.forEach((room, roomIndex) => {
              if (roomId === (room.get('roomTypeId').value)) {
                if (event.checked) {
                  this.roomCountForAll++;
                  type.get('disableSaveForError').setValue(false);
                  room.get('isSelected').setValue(true);
                  type.get('roomMessageForAll').setValue(false);
                } else {
                  this.roomCountForAll--;
                  if (this.roomCountForAll === 0) {
                    type.get('disableSaveForError').setValue(true);
                    type.get('roomMessageForAll').setValue(true);
                  }
                  room.get('isSelected').setValue(false);
                }
              }
            });
          });
        });
      }
    });
    this.disableSaveOnError();
  }

  checkIfAllUnchanged() {

    const allUnchangedFacility = [];
    const allUnchangedFacilityArray = [];
    const allUnchangedRoom = [];
    const allUnchangedRoomArray = [];

    this.amenitiesList.forEach((amenityGroup, j) => {
      amenityGroup.roomFacilityTypes.forEach((amenityType, i) => {
        allUnchangedFacility[j] = amenityType.facilityList.every(function (facility: any) {
          return facility.objectState === ObjectState.Unchanged;
        });
        amenityType.facilityList.forEach((facility, k) => {
          allUnchangedRoom[k] = facility.facilitiesRoomList.every(function (room: any) {
            return room.objectState === ObjectState.Unchanged;
          });
          allUnchangedRoomArray.push(allUnchangedRoom[k]);
        });
        allUnchangedFacilityArray.push(allUnchangedFacility[j]);
      });
    });

    const x = allUnchangedFacilityArray.every(function (item: any) {
      return item === true;
    });

    const y = allUnchangedRoomArray.every(function (item: any) {
      return item === true;
    });

    if (x === true && y === true) {
      return true;
    } else {
      return false;
    }
  }

  disableSaveOnError() {
    const allType = [];
    const allTypeArray = [];
    const allFacility = [];
    const allFacilityArray = [];

    this.amenitiesGroupArray.controls.forEach((group, groupIndex) => {
      this.getTypeArrayForGroup(groupIndex).controls.forEach((type, typeIndex) => {
        if (type.get('disableSaveForError').value) {
          allType[typeIndex] = true;
        } else {
          allType[typeIndex] = false;
        }
        allTypeArray.push(allType[typeIndex]);

        this.getAmenitiesArrayForGroupAndType(groupIndex, typeIndex).controls.forEach((facility, facilityIndex) => {
          if (facility.get('disableSaveIfRoomMsg').value) {
            allFacility[facilityIndex] = true;
          } else {
            allFacility[facilityIndex] = false;
          }
          allFacilityArray.push(allFacility[facilityIndex]);
        });
      });
    });

    const x = allTypeArray.every(function (item: any) {
      return item === false;
    });

    const y = allFacilityArray.every(function (item: any) {
      return item === false;
    });

    if (x === true && y === true) {
      this.isDisable = false;
    } else {
      this.isDisable = true;
    }

  }



}
