import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CONSTANTS } from '../../../../common/constants';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';
import { MgUsersListViewModel } from '../../../viewmodel/usersviewmodel/mguserlistviewmodel';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { DateAdapter, NativeDateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { DatePipe } from '@angular/common';
import { UserDetailsViewModel } from '../../../../common/viewmodels/userdetailsviewmodel';
import { NgForOf } from '@angular/common/src/directives';
import { DialogsService } from '../../../common/backoffice-shared/dialogs/dialogs.service';
import {Sort} from '@angular/material';

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
  selector: 'app-mg-user-list',
  templateUrl: './mg-user-list.component.html',
  styleUrls: ['./mg-user-list.component.css'],
  providers: [DatePipe, DialogsService,
    { provide: DateAdapter, useClass: DatePickerDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: DATE_FORMATS },
  ]
})

export class MgUserListComponent implements OnInit {
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  // isRead: boolean;
  dataSource: MatTableDataSource<MgUsersListViewModel>;
  displayedColumns = [/*'firstName'*/'userName', 'employeeId', 'email', 'departments',
  'userApplicationRole', 'activationDate', 'isActive', 'actions'];
  isDeleted: boolean;
  userList: MgUsersListViewModel[];
  result: any;
  actions: string;
  filteredData: MatTableDataSource<MgUsersListViewModel>;
  searchUsers: FormGroup;
  isSearch: boolean;
  isAppRoleData: boolean;
  isDepartmentData: boolean;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @Input()
  _dateValue;

  constructor(private router: Router,
    private activatedRoute: ActivatedRoute,
    private userDataService: UserDataService,
    private dialogsService: DialogsService,
    public datepipe: DatePipe) { }

  ngOnInit() {
    this.getMgUserList();
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

    this.filteredData = new MatTableDataSource<MgUsersListViewModel>(this.userList.filter(user => {
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

  filterUser(user: MgUsersListViewModel, filterValue: string) {
    this.isAppRoleData = false;
    this.isDepartmentData = false;
    for (let i = 0; i < user.userApplicationRole.length; i++) {
      if ((user.userApplicationRole[i].applicationName.toLowerCase().includes(filterValue))
       || (user.userApplicationRole[i].roleName.toLowerCase().includes(filterValue))) {
        this.isAppRoleData = true;
        break;
      }
    }
    for (let j = 0; j < user.departments.length; j++) {
      if (user.departments[j].name.toLowerCase().includes(filterValue)) {
        this.isDepartmentData = true;
      }
    }
    return user.lastName.toLowerCase().includes(filterValue) ||
    user.email.toLowerCase().includes(filterValue) ||
    // user.firstName.toLowerCase().includes(filterValue) ||
    user.userName.toString().includes(filterValue) ||
    user.employeeId.toString().includes(filterValue) ||
    this.isAppRoleData || this.isDepartmentData ;
  }

  checkIsInputCleared() {
    if (this.searchUsers.get('searchText').value.length === 1) {
      this.filteredData = new MatTableDataSource<MgUsersListViewModel>(this.userList);
    }
  }

  sortData(sort: Sort) {
    const data = this.userList.slice();
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
            // case 'name': return compare(a.firstName, b.firstName, isAsc);
            case 'name': return compare(a.userName, b.userName, isAsc);
            case 'email': return compare(a.email, b.email, isAsc);
            case 'employeeId': return compare(+a.employeeId, +b.employeeId, isAsc);
            case 'isActive': return compare(a.isActive, b.isActive, isAsc);
            case 'departments': return compare((a.departments.length === 0) ? '' :
            a.departments[0].name, (b.departments.length === 0) ? '' :
            b.departments[0].name, isAsc);
            case 'userApplicationRole':
            return compare((a.userApplicationRole.length === 0) ? '' :
            a.userApplicationRole[0].applicationName, (b.userApplicationRole.length === 0) ? '' :
            b.userApplicationRole[0].applicationName, isAsc);
            case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
            default: return 0;
          }
        });
        this.filteredData.paginator = this.paginator;
      }
      this.dataSource.data = data.sort((a, b) => {
        const isAsc = sort.direction === 'asc';
        switch (sort.active) {
          // case 'name': return compare(a.firstName, b.firstName, isAsc);
          case 'name': return compare(a.userName, b.userName, isAsc);
          case 'email': return compare(a.email, b.email, isAsc);
          case 'employeeId': return compare(+a.employeeId, +b.employeeId, isAsc);
          case 'isActive': return compare(a.isActive, b.isActive, isAsc);
          case 'departments': return compare((a.departments.length === 0) ? '' :
          a.departments[0].name, (b.departments.length === 0) ? '' :
          b.departments[0].name, isAsc);
          case 'userApplicationRole':
          return compare((a.userApplicationRole.length === 0) ? '' :
          a.userApplicationRole[0].applicationName, (b.userApplicationRole.length === 0) ? '' :
          b.userApplicationRole[0].applicationName, isAsc);
          case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
          default: return 0;
        }
      });
      this.dataSource.paginator = this.paginator;
    }
  }

  getMgUserList() {
    this.userDataService.getMgUsers().subscribe((mgUsersList) => {
      this.userList = mgUsersList;
      this.dataSource = new MatTableDataSource<MgUsersListViewModel>(this.userList);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

   createMgUser() {
    this.router.navigate(['../mguser', 0, this.create], { relativeTo: this.activatedRoute });
  }

  deleteUser(userId) {
    this.userDataService.deleteMGUser(userId).subscribe((isDeleted) => {
      this.isDeleted = isDeleted;
    });
  }

  GoUserUpdate(value) {
    const val = value.split(':');
    const userId = val[0];
    this.operation = val[1];
    this.router.navigate(['../mguser', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
  }

  GoUserDelete(value) {
    const val = value.split(':');
    const userId = val[0];
    this.dialogsService
      .confirm('Confirm', 'Are you sure you want to delete this user?').subscribe(res => {
        this.result = res;
        if (this.result) {
          // this.deleteUser(userId);
          this.getMgUserList();
        } else {
          this.actions = null;
        }
      });
  }
}

function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}

