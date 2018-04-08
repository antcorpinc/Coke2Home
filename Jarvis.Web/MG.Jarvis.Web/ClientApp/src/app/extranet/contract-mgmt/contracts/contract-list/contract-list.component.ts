import { Component, OnInit, ViewChild, Input, ChangeDetectorRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { CONSTANTS } from '../../../../common/constants';
import { TemplatesDataService } from '../../../common/extranet-shared/services/templates/templates-data.service';
import { Templateslistviewmodel } from '../../../viewmodel/templates/templates-details/templateslistviewmodel';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { UserProfileService } from '../../../../common/shared/services/user-profile.service';
import { DateAdapter, NativeDateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { DatePipe } from '@angular/common';
import { DialogsService } from '../../../common/extranet-shared/dialogs/dialogs.service';
import { ContractDataService } from './../../../common/extranet-shared/services/contracts/contract-data.service';
import { ContractsListViewModel } from './../../../viewmodel/contracts/contractslistviewmodel';

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
  selector: 'app-contract-list',
  templateUrl: './contract-list.component.html',
  styleUrls: ['./contract-list.component.css'],
  providers: [
    { provide: DateAdapter, useClass: DatePickerDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: DATE_FORMATS },
  ]
})

export class ContractListComponent implements OnInit {

  privileges: string[];
  deleteView = false;
  createView = false;
  readView = false;
  operation: string;
  isRead: boolean;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  searchContracts: FormGroup;
  hotelId: string;
  contractsList: ContractsListViewModel[];
  filteredData: ContractsListViewModel[];
  isSearch: boolean;
  minChar: boolean;
  noDataAvailable: boolean;
  actions: string;
  isDesc = false;
  column: string;
  direction: number;
  pagesize = 10;
  currentpage = 1;

