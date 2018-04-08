import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { ContractNameDataService } from '../../../../common/extranet-shared/services/contracts/contract-name-data.service';
import { ContractUrlNotificationService } from '../../../../common/extranet-shared/services/contracts/contract-url-notification.service';
import { LookupService } from '../../../../../common/shared/services/lookup.service';
import { CountryViewModel } from '../../../../../common/viewmodels/countryviewmodel';
import { HotelTypeViewModel } from '../../../../../common/viewmodels/hoteltypeviewmodel';
import { HotelChainViewModel } from '../../../../../common/viewmodels/hotelchainviewmodel';
import { ContactPersonTitleViewModel } from '../../../../../common/viewmodels/contactpersontitleviewmodel';
import { CurrencyViewModel } from '../../../../../common/viewmodels/currencyviewmodel';
import { PaymentMethodViewModel } from '../../../../viewmodel/hoteldetailsviewmodel/paymentmethodviewmodel';
import { RateTypeViewModel } from '../../../../viewmodel/hoteldetailsviewmodel/ratetypeviewmodel';
import { ChannelManagerViewModel } from '../../../../viewmodel/hoteldetailsviewmodel/channelmanagerviewmodel';
import { TaxesApplicabilityViewModel } from '../../../../viewmodel/hoteldetailsviewmodel/taxesapplicabilityviewmodel';
import { StarRatingViewModel } from '../../../../viewmodel/hoteldetailsviewmodel/starratingviewmodel';
import { ContractHotelDetailsDataService } from '../../../../common/extranet-shared/services/contracts/contract-hotel-details-data.service';
import { HotelsNameList } from '../../../../viewmodel/contracts/hoteldetails/hotelsnamelist';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';
import {startWith} from 'rxjs/operators/startWith';
import { HotelDataService } from '../../../../common/extranet-shared/services/hotel-data.service';
import { HotelDetailsViewModel } from '../../../../viewmodel/hoteldetailsviewmodel/hoteldetailsviewmodel';
import { HotelBrandViewModel } from '../../../../../common/viewmodels/hotelbrandviewmodel';
import { CityViewModel } from '../../../../../common/viewmodels/cityviewmodel';
import { EXTRANETCONSTANTS } from '../../../../common/constants';
import { HotelPaymentMethodRelationViewModel } from '../../../../viewmodel/hoteldetailsviewmodel/hotelpaymentmethodrelationviewmodel';
import { ContractDataService } from '../../../../common/extranet-shared/services/contracts/contract-data.service';
import { ContractType, ObjectState } from '../../../../../common/enums';
import { TemplateFacilitiesDataService } from '../../../../common/extranet-shared/services/templates/template-facilities-data.service';
import { TemplatesDataService } from '../../../../common/extranet-shared/services/templates/templates-data.service';
import { TemplateHotelInfoViewModel, TemplateViewModel } from '../../../../viewmodel/templates/hotel-info/hotelinfoviewmodel';
import { ContractHotelDetailsViewModel } from '../../../../viewmodel/contracts/hoteldetails/contracthoteldetailsviewmodel';
import { MatSnackBar } from '@angular/material';
import { StaticContractHotelDetailsVieModel } from '../../../../viewmodel/contracts/hoteldetails/staticcontracthoteldetailsviewmodel';

@Component({
  selector: 'app-hotel-details',
  templateUrl: './hotel-details.component.html',
  styleUrls: ['./hotel-details.component.css']
})
export class HotelDetailsComponent implements OnInit {

  hotelDetailsContractGroup: FormGroup;
  contractBasicData: string[] = [];
  rowSelected: number;
  nonMg = ContractType.NonMG;
  mgStatic = ContractType.MGStatic;
  mgDynamic = ContractType.MGDynamic;
  hotelInfoCodes = EXTRANETCONSTANTS.templates.hotelinfo;
  contractType: any;
  templateId: number;
  templateHotelInfoViewModel: TemplateHotelInfoViewModel;
  templateViewModel: TemplateViewModel;
  contractHotelDetailsViewModel: ContractHotelDetailsViewModel;
  staticContractHotelDetailsVieModel: StaticContractHotelDetailsVieModel;

