import { Component, OnInit, ViewChild, Input, ChangeDetectorRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar } from '@angular/material';
import { CONSTANTS } from '../../../../common/constants';
import { TemplatesDataService } from '../../../common/extranet-shared/services/templates/templates-data.service';
import { Templateslistviewmodel } from '../../../viewmodel/templates/templates-details/templateslistviewmodel';
import { FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { UserProfileService } from '../../../../common/shared/services/user-profile.service';
import { DateAdapter, NativeDateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { DatePipe } from '@angular/common';
import { DialogsService } from './../../../common/extranet-shared/dialogs/dialogs.service';
import { rowsAnimation } from './template.animations';

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
  selector: 'app-template-list',
  templateUrl: './template-list.component.html',
  styleUrls: ['./template-list.component.css'],
  providers: [
    { provide: DateAdapter, useClass: DatePickerDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: DATE_FORMATS },
  ],
  animations: [rowsAnimation],
})
export class TemplateListComponent implements OnInit {
  privileges: string[];
  deleteView = false;
  createView = false;
  readView = false;
  operation: string;
  isRead: boolean;
  displayedColumns = []; // ['name', 'createdBy', 'createdDate', 'actions'];
  templatesDataSource: MatTableDataSource<Templateslistviewmodel>;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  searchTemplates: FormGroup;
  hotelId: string;
  noDataAvailable: boolean;
  templatesList: Templateslistviewmodel[];
  filteredData: MatTableDataSource<Templateslistviewmodel>;
  isSearch: boolean;
  minChar: boolean;
  result: any;
  actions: string;
  isDeleted: boolean;
  isCopy = false;
  @Input()
  _dateValue; // notice the '_'

