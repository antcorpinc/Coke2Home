import { Component, OnInit } from '@angular/core';
import { EXTRANETCONSTANTS } from '../../../../common/constants';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TemplateNameDataService } from '../../../../common/extranet-shared/services/templates/template-name-data.service';
import { TemplatesDataService } from '../../../../common/extranet-shared/services/templates/templates-data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ObjectState, EntityState } from '../../../../../common/enums';
import { CONSTANTS } from '../../../../../common/constants';
import { TemplateUrlNotificationService } from '../../../../common/extranet-shared/services/templates/template-url-notification.service';
import { TemplateRoomtypeinfoviewmodel, Roomtypeinfoviewmodel } from '../../../../viewmodel/templates/room-type/roomtypeinfoviewmodel';
import { TemplateRoomTypeDataService } from '../../../../common/extranet-shared/services/templates/template-room-type-data.service';
import { MatSnackBar } from '@angular/material';


const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;

const roomTypeInfo = EXTRANETCONSTANTS.templates.roomtype;

@Component({
  selector: 'app-room-type',
  templateUrl: './room-type.component.html',
  styleUrls: ['./room-type.component.css']
})
export class RoomTypeComponent implements OnInit {
  isRead: boolean;
  operation: string;
  templateName: string;
  templateId = this.activatedRoute.parent.snapshot.params['id'];

  roomtype = roomTypeInfo.roomtype;
  roomname = roomTypeInfo.roomname;
  roomsize = roomTypeInfo.roomsize;
  totalnumberofrooms = roomTypeInfo.totalnumberofrooms;
  totalNumberofdoublerooms = roomTypeInfo.totalNumberofdoublerooms;
  totalnumberofTwinrooms = roomTypeInfo.totalnumberofTwinrooms;
  isfreesale = roomTypeInfo.isfreesale;
  smokingroom = roomTypeInfo.smokingroom;
  roomDescription = roomTypeInfo.roomDescription;
  bedoptions = roomTypeInfo.bedoptions;

  templateRoomtypeinfoviewmodel: TemplateRoomtypeinfoviewmodel;
  roomtypeiFields: Roomtypeinfoviewmodel[];

  roomtypeStatus: Roomtypeinfoviewmodel[];
  roomnameStatus: Roomtypeinfoviewmodel[];
  roomsizeStatus: Roomtypeinfoviewmodel[];
  totalnumberofroomsStatus: Roomtypeinfoviewmodel[];
  totalNumberofdoubleroomsStatus: Roomtypeinfoviewmodel[];
  totalnumberofTwinroomsStatus: Roomtypeinfoviewmodel[];
  isfreesaleStatus: Roomtypeinfoviewmodel[];
  smokingroomStatus: Roomtypeinfoviewmodel[];
  roomDescriptionStatus: Roomtypeinfoviewmodel[];
  bedoptionsStatus: Roomtypeinfoviewmodel[];

