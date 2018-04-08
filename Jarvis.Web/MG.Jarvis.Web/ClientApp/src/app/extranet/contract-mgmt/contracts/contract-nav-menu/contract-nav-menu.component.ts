import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CONSTANTS } from '../../../../common/constants';
import { Observable } from 'rxjs/Observable';
import { ContractUrlNotificationService } from '../../../common/extranet-shared/services/contracts/contract-url-notification.service';
import { ContractNameDataService } from '../../../common/extranet-shared/services/contracts/contract-name-data.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { ContractDataService } from '../../../common/extranet-shared/services/contracts/contract-data.service';
import { ContractType } from '../../../../common/enums';
import { DatePipe } from '@angular/common';
import { DateAdapter, NativeDateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';

const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;


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
  selector: 'app-contract-nav-menu',
  templateUrl: './contract-nav-menu.component.html',
  styleUrls: ['./contract-nav-menu.component.css'],
  providers: [
    { provide: DateAdapter, useClass: DatePickerDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: DATE_FORMATS },
  ],
})
export class ContractNavMenuComponent implements OnInit {
  path: string;
  @Input() contractName: string;
  isRead: boolean;
  operation: string;
  contractId: number;
  isDisabledTab: boolean;
  colorClass = '';
  state1 = true;
  state2 = false;
  state3 = false;
  state4 = false;
  showhotelinfo: boolean;
  showRate: boolean;
  isNameEditable: boolean;
  contractEnteredName: string;
  createContract: FormGroup;
  contractType: ContractType;
  showMenuChips: boolean;
  breadcrumbs: string;
  chipsList = [
    {
      chipId: 1,
      chipname: 'Hotel Info',
      chipcolor: 'primary',
      chipchild: 'hotelinfo',
      routerLink: 'hoteldetails',
      selected: true
    },
    {
      chipId: 2,
      chipname: 'Rate',
      chipcolor: 'accent',
      chipchild: 'Rate',
      routerLink: 'roomtype',
      selected: false
    },
    {
      chipId: 3,
      chipname: 'Allocations',
      chipcolor: 'accent',
      chipchild: 'allocation',
      routerLink: 'allocation',
      selected: false
    },
    {
      chipId: 4,
      chipname: 'Contract Terms',
      chipcolor: 'accent',
      chipchild: '',
      routerLink: 'contractterms',
      selected: false
    }
  ];
  params: any;
  coming: any;
  events: string[] = [];
  contractTypeName: string;
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    public contractNameDataService: ContractNameDataService,
    public contractDataService: ContractDataService,
    public contractUrlNotificationService: ContractUrlNotificationService,
    public datepipe: DatePipe,
  ) {}

  ngOnInit() {
    this.operation = this.activatedRoute.snapshot.params['operation'];
    if (this.operation === create) {
      this.breadcrumbs = 'Create New ';
    } else {
      this.breadcrumbs = 'Edit ';
    }
    this.contractType = this.contractDataService.contractType;
    switch (this.contractType) {
      case 0:
      this.contractTypeName = ' (MG - Staic)';
      break;
      case 1:
      this.contractTypeName = ' (MG - Dynamic)';
      break;
      case 2:
      this.contractTypeName = ' (Non - MG)';
      break;

    }
  // MGStatic = 0,
  // MGDynamic,
  // NonMG
  if (this.contractType === ContractType.MGStatic) {
    this.showMenuChips = true;
    // console.log('this.contractDataService.templateId-' + this.contractDataService.templateId);
    this.contractDataService.getTemplateSteps(this.contractDataService.templateId).subscribe(templatesSteps => {
     //  console.log('templatesSteps -' + JSON.stringify(templatesSteps));
      if (templatesSteps !== null) {
        const step = templatesSteps;
        if ( templatesSteps.facilityCount > 0) {
          this.contractDataService.showFacility = true;
        } else { this.contractDataService.showFacility = false;
        }
        if ( templatesSteps.amenityCount > 0) {
          this.contractDataService.showamenity = true;
        } else { this.contractDataService.showamenity = false;
        }
      }
      });
  } else {
    this.showMenuChips = false;
  }
    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.contractId = +this.activatedRoute.snapshot.params['id'];

    this.contractNameDataService.contractName.subscribe(contractNameEntered => {
      this.contractName = contractNameEntered;
    });
    this.contractUrlNotificationService.urlPath.subscribe(path => {
      if (this.router.url.indexOf('hoteldetails') >= 0) {
        this.isNameEditable = false;
      } else {
        this.isNameEditable = true;
      }
      if (
        this.operation.trim().toLocaleLowerCase() === create &&
        this.contractId === 0
      ) {
        this.isDisabledTab = true;
      } else {
        this.isDisabledTab = false;
      }
      this.path = path;
      if (this.path === 'hoteldetails' || this.path === 'facilitiesservices') {
        this.changeChip(this.chipsList[0], this.chipsList);
      } else if (
        this.path === 'roomtype' ||
        this.path === 'amenities' ||
        this.path === 'mealplan' ||
        this.path === 'ratecategory' ||
        this.path === 'childpolicy' ||
        this.path === 'cancellationpolicy'
      ) {
        this.changeChip(this.chipsList[1], this.chipsList);
      } else if (this.path === 'allocation') {
        this.changeChip(this.chipsList[2], this.chipsList);
      } else if (this.path === 'contractterms') {
        this.changeChip(this.chipsList[3], this.chipsList);
      }
    });

    if (this.contractName !== '') {
      this.contractBasicDetails();
    }

    // For Disabling the Template Name text box
    this.showhotelinfo = true;
    this.showRate = false;

    this.createContract = new FormGroup({
      contractNameEntered: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required)
    });
  }
  dateChangeEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.events = [];
    this.events.push(`${event.value}`);
    this.contractBasicDetails();
  }
  contractBasicDetails() {
    let sDate = '';
    let eDate = '';
    let newSDate: Date;
    let newEDate: Date;
    if (this.createContract.controls['startDate'].value !== null) {
       newSDate = new Date(this.createContract.controls['startDate'].value);
    }
    if (this.createContract.controls['endDate'].value !== null) {
       newEDate = new Date(this.createContract.controls['endDate'].value);
    }
    if (newSDate > newEDate) {
      this.createContract.controls['endDate'].setValue('');
    } else {
      sDate = (this.datepipe.transform(this.createContract.controls['startDate'].value, 'dd-MM-yy')) === null ? '' : this.datepipe.transform(this.createContract.controls['startDate'].value, 'dd-MM-yy') ;

      eDate = (this.datepipe.transform(this.createContract.controls['endDate'].value, 'dd-MM-yy') === null) ? '' : this.datepipe.transform(this.createContract.controls['endDate'].value, 'dd-MM-yy');
    }
    if (this.router.url.indexOf('hoteldetails') >= 0) {
      this.isNameEditable = false;
    } else {
      this.isNameEditable = true;
    }
    const contractBasicInfo =
      this.createContract.controls['contractNameEntered'].value +
      '~#' +
      new Date(this.createContract.get('startDate').value) +
      '~#' +
      new Date(this.createContract.get('endDate').value);
    console.log('contractBasicInfo-' + contractBasicInfo);
    this.contractNameDataService.changeContractName(contractBasicInfo);
  }

  changeChip(chip, chipsList) {
    if (chip.selected) {
      chip.chipcolor = 'primary';
    } else {
      for (const cc of chipsList) {
        if (cc.chipId !== chip.chipId) {
          cc.selected = false;
          cc.chipcolor = 'accent';
        }
      }
      chip.selected = !chip.selected;
      chip.chipcolor = 'primary';
      if (chip.chipId === 1) {
        this.showhotelinfo = true;
        this.showRate = false;
      } else if (chip.chipId === 2) {
        this.showhotelinfo = false;
        this.showRate = true;
      } else {
        this.showhotelinfo = false;
        this.showRate = false;
      }
    }
  }

}
