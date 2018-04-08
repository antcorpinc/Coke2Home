import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CONSTANTS } from '../../../../common/constants';
import { Router, ActivatedRoute } from '@angular/router';
import { FormArray, FormBuilder, FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { RoomtypeDataService } from '../../../common/extranet-shared/services/roomtype-data.service';
import { HotelRoomTypeViewModel } from '../../../viewmodel/roomtypeviewmodel/HotelRoomTypeViewModel';
import { RoomTypeViewModel } from '../../../viewmodel/roomtypeviewmodel/RoomTypeViewModel';
import { SizeMeasureViewModel } from '../../../viewmodel/roomtypeviewmodel/SizeMeasureViewModel';
import { BedsViewModel } from '../../../viewmodel/roomtypeviewmodel/BedsViewModel';
import { OccupancyViewModel } from '../../../viewmodel/roomtypeviewmodel/OccupancyViewModel';
import { MatSnackBar } from '@angular/material';
import { ObjectState } from '../../../../common/enums';

function ValidateArrangment(control: AbstractControl): { [key: string]: boolean } | null {
  const occupancy = control.get('occupancyId');
  const roomBed = control.get('roomBedList');
  let totalArrangment = 0, occ, totalNoOfBeds = 0;
  const list = [];

  if (((occupancy.value !== undefined) && (occupancy.value !== null)) &&
    (roomBed.value !== undefined) && (roomBed.value !== null) && (roomBed.value.length > 0)) {
    occ = occupancy.value;

    roomBed.value.forEach(element => {
      const BedID = element.bedId;
      list.push(BedID);
      const noOfBeds = element.noOfBeds;
      totalNoOfBeds = noOfBeds + totalNoOfBeds;
      if (BedID === 1) {
        totalArrangment += BedID * noOfBeds;
      } else {
        totalArrangment += 2 * noOfBeds;
      }
    });

    const sorted_arr = list.slice().sort();
    const results = [];
    for (let i = 0; i < sorted_arr.length - 1; i++) {
      if (sorted_arr[i + 1] === sorted_arr[i]) {
        results.push(sorted_arr[i]);
      }
    }

    if (results.length > 0) {
      return { 'ValidateArrangmentSameBed': true };
    }
    if (occ !== 1 && occ !== totalArrangment) {
      return { 'ValidateArrangment': true };
    }
    if (occ === 1 && occ !== totalNoOfBeds) {
      return { 'ValidateArrangmentSingleGuest': true };
    }
  }
  return null;
}

function ValidateRooms(control: AbstractControl): { [key: string]: boolean } | null {
  const noOfRooms = control.get('noOfRooms').value;
  const noOfDoubleRooms = control.get('noOfDoubleRooms').value;
  const noOfTwinRooms = control.get('noOfTwinRooms').value;
  let totalRooms = 0;
  totalRooms = noOfDoubleRooms + noOfTwinRooms;

  if (totalRooms > noOfRooms) {
    return { 'validateRoooms': true };
  }
  return null;
}

@Component({
  selector: 'app-room-type-info',
  templateUrl: './room-type-info.component.html',
  styleUrls: ['./room-type-info.component.css']
})
export class RoomTypeInfoComponent implements OnInit {
  operation: string;
  roomOperation: string;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  hotelId: string;
  roomId: number;
  roomBedListLen: number;
  isMaxLength: boolean;
  roomTypesList: RoomTypeViewModel[];
  sizeMeasureList: SizeMeasureViewModel[];
  bedsList: BedsViewModel[];
  occupancyList: OccupancyViewModel[];
  roomTypeInfo: HotelRoomTypeViewModel = <HotelRoomTypeViewModel>{};

  roomForm: FormGroup;

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    private roomTypeDataService: RoomtypeDataService, private cd: ChangeDetectorRef, public snackBar: MatSnackBar) { }

  ngOnInit() {
    this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.roomOperation = this.activatedRoute.snapshot.params['operation'];
    this.roomId = this.activatedRoute.snapshot.params['id'];
    this.getRoomTypes();
    this.getRoomSizes();
    this.getBeds();
    this.getOccupancy();

    this.roomForm = new FormGroup({
      isActive: new FormControl('true'),
      roomTypeId: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      size: new FormControl('', Validators.required),
      sizeMeasureId: new FormControl('', Validators.required),
      noOfRooms: new FormControl('', Validators.required),
      noOfDoubleRooms: new FormControl('', Validators.required),
      noOfTwinRooms: new FormControl('', Validators.required),
      isFreeSale: new FormControl(false, Validators.required),
      isSmoking: new FormControl(false, Validators.required),
      description: new FormControl('', Validators.required),
      objectState: new FormControl(ObjectState.Unchanged),
      roomBedOptions: this.buildRoomBedOptions()
    }, ValidateRooms);

    if (this.roomOperation.toLowerCase().trim() === this.edit) {
      this.getRoomDetails(this.roomId);
    }
  }

  get roomBedList(): FormArray {
    return <FormArray>this.roomForm.controls.roomBedOptions.get('roomBedList');
  }
  buildRoomBedOptions(): FormGroup {
    let roomBedOptionsFormGroup: FormGroup;
    roomBedOptionsFormGroup = new FormGroup({
      occupancyId: new FormControl(),
      objectState: new FormControl(ObjectState.Unchanged),
      roomBedList: new FormArray([this.buildRoomBed()])
    }, ValidateArrangment);

    return roomBedOptionsFormGroup;
  }

  addRoomBed() {
    this.roomBedList.push(this.buildRoomBed());
    this.roomBedListLen = this.roomBedList.length;
    if (this.roomBedListLen === 3) {
      this.isMaxLength = true;
    }
    this.cd.detectChanges();
  }
  deleteRoomBed(index: number) {
    if (this.roomOperation.toLowerCase().trim() === this.edit) {
      const id = this.roomBedList.controls[index].get('id').value;
      this.roomTypeDataService.deleteRoomBedRelation(id).subscribe(data => {
      });
    }
    this.isMaxLength = false;

    this.roomBedList.removeAt(index);
    this.cd.detectChanges();
  }
  buildRoomBed(): FormGroup {
    let roomBedFormGroup: FormGroup;
    roomBedFormGroup = new FormGroup({
      bedId: new FormControl(),
      noOfBeds: new FormControl(),
      id: new FormControl(0),
      objectState: new FormControl(ObjectState.Added),
    });
    return roomBedFormGroup;
  }
  cancelRoomType() {
    this.router.navigate(['/hotelmgmt/hotel', this.hotelId, this.operation.trim().toLowerCase(), 'roomtypelist']);
  }
  getRoomTypes() {
    this.roomTypeDataService.getRoomTypes().subscribe(roomTypesList => {
      this.roomTypesList = roomTypesList;
    });
  }
  getRoomSizes() {
    this.roomTypeDataService.getSizeMeasure().subscribe(sizeMeasureList => {
      this.sizeMeasureList = sizeMeasureList;
    });
  }
  getBeds() {
    this.roomTypeDataService.getBeds().subscribe(bedsList => {
      this.bedsList = bedsList;
    });
  }
  getOccupancy() {
    this.roomTypeDataService.getOccupancy().subscribe(occupancyList => {
      this.occupancyList = occupancyList;
    });
  }

  saveRoom() {
    if (this.roomForm.valid) {
      const roomtypes = Object.assign({}, this.roomTypeInfo, this.roomForm.value);
      roomtypes.hotelId = this.hotelId;

      if (this.roomOperation.toLowerCase().trim() === this.create) {
        roomtypes.objectState = ObjectState.Added;
        roomtypes.roomId = 0;
        roomtypes.roomBedOptions.hotelId = this.hotelId;
        roomtypes.roomBedOptions.objectState = ObjectState.Added;
        // roomtypes.roomBedOptions.roomBedList.forEach(element => {
        //   roomtypes.roomBedOptions.roomBedList.map((item) => {
        //     item.id = 0;
        //     item.objectState = ObjectState.Added;
        //   });
        // });
      }

      if (this.roomOperation.toLowerCase().trim() === this.edit) {
      //  roomtypes.objectState = ObjectState.Modified;
        roomtypes.roomId = this.roomId;
        roomtypes.roomBedOptions.hotelId = this.hotelId;
        // roomtypes.roomBedOptions.objectState = ObjectState.Modified;
        // roomtypes.roomBedOptions.roomBedList.forEach(element => {
        //   roomtypes.roomBedOptions.roomBedList.map(function(item) {
        //     item.objectState = ObjectState.Modified;
        //   });
        // });
      }

      this.roomTypeDataService.addRoom(roomtypes as HotelRoomTypeViewModel)
        .subscribe(data => {
          if (this.roomOperation.toLowerCase().trim() === this.edit) {
            this.snackBar.open('Room Updated Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
          } else {
            this.snackBar.open('Room Created Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
          }

        this.router.navigate(['/hotelmgmt/hotel', this.hotelId, this.operation.trim().toLowerCase(), 'roomtypelist']);
      });
    }
  }

  flagRoomTypeAsEdited() {
    if (this.roomOperation.toLowerCase().trim() === this.edit) {
      this.roomForm.get('objectState').setValue(ObjectState.Modified);
    }
  }

  flagBedTypeAsEdited(index: number) {
    if (this.roomOperation.toLowerCase().trim() === this.edit) {
      if (this.roomBedList.controls[index].get('objectState').value !== ObjectState.Added) {
        this.roomBedList.controls[index].get('objectState').setValue(ObjectState.Modified);
      }
    }
  }

  private getRoomDetails(roomId) {
    this.roomTypeDataService.getRoom(roomId).subscribe(roomData => {

      const roomBedvalue = roomData.roomBedOptions.roomBedList;
      for (let i = 0; i < roomBedvalue.length - 1; i++) {
        this.addRoomBed();
      }

      if (this.roomOperation.toLowerCase().trim() === this.edit) {
        this.roomForm.get('isActive').setValue(roomData.isActive);
        this.roomForm.get('roomTypeId').setValue(roomData.roomTypeId);
        this.roomForm.get('name').setValue(roomData.name);
        this.roomForm.get('size').setValue(roomData.size);
        this.roomForm.get('sizeMeasureId').setValue(roomData.sizeMeasureId);
        this.roomForm.get('noOfRooms').setValue(roomData.noOfRooms);
        this.roomForm.get('noOfDoubleRooms').setValue(roomData.noOfDoubleRooms);
        this.roomForm.get('noOfTwinRooms').setValue(roomData.noOfTwinRooms);
        this.roomForm.get('isFreeSale').setValue(roomData.isFreeSale);
        this.roomForm.get('isSmoking').setValue(roomData.isSmoking);
        this.roomForm.get('description').setValue(roomData.description);
        this.roomForm.controls.roomBedOptions.get('occupancyId').setValue(roomData.roomBedOptions.occupancyId);

        this.roomBedList.controls.forEach((control, index) => {
          control.get('bedId').setValue(roomBedvalue[index].bedId);
          control.get('noOfBeds').setValue(roomBedvalue[index].noOfBeds);
          control.get('id').setValue(roomBedvalue[index].id);
          control.get('objectState').setValue(ObjectState.Unchanged);
        });
      }

    });
  }

}
