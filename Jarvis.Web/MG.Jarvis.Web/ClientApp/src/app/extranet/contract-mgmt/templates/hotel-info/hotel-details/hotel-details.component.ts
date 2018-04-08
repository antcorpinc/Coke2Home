import { Component, OnInit } from '@angular/core';
import { EXTRANETCONSTANTS } from '../../../../common/constants';
import {
  HotelInfoViewModel,
  TemplateHotelInfoViewModel,
  TemplateViewModel
} from '../../../../viewmodel/templates/hotel-info/hotelinfoviewmodel';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TemplateNameDataService } from '../../../../common/extranet-shared/services/templates/template-name-data.service';
import { TemplatesDataService } from '../../../../common/extranet-shared/services/templates/templates-data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ObjectState, EntityState } from '../../../../../common/enums';
import { CONSTANTS } from '../../../../../common/constants';
import { TemplateUrlNotificationService } from '../../../../common/extranet-shared/services/templates/template-url-notification.service';
import { MatSnackBar } from '@angular/material';

const hotelinfo = EXTRANETCONSTANTS.templates.hotelinfo;
const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;

@Component({
  selector: 'app-hotel-details',
  templateUrl: './hotel-details.component.html',
  styleUrls: ['./hotel-details.component.css']
})
export class HotelDetailsComponent implements OnInit {
  isRead: boolean;
  operation: string;
  templateId: string;
  templateName: string;
  isName = true;
  name = hotelinfo.name;
  chain = hotelinfo.chain;
  brand = hotelinfo.brand;
  type = hotelinfo.type;
  address1 = hotelinfo.address1;
  address2 = hotelinfo.address2;
  country = hotelinfo.country;
  city = hotelinfo.city;
  zip = hotelinfo.zip;
  latlong = hotelinfo.latlong;
  starrating = hotelinfo.starrating;
  mgpoints = hotelinfo.mgpoints;
  shortdescription = hotelinfo.shortdescription;
  longdescription = hotelinfo.longdescription;
  contactdetails = hotelinfo.contactdetails;
  paymentdetails = hotelinfo.paymentdetails;
  extranetdetails = hotelinfo.extranetdetails;
  taxes = hotelinfo.taxes;
  checkincheckout = hotelinfo.checkincheckout;

  hotelnameStatus: HotelInfoViewModel[];
  chainStatus: HotelInfoViewModel[];
  brandStatus: HotelInfoViewModel[];
  typeStatus: HotelInfoViewModel[];
  add1Status: HotelInfoViewModel[];
  add2Status: HotelInfoViewModel[];
  countryStatus: HotelInfoViewModel[];
  cityStatus: HotelInfoViewModel[];
  zipStatus: HotelInfoViewModel[];
  latlongStatus: HotelInfoViewModel[];
  starratingStatus: HotelInfoViewModel[];
  mgpointsStatus: HotelInfoViewModel[];
  shortdescriptionStatus: HotelInfoViewModel[];
  longdescriptionStatus: HotelInfoViewModel[];
  contactStatus: HotelInfoViewModel[];
  paymentStatus: HotelInfoViewModel[];
  extranetStatus: HotelInfoViewModel[];
  taxesStatus: HotelInfoViewModel[];
  checkincheckoutStatus: HotelInfoViewModel[];

  formFieldList: HotelInfoViewModel[];
  initialFormFieldList: HotelInfoViewModel[];
  hotelInfoForm: FormGroup;

  templateHotelInfoViewModel: TemplateHotelInfoViewModel;
  constructor(
    private router: Router,
    public snackBar: MatSnackBar,
    public templateNameDataService: TemplateNameDataService,
    private templateDataService: TemplatesDataService,
    private activatedRoute: ActivatedRoute,
    private templateUrlNotificationService: TemplateUrlNotificationService
  ) {
      templateUrlNotificationService.changeURLRoute(activatedRoute.snapshot.url[0].path);
  }

