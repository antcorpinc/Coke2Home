
import { UserDataService } from './../../../common/backoffice-shared/services/user-data.service';
import { DatePipe } from '@angular/common';
import { HotelUserListViewModel } from './../../../viewmodel/usersviewmodel/hoteluserlistviewmodel';
import { DateAdapter, NativeDateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { CONSTANTS } from '../../../../common/constants';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource, MatPaginator, MatSort, Sort } from '@angular/material';
import { FormGroup, FormControl } from '@angular/forms';
import { DialogsService } from '../../../common/backoffice-shared/dialogs/dialogs.service';


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
  selector: 'app-hotel-user-list',
  templateUrl: './hotel-user-list.component.html',
  styleUrls: ['./hotel-user-list.component.css'],
  providers: [DatePipe, DialogsService,
    { provide: DateAdapter, useClass: DatePickerDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: DATE_FORMATS },
  ]
})
export class HotelUserListComponent implements OnInit {
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  dataSource: MatTableDataSource<HotelUserListViewModel>;
  displayedColumns = ['userName', 'hotels', 'designation', 'email', 'userApplicationRole', 'activationDate', 'isActive', 'actions'];
  hotelUserList: HotelUserListViewModel[];
  actions: string;
  filteredData: MatTableDataSource<HotelUserListViewModel>;
  searchHotelUsers: FormGroup;
  isSearch: boolean;
  selectedRow: number;
  isAppRoleData: boolean;
  isHotelData: boolean;
  isDeleted: boolean;
  hideme: any;
  result: any;


  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @Input()
  _dateValue;

  hotel= {
    ' kind ' : ' title ',
    'label': 'ADD_TITLE' };

  constructor(private router: Router,
    private activatedRoute: ActivatedRoute,
    private userDataService: UserDataService,
    private dialogsService: DialogsService,
    public datepipe: DatePipe) { }

  ngOnInit() {
    this.getHotelUserList();
    this.hideme = {};
    this.isSearch = false;
    this.searchHotelUsers = new FormGroup({
      startDate: new FormControl(),
      endDate: new FormControl(),
      searchText: new FormControl()
    });
  }