  // @Input() title: string;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    public snackBar: MatSnackBar,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private templatesDataService: TemplatesDataService,
    private userProfileService: UserProfileService,
    public datepipe: DatePipe,
    private dialogsService: DialogsService,
    private changeDetectorRefs: ChangeDetectorRef) { }

  ngOnInit() {
    window.scrollTo(0, 0);
  //   const intervalID = setInterval(function(){
  //    // console.log(new Date());
  //    this.makeCopyFalse();
  // }, 2000);

    this.isSearch = false;
    this.searchTemplates = new FormGroup({
      startDate: new FormControl(),
      endDate: new FormControl(),
      searchText: new FormControl()
    });
    this.getPrivileges();
    this.getTemplateList();
    /*
    this.templatesList = this.activatedRoute.snapshot.data['templateListData'].result;
    this.templatesDataSource = new MatTableDataSource<Templateslistviewmodel>(this.templatesList);
    this.templatesDataSource.sort = this.sort;
    this.templatesDataSource.paginator = this.paginator;
    */
  }

  private createTemplate() {
    this.router.navigate(['../template', 0, this.create], {
      relativeTo: this.activatedRoute
    });
  }

  getPrivileges() {
    this.privileges = this.userProfileService.GetUserPermissionsForFeature(
      CONSTANTS.application.extranet,
      CONSTANTS.featuretypeid.Templates
    );
    // console.log(' ### User Privileges #### ' + this.privileges);
    for (const privilege of this.privileges) {
      if (privilege === 'VW') {
        this.readView = true;
      } else if (privilege === 'CR') {
        this.createView = true;
      } else if (privilege === 'DE') {
        this.deleteView = true;
      }
    }

    if (this.createView || this.deleteView) {
      this.displayedColumns = ['name', 'updatedBy', 'updatedDate', 'actions'];
    } else {
      this.displayedColumns = ['name', 'updatedBy', 'updatedDate'];
    }
  }

  findTemplates(filterValue: string, filterFrom: string, filterTo: string) {
    this.makeCopyFalse();
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
    this.filteredData = new MatTableDataSource<Templateslistviewmodel>(this.templatesList.filter(template => {
      const searchDate = this.datepipe.transform(template.createdDate, 'dd-MMM-yy hh:mm a');
      const date = this.datepipe.transform(template.createdDate, 'yyyy-MM-dd');
      if (filterValue !== null && (filterFrom === null && filterTo === null)) {
        return template.name.toLowerCase().includes(filterValue) ||
          template.createdBy.toLowerCase().includes(filterValue) ||
          searchDate.toLowerCase().includes(filterValue);
      } else if (filterFrom !== null && (filterTo === null && filterValue === null)) {
        return date >= filterFrom;
      } else if (filterTo !== null && (filterFrom === null && filterValue === null)) {
        return date <= filterTo;
      } else if (filterValue === null && (filterFrom !== null && filterTo !== null)) {
        return filterFrom <= date && date <= filterTo;
      } else if (filterFrom === null && (filterValue !== null && filterTo !== null)) {
        return (template.name.toLowerCase().includes(filterValue) ||
          template.createdBy.toLowerCase().includes(filterValue) ||
          searchDate.toLowerCase().includes(filterValue)) &&
          date <= filterTo;
      } else if (filterTo === null && (filterFrom !== null && filterValue !== null)) {
        return (template.name.toLowerCase().includes(filterValue) ||
          template.createdBy.toLowerCase().includes(filterValue) ||
          searchDate.toLowerCase().includes(filterValue)) &&
          date >= filterFrom;
      } else if (filterFrom !== null && filterTo !== null && filterValue !== null) {
        return (template.name.toLowerCase().includes(filterValue) ||
          template.createdBy.toLowerCase().includes(filterValue) ||
          searchDate.toLowerCase().includes(filterValue)) &&
          filterFrom <= date && date <= filterTo;
      }
    }));
    this.filteredData.paginator = this.paginator;
    this.filteredData.sort = this.sort;
  }

  checkIsInputCleared() {
    if (this.searchTemplates.get('searchText').value.length === 1 &&
      this.searchTemplates.get('startDate').value === null &&
      this.searchTemplates.get('endDate').value === null) {
      this.filteredData = new MatTableDataSource<Templateslistviewmodel>(this.templatesList);
      this.filteredData.paginator = this.paginator;
      this.filteredData.sort = this.sort;
    }
  }

  GoTemplateUpdate(value) {
    this.isCopy = false;
    const val = value.split('-');
    const templateId = val[0];
    this.operation = val[1];
    this.router.navigate(
      ['../template', templateId, this.operation.trim().toLowerCase()],
      { relativeTo: this.activatedRoute }
    );
  }

  GoTemplateCopy(value) {
    const val = value.split('-');
    const templateId = val[0];
    const templateName = val[1];
    this.operation = val[2];
    this.dialogsService
      .openCopyModal(templateId, templateName, this.templatesList).subscribe(res => {
        this.result = res;
        if (this.result !== null) {
          this.templatesDataService.copyTemplate(this.result).subscribe(
            (response) => {
              console.log(JSON.stringify(response));
              this.snackBar.open('The copy of the template is created successfully', '', { duration: 5000, verticalPosition: 'top', panelClass: 'showSnackBar'});
              this.getTemplateList();
              this.isCopy = true;
            }
          );
        }
        this.actions = null;
      });
  }

  GoTemplateDelete(value) {
    this.isCopy = false;
    this.isCopy = false;
    const val = value.split('-');
    const templateId = val[0];
    this.dialogsService
      .confirm('Confirm', 'Are you sure you want to delete this template?').subscribe(res => {
        this.result = res;
        if (this.result) {
          this.deleteTemplate(templateId);
        } else {
          this.actions = null;
        }
      });
  }

  deleteTemplate(templateId) {
    this.templatesDataService.deleteTemplate(templateId).subscribe((isDeleted) => {
      this.isDeleted = isDeleted;
      this.snackBar.open('Template Deleted Successfully', '', { duration: 5000, verticalPosition: 'top', panelClass: 'showSnackBar'});
      this.getTemplateList();
    });
  }

  private getTemplateList() {
    this.templatesDataService.getTemplatesList().subscribe(templatesList => {
      if (templatesList !== null) {
        this.templatesDataSource = new MatTableDataSource<Templateslistviewmodel>(templatesList.result);
       // console.log('templatesList.result - ' + JSON.stringify(templatesList.result));
        this.changeDetectorRefs.detectChanges();
        this.templatesList = templatesList.result;
        this.templatesDataService.templateListDto = templatesList.result;
        this.paginator._pageIndex = 0;
        this.templatesDataSource.paginator = this.paginator;
        this.templatesDataSource.sort = this.sort;
        if (templatesList.result.length === 0) {
          this.noDataAvailable = true;
        } else {
          this.noDataAvailable = false;
        }

      } else { this.noDataAvailable = true;
      }
    });
    window.scrollTo(0, 0);
  }
  makeCopyFalse() {
   // console.log(this.paginator);
    this.isCopy = false;
  }
}
