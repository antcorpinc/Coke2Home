import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CONSTANTS } from '../../../../common/constants';
import { NativeDateAdapter, DateAdapter, MAT_DATE_FORMATS, MatTableDataSource, MatPaginator, MatSort, Sort } from '@angular/material';
import { DatePipe } from '@angular/common';
import { DialogsService } from '../../../common/backoffice-shared/dialogs/dialogs.service';
import { Agentuserlistviewmodel } from '../../../viewmodel/usersviewmodel/agentuserlistviewmodel';
import { FormGroup, FormControl } from '@angular/forms';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';

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
  selector: 'app-agent-user-list',
  templateUrl: './agent-user-list.component.html',
  styleUrls: ['./agent-user-list.component.css'],
  providers: [DatePipe, DialogsService,
    { provide: DateAdapter, useClass: DatePickerDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: DATE_FORMATS },
  ]
})
export class AgentUserListComponent implements OnInit {
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  isDeleted: boolean;
  dataSource: MatTableDataSource<Agentuserlistviewmodel>;
  displayedColumns = ['userName', 'agencyName', 'branchName', 'designation', 'email', 'userApplicationRole' ,
   'activationDate', 'isActive', 'actions'];
  searchUsers: FormGroup;
  filteredData: MatTableDataSource<Agentuserlistviewmodel>;
  isSearch: boolean;
  actions: string;
  result: any;
  isAppRoleData: boolean;
  isDesignationData: boolean;
  agentUserList: Agentuserlistviewmodel[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @Input()
  _dateValue;

  constructor(  private agentUserDataService: UserDataService,
    private dialogsService: DialogsService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    public datepipe: DatePipe) { }

  ngOnInit() {
    this.getAgentUserList();
    this.isSearch = false;
    this.searchUsers = new FormGroup({
      startDate: new FormControl(),
      endDate: new FormControl(),
      searchText: new FormControl()
    });
  }
  findUsers(filterValue: string, filterFrom: string, filterTo: string) {
    if (filterFrom !== null || filterTo !== null || (filterValue !== null && filterValue.length >= 3)) {
      this.isSearch = true;
    }
    if (filterFrom !== null) {
      filterFrom = this.datepipe.transform(filterFrom, 'yyyy-MM-dd');
    }
    if (filterTo !== null) {
      filterTo = this.datepipe.transform(filterTo, 'yyyy-MM-dd');
    }
    if (filterValue !== null) {
      filterValue = filterValue.trim();
      filterValue = filterValue.toLowerCase();
    }

    this.filteredData = new MatTableDataSource<Agentuserlistviewmodel>(this.agentUserList.filter(user => {
      const searchActivationDate = this.datepipe.transform(user.activationDate, 'dd-MMM-yy hh:mm a');
      const activationDate = this.datepipe.transform(user.activationDate, 'yyyy-MM-dd');
      if (filterValue !== null && (filterFrom === null && filterTo === null)) {
        return this.filterUser(user, filterValue) ||
        searchActivationDate.toLowerCase().includes(filterValue);
      } else if (filterFrom !== null && (filterTo === null && filterValue === null)) {
        return activationDate >= filterFrom;
      } else if (filterTo !== null && (filterFrom === null && filterValue === null)) {
        return activationDate <= filterTo;
      } else if (filterValue === null && (filterFrom !== null && filterTo !== null)) {
        return filterFrom <= activationDate && activationDate <= filterTo;
      } else if (filterFrom === null && (filterValue !== null && filterTo !== null)) {
        return (this.filterUser(user, filterValue) ||
        searchActivationDate.toLowerCase().includes(filterValue)) && activationDate <= filterTo;
      } else if (filterTo === null && (filterFrom !== null && filterValue !== null)) {
        return (this.filterUser(user, filterValue) ||
        searchActivationDate.toLowerCase().includes(filterValue)) &&
        activationDate >= filterFrom;
      } else if (filterFrom !== null && filterTo !== null && filterValue !== null) {
        return (this.filterUser(user, filterValue) ||
        searchActivationDate.toLowerCase().includes(filterValue)) &&
          (filterFrom <= activationDate && activationDate <= filterTo);
      }
    }));
    this.filteredData.paginator = this.paginator;
    this.filteredData.sort = this.sort;
  }
  filterUser(agentUser: Agentuserlistviewmodel, filterValue: string) {
    this.isAppRoleData = false;
    this.isDesignationData = false;
    for (let i = 0; i < agentUser.userApplicationRole.length; i++) {
      if (agentUser.userApplicationRole[i].roleName.toLowerCase().includes(filterValue)) {
        this.isAppRoleData = true;
        break;
      }
    }
    return agentUser.userName.toLowerCase().includes(filterValue) ||
    agentUser.email.toLowerCase().includes(filterValue) ||
    // agentUser.designation.toLowerCase().includes(filterValue) ||
    // agentUser.branchName.toLowerCase().includes(filterValue) ||
    // agentUser.agencyName.toLowerCase().includes(filterValue) ||
    // agentUser.agencyCode.toLowerCase().includes(filterValue) ||
    this.isAppRoleData || this.isDesignationData ;
  }
  checkIsInputCleared() {
    if (this.searchUsers.get('searchText').value.length === 1) {
      this.filteredData = new MatTableDataSource<Agentuserlistviewmodel>(this.agentUserList);
    }
  }
  sortData(sort: Sort) {
    const data = this.agentUserList.slice();
    if (!sort.active || sort.direction === '') {
      this.dataSource.data =  data.sort((a, b) => {
        const isAsc = sort.direction === 'desc';
           return compare(a.activationDate, b.activationDate, isAsc);
      });
      return;
    }else {
      if (this.isSearch) {
        this.filteredData.data = this.filteredData.data.sort((a, b) => {
          const isAsc = sort.direction === 'asc';
          switch (sort.active) {
            case 'userName': return compare(a.userName.toLowerCase(), b.userName.toLowerCase(), isAsc);
            case 'email': return compare(a.email, b.email, isAsc);
            case 'designation': return compare(+a.designation, +b.designation, isAsc);
            case 'branchName': return compare(a.branchName, b.branchName, isAsc);
            case 'agencyName': return compare(a.agencyName, b.agencyName, isAsc);
            case 'userApplicationRole':
            return compare((a.userApplicationRole.length === 0) ? '' :
            a.userApplicationRole[0].roleName, (b.userApplicationRole.length === 0) ? '' :
            b.userApplicationRole[0].roleName, isAsc);
            case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
            case 'isActive': return compare(a.isActive, b.isActive, isAsc);
            default: return 0;
          }
        });
        this.filteredData.paginator = this.paginator;
      }
      this.dataSource.data = data.sort((a, b) => {
        const isAsc = sort.direction === 'asc';
        switch (sort.active) {
          case 'userName': return compare(a.userName.toLowerCase(), b.userName.toLowerCase(), isAsc);
            case 'email': return compare(a.email, b.email, isAsc);
            case 'designation': return compare(+a.designation, +b.designation, isAsc);
            case 'branchName': return compare(a.branchName, b.branchName, isAsc);
            case 'agencyName': return compare(a.agencyName, b.agencyName, isAsc);
            case 'agencyCode': return compare(a.agencyCode, b.agencyCode, isAsc);
            case 'userApplicationRole':
            return compare((a.userApplicationRole.length === 0) ? '' :
            a.userApplicationRole[0].roleName, (b.userApplicationRole.length === 0) ? '' :
            b.userApplicationRole[0].roleName, isAsc);
            case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
            case 'isActive': return compare(a.isActive, b.isActive, isAsc);
            default: return 0;
        }
      });
      this.dataSource.paginator = this.paginator;
    }
  }
  createAgent() {
    this.router.navigate(['../agentusers', 0, this.create], { relativeTo: this.activatedRoute });
  }

  getAgentUserList() {
    this.agentUserDataService.getAgentUsers().subscribe((agentUsersList) => {
      this.agentUserList = agentUsersList;
      this.dataSource = new MatTableDataSource<Agentuserlistviewmodel>(this.agentUserList);
      this.dataSource.paginator = this.paginator;
      // this.dataSource.sort = this.sort;
    });
 }
 deleteAgentUser(agentUserId) {
  this.agentUserDataService.deleteAgentUser(agentUserId).subscribe((isDeleted) => {
    this.isDeleted = isDeleted;
  });
}
  GoUserDelete(value) {
    const val = value.split(':');
    const agentUserId = val[0];
    this.dialogsService
      .confirm('Confirm', 'Are you sure you want to delete this user?').subscribe(res => {
        this.result = res;
        if (this.result) {
          // this.deleteAgentUser(agentUserId);
          this.getAgentUserList();
        } else {
          this.actions = null;
        }
      });
  }
  GoUserUpdate(value) {
    const val = value.split(':');
    const agentUserId = val[0];
    this.operation = val[1];
    this.router.navigate(['../agentusers', agentUserId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
  }

}
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