  ngOnInit() {
    window.scrollTo(0, 0);
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.templateId = this.activatedRoute.parent.snapshot.params['id'];

    this.getHotelFieldsList();
    this.formFieldList = this.templateHotelInfoViewModel.hotelFields;
    this.getFieldStatus();
    this.hotelInfoForm = new FormGroup({
      hotelName: new FormControl(this.hotelnameStatus[0]['isSelected']),
      chain: new FormControl(this.chainStatus[0]['isSelected']),
      brand: new FormControl({value: this.brandStatus[0]['isSelected'], disabled: true}),
      type: new FormControl(this.typeStatus[0]['isSelected']),
      address1: new FormControl(this.add1Status[0]['isSelected']),
      address2: new FormControl(this.add2Status[0]['isSelected']),
      country: new FormControl(this.countryStatus[0]['isSelected']),
      city: new FormControl(this.cityStatus[0]['isSelected']),
      zip: new FormControl(this.zipStatus[0]['isSelected']),
      latlong: new FormControl(this.latlongStatus[0]['isSelected']),
      starrating: new FormControl(this.starratingStatus[0]['isSelected']),
      mgpoints: new FormControl(this.mgpointsStatus[0]['isSelected']),
      shortdescription: new FormControl(
        this.shortdescriptionStatus[0]['isSelected']
      ),
      longdescription: new FormControl(
        this.longdescriptionStatus[0]['isSelected']
      ),
      contactdetails: new FormControl(this.contactStatus[0]['isSelected']),
      paymentdetails: new FormControl(this.paymentStatus[0]['isSelected']),
      extranetdetails: new FormControl(this.extranetStatus[0]['isSelected']),
      taxes: new FormControl(this.taxesStatus[0]['isSelected']),
      checkincheckout: new FormControl(
        this.checkincheckoutStatus[0]['isSelected']
      ),
      templateName: new FormControl('', Validators.required)
    });
    this.templateNameDataService.templateName.subscribe(templateNameEntered => {
      this.templateName = templateNameEntered;
      console.log('this.templateName-' + this.templateName);
      this.hotelInfoForm.controls['templateName'].setValue(this.templateName);
    });

  }

  private getHotelFieldsList() {
    this.templateHotelInfoViewModel = this.activatedRoute.snapshot.data['hotelFieldData'];
    // console.log('Template Hotel Info data - ' +  JSON.stringify(this.templateHotelInfoViewModel ));
    this.getTemplateName(this.templateHotelInfoViewModel.name);
  }

  getTemplateName(tempName: string) {
    this.templateNameDataService.changeTemplateName(tempName);
  }

  onChainChange(event) {
    if (event.checked) {
      this.hotelInfoForm.controls['brand'].setValue(true);
    } else {
      this.hotelInfoForm.controls['brand'].setValue(false);
    }
  }

  getFieldStatus() {
    this.hotelnameStatus = this.formFieldList.filter(
      arr => arr.code === this.name
    );
    this.chainStatus = this.formFieldList.filter(
      arr => arr.code === this.chain
    );
    this.brandStatus = this.formFieldList.filter(
      arr => arr.code === this.brand
    );
    this.typeStatus = this.formFieldList.filter(arr => arr.code === this.type);
    this.add1Status = this.formFieldList.filter(
      arr => arr.code === this.address1
    );
    this.add2Status = this.formFieldList.filter(
      arr => arr.code === this.address2
    );
    this.countryStatus = this.formFieldList.filter(
      arr => arr.code === this.country
    );
    this.cityStatus = this.formFieldList.filter(arr => arr.code === this.city);
    this.zipStatus = this.formFieldList.filter(arr => arr.code === this.zip);
    this.latlongStatus = this.formFieldList.filter(
      arr => arr.code === this.latlong
    );
    this.starratingStatus = this.formFieldList.filter(
      arr => arr.code === this.starrating
    );
    this.mgpointsStatus = this.formFieldList.filter(
      arr => arr.code === this.mgpoints
    );
    this.shortdescriptionStatus = this.formFieldList.filter(
      arr => arr.code === this.shortdescription
    );
    this.longdescriptionStatus = this.formFieldList.filter(
      arr => arr.code === this.longdescription
    );
    this.contactStatus = this.formFieldList.filter(
      arr => arr.code === this.contactdetails
    );
    this.paymentStatus = this.formFieldList.filter(
      arr => arr.code === this.paymentdetails
    );
    this.extranetStatus = this.formFieldList.filter(
      arr => arr.code === this.extranetdetails
    );
    this.taxesStatus = this.formFieldList.filter(
      arr => arr.code === this.taxes
    );
    this.checkincheckoutStatus = this.formFieldList.filter(
      arr => arr.code === this.checkincheckout
    );
    // this.checkincheckoutStatus[0].objectState = ObjectState.Added;
  }

