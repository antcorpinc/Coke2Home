import { Component, OnInit, Input } from '@angular/core';
import { HotelNavMenuComponent } from '../../hotel-mgmt/hotel-nav-menu/hotel-nav-menu.component';
import { ContactDetailsViewModel } from '../../viewmodel/hoteldetailsviewmodel/contactdetailsviewmodel';
import { HotelDetailsViewModel } from '../../viewmodel/hoteldetailsviewmodel/hoteldetailsviewmodel';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { CountryViewModel } from '../../../common/viewmodels/countryviewmodel';
import { LookupService } from '../../../common/shared/services/lookup.service';
import { CityViewModel } from '../../../common/viewmodels/cityviewmodel';
import { HotelTypeViewModel } from '../../../common/viewmodels/hoteltypeviewmodel';
import { HotelBrandViewModel } from '../../../common/viewmodels/hotelbrandviewmodel';
import { HotelChainViewModel } from '../../../common/viewmodels/hotelchainviewmodel';
import { ContactPersonTitleViewModel } from '../../../common/viewmodels/contactpersontitleviewmodel';
import { HotelDataService } from '../../common/extranet-shared/services/hotel-data.service';
import { ChannelManagerViewModel } from '../../viewmodel/hoteldetailsviewmodel/channelmanagerviewmodel';
import { MatSnackBar } from '@angular/material';
import { PaymentMethodViewModel } from '../../viewmodel/hoteldetailsviewmodel/paymentmethodviewmodel';
import { CurrencyViewModel } from '../../../common/viewmodels/currencyviewmodel';
import { RateTypeViewModel } from '../../viewmodel/hoteldetailsviewmodel/ratetypeviewmodel';
import { MatTableDataSource } from '@angular/material';
import { TaxesApplicabilityViewModel } from '../../viewmodel/hoteldetailsviewmodel/taxesapplicabilityviewmodel';
import { TaxesViewModel } from '../../viewmodel/hoteldetailsviewmodel/taxesviewmodel';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MapsdialogComponent } from '../mapsdialog/mapsdialog.component';
import { CONSTANTS } from '../../../common/constants';
import { ObjectState } from '../../../common/enums';
import { StarRatingViewModel } from '../../viewmodel/hoteldetailsviewmodel/starratingviewmodel';
import { HotelPaymentMethodRelationViewModel } from '../../viewmodel/hoteldetailsviewmodel/hotelpaymentmethodrelationviewmodel';
import { EXTRANETCONSTANTS } from '../../common/constants';
import { UserProfileService } from '../../../common/shared/services/user-profile.service';

