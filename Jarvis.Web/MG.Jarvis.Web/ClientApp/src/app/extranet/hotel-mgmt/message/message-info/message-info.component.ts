import { Component, OnInit } from '@angular/core';
import { CONSTANTS } from '../../../../common/constants';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { MessageInfoViewModel } from '../../../viewmodel/messageviewmodel/messageinfoviewmodel';
import { MessageDataService } from '../../../common/extranet-shared/services/message-data.service';
import { MessageTypeViewModel } from '../../../viewmodel/messageviewmodel/messagetypeviewmodel';
import { DateAdapter, NativeDateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';
import { ObjectState } from '../../../../common/enums';

const DATE_FORMATS = {
  parse: {
    dateInput: { month: 'short', year: 'numeric', day: 'numeric' }
  },
  display: {
    dateInput: 'input',
    monthYearLabel: { year: 'numeric', month: 'short' },
    dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric' },
    monthYearA11yLabel: { year: 'numeric', month: 'long' },
  }
};

export class DatePickerDateAdapter extends NativeDateAdapter {
  format(date: Date, displayFormat: Object): string {
    date.setMinutes((date.getTimezoneOffset() * -1));
    if (displayFormat === 'input') {
      const day = date.getDate();
      const month = date.toLocaleString('en-us', { month: 'long' });
      const year = date.getFullYear();
      return this._to2digit(day) + '-' + month.substring(0, 3) + '-' + year % 100;
    } else {
      return date.toDateString();
    }
  }

  private _to2digit(n: number) {
    return ('00' + n).slice(-2);
  }
}

@Component({
  selector: 'app-message-info',
  templateUrl: './message-info.component.html',
  styleUrls: ['./message-info.component.css'],
  providers: [
    { provide: DateAdapter, useClass: DatePickerDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: DATE_FORMATS },
  ],
})

export class MessageInfoComponent implements OnInit {
  operation: string;
  msgOperation: string;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  hotelId: number;
  msgId: string;
  messageInfo: MessageInfoViewModel = <MessageInfoViewModel>{};
  messageForm: FormGroup;
  messageTypes: MessageTypeViewModel;
  selectedStartDate: string;
  public todaysDate = new Date();
  minDate: string;

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private messageDataService: MessageDataService,
    public snackBar: MatSnackBar) { }

  ngOnInit() {
    this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.msgOperation = this.activatedRoute.snapshot.params['operation'];
    this.msgId = this.activatedRoute.snapshot.params['id'];
    this.messageForm = new FormGroup({
      isActive: new FormControl(true),
      messageTitle: new FormControl('', Validators.required),
      messageTypeId: new FormControl('', Validators.required),
      messageDescription: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required)
    });

    if (this.msgOperation.toLowerCase().trim() === this.create) {
      this.messageInfo.objectState = ObjectState.Added;
    }

    if (this.msgOperation.toLowerCase().trim() === this.edit) {
      this.messageForm.get('endDate').markAsTouched();
      this.getMessageDetails(this.msgId);
    }

    this.getMessageTypes();
    this.messageInfo.hotelId = this.hotelId;
  }

  cancelMessage() {
    this.router.navigate(['/hotelmgmt/hotel', this.hotelId, this.operation, 'messagelist']);
  }

  getMessageTypes() {
    this.messageDataService.getMessageTypes().subscribe((messageTypes) => {
      this.messageTypes = messageTypes.result;
    });
  }

  saveMessage() {
    const message = Object.assign({}, this.messageInfo, this.messageForm.value);
    this.messageDataService.addMessage(message as MessageInfoViewModel)
      .subscribe(data => {
        this.snackBar.open('Message Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
        this.router.navigate(['/hotelmgmt/hotel', this.hotelId, this.operation, 'messagelist']);
      });
  }

  flagMessageAsEdited() {
    if (this.messageInfo.objectState !== ObjectState.Added) {
      this.messageInfo.objectState = ObjectState.Modified;
    }
  }

  getMessageDetails(messageId) {
    this.messageDataService.getMessageDetails(+messageId).subscribe(
      (messageData) => {
        this.messageDataService.messageDetails = messageData;
        if (this.msgOperation.toLowerCase().trim() === this.edit) {
          this.messageForm.get('isActive').setValue(this.messageDataService.messageDetails.isActive);
          this.messageForm.get('messageTitle').setValue(this.messageDataService.messageDetails.messageTitle);
          this.messageForm.get('messageTypeId').setValue(this.messageDataService.messageDetails.messageTypeId);
          this.messageForm.get('messageDescription').setValue(this.messageDataService.messageDetails.messageDescription);
          this.messageForm.get('startDate').setValue(this.messageDataService.messageDetails.startDate);
          this.messageForm.get('endDate').setValue(this.messageDataService.messageDetails.endDate);
          this.messageInfo.objectState = ObjectState.Unchanged;
          this.messageInfo.messageId = messageId;
          this.selectedStartDate = this.messageDataService.messageDetails.startDate;
          if (this.messageForm.get('startDate').value < this.todaysDate.toISOString()) {
            this.minDate = this.messageForm.get('startDate').value;
          } else {
            this.minDate = this.todaysDate.toISOString();
          }
        }
      });
  }
}
