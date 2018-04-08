import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CONSTANTS } from '../../../../common/constants';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { MessageListViewModel } from '../../../viewmodel/messageviewmodel/messagelistviewmodel';
import { MessageDataService } from '../../../common/extranet-shared/services/message-data.service';
import { DialogsService } from '../../../common/extranet-shared/dialogs/dialogs.service';

@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent implements OnInit {

  operation: string;
  isRead: boolean;
  dataSource: MatTableDataSource<MessageListViewModel>;
  displayedColumns = [];
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  isDeleted: boolean;
  hotelId: string;
  messageList: MessageListViewModel[];
  result: any;
  actions: string;
  noDataAvailable: boolean;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private router: Router,
    private activatedRoute: ActivatedRoute,
    private messageDataService: MessageDataService,
    private dialogsService: DialogsService,
    private changeDetectorRefs: ChangeDetectorRef) { }

  ngOnInit() {

    this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.getMessageList(this.hotelId);
    
    if (this.operation.toLowerCase().trim() === this.read) {
      this.isRead = true;
    }

    if (this.isRead) {
      this.displayedColumns = ['messageTitle', 'messageTypeName', 'messageDescription', 'lastModifiedBy', 'startDate', 'endDate', 'isActive'];
    } else {
      this.displayedColumns = ['messageTitle', 'messageTypeName', 'messageDescription', 'lastModifiedBy', 'startDate', 'endDate', 'isActive',
        'actions'];
    }
  }

  getMessageList(hotelId) {
    this.messageDataService.getMessages(hotelId).subscribe((messageList) => {
      this.messageList = messageList;
      console.log(this.messageList);
      this.dataSource = new MatTableDataSource<MessageListViewModel>(this.messageList);
      this.changeDetectorRefs.detectChanges();
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      if(messageList.length === 0){
        this.noDataAvailable = true;
      }
    }
    );
  }

  private createMessage() {
    this.router.navigate(['../message', 0, this.create], { relativeTo: this.activatedRoute });
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }

  deleteMessage(messageId) {
    this.messageDataService.deleteMessage(messageId).subscribe((isDeleted) => {
      this.isDeleted = isDeleted;
      this.getMessageList(this.hotelId);
    });
  }

  GoMsgUpdate(value) {
    const val = value.split('-');
    const msgId = val[0];
    this.operation = val[1];
    this.router.navigate(['../message', msgId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
  }

  GoMsgDelete(value) {
    const val = value.split('-');
    const msgId = val[0];
    this.dialogsService
      .confirm('Confirm', 'Are you sure you want to delete this message?').subscribe(res => {
        this.result = res;
        if (this.result) {
          this.deleteMessage(msgId);
        } else {
          this.actions = null;
        }
      });
  }
}
