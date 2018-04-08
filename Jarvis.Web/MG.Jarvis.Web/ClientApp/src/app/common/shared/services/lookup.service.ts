import { Injectable } from '@angular/core';
import {AuthenticatedHttpService} from './authenticated-http.service';
import { CountryViewModel } from '../../viewmodels/countryviewmodel';
import { PortalService } from './portal.service';
import { CityViewModel } from '../../viewmodels/cityviewmodel';
import { HotelTypeViewModel } from '../../viewmodels/hoteltypeviewmodel';
import { HotelBrandViewModel } from '../../viewmodels/hotelbrandviewmodel';
import { HotelChainViewModel } from '../../viewmodels/hotelchainviewmodel';
import { ChannelManagerViewModel } from '../../../extranet/viewmodel/hoteldetailsviewmodel/channelmanagerviewmodel';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { ContactPersonTitleViewModel } from '../../viewmodels/contactpersontitleviewmodel';
import { CurrencyViewModel } from '../../viewmodels/currencyviewmodel';
import { PaymentMethodViewModel } from '../../../extranet/viewmodel/hoteldetailsviewmodel/paymentmethodviewmodel';
import { RateTypeViewModel } from '../../../extranet/viewmodel/hoteldetailsviewmodel/ratetypeviewmodel';
import { TaxesViewModel } from '../../../extranet/viewmodel/hoteldetailsviewmodel/taxesviewmodel';
import { TaxesApplicabilityViewModel } from '../../../extranet/viewmodel/hoteldetailsviewmodel/taxesapplicabilityviewmodel';
import { StarRatingViewModel } from '../../../extranet/viewmodel/hoteldetailsviewmodel/starratingviewmodel';
// import { RoomTypeViewModel } from '../../viewmodels/roomtypeviewmodel';

export interface ILookupService {
   getCountries();
}

@Injectable()
export class LookupService  {

  countriesDto: CountryViewModel[];
  citiesDto: CityViewModel[];
  hotelTypesDto: HotelTypeViewModel[];
  hotelChainDto: HotelChainViewModel[];
  hotelBrandDto: HotelBrandViewModel[];
  contactTitleDto: ContactPersonTitleViewModel[];
  paymentMethodDto: PaymentMethodViewModel[];
  currencyDto: CurrencyViewModel[];
  rateTypeDto: RateTypeViewModel[];
  channelmanagerDto: ChannelManagerViewModel[];
  taxTypeDto: TaxesViewModel[];
  taxApplicabilityDto: TaxesApplicabilityViewModel[];
  starRatingDto: StarRatingViewModel[];
  // roomsDto: RoomTypeViewModel[];

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
              private portalService: PortalService
             ) {

  }

  getCountries(): Observable<CountryViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/MasterData/GetCountries/').map( data => {
       // data.json();
       this.countriesDto = data.result;
       console.log('Country at service', this.countriesDto);
      return this.countriesDto;
  });
  }

  getCities(countryId): Observable<CityViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
         + 'api/MasterData/GetCities?id=' + countryId).map( data => {
       this.citiesDto = data.result;
       console.log('Cities at service', this.citiesDto);
      return this.citiesDto;
  });
  }

  getHotelTypes(): Observable<HotelTypeViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/MasterData/GetHoteltypes/').map( data => {
      this.hotelTypesDto = data.result;
      console.log('Type at service', this.hotelTypesDto);
      return this.hotelTypesDto;
  });
  }

  getHotelChains(): Observable<HotelChainViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/MasterData/GetHotelChains/').map( data => {
      this.hotelChainDto = data.result;
      console.log('Chain at service', this.hotelChainDto);
      return this.hotelChainDto;
  });
  }

  getHotelBrands(chainId): Observable<HotelBrandViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/MasterData/GetHotelBrands?id=' + chainId).map( data => {
      this.hotelBrandDto = data.result;
      console.log('Brand at service', this.hotelBrandDto);
      return this.hotelBrandDto;
  });
  }

  getDesignation(): Observable<ContactPersonTitleViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/Miscellaneous/GetDesignation/', '').map( data => {
      this.contactTitleDto = data.result;
      console.log('Contact at service', this.contactTitleDto);
      return this.contactTitleDto;
  });
  }

  getCurrency(): Observable<CurrencyViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/PaymentData/GetCurrency/').map( data => {
      this.currencyDto = data.result;
      return this.currencyDto;
  });
  }

  getPaymentMethod(): Observable<PaymentMethodViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/PaymentData/GetPaymentMethod/').map( data => {
      this.paymentMethodDto = data.result;
      return this.paymentMethodDto;
  });
}

  getRateType(): Observable<RateTypeViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/PaymentData/GetRateType/').map( data => {
      this.rateTypeDto = data.result;
      return this.rateTypeDto;
  });
  }

  getChannelManager(): Observable<ChannelManagerViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/Miscellaneous/GetChannelManager/').map( data => {
      this.channelmanagerDto = data.result;
      return this.channelmanagerDto;
  });
  }

  getTaxType(): Observable<TaxesViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/PaymentData/GetTaxType/').map( data => {
      this.taxTypeDto = data.result;
      return this.taxTypeDto;
  });
  }

  getTaxApplicability(): Observable<TaxesApplicabilityViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/PaymentData/GetTaxApplicability/').map( data => {
      this.taxApplicabilityDto = data.result;
      return this.taxApplicabilityDto;
  });
  }

  getStarRating(): Observable<StarRatingViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/MasterData/GetStarRating/').map( data => {
      this.starRatingDto = data.result;
      return this.starRatingDto;
  });
  }

  // getRooms(hotelId): Observable<RoomTypeViewModel[]> {
  //   return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
  //        + 'api/room/GetRoomsByHotelId?id=' + hotelId).map( data => {
  //      this.roomsDto = data.result;
  //     return this.roomsDto;
  //   });
  // }

}