  hotelData: HotelDetailsViewModel;
  hotelDataSave: HotelDetailsViewModel;
  latLong: any;
  hotelPaymentMethodRelation: HotelPaymentMethodRelationViewModel;
  checkInCheckOut = EXTRANETCONSTANTS.arrCheckInCheckOut;
  countriesList: CountryViewModel[];
  citiesList: CityViewModel[];
  hotelTypeList: HotelTypeViewModel[];
  hotelChainList: HotelChainViewModel[];
  hotelBrandList: HotelBrandViewModel[];
  contactPersonTitleList: ContactPersonTitleViewModel[];
  currencyList: CurrencyViewModel[];
  paymentMethodList: PaymentMethodViewModel[];
  rateTypeList: RateTypeViewModel[];
  channelManagerList: ChannelManagerViewModel[];
  taxesApplicabilityList: TaxesApplicabilityViewModel[];
  starRatingList: StarRatingViewModel[];
  hotelsNameList: HotelsNameList[];
  filteredOptions: Observable<any>;
  // name: FormControl = new FormControl();

  isSelectedName: boolean;
  isSelectedChain: boolean;
  isSelectedBrand: boolean;
  isSelectedType: boolean;
  isSelectedAddress1: boolean;
  isSelectedAddress2: boolean;
  isSelectedCountry: boolean;
  isSelectedCity: boolean;
  isSelectedZip: boolean;
  isSelectedLatLong: boolean;
  isSelectedStarRating: boolean;
  isSelectedMgPoints: boolean;
  isSelectedShortDescription: boolean;
  isSelectedLongDescription: boolean;
  isSelectedContactDetails: boolean;
  isSelectedPaymentDetails: boolean;
  isSelectedExtranetDetails: boolean;
  isSelectedTaxes: boolean;
  isSelectedCheckinCheckout: boolean;

  constructor( public contractNameDataService: ContractNameDataService,
               public contractDataService: ContractDataService,
               public contractUrlNotificationService: ContractUrlNotificationService,
               public lookupService: LookupService,
               public contractHotelDetailsDataService: ContractHotelDetailsDataService,
               public templatesDataService: TemplatesDataService,
               private activatedRoute: ActivatedRoute,
               private router: Router,
               private hotelDataService: HotelDataService,
               private changeDetector: ChangeDetectorRef,
               public snackBar: MatSnackBar) { }

  ngOnInit() {

    this.getCountries();
    this.getHotelTypes();
    this.getHotelChains();
    this.getContactTitles();
    this.getCurrency();
    this.getPaymentMethod();
    this.getRateType();
    this.getChannelManager();
    this.getTaxApplicability();
    this.getStarRating();

    this.hotelsNameList = this.activatedRoute.snapshot.data['hotelsName'];
    this.templateId = this.contractDataService.templateId;
    this.contractType = this.contractDataService.contractType;

    this.hotelDetailsContractGroup = new FormGroup({
      hotelId: new FormControl(),
      hotelName: new FormControl(),
      hotelChainId: new FormControl(),
      hotelBrandId: new FormControl(),
      hotelTypeId: new FormControl('', Validators.required),
      countryId: new FormControl('', Validators.required),
      cityId: new FormControl('', Validators.required),
      address1: new FormControl('', Validators.required),
      address2: new FormControl(),
      zipCode: new FormControl('', Validators.required),
      latLong: new FormControl('', Validators.required),
      starRatingId: new FormControl('', Validators.required),
      mgPoint: new FormControl(),
      shortDescription: new FormControl('', Validators.required),
      longDescription: new FormControl(),
      checkInFrom: new FormControl('', Validators.required),
      checkOutTo: new FormControl('', Validators.required),
      contactDetails: new FormArray([this.buildContactDetailsForm()]),
      website: new FormControl('', Validators.required),
      reservationEmail: new FormControl('', Validators.required),
      reservationContactNo: new FormControl('', Validators.required),
      hotelPaymentMethodRelation: this.buildPaymentMethod(),
      isExtranetAccess: new FormControl(),
      isChannelManagerConnectivity: new FormControl(),
      channelManagerId: new FormControl(),
      taxDetails: new FormArray([this.buildTaxDetailsForm()]),
      contractNameEntered: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required)
    });
    this.contractNameDataService.contractName.subscribe(contractBasicDetails => {
      this.contractBasicData = contractBasicDetails.split('~#');
      this.hotelDetailsContractGroup.controls['contractNameEntered'].setValue(this.contractBasicData[0]);
      this.hotelDetailsContractGroup.controls['startDate'].setValue(this.contractBasicData[1]);
      this.hotelDetailsContractGroup.controls['endDate'].setValue(this.contractBasicData[2]);
    });