  roomTypeForm: FormGroup;
  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private templateRoomTypeDataService: TemplateRoomTypeDataService,
    private templateUrlNotificationService: TemplateUrlNotificationService,
    public snackBar: MatSnackBar
  ) {
    templateUrlNotificationService.changeURLRoute(activatedRoute.snapshot.url[0].path);
     }

  ngOnInit() {
    window.scrollTo(0, 0);
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.templateId = this.activatedRoute.parent.snapshot.params['id'];
    this.getRoomTypeFieldsList();
    this.getRoomFieldStatus();

    this.roomTypeForm = new FormGroup({
      roomtype : new FormControl(this.roomtypeStatus[0]['isSelected']),
      roomname : new FormControl(this.roomnameStatus[0]['isSelected']),
      roomsize : new FormControl(this.roomsizeStatus[0]['isSelected']),
      totalnumberofrooms : new FormControl(this.totalnumberofroomsStatus[0]['isSelected']),
      totalNumberofdoublerooms : new FormControl(this.totalNumberofdoubleroomsStatus[0]['isSelected']),
      totalnumberofTwinrooms : new FormControl(this.totalnumberofTwinroomsStatus[0]['isSelected']),
      isfreesale : new FormControl(this.isfreesaleStatus[0]['isSelected']),
      smokingroom : new FormControl(this.smokingroomStatus[0]['isSelected']),
      roomDescription : new FormControl(this.roomDescriptionStatus[0]['isSelected']),
      bedoptions : new FormControl(this.bedoptionsStatus[0]['isSelected']),
    });

  }

  private getRoomTypeFieldsList() {
    this.templateRoomtypeinfoviewmodel = this.activatedRoute.snapshot.data['roomTypeData'];
    this.roomtypeiFields = this.templateRoomtypeinfoviewmodel.roomFields;
    // console.log('this.templateRoomtypeinfoviewmodel -' + JSON.stringify(this.templateRoomtypeinfoviewmodel));
    // console.log('this.roomtypeiFields -' + JSON.stringify(this.roomtypeiFields));
  }

  private getRoomFieldStatus() {
    this.roomtypeStatus = this.roomtypeiFields.filter( arr => arr.code === this.roomtype );
    this.roomnameStatus = this.roomtypeiFields.filter(arr => arr.code === this.roomname);
    this.roomsizeStatus = this.roomtypeiFields.filter(arr => arr.code === this.roomsize);
    this.totalnumberofroomsStatus = this.roomtypeiFields.filter(arr => arr.code === this.totalnumberofrooms);
    this.totalNumberofdoubleroomsStatus = this.roomtypeiFields.filter(arr => arr.code === this.totalNumberofdoublerooms);
    this.totalnumberofTwinroomsStatus = this.roomtypeiFields.filter(arr => arr.code === this.totalnumberofTwinrooms);
    this.isfreesaleStatus = this.roomtypeiFields.filter(arr => arr.code === this.isfreesale);
    this.smokingroomStatus = this.roomtypeiFields.filter( arr => arr.code === this.smokingroom );
    this.roomDescriptionStatus = this.roomtypeiFields.filter(arr => arr.code === this.roomDescription );
    this.bedoptionsStatus = this.roomtypeiFields.filter(arr => arr.code === this.bedoptions);

  }

  createSavingData(operation: string) {
    let arrayRoomTypeFields: Roomtypeinfoviewmodel[];
    arrayRoomTypeFields = [];
    if (operation === create) {
      this.roomtypeStatus[0]['isSelected'] = this.roomTypeForm.controls[
        'roomtype'
      ].value;
      this.roomtypeStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.roomtypeStatus[0]);
      this.roomnameStatus[0]['isSelected'] = this.roomTypeForm.controls[
        'roomname'
      ].value;
      this.roomnameStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.roomnameStatus[0]);
      this.roomsizeStatus[0]['isSelected'] = this.roomTypeForm.controls[
        'roomsize'
      ].value;
      this.roomsizeStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.roomsizeStatus[0]);
      this.totalnumberofroomsStatus[0]['isSelected'] = this.roomTypeForm.controls[
        'totalnumberofrooms'
      ].value;
      this.totalnumberofroomsStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.totalnumberofroomsStatus[0]);

      this.totalNumberofdoubleroomsStatus[0]['isSelected'] = this.roomTypeForm.controls[
        'totalNumberofdoublerooms'
      ].value;
      this.totalNumberofdoubleroomsStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.totalNumberofdoubleroomsStatus[0]);

      this.totalnumberofTwinrooms[0]['isSelected'] = this.roomTypeForm.controls[
        'totalnumberofTwinrooms'
      ].value;
      this.totalnumberofTwinroomsStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.totalnumberofTwinroomsStatus[0]);
      this.isfreesaleStatus[0]['isSelected'] = this.roomTypeForm.controls[
        'isfreesale'
      ].value;
      this.isfreesaleStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.isfreesaleStatus[0]);

      this.smokingroomStatus[0]['isSelected'] = this.roomTypeForm.controls[
        'smokingroom'
      ].value;
      this.smokingroomStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.smokingroomStatus[0]);
      this.roomDescriptionStatus[0]['isSelected'] = this.roomTypeForm.controls[
        'roomDescription'
      ].value;
      this.roomDescriptionStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.roomDescriptionStatus[0]);
      this.bedoptionsStatus[0]['isSelected'] = this.roomTypeForm.controls[
        'bedoptions'
      ].value;
      this.bedoptionsStatus[0]['objectState'] = ObjectState.Added;
      arrayRoomTypeFields.push(this.bedoptionsStatus[0]);
    } else if (operation === edit) {
      if (
        this.roomtypeStatus[0]['isSelected'] !==
        this.roomTypeForm.controls['roomtype'].value
      ) {
        this.roomtypeStatus[0]['isSelected'] = this.roomTypeForm.controls[
          'roomtype'].value;
        if ( this.roomtypeStatus[0]['status'] === EntityState.New) {
          this.roomtypeStatus[0]['objectState'] = ObjectState.Added; } else {
        this.roomtypeStatus[0]['objectState'] = ObjectState.Modified;
      } } else {
        this.roomtypeStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.roomtypeStatus[0]);
      if (
        this.roomnameStatus[0]['isSelected'] !==
        this.roomTypeForm.controls['roomname'].value
      ) {
        this.roomnameStatus[0]['isSelected'] = this.roomTypeForm.controls[
          'roomname' ].value;
        if ( this.roomnameStatus[0]['status'] === EntityState.New) {
          this.roomnameStatus[0]['objectState'] = ObjectState.Added; } else {
        this.roomnameStatus[0]['objectState'] = ObjectState.Modified;
      } } else {
        this.roomnameStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.roomnameStatus[0]);
      if (
        this.roomsizeStatus[0]['isSelected'] !==
        this.roomTypeForm.controls['roomsize'].value
      ) {
        this.roomsizeStatus[0]['isSelected'] = this.roomTypeForm.controls[
          'roomsize'].value;
       // this.roomsizeStatus[0]['objectState'] = ObjectState.Modified;
       if ( this.roomsizeStatus[0]['status'] === EntityState.New) {
        this.roomsizeStatus[0]['objectState'] = ObjectState.Added; } else {
      this.roomsizeStatus[0]['objectState'] = ObjectState.Modified;
    } }  else {
        this.roomsizeStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.roomsizeStatus[0]);
      if (
        this.totalnumberofroomsStatus[0]['isSelected'] !==
        this.roomTypeForm.controls['totalnumberofrooms'].value
      ) {
        this.totalnumberofroomsStatus[0]['isSelected'] = this.roomTypeForm.controls[
          'totalnumberofrooms'].value;
        if ( this.totalnumberofroomsStatus[0]['status'] === EntityState.New) {
          this.totalnumberofroomsStatus[0]['objectState'] = ObjectState.Added; } else {
        this.totalnumberofroomsStatus[0]['objectState'] = ObjectState.Modified;
      } }else {
        this.totalnumberofroomsStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.totalnumberofroomsStatus[0]);
      if (
        (this.totalNumberofdoubleroomsStatus[0]['isSelected'] !== this.roomTypeForm.controls[
          'totalNumberofdoublerooms'
        ].value)
      ) {
        this.totalNumberofdoubleroomsStatus[0]['isSelected'] = this.roomTypeForm.controls[
          'totalNumberofdoublerooms'
        ].value;
        if ( this.totalNumberofdoubleroomsStatus[0]['status'] === EntityState.New) {
          this.totalNumberofdoubleroomsStatus[0]['objectState'] = ObjectState.Added; } else {
        this.totalNumberofdoubleroomsStatus[0]['objectState'] = ObjectState.Modified;
      } }else {
        this.totalNumberofdoubleroomsStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.totalNumberofdoubleroomsStatus[0]);
      if (
        this.totalnumberofTwinroomsStatus[0]['isSelected'] !==
        this.roomTypeForm.controls['totalnumberofTwinrooms'].value
      ) {
        this.totalnumberofTwinroomsStatus[0]['isSelected'] = this.roomTypeForm.controls[
          'totalnumberofTwinrooms'
        ].value;
        if ( this.totalnumberofTwinroomsStatus[0]['status'] === EntityState.New) {
          this.totalnumberofTwinroomsStatus[0]['objectState'] = ObjectState.Added; } else {
        this.totalnumberofTwinroomsStatus[0]['objectState'] = ObjectState.Modified;
      } } else {
        this.totalnumberofTwinroomsStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.totalnumberofTwinroomsStatus[0]);
      if (
        this.isfreesaleStatus[0]['isSelected'] !==
        this.roomTypeForm.controls['isfreesale'].value
      ) {
        this.isfreesaleStatus[0]['isSelected'] = this.roomTypeForm.controls[
          'isfreesale'].value;
        if ( this.isfreesaleStatus[0]['status'] === EntityState.New) {
          this.isfreesaleStatus[0]['objectState'] = ObjectState.Added; } else {
        this.isfreesaleStatus[0]['objectState'] = ObjectState.Modified;
      } }  else {
        this.isfreesaleStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.isfreesaleStatus[0]);
      if (
        this.smokingroomStatus[0]['isSelected'] !==
        this.roomTypeForm.controls['smokingroom'].value
      ) {
        this.smokingroomStatus[0]['isSelected'] = this.roomTypeForm.controls[
          'smokingroom'].value;
        if ( this.smokingroomStatus[0]['status'] === EntityState.New) {
          this.smokingroomStatus[0]['objectState'] = ObjectState.Added; } else {
        this.smokingroomStatus[0]['objectState'] = ObjectState.Modified;
      } }  else {
        this.smokingroomStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.smokingroomStatus[0]);
      if (
        this.roomDescriptionStatus[0]['isSelected'] !==
        this.roomTypeForm.controls['roomDescription'].value
      ) {
        this.roomDescriptionStatus[0]['isSelected'] = this.roomTypeForm.controls[
          'roomDescription'].value;
        if ( this.roomDescriptionStatus[0]['status'] === EntityState.New) {
          this.roomDescriptionStatus[0]['objectState'] = ObjectState.Added; } else {
        this.roomDescriptionStatus[0]['objectState'] = ObjectState.Modified;
      } }  else {
        this.roomDescriptionStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.roomDescriptionStatus[0]);
      if (
      this.bedoptionsStatus[0]['isSelected'] !== this.roomTypeForm.controls[
        'bedoptions'].value) {
          this.bedoptionsStatus[0]['isSelected'] = this.roomTypeForm.controls[
            'bedoptions'].value;
            if ( this.bedoptionsStatus[0]['status'] === EntityState.New) {
              this.bedoptionsStatus[0]['objectState'] = ObjectState.Added; } else {
            this.bedoptionsStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.bedoptionsStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayRoomTypeFields.push(this.bedoptionsStatus[0]);
    }
    this.templateRoomtypeinfoviewmodel.objectState = ObjectState.Unchanged;
    this.templateRoomtypeinfoviewmodel.roomFields = arrayRoomTypeFields;
  }

  saveRoomTypeInfo() {
    // console.log('Room Type Saving -');
    if (this.roomTypeForm.valid) {
        this.createSavingData(this.operation.toLowerCase().trim());
        // console.log('Save room data -' + JSON.stringify(this.templateRoomtypeinfoviewmodel));
      this.templateRoomTypeDataService.saveTemplateRoomTypeFields (this.templateRoomtypeinfoviewmodel).subscribe(
        (response) => {
          this.router.navigate(['/templatemgmt/templates']);
          this.snackBar.open('Rate Type Template Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
        window.scrollTo(0, 0);
        }
      );
    }
  }

  private saveandContinue() {
    if (this.roomTypeForm.valid) {
      this.createSavingData(this.operation.toLowerCase().trim());
    this.templateRoomTypeDataService.saveTemplateRoomTypeFields (this.templateRoomtypeinfoviewmodel).subscribe(
      (response) => {
        this.router.navigate(['/templatemgmt/template', this.templateId, edit, 'amenities']);
        this.snackBar.open('Rate Type Template Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
        window.scrollTo(0, 0);
      }
    );
  }
  }

  backToList() {
    this.router.navigate(['/templatemgmt/templates']);
 }

}