declare var google: any;
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
  hotelId: string;
  hotelDetails: HotelDetailsViewModel = <HotelDetailsViewModel>{};
  contacts: Array<ContactDetailsViewModel> = [];
  hotelPaymentMethodRelation: HotelPaymentMethodRelationViewModel = <HotelPaymentMethodRelationViewModel>{};
  newContact: any = {};
  rowselected: any = 0;
  newContactLength: any = 0;
  latLong: any;
  geocoder = null;
  mapCity = [];
  mapCountry = [];
  mapCityName = '';
  mapCountryName = '';
  mapCountryId = null;
  btnLatLng = true;
  mapAddress = '';
  disable = true;
  checkInCheckOut = EXTRANETCONSTANTS.arrCheckInCheckOut;
  isPrimaryId: number;
  countriesList: CountryViewModel[];
  citiesList: CityViewModel[];
  citiesListByCountry: CityViewModel[];
  hotelTypeList: HotelTypeViewModel[];
  hotelBrandList: HotelBrandViewModel[];
  hotelChainList: HotelChainViewModel[];
  brandsListByChain: HotelBrandViewModel[];
  contactPersonTitleList: ContactPersonTitleViewModel[];
  paymentMethodList: PaymentMethodViewModel[];
  currencyList: CurrencyViewModel[];
  rateTypeList: RateTypeViewModel[];
  channelManagerList: ChannelManagerViewModel[];
  taxTypeList: TaxesViewModel[] = [];
  taxesApplicabilityList: TaxesApplicabilityViewModel[];
  starRatingList: StarRatingViewModel[];
  deleteView = false;
  createView = false;
  readView = false;
  privileges: string[];

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    public snackBar: MatSnackBar, public lookupService: LookupService, private hotelDataService: HotelDataService
    , public dialog: MatDialog, private userProfileService: UserProfileService) {

  }

  ngOnInit() {
    window.scrollTo(0, 0);
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
    this.getPrivileges();

    this.hotelDetails.isActive = true;
    this.hotelDetails.hotelBrandId = null;
    this.hotelDetails.hotelChainId = null;
    this.hotelDetails.hotelTypeId = null;
    this.hotelDetails.cityId = null;
    this.hotelDetails.countryId = null;
    this.hotelDetails.isExtranetAccess = true;
    this.hotelDetails.isChannelManagerConnectivity = false;
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];

    if (this.operation.toLowerCase().trim() === create) {
      this.getTaxType();
      this.hotelDetails.isActive = true;
      this.hotelDetails.hotelBrandId = null;
      this.hotelDetails.hotelChainId = null;
      this.hotelDetails.hotelTypeId = null;
      this.hotelDetails.cityId = null;
      this.hotelDetails.countryId = null;
      this.hotelDetails.checkInFrom = '10:00 AM';
      this.hotelDetails.checkOutTo = '12:00 PM';

      // Update the Object State to Added when creating new Hotel
      this.newContact.objectState = ObjectState.Added;
      this.hotelPaymentMethodRelation.objectState = ObjectState.Added;
      this.hotelDetails.objectState = ObjectState.Added;
    }

    if (this.operation.toLowerCase().trim() === read) {
      this.isRead = true;
      this.btnLatLng = true;
    }

    if (this.operation.toLowerCase().trim() === edit) {
      this.btnLatLng = false;
    }

    if (this.operation.toLowerCase().trim() === read ||
      this.operation.toLowerCase().trim() === edit) {
      if (this.hotelDataService.hotelDetails !== undefined) {
        this.hotelDetails = this.hotelDataService.hotelDetails;
        this.hotelDetails.objectState = ObjectState.Unchanged;
        this.getHotelBrands(this.hotelDetails.hotelChainId);
        this.getCities(this.hotelDetails.countryId);
        this.latLong = this.hotelDetails.latitude + '/' + this.hotelDetails.longitude;
        for (let i = 0; i < this.hotelDetails.contactDetails.length; i++) {
          if (i < this.hotelDetails.contactDetails.length - 1) {
            this.contacts[i] = this.hotelDetails.contactDetails[i];
          } else {
            this.newContact = this.hotelDetails.contactDetails[i];
            this.newContactLength = this.contacts.length;
          }
          if (this.hotelDetails.contactDetails[i].isPrimary === true) {
            this.isPrimaryId = i;
            this.rowselected = i;
          }
        }
        this.hotelPaymentMethodRelation = this.hotelDetails.hotelPaymentMethodRelation;
        this.taxTypeList = this.hotelDetails.taxDetails;

        // Update the Object State to Unchanged on read & edit
        this.hotelDetails.taxDetails.forEach(tax => {
          tax.objectState = ObjectState.Unchanged;
        });
        this.hotelDetails.hotelPaymentMethodRelation.objectState = ObjectState.Unchanged;
        this.hotelDetails.contactDetails.forEach(contact => {
          contact.objectState = ObjectState.Unchanged;
        });
      }
    }
  }

  addContact() {
    this.contacts.push(this.newContact);
    this.newContact = {};
    this.newContact.objectState = ObjectState.Added;
    const contactLength = this.contacts.length;
    this.newContactLength = contactLength;
  }

  saveHotelDetails() {
    // Contact Details
    this.hotelDetails.contactDetails = [];
    for (let i = 0; i < this.contacts.length; i++) {
      this.hotelDetails.contactDetails.push(this.contacts[i]);
    }
    this.hotelDetails.contactDetails.push(this.newContact);
    for (let i = 0; i < this.hotelDetails.contactDetails.length; i++) {
      if (i === this.rowselected) {
        this.hotelDetails.contactDetails[i].isPrimary = true;
      } else {
        this.hotelDetails.contactDetails[i].isPrimary = false;
      }
    }
    if (this.operation.toLowerCase().trim() === edit) {
      if (this.hotelDetails.contactDetails[this.isPrimaryId].isPrimary === false) {
        this.hotelDetails.contactDetails[this.isPrimaryId].objectState = ObjectState.Modified;
      }
  }

    // Payment Details
    this.hotelDetails.hotelPaymentMethodRelation = this.hotelPaymentMethodRelation;
    // taxes Detail
    this.hotelDetails.taxDetails = this.taxTypeList;
    // Latitude/Longitude
    this.hotelDetails.latitude = +(this.latLong.split('/')[0]);
    this.hotelDetails.longitude = +(this.latLong.split('/')[1]);

    // Hotel Detail
    if (this.checkIfAllUnchanged()) {
      this.router.navigate(['/hotelmgmt/redirect']);
      window.scrollTo(0, 0);
    } else {
    this.hotelDataService.addHotelDetails(this.hotelDetails as HotelDetailsViewModel).subscribe(
      (response) => {
        this.router.navigate(['/hotelmgmt/redirect', response]);
        this.snackBar.open('Hotel Saved Successfully', 'close', {
          duration: 8000, verticalPosition: 'top',
          horizontalPosition: 'center'
        });
        window.scrollTo(0, 0);
      }
    );
  }
    localStorage.removeItem('mapGeocodeLat');
    localStorage.removeItem('mapGeocodeLng');
    localStorage.removeItem('retLat');
    localStorage.removeItem('retLng');
  }

  cancelHotelDetails() {
    this.router.navigate(['/hotelmgmt/hotels']);
    window.scrollTo(0, 0);
  }

  getCountries() {
    this.lookupService.getCountries().subscribe(countriesData => {
      this.countriesList = countriesData;
    });
  }

  getCities(countryId) {
    if (this.operation.toLowerCase().trim() === create) {
      this.hotelDetails.cityId = null;
    }
    this.lookupService.getCities(countryId).subscribe(citiesData => {
      this.citiesList = citiesData;
    });
  }

  getHotelTypes() {
    this.lookupService.getHotelTypes().subscribe(hotelTypeData => {
      this.hotelTypeList = hotelTypeData;
    });
  }

  getHotelBrands(chainId) {
    if (this.operation.toLowerCase().trim() === create) {
      this.hotelDetails.hotelBrandId = null;
    }
    if (chainId === null) {
      this.hotelDetails.hotelBrandId = null;
    } else {
      this.lookupService.getHotelBrands(chainId).subscribe(hotelBrandData =>
        this.hotelBrandList = hotelBrandData
      );
    }
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

  getLatLng(cityId) {
    this.latLong = '';
    localStorage.removeItem('mapGeocodeLat');
    localStorage.removeItem('mapGeocodeLng');
    localStorage.removeItem('retLat');
    localStorage.removeItem('retLng');
    this.geocoder = null;
    this.geocoder = new google.maps.Geocoder();
    this.mapAddress = '';
    this.btnLatLng = false;
    this.flagHotelDetailsAsEdited();

    if (cityId !== null) {
      this.mapCity = this.citiesList.filter(mcity => mcity.cityId === cityId);
      this.mapCityName = this.mapCity[0].cityName;
      this.mapCountryId = this.mapCity[0].countryId;
      this.mapCountry = this.countriesList.filter(mcountry => mcountry.countryId === this.mapCountryId);
      this.mapCountryName = this.mapCountry[0].countryName;
      if ((this.hotelDetails.address1 === undefined)
        || (this.hotelDetails.address2 === undefined)) {
        this.mapAddress = this.mapCityName + ',' + this.mapCountryName;
      } else {
        this.mapAddress = this.hotelDetails.address1 + ',' + this.hotelDetails.address2
          + ',' + this.mapCityName + ',' + this.mapCountryName;
      }
      this.geocoder.geocode({ 'address': this.mapAddress }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
          this.latitude = results[0].geometry.location.lat().toFixed(6);
          this.longitude = results[0].geometry.location.lng().toFixed(6);
          localStorage.setItem('mapGeocodeLat', this.latitude);
          localStorage.setItem('mapGeocodeLng', this.longitude);
        } else {
          this.btnLatLng = true;
          this.latLong = '0/0';
        }
      });
    } else {
      this.latLong = '0/0';
    }
  }

  openMap(): void {
    let mapGLat: any;
    let mapGLng: any;
    if (this.latLong === undefined || this.latLong === '') {
      mapGLat = localStorage.getItem('mapGeocodeLat');
      mapGLng = localStorage.getItem('mapGeocodeLng');
    } else {
      mapGLat = +(this.latLong.split('/')[0]);
      mapGLng = +(this.latLong.split('/')[1]);
    }
    const mapdialogRef = this.dialog.open(MapsdialogComponent, {
      width: '100%',
      height: '560px',
      data: { latitude: +mapGLat, longitude: +mapGLng }
    });
    mapdialogRef.afterClosed().subscribe(result => {
      const retResult = `${result}`;
      if (retResult !== 'undefined' && retResult !== 'unselected') {
        const parseresult = JSON.parse(result);
        this.latLong = parseresult.Lat + '/' + parseresult.Lng;
      } else {
        if (mapGLat === null || mapGLng === null) {
          mapGLat = 0;
          mapGLng = 0;
        }
        this.latLong = mapGLat + '/' + mapGLng;
      }
    });
  }

  getCurrency() {
    this.lookupService.getCurrency().subscribe(currencyData =>
      this.currencyList = currencyData
    );
  }

  getPaymentMethod() {
    this.lookupService.getPaymentMethod().subscribe(paymentData => {
      if (this.operation.toLowerCase().trim() === create) {
        this.hotelPaymentMethodRelation.paymentMethodId = paymentData[0].id;
      }
      this.paymentMethodList = paymentData;
    });
  }

  getRateType() {
    this.lookupService.getRateType().subscribe(rateTypeData => {
      if (this.operation.toLowerCase().trim() === create) {
        this.hotelPaymentMethodRelation.rateTypeId = rateTypeData[0].id;
      }
      this.rateTypeList = rateTypeData;
    });
  }

  isChannelManager(selected) {
    this.flagHotelDetailsAsEdited();
    if (!selected) {
      this.disable = true;
      this.hotelDetails.channelManagerId = null;
    } else {
      this.disable = false;
    }
  }

  getChannelManager() {
    this.lookupService.getChannelManager().subscribe(channelManagerData =>
      this.channelManagerList = channelManagerData
    );
  }

  getTaxType() {
    this.lookupService.getTaxType().subscribe((taxTypeData) => {
      for (let i = 0; i < taxTypeData.length; i++) {
        this.taxTypeList.push({
          'taxTypeId': taxTypeData[i]['id'],
          'taxesType': taxTypeData[i]['name'],
          'taxApplicabilityId': 1,
          'amount': 0,
          'isIncludedInRates': true,
          'objectState': ObjectState.Added
        });
      }
    });
  }

  getTaxApplicability() {
    this.lookupService.getTaxApplicability().subscribe(taxesApplicabilityData =>
      this.taxesApplicabilityList = taxesApplicabilityData
    );
  }

  getStarRating() {
    this.lookupService.getStarRating().subscribe(starRatingData => {
      if (this.operation.toLowerCase().trim() === create) {
        this.hotelDetails.starRatingId = starRatingData[0].hotelStarRatingId;
      }
      this.starRatingList = starRatingData;
    });
  }

  flagHotelDetailsAsEdited() {
    if (this.hotelDetails.objectState !== ObjectState.Added) {
      this.hotelDetails.objectState = ObjectState.Modified;
    }
  }

  flagPaymentDetailsAsEdited() {
    if (this.hotelPaymentMethodRelation.objectState !== ObjectState.Added) {
      this.hotelPaymentMethodRelation.objectState = ObjectState.Modified;
    }
  }

  flagTaxDetailsAsEdited(index) {
    if (this.taxTypeList[index].objectState !== ObjectState.Added) {
      this.taxTypeList[index].objectState = ObjectState.Modified;
    }
  }

  flagContactDetailsAsEdited(index) {
    if (this.contacts[index].objectState !== ObjectState.Added) {
      this.contacts[index].objectState = ObjectState.Modified;
    }
  }

  flagNewContactDetailsAsEdited() {
    if (this.newContact.objectState !== ObjectState.Added) {
      this.newContact.objectState = ObjectState.Modified;
    }
  }

  checkIfAllUnchanged() {
    let allUnchangedcontact;
    let allUnchangedtaxDetail;
    let allUnchangedhotelDetails;
    const allUnchnagedtaxDetail =  [];
    const allUnchangedcontactArray = [];

    if (this.hotelDetails.objectState === ObjectState.Unchanged &&
      this.hotelDetails.hotelPaymentMethodRelation.objectState === ObjectState.Unchanged) {
        allUnchangedhotelDetails = true;
      } else {
        allUnchangedhotelDetails = false;
      }

    this.hotelDetails.contactDetails.forEach( (contact, i) => {
    if (contact.objectState === ObjectState.Unchanged) {
      allUnchangedcontactArray[i] = true;
    } else {
      allUnchangedcontactArray[i] = false;
    }
    });

    this.hotelDetails.taxDetails.forEach( (tax, i) => {
      if (tax.objectState === ObjectState.Unchanged) {
        allUnchnagedtaxDetail[i] = true;
      } else {
        allUnchnagedtaxDetail[i] = false;
      }
      });

      allUnchangedcontact = allUnchangedcontactArray.every( function (item) {
         return  item === true;
      });

      allUnchangedtaxDetail = allUnchnagedtaxDetail.every(function (item) {
      return item === true;
    });

    if (allUnchangedhotelDetails === true && allUnchangedcontact === true && allUnchangedtaxDetail === true) {
      return true;
    } else {
      return false;
    }
}

getPrivileges() {
  this.privileges = this.userProfileService.GetUserPermissionsForFeature
    (CONSTANTS.application.extranet, CONSTANTS.featuretypeid.HotelProfile);
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

GoHotelUpdate() {
  this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
  this.router.navigate(['hotelmgmt/hotel', this.hotelId, edit.trim().toLowerCase(), 'hoteldetails']);
  this.isRead = false;
}

}