    if (this.contractType === this.mgStatic) {
      this.templateViewModel = {
        id: this.templateId
      };
      // this.templateHotelInfoViewModel = this.activatedRoute.snapshot.data['templateHotelData'];
      this.templatesDataService.getTemplateHotelFields(this.templateViewModel).subscribe(templateData => {
        this.templateHotelInfoViewModel = templateData;

        this.templateHotelInfoViewModel.hotelFields.forEach(hotelField => {
          if (hotelField.isConfigurable === false) {
            hotelField.isSelected = true;
          }

          if (this.hotelInfoCodes.name === hotelField.code) {
            this.isSelectedName = hotelField.isSelected;
          } else if (this.hotelInfoCodes.chain === hotelField.code) {
            this.isSelectedChain = hotelField.isSelected;
          } else if (this.hotelInfoCodes.brand === hotelField.code) {
            this.isSelectedBrand = hotelField.isSelected;
          } else if (this.hotelInfoCodes.type === hotelField.code) {
            this.isSelectedType = hotelField.isSelected;
          } else if (this.hotelInfoCodes.address1 === hotelField.code) {
            this.isSelectedAddress1 = hotelField.isSelected;
          } else if (this.hotelInfoCodes.address2 === hotelField.code) {
            this.isSelectedAddress2 = hotelField.isSelected;
          } else if (this.hotelInfoCodes.country === hotelField.code) {
            this.isSelectedCountry = hotelField.isSelected;
          } else if (this.hotelInfoCodes.city === hotelField.code) {
            this.isSelectedCity = hotelField.isSelected;
          } else if (this.hotelInfoCodes.zip === hotelField.code) {
            this.isSelectedZip = hotelField.isSelected;
          } else if (this.hotelInfoCodes.latlong === hotelField.code) {
            this.isSelectedLatLong = hotelField.isSelected;
          } else if (this.hotelInfoCodes.starrating === hotelField.code) {
            this.isSelectedStarRating = hotelField.isSelected;
          } else if (this.hotelInfoCodes.mgpoints === hotelField.code) {
            this.isSelectedMgPoints = hotelField.isSelected;
          } else if (this.hotelInfoCodes.shortdescription === hotelField.code) {
            this.isSelectedShortDescription = hotelField.isSelected;
          } else if (this.hotelInfoCodes.longdescription === hotelField.code) {
            this.isSelectedLongDescription = hotelField.isSelected;
          } else if (this.hotelInfoCodes.contactdetails === hotelField.code) {
            this.isSelectedContactDetails = hotelField.isSelected;
          } else if (this.hotelInfoCodes.paymentdetails === hotelField.code) {
            this.isSelectedPaymentDetails = hotelField.isSelected;
          } else if (this.hotelInfoCodes.extranetdetails === hotelField.code) {
            this.isSelectedExtranetDetails = hotelField.isSelected;
          } else if (this.hotelInfoCodes.taxes === hotelField.code) {
            this.isSelectedTaxes = hotelField.isSelected;
          } else if (this.hotelInfoCodes.checkincheckout === hotelField.code) {
            this.isSelectedCheckinCheckout = hotelField.isSelected;
          }

        });

      });
    } else if (this.contractType === this.nonMg || this.contractType === this.mgDynamic) {
      this.isSelectedName = true;
      this.isSelectedChain = true;
      this.isSelectedBrand = true;
      this.isSelectedType = true;
      this.isSelectedAddress1 = true;
      this.isSelectedAddress2 = true;
      this.isSelectedCountry = true;
      this.isSelectedCity = true;
      this.isSelectedZip = true;
      this.isSelectedLatLong = true;
      this.isSelectedStarRating = true;
      this.isSelectedMgPoints = true;
      this.isSelectedShortDescription = true;
      this.isSelectedLongDescription = true;
      this.isSelectedContactDetails = true;
      this.isSelectedPaymentDetails = false;
      this.isSelectedExtranetDetails = false;
      this.isSelectedTaxes = false;
      this.isSelectedCheckinCheckout = true;
    }