  getHotelUserList() {
    this.userDataService.getHotelUsers().subscribe((mgUsersList) => {
      this.hotelUserList = mgUsersList;
      this.dataSource = new MatTableDataSource<HotelUserListViewModel>(this.hotelUserList);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  createHotelUser() {
    this.router.navigate(['../hotelusers'], { relativeTo: this.activatedRoute });
  }

  findHotelUser( filterValue: string, filterFrom: string, filterTo: string ) {
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

    this.filteredData = new MatTableDataSource<HotelUserListViewModel>(this.hotelUserList.filter(user => {
      const searchActivationDate = this.datepipe.transform(user.activationDate, 'dd-MMM-yy hh:mm a');
      const activationDate = this.datepipe.transform(user.activationDate, 'yyyy-MM-dd');
      if (filterValue !== null && (filterFrom === null && filterTo === null)) {
        return this.filterHotelUser(user, filterValue) ||
        searchActivationDate.toLowerCase().includes(filterValue);
      } else if (filterFrom !== null && (filterTo === null && filterValue === null)) {
        return activationDate >= filterFrom;
      } else if (filterTo !== null && (filterFrom === null && filterValue === null)) {
        return activationDate <= filterTo;
      } else if (filterValue === null && (filterFrom !== null && filterTo !== null)) {
        return filterFrom <= activationDate && activationDate <= filterTo;
      } else if (filterFrom === null && (filterValue !== null && filterTo !== null)) {
        return (this.filterHotelUser(user, filterValue) ||
        searchActivationDate.toLowerCase().includes(filterValue)) && activationDate <= filterTo;
      } else if (filterTo === null && (filterFrom !== null && filterValue !== null)) {
        return (this.filterHotelUser(user, filterValue) ||
        searchActivationDate.toLowerCase().includes(filterValue)) &&
        activationDate >= filterFrom;
      } else if (filterFrom !== null && filterTo !== null && filterValue !== null) {
        return (this.filterHotelUser(user, filterValue) ||
        searchActivationDate.toLowerCase().includes(filterValue)) &&
          (filterFrom <= activationDate && activationDate <= filterTo);
      }
    }));
    this.filteredData.paginator = this.paginator;
    this.filteredData.sort = this.sort;

  }
  filterHotelUser( user: HotelUserListViewModel, filterValue: string) {
    this.isAppRoleData = false;
    for (let i = 0; i < user.userApplicationRole.length; i++) {
      if (user.userApplicationRole[i].roleName.toLowerCase().includes(filterValue)) {
        this.isAppRoleData = true;
        break;
      }
    }
    for (let j = 0; j < user.hotels.length; j++) {
      if (user.hotels[j].name.toLowerCase().includes(filterValue)) {
        this.isHotelData = true;
      }
    }

    return user.userName.toLowerCase().includes(filterValue) ||
    user.email.toLowerCase().includes(filterValue) ||
    // user.designation.toLowerCase().includes(filterValue)
    this.isAppRoleData || this.isHotelData ;

  }
  checkIsInputCleared() {
    if (this.searchHotelUsers.get('searchText').value.length === 1) {
      this.filteredData = new MatTableDataSource<HotelUserListViewModel>(this.hotelUserList);
    }
  }

  sortData(sort: Sort) {
    const data = this.hotelUserList.slice();
    if (!sort.active || sort.direction === '') {
      this.dataSource.data =  data.sort((a, b) => {
        const isAsc = sort.direction === 'desc';
           return compare(a.activationDate, b.activationDate, isAsc);
      });
      return;
    } else {
      if (this.isSearch) {
        this.filteredData.data = this.filteredData.data.sort((a, b) => {
          const isAsc = sort.direction === 'asc';
          switch (sort.active) {
            // case 'name': return compare(a.firstName, b.firstName, isAsc);
            case 'name': return compare(a.userName, b.userName, isAsc);
            case 'email': return compare(a.email, b.email, isAsc);
            case 'hotels':
            return compare((a.hotels.length === 0) ? '' :
            a.hotels[0].name, (b.hotels.length === 0) ? '' :
            b.hotels[0].name, isAsc);
            case 'isActive': return compare(a.isActive, b.isActive, isAsc);
            case 'userApplicationRole':
            return compare((a.userApplicationRole.length === 0) ? '' :
            a.userApplicationRole[0].roleName, (b.userApplicationRole.length === 0) ? '' :
            b.userApplicationRole[0].roleName, isAsc);
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
            case 'hotels':
            return compare((a.hotels.length === 0) ? '' :
            a.hotels[0].name, (b.hotels.length === 0) ? '' :
            b.hotels[0].name, isAsc);
            case 'isActive': return compare(a.isActive, b.isActive, isAsc);
            case 'userApplicationRole':
            return compare((a.userApplicationRole.length === 0) ? '' :
            a.userApplicationRole[0].roleName, (b.userApplicationRole.length === 0) ? '' :
            b.userApplicationRole[0].roleName, isAsc);
            case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
            default: return 0;
          }
        });
        this.dataSource.paginator = this.paginator;
      }
    }


  GoUserUpdate(value) {
    const val = value.split(':');
    const userId = val[0];
    this.operation = val[1];
    const userType = val[2];
    if (userType === '1') {
      this.router.navigate(['../hoteluserinfo', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
    } else if (userType === '2') {
      this.router.navigate(['../individual', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
    }

  }

  deleteHotelUser(userId) {
    this.userDataService.deleteHotelUser(userId).subscribe((isDeleted) => {
      this.isDeleted = isDeleted;
    });
  }

  GoUserDelete(value) {
    const val = value.split(':');
    const userId = val[0];
    this.dialogsService
      .confirm('Confirm', 'Are you sure you want to delete this user?').subscribe(res => {
        this.result = res;
        if (this.result) {
          // this.deleteHotelUser(userId);
          this.getHotelUserList();
        } else {
          this.actions = null;
        }
      });
   }
}
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}