  @Input()
  _dateValue; // notice the '_'
  result: any;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private contractsDataService: ContractDataService,
    private userProfileService: UserProfileService,
    public datepipe: DatePipe,
    private dialogsService: DialogsService,
    private changeDetectorRefs: ChangeDetectorRef
  ) { }

  ngOnInit() {
    this.isSearch = false;
    this.isDesc = false;
    this.searchContracts = new FormGroup({
      fromDate: new FormControl(),
      toDate: new FormControl(),
      startOrEndDate: new FormControl('start'),
      searchText: new FormControl()
    });
    this.getPrivileges();
    this.contractsList = this.activatedRoute.snapshot.data['contractListData'];
    for (const contract of this.contractsList) {
      contract.contactPerson = contract.contacts[0].contactPerson.toLowerCase() + '\n' + contract.designation + '\n' +
        contract.contacts.contactPerson + '\n' + contract.contacts.contactPerson;
    }
    for (const contract of this.contractsList) {
      contract.isExpanded = false;
    }
    this.changeDetectorRefs.detectChanges();
    if (this.contractsList.length === 0) {
      this.noDataAvailable = true;
    }
  }

  private createContract() {
    this.dialogsService.openContractTemplateModal().subscribe(res => {
      this.result = res;
    });
  }

  getPrivileges() {
    this.privileges = this.userProfileService.GetUserPermissionsForFeature(
      CONSTANTS.application.extranet,
      CONSTANTS.featuretypeid.Templates
    );
    for (const privilege of this.privileges) {
      if (privilege === 'VW') {
        this.readView = true;
      } else if (privilege === 'CR') {
        this.createView = true;
      } else if (privilege === 'DE') {
        this.deleteView = true;
      }
    }
  }

  findContracts(filterValue: string, filterFrom: string, filterTo: string, startOrEndDate: string) {
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

    function getFilteredPromoContracts(contract) {
      let isTrue;
      isTrue = false;
      const promoData = contract.promoContracts.filter(promoContract => {
        if (promoContract.name.toLowerCase().includes(filterValue)) {
          isTrue = true;
          return promoContract;
        }
      });
      if (isTrue) {
        contract.isExpanded = true;
        contract.promoContracts = promoData;
        return contract;
      }
    }

    if (this.isSearch) {
      this.filteredData = this.contractsList.filter(contract => {
        const startDate = this.datepipe.transform(contract.startDate, 'yyyy-MM-dd');
        const endDate = this.datepipe.transform(contract.endDate, 'yyyy-MM-dd');
        if (startOrEndDate === 'start') {
          if (filterValue !== null && (filterFrom === null && filterTo === null)) {
            if (contract.hotelName.toLowerCase().includes(filterValue) ||
              contract.name.toLowerCase().includes(filterValue) ||
              contract.designation.toLowerCase().includes(filterValue) ||
              (contract.contacts[0].contactPerson.toLowerCase().includes(filterValue) ||
                contract.contacts[0].emailAddress.toLowerCase().includes(filterValue) ||
                contract.contacts[0].contactNumber.toLowerCase().includes(filterValue)) ||
              contract.location.toLowerCase().includes(filterValue) ||
              getFilteredPromoContracts(contract)) {
              contract.isExpanded = true;
              return contract;
            }
          } else if (filterFrom !== null && (filterTo === null && filterValue === null)) {
            return startDate >= filterFrom;
          } else if (filterTo !== null && (filterFrom === null && filterValue === null)) {
            return startDate <= filterTo;
          } else if (filterValue === null && (filterFrom !== null && filterTo !== null)) {
            return filterFrom <= startDate && startDate <= filterTo;
          } else if (filterFrom === null && (filterValue !== null && filterTo !== null)) {
            if ((contract.hotelName.toLowerCase().includes(filterValue) ||
              contract.name.toLowerCase().includes(filterValue) ||
              contract.designation.toLowerCase().includes(filterValue) ||
              (contract.contacts[0].contactPerson.toLowerCase().includes(filterValue) ||
                contract.contacts[0].emailAddress.toLowerCase().includes(filterValue) ||
                contract.contacts[0].contactNumber.toLowerCase().includes(filterValue)) ||
              contract.location.toLowerCase().includes(filterValue) ||
              getFilteredPromoContracts(contract)) &&
              startDate <= filterTo) {
              contract.isExpanded = true;
              return contract;
            }
          } else if (filterTo === null && (filterFrom !== null && filterValue !== null)) {
            if ((contract.hotelName.toLowerCase().includes(filterValue) ||
              contract.name.toLowerCase().includes(filterValue) ||
              contract.designation.toLowerCase().includes(filterValue) ||
              (contract.contacts[0].contactPerson.toLowerCase().includes(filterValue) ||
                contract.contacts[0].emailAddress.toLowerCase().includes(filterValue) ||
                contract.contacts[0].contactNumber.toLowerCase().includes(filterValue)) ||
              contract.location.toLowerCase().includes(filterValue) ||
              getFilteredPromoContracts(contract)) &&
              startDate >= filterFrom) {
              contract.isExpanded = true;
              return contract;
            }
          } else if (filterFrom !== null && filterTo !== null && filterValue !== null) {
            if ((contract.hotelName.toLowerCase().includes(filterValue) ||
              contract.name.toLowerCase().includes(filterValue) ||
              contract.designation.toLowerCase().includes(filterValue) ||
              (contract.contacts[0].contactPerson.toLowerCase().includes(filterValue) ||
                contract.contacts[0].emailAddress.toLowerCase().includes(filterValue) ||
                contract.contacts[0].contactNumber.toLowerCase().includes(filterValue)) ||
              contract.location.toLowerCase().includes(filterValue) ||
              getFilteredPromoContracts(contract)) &&
              filterFrom <= startDate && startDate <= filterTo) {
              contract.isExpanded = true;
              return contract;
            }
          }
        } else {
          if (filterValue !== null && (filterFrom === null && filterTo === null)) {
            if (contract.hotelName.toLowerCase().includes(filterValue) ||
              contract.name.toLowerCase().includes(filterValue) ||
              contract.designation.toLowerCase().includes(filterValue) ||
              (contract.contacts[0].contactPerson.toLowerCase().includes(filterValue) ||
                contract.contacts[0].emailAddress.toLowerCase().includes(filterValue) ||
                contract.contacts[0].contactNumber.toLowerCase().includes(filterValue)) ||
              contract.location.toLowerCase().includes(filterValue) ||
              getFilteredPromoContracts(contract)) {
              contract.isExpanded = true;
              return contract;
            }
          } else if (filterFrom !== null && (filterTo === null && filterValue === null)) {
            return startDate >= filterFrom;
          } else if (filterTo !== null && (filterFrom === null && filterValue === null)) {
            return startDate <= filterTo;
          } else if (filterValue === null && (filterFrom !== null && filterTo !== null)) {
            return filterFrom <= startDate && startDate <= filterTo;
          } else if (filterFrom === null && (filterValue !== null && filterTo !== null)) {
            if ((contract.hotelName.toLowerCase().includes(filterValue) ||
              contract.name.toLowerCase().includes(filterValue) ||
              contract.designation.toLowerCase().includes(filterValue) ||
              (contract.contacts[0].contactPerson.toLowerCase().includes(filterValue) ||
                contract.contacts[0].emailAddress.toLowerCase().includes(filterValue) ||
                contract.contacts[0].contactNumber.toLowerCase().includes(filterValue)) ||
              contract.location.toLowerCase().includes(filterValue) ||
              getFilteredPromoContracts(contract)) &&
              startDate <= filterTo) {
              contract.isExpanded = true;
              return contract;
            }
          } else if (filterTo === null && (filterFrom !== null && filterValue !== null)) {
            if ((contract.hotelName.toLowerCase().includes(filterValue) ||
              contract.name.toLowerCase().includes(filterValue) ||
              contract.designation.toLowerCase().includes(filterValue) ||
              (contract.contacts[0].contactPerson.toLowerCase().includes(filterValue) ||
                contract.contacts[0].emailAddress.toLowerCase().includes(filterValue) ||
                contract.contacts[0].contactNumber.toLowerCase().includes(filterValue)) ||
              contract.location.toLowerCase().includes(filterValue) ||
              getFilteredPromoContracts(contract)) &&
              startDate >= filterFrom) {
              contract.isExpanded = true;
              return contract;
            }
          } else if (filterFrom !== null && filterTo !== null && filterValue !== null) {
            if ((contract.hotelName.toLowerCase().includes(filterValue) ||
              contract.name.toLowerCase().includes(filterValue) ||
              contract.designation.toLowerCase().includes(filterValue) ||
              (contract.contacts[0].contactPerson.toLowerCase().includes(filterValue) ||
                contract.contacts[0].emailAddress.toLowerCase().includes(filterValue) ||
                contract.contacts[0].contactNumber.toLowerCase().includes(filterValue)) ||
              contract.location.toLowerCase().includes(filterValue) ||
              getFilteredPromoContracts(contract)) &&
              filterFrom <= startDate && startDate <= filterTo) {
              contract.isExpanded = true;
              return contract;
            }
          }
        }
      });
      for (const contract of this.filteredData) {
        contract.contactPerson = contract.contacts[0].contactPerson.toLowerCase() + '\n' + contract.designation + '\n' +
          contract.contacts.contactPerson + '\n' + contract.contacts.contactPerson;
      }
    }
  }

  checkIsInputCleared(event) {
    if (this.searchContracts.get('searchText').value && this.searchContracts.get('searchText').value.length < 3) {
      this.getContractsList();
    }
  }

  sort(property) {
    this.isDesc = !this.isDesc;
    this.column = property;
    this.direction = this.isDesc ? 1 : -1;
  }

  onPageChange(event) {
    this.pagesize = event.value;
  }

  GoContractUpdate(e) {
    // const val = e.value.split('-');
    // const templateId = val[0];
    // this.operation = val[1];
    // if (this.operation.trim().toLowerCase() === this.edit) {
    //   this.router.navigate(
    //     ['../template', templateId, this.operation.trim().toLowerCase()],
    //     { relativeTo: this.activatedRoute }
    //   );
    // }
  }

  getContractsList() {
    this.contractsDataService.getContractsList().subscribe((contractsList) => {
      this.isSearch = false;
      this.contractsList = contractsList;
      this.filteredData = contractsList;
      for (const contract of this.filteredData) {
        contract.isExpanded = false;
        contract.contactPerson = contract.contacts[0].contactPerson.toLowerCase() + '\n' + contract.designation + '\n' +
          contract.contacts.contactPerson + '\n' + contract.contacts.contactPerson;
      }
      for (const contract of contractsList) {
        contract.isExpanded = false;
        contract.contactPerson = contract.contacts[0].contactPerson.toLowerCase() + '\n' + contract.designation + '\n' +
          contract.contacts.contactPerson + '\n' + contract.contacts.contactPerson;
      }
      this.changeDetectorRefs.detectChanges();
    }
    );
  }
}