    // function for serach by hotel name
    this.filteredOptions = this.hotelDetailsContractGroup.get('hotelName').valueChanges
      .pipe(
         map(val => this.filter(val))
      );

  }

  /* ---------- Contact Details ---------------- */
  buildContactDetailsForm(): FormGroup {
    let contactDetailsFormGroup: FormGroup;
    contactDetailsFormGroup = new FormGroup({
      contactId: new FormControl(),
      isPrimary: new FormControl(),
      contactPerson: new FormControl('', Validators.required),
      designationId: new FormControl('', Validators.required),
      emailAddress: new FormControl('', Validators.required),
      contactNumber: new FormControl('', Validators.required),
      rowSelected: new FormControl()
    });

    return contactDetailsFormGroup;
  }

  get contactDetails(): FormArray {
    return <FormArray>this.hotelDetailsContractGroup.get('contactDetails');
  }

  addContact() {
    this.contactDetails.push(this.buildContactDetailsForm());
    this.changeDetector.detectChanges();
  }

  /* ---------- Contact Details Ends ---------------- */

  /* ---------- Payment Method ---------------- */
  buildPaymentMethod(): FormGroup {
    let paymentMethodFormGroup: FormGroup;
    paymentMethodFormGroup = new FormGroup({
      hotelPaymentMethodRelationId: new FormControl(),
      paymentMethodId: new FormControl(),
      currencyId: new FormControl(),
      rateTypeId: new FormControl()
    });

    return paymentMethodFormGroup;
  }

  /* ---------- Payment Method Ends ---------------- */

  /* ---------- Tax Details ---------------- */
  buildTaxDetailsForm(): FormGroup {
    let taxDetailsFormGroup: FormGroup;
    taxDetailsFormGroup = new FormGroup({
      taxTypeId: new FormControl(),
      taxesType: new FormControl(),
      taxApplicabilityId: new FormControl(),
      amount: new FormControl(),
      isIncludedInRates: new FormControl()
    });

    return taxDetailsFormGroup;
  }

  get taxDetails(): FormArray {
    return <FormArray>this.hotelDetailsContractGroup.get('taxDetails');
  }

  addTax() {
    this.taxDetails.push(this.buildTaxDetailsForm());
    this.changeDetector.detectChanges();
  }
  /* ---------- Tax Details Ends ---------------- */

  /* ---------- Filter Hotel ---------------- */
  filter(val: string): HotelsNameList[] {
    return this.hotelsNameList.filter(hotelsNameList =>
      hotelsNameList.name.toLowerCase().includes(val.toLowerCase()));
  }

  searchHotel(event, hotelId) {
    if (event.source.selected) {
      this.hotelDataService.getHotel(hotelId).subscribe(hotelData => {
        this.hotelData = hotelData;

        if (this.contactDetails.controls.length !== 0) {
          this.contactDetails.removeAt(1);
        }

        if (this.taxDetails.controls.length !== 0) {
          this.taxDetails.removeAt(1);
        }

        if (this.hotelData.hotelChainId != null) {
          this.getHotelBrands(this.hotelData.hotelChainId);
        }
        if (this.hotelData.countryId != null) {
          this.getCities(this.hotelData.countryId);
        }
        this.latLong = this.hotelData.latitude + '/' + this.hotelData.longitude;

        for (let i = 0; i < (this.hotelData.contactDetails.length - 1); i++) {
          this.addContact();
        }

        for (let i = 0; i < this.hotelData.contactDetails.length; i++) {
          if (this.hotelData.contactDetails[i].isPrimary === true) {
            this.rowSelected = i;
          }
        }

        for (let i = 0; i < (this.hotelData.taxDetails.length - 1); i++) {
          this.addTax();
        }

        this.hotelDetailsContractGroup.get('hotelId').setValue(this.hotelData.hotelId);
        this.hotelDetailsContractGroup.get('hotelName').setValue(this.hotelData.hotelName);
        this.hotelDetailsContractGroup.get('hotelChainId').setValue(this.hotelData.hotelChainId);
        this.hotelDetailsContractGroup.get('hotelBrandId').setValue(this.hotelData.hotelBrandId);
        this.hotelDetailsContractGroup.get('hotelTypeId').setValue(this.hotelData.hotelTypeId);
        this.hotelDetailsContractGroup.get('countryId').setValue(this.hotelData.countryId);
        this.hotelDetailsContractGroup.get('cityId').setValue(this.hotelData.cityId);
        this.hotelDetailsContractGroup.get('address1').setValue(this.hotelData.address1);
        this.hotelDetailsContractGroup.get('address2').setValue(this.hotelData.address2);
        this.hotelDetailsContractGroup.get('zipCode').setValue(this.hotelData.zipCode);
        this.hotelDetailsContractGroup.get('latLong').setValue(this.latLong);
        this.hotelDetailsContractGroup.get('starRatingId').setValue(this.hotelData.starRatingId);
        this.hotelDetailsContractGroup.get('mgPoint').setValue(this.hotelData.mgPoint);
        this.hotelDetailsContractGroup.get('shortDescription').setValue(this.hotelData.shortDescription);
        this.hotelDetailsContractGroup.get('longDescription').setValue(this.hotelData.longDescription);
        this.hotelDetailsContractGroup.get('checkInFrom').setValue(this.hotelData.checkInFrom);
        this.hotelDetailsContractGroup.get('checkOutTo').setValue(this.hotelData.checkOutTo);
        this.hotelDetailsContractGroup.get('website').setValue(this.hotelData.website);
        this.hotelDetailsContractGroup.get('reservationEmail').setValue(this.hotelData.reservationEmail);
        this.hotelDetailsContractGroup.get('reservationContactNo').setValue(this.hotelData.reservationContactNo);
        this.hotelDetailsContractGroup.get('isExtranetAccess').setValue(this.hotelData.isExtranetAccess);
        this.hotelDetailsContractGroup.get('isChannelManagerConnectivity').setValue(this.hotelData.isChannelManagerConnectivity);
        this.hotelDetailsContractGroup.get('channelManagerId').setValue(this.hotelData.channelManagerId);

        this.contactDetails.controls.forEach((contact, index) => {
          contact.get('contactId').setValue(this.hotelData.contactDetails[index].contactId);
          contact.get('contactPerson').setValue(this.hotelData.contactDetails[index].contactPerson);
          contact.get('designationId').setValue(this.hotelData.contactDetails[index].designationId);
          contact.get('emailAddress').setValue(this.hotelData.contactDetails[index].emailAddress);
          contact.get('contactNumber').setValue(this.hotelData.contactDetails[index].contactNumber);
          contact.get('rowSelected').setValue(this.rowSelected);
        });

        this.hotelDetailsContractGroup.controls.hotelPaymentMethodRelation.get('paymentMethodId').
                          setValue(this.hotelData.hotelPaymentMethodRelation.paymentMethodId);
        this.hotelDetailsContractGroup.controls.hotelPaymentMethodRelation.get('currencyId').
                          setValue(this.hotelData.hotelPaymentMethodRelation.currencyId);
        this.hotelDetailsContractGroup.controls.hotelPaymentMethodRelation.get('rateTypeId').
                          setValue(this.hotelData.hotelPaymentMethodRelation.rateTypeId);

        this.taxDetails.controls.forEach((tax, index) => {
          tax.get('taxTypeId').setValue(this.hotelData.taxDetails[index].taxTypeId);
          tax.get('taxesType').setValue(this.hotelData.taxDetails[index].taxesType);
          tax.get('taxApplicabilityId').setValue(this.hotelData.taxDetails[index].taxApplicabilityId);
          tax.get('amount').setValue(this.hotelData.taxDetails[index].amount);
          tax.get('isIncludedInRates').setValue(this.hotelData.taxDetails[index].isIncludedInRates);
        });

      });
    }
  }

  saveContract() {
    const startDate = new Date(this.hotelDetailsContractGroup.get('startDate').value.trim());
    const endDate = new Date(this.hotelDetailsContractGroup.get('endDate').value.trim());

    if (this.contractType === this.nonMg) {
      this.contractHotelDetailsViewModel = {
        id: 0,
        name: this.hotelDetailsContractGroup.get('contractNameEntered').value,
        startDate: startDate.toISOString(),
        endDate: endDate.toISOString(),
        objectState: ObjectState.Added,
        hotelId: this.hotelDetailsContractGroup.get('hotelId').value,
        contractType: this.contractType,
        pdfLink: 'xyz '
      };
      this.contractHotelDetailsDataService.addNonMgContract(this.contractHotelDetailsViewModel as ContractHotelDetailsViewModel)
        .subscribe(data => {
          this.router.navigate(['/contractmgmt/contracts']);
          this.snackBar.open('NonMG Contract Saved Successfully', '',
          { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
    } else if (this.contractType === this.mgDynamic) {
      this.contractHotelDetailsViewModel = {
        id: 0,
        name: this.hotelDetailsContractGroup.get('contractNameEntered').value,
        startDate: startDate.toISOString(),
        endDate: endDate.toISOString(),
        objectState: ObjectState.Added,
        hotelId: this.hotelDetailsContractGroup.get('hotelId').value,
        contractType: this.contractType,
        pdfLink: 'xyz '
      };
      this.contractHotelDetailsDataService.addDynamicContract(this.contractHotelDetailsViewModel as ContractHotelDetailsViewModel)
        .subscribe(data => {
          this.router.navigate(['/contractmgmt/contracts']);
          this.snackBar.open('Dynamic Contract Saved Successfully', '',
          { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
    } else if (this.contractType === this.mgStatic) {

      this.hotelDataSave = Object.assign({}, this.hotelData, this.hotelDetailsContractGroup.value);
      this.hotelDataSave.objectState = ObjectState.Added;
      this.hotelDataSave.isActive = true;
      this.hotelDataSave.latitude = +(this.latLong.split('/')[0]);
      this.hotelDataSave.longitude = +(this.latLong.split('/')[1]);
      this.hotelDataSave.contactDetails.forEach( (contact, index) => {
        if (index === this.rowSelected) {
          contact.isPrimary = true;
        } else {
          contact.isPrimary = false;
        }
        if (contact.contactId === null) {
          contact.contactId = 0;
        }
        contact.objectState = ObjectState.Added;
      });
      this.hotelDataSave.hotelPaymentMethodRelation.objectState = ObjectState.Added;
      this.hotelDataSave.taxDetails.forEach( tax => {
        tax.objectState = ObjectState.Added;
      });
      this.hotelDataSave.hotelPaymentMethodRelation.hotelPaymentMethodRelationId =
                                            this.hotelData.hotelPaymentMethodRelation.hotelPaymentMethodRelationId;

      this.staticContractHotelDetailsVieModel = {
        templateId: this.templateId,
        contractId: 0,
        name: this.hotelDetailsContractGroup.get('contractNameEntered').value,
        startDate: startDate.toISOString(),
        endDate: endDate.toISOString(),
        objectState: ObjectState.Added,
        hotelDetailsViewModel: this.hotelDataSave,
        contractType: this.contractType,
        isDeleted: false
      };
      this.contractHotelDetailsDataService.addStaticContract(this.staticContractHotelDetailsVieModel as StaticContractHotelDetailsVieModel)
        .subscribe(data => {
          this.router.navigate(['/contractmgmt/contracts']);
          this.snackBar.open('Static Contract Saved Successfully', '',
          { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
    }
  }

  /* ---------- Filter Hotel Ends ---------------- */

  /* ---------- Get Master Data -------------- */
  getHotelBrands(chainId) {
    this.lookupService.getHotelBrands(chainId).subscribe(hotelBrandData => {
      this.hotelBrandList = hotelBrandData;
    });
  }

  getCountries() {
    this.lookupService.getCountries().subscribe(countriesData => {
      this.countriesList = countriesData;
    });
  }

  getCities(countryId) {
    this.lookupService.getCities(countryId).subscribe(citiesData => {
      this.citiesList = citiesData;
    });
  }

  getHotelTypes() {
    this.lookupService.getHotelTypes().subscribe(hotelTypeData => {
      this.hotelTypeList = hotelTypeData;
    });
  }

  getHotelChains() {
    this.lookupService.getHotelChains().subscribe(hotelChainData =>
      this.hotelChainList = hotelChainData
    );
  }

  getContactTitles() {
    this.lookupService.getDesignation().subscribe(contactTitleData =>
      this.contactPersonTitleList = contactTitleData
    );
  }

  getCurrency() {
    this.lookupService.getCurrency().subscribe(currencyData =>
      this.currencyList = currencyData
    );
  }

  getPaymentMethod() {
    this.lookupService.getPaymentMethod().subscribe(paymentData => {
      this.paymentMethodList = paymentData;
    });
  }

  getRateType() {
    this.lookupService.getRateType().subscribe(rateTypeData => {
      this.rateTypeList = rateTypeData;
    });
  }

  getChannelManager() {
    this.lookupService.getChannelManager().subscribe(channelManagerData =>
      this.channelManagerList = channelManagerData
    );
  }

  getTaxApplicability() {
    this.lookupService.getTaxApplicability().subscribe(taxesApplicabilityData =>
      this.taxesApplicabilityList = taxesApplicabilityData
    );
  }

  getStarRating() {
    this.lookupService.getStarRating().subscribe(starRatingData => {
      this.starRatingList = starRatingData;
    });
  }
  /* ---------- Get Master Data Ends -------------- */

  backToList() {
     this.router.navigate(['/contractmgmt/contracts']);
  }

}