  saveHotelInfo() {
    if (this.hotelInfoForm.valid) {
        this.createSavingData(this.operation.toLowerCase().trim());
    // console.log('Template Hotel Info data for saving - ' +  JSON.stringify(this.templateHotelInfoViewModel ));
      this.templateDataService.saveTemplateHotelFields(this.templateHotelInfoViewModel).subscribe(
        (response) => {
          this.router.navigate(['/templatemgmt/templates']);
          this.snackBar.open('Hotel Info Template Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
    }
  }

  saveandContinue() {
    if (this.hotelInfoForm.valid) {
        this.createSavingData(this.operation.toLowerCase().trim());
      this.templateDataService.saveTemplateHotelFields(this.templateHotelInfoViewModel).subscribe(
        (response) => {
          this.router.navigate(['/templatemgmt/redirect', response.result]);
          this.snackBar.open('Hotel Info Template Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
    }
  }

  createSavingData(operation: string) {
    let arrayHotelFields: HotelInfoViewModel[];
    arrayHotelFields = [];

    if (operation === create) {
      this.hotelnameStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'hotelName'
      ].value;
      this.hotelnameStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.hotelnameStatus[0]);
      this.chainStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'chain'
      ].value;
      this.chainStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.chainStatus[0]);
      this.brandStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'brand'
      ].value;
      this.brandStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.brandStatus[0]);
      this.typeStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'type'
      ].value;
      this.typeStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.typeStatus[0]);
      this.add1Status[0]['isSelected'] = this.hotelInfoForm.controls[
        'address1'
      ].value;
      this.add1Status[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.add1Status[0]);
      this.add2Status[0]['isSelected'] = this.hotelInfoForm.controls[
        'address2'
      ].value;
      this.add2Status[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.add2Status[0]);
      this.countryStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'country'
      ].value;
      this.countryStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.countryStatus[0]);
      this.cityStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'city'
      ].value;
      this.cityStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.cityStatus[0]);
      this.zipStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'zip'
      ].value;
      this.zipStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.zipStatus[0]);
      this.latlongStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'latlong'
      ].value;
      this.latlongStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.latlongStatus[0]);
      this.starratingStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'starrating'
      ].value;
      this.starratingStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.starratingStatus[0]);
      this.mgpointsStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'mgpoints'
      ].value;
      this.mgpointsStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.mgpointsStatus[0]);
      this.shortdescriptionStatus[0][
        'isSelected'
      ] = this.hotelInfoForm.controls['shortdescription'].value;
      this.shortdescriptionStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.shortdescriptionStatus[0]);
      this.longdescriptionStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'longdescription'
      ].value;
      this.longdescriptionStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.longdescriptionStatus[0]);
      this.contactStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'contactdetails'
      ].value;
      this.contactStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.contactStatus[0]);
      this.paymentStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'paymentdetails'
      ].value;
      this.paymentStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.paymentStatus[0]);
      this.extranetStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'extranetdetails'
      ].value;
      this.extranetStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.extranetStatus[0]);
      this.taxesStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'taxes'
      ].value;
      this.taxesStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.taxesStatus[0]);
      this.checkincheckoutStatus[0]['isSelected'] = this.hotelInfoForm.controls[
        'checkincheckout'
      ].value;
      this.checkincheckoutStatus[0]['objectState'] = ObjectState.Added;
      arrayHotelFields.push(this.checkincheckoutStatus[0]);
      this.templateHotelInfoViewModel.name = this.hotelInfoForm.controls[
        'templateName'
      ].value;
      this.templateHotelInfoViewModel.objectState = ObjectState.Added;
    } else if (operation === edit) {
      if (
        this.hotelnameStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['hotelName'].value
      ) {
        this.hotelnameStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'hotelName'
        ].value;
       if ( this.hotelnameStatus[0]['status'] === EntityState.New) {
        this.hotelnameStatus[0]['objectState'] = ObjectState.Added; } else {
      this.hotelnameStatus[0]['objectState'] = ObjectState.Modified;
    } } else {
        this.hotelnameStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.hotelnameStatus[0]);
      if (
        this.chainStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['chain'].value
      ) {
        this.chainStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'chain'
        ].value;
       if ( this.chainStatus[0]['status'] === EntityState.New) {
        this.chainStatus[0]['objectState'] = ObjectState.Added; } else {
      this.chainStatus[0]['objectState'] = ObjectState.Modified;
    } } else {
        this.chainStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.chainStatus[0]);
      if (
        this.brandStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['brand'].value
      ) {
        this.brandStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'brand'
        ].value;
        if ( this.brandStatus[0]['status'] === EntityState.New) {
        this.brandStatus[0]['objectState'] = ObjectState.Added; } else {
          this.brandStatus[0]['objectState'] = ObjectState.Modified;
        } }  else {
        this.brandStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.brandStatus[0]);
      if (
        this.typeStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['type'].value
      ) {
        this.typeStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'type'
        ].value;
        if ( this.typeStatus[0]['status'] === EntityState.New) {
          this.typeStatus[0]['objectState'] = ObjectState.Added; } else {
            this.typeStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.typeStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.typeStatus[0]);
      if (
        (this.add1Status[0]['isSelected'] !== this.hotelInfoForm.controls[
          'address1'
        ].value)
      ) {
        this.add1Status[0]['isSelected'] = this.hotelInfoForm.controls[
          'address1'
        ].value;
        if ( this.add1Status[0]['status'] === EntityState.New) {
          this.add1Status[0]['objectState'] = ObjectState.Added; } else {
            this.add1Status[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.add1Status[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.add1Status[0]);
      if (
        this.add2Status[0]['isSelected'] !==
        this.hotelInfoForm.controls['address2'].value
      ) {
        this.add2Status[0]['isSelected'] = this.hotelInfoForm.controls[
          'address2'
        ].value;
        if ( this.add2Status[0]['status'] === EntityState.New) {
          this.add2Status[0]['objectState'] = ObjectState.Added; } else {
            this.add2Status[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.add2Status[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.add2Status[0]);
      if (
        this.countryStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['country'].value
      ) {
        this.countryStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'country'
        ].value;
        if ( this.countryStatus[0]['status'] === EntityState.New) {
          this.countryStatus[0]['objectState'] = ObjectState.Added; } else {
            this.countryStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.countryStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.countryStatus[0]);
      if (
        this.cityStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['city'].value
      ) {
        this.cityStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'city'
        ].value;
        if ( this.cityStatus[0]['status'] === EntityState.New) {
          this.cityStatus[0]['objectState'] = ObjectState.Added; } else {
            this.cityStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.cityStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.cityStatus[0]);
      if (
        this.zipStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['zip'].value
      ) {
        this.zipStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'zip'
        ].value;
        if ( this.zipStatus[0]['status'] === EntityState.New) {
          this.zipStatus[0]['objectState'] = ObjectState.Added; } else {
            this.zipStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.zipStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.zipStatus[0]);
      if (
      this.latlongStatus[0]['isSelected'] !== this.hotelInfoForm.controls[
        'latlong'].value) {
          this.latlongStatus[0]['isSelected'] = this.hotelInfoForm.controls[
            'latlong'].value;
            if ( this.latlongStatus[0]['status'] === EntityState.New) {
              this.latlongStatus[0]['objectState'] = ObjectState.Added; } else {
                this.latlongStatus[0]['objectState'] = ObjectState.Modified;
              } } else {
        this.latlongStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.latlongStatus[0]);

      if (
        this.starratingStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['starrating'].value
      ) {
        this.starratingStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'starrating'
        ].value;
        if ( this.starratingStatus[0]['status'] === EntityState.New) {
          this.starratingStatus[0]['objectState'] = ObjectState.Added; } else {
            this.starratingStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.starratingStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.starratingStatus[0]);
      if (
        this.mgpointsStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['mgpoints'].value
      ) {
        this.mgpointsStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'mgpoints'
        ].value;
        if ( this.mgpointsStatus[0]['status'] === EntityState.New) {
          this.mgpointsStatus[0]['objectState'] = ObjectState.Added; } else {
            this.mgpointsStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.mgpointsStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.mgpointsStatus[0]);
      if (
        this.shortdescriptionStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['shortdescription'].value
      ) {
        this.shortdescriptionStatus[0][
          'isSelected'
        ] = this.hotelInfoForm.controls['shortdescription'].value;
        if ( this.shortdescriptionStatus[0]['status'] === EntityState.New) {
          this.shortdescriptionStatus[0]['objectState'] = ObjectState.Added; } else {
            this.shortdescriptionStatus[0]['objectState'] = ObjectState.Modified;
          } }  else {
        this.shortdescriptionStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.shortdescriptionStatus[0]);
      if (
        this.longdescriptionStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['longdescription'].value
      ) {
        this.longdescriptionStatus[0][
          'isSelected'
        ] = this.hotelInfoForm.controls['longdescription'].value;
        if ( this.longdescriptionStatus[0]['status'] === EntityState.New) {
          this.longdescriptionStatus[0]['objectState'] = ObjectState.Added; } else {
            this.longdescriptionStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.longdescriptionStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.longdescriptionStatus[0]);
      if (
        this.contactStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['contactdetails'].value
      ) {
        this.contactStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'contactdetails'
        ].value;
        if ( this.contactStatus[0]['status'] === EntityState.New) {
          this.contactStatus[0]['objectState'] = ObjectState.Added; } else {
            this.contactStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.contactStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.contactStatus[0]);
      if (
        this.paymentStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['paymentdetails'].value
      ) {
        this.paymentStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'paymentdetails'
        ].value;
        if ( this.paymentStatus[0]['status'] === EntityState.New) {
          this.paymentStatus[0]['objectState'] = ObjectState.Added; } else {
            this.paymentStatus[0]['objectState'] = ObjectState.Modified;
          } }  else {
        this.paymentStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.paymentStatus[0]);
      if (
        this.extranetStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['extranetdetails'].value
      ) {
        this.extranetStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'extranetdetails'
        ].value;
        if ( this.extranetStatus[0]['status'] === EntityState.New) {
          this.extranetStatus[0]['objectState'] = ObjectState.Added; } else {
            this.extranetStatus[0]['objectState'] = ObjectState.Modified;
          } } else {
        this.extranetStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.extranetStatus[0]);
      if (
        this.taxesStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['taxes'].value
      ) {
        this.taxesStatus[0]['isSelected'] = this.hotelInfoForm.controls[
          'taxes'
        ].value;
        if ( this.taxesStatus[0]['status'] === EntityState.New) {
          this.taxesStatus[0]['objectState'] = ObjectState.Added; } else {
            this.taxesStatus[0]['objectState'] = ObjectState.Modified;
          } }  else {
        this.taxesStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.taxesStatus[0]);
      if (
        this.checkincheckoutStatus[0]['isSelected'] !==
        this.hotelInfoForm.controls['checkincheckout'].value
      ) {
        this.checkincheckoutStatus[0][
          'isSelected'
        ] = this.hotelInfoForm.controls['checkincheckout'].value;
        if ( this.checkincheckoutStatus[0]['status'] === EntityState.New) {
          this.checkincheckoutStatus[0]['objectState'] = ObjectState.Added; } else {
            this.checkincheckoutStatus[0]['objectState'] = ObjectState.Modified;
          } }else {
        this.checkincheckoutStatus[0]['objectState'] = ObjectState.Unchanged;
      }
      arrayHotelFields.push(this.checkincheckoutStatus[0]);
      if (
        this.templateHotelInfoViewModel.name !==
        this.hotelInfoForm.controls['templateName'].value
      ) {
        this.templateHotelInfoViewModel.name = this.hotelInfoForm.controls[
          'templateName'
        ].value;
        this.templateHotelInfoViewModel.objectState = ObjectState.Modified;
      } else {
        this.templateHotelInfoViewModel.objectState = ObjectState.Unchanged;
      }
    }
    this.templateHotelInfoViewModel.hotelFields = arrayHotelFields;
  }

  backToList() {
    this.router.navigate(['/templatemgmt/templates']);
 }
}
