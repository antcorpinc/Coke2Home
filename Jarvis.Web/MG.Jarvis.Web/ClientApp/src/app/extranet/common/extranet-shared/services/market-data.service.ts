import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { MarketCountryViewModel } from '../../../viewmodel/common/marketcountryviewmodel';
import { MarketContinentViewModel } from '../../../viewmodel/common/marketcontinentviewmodel';
import { MarketDetailsViewModel } from '../../../viewmodel/common/marketdetailsviewmodel';
import {MarketIncludedAndExcludedCountryViewModel} from '../../../viewmodel/common/marketincludedandexcludedcountryviewmodel';
import { MarketViewModel } from '../../../viewmodel/common/marketviewmodel';

@Injectable()
export class MarketDataService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private portalService: PortalService,
    private activatedRoute: ActivatedRoute) { }

    countryListDto: MarketCountryViewModel[];
    countinentListDto: MarketContinentViewModel[];
    marketIncludedAndExcludedCountriesListDto: MarketIncludedAndExcludedCountryViewModel[];
    marketListDto: MarketViewModel[];

  getCountries(): Observable<MarketCountryViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/MasterData/GetCountries').map(data => {
        if (data === null) {
          this.countryListDto = [];
        } else {
          this.countryListDto = data.result;
        }
        return this.countryListDto;
      });
  }

  getContinents(): Observable<MarketContinentViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/MasterData/GetContinents').map(data => {
        if (data === null) {
          this.countinentListDto = [];
        } else {
          this.countinentListDto = data.result;
        }
        return this.countinentListDto;
      });
  }

  getMarkets(): Observable<MarketViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/RatesCategory/GetMarkets').map(data => {
        if (data === null) {
          this.marketListDto = [];
        } else {
          this.marketListDto = data.result;
        }
        return this.marketListDto;
      });
  }

  addMarket(markettypes: MarketDetailsViewModel): Observable<any> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Market/CreateMarket', markettypes)
      .do(data => console.log('All: '))
      .catch(this.handleError)  ;
  }

  getMarketIncludedAndExcludedCountry(marketId): Observable<MarketIncludedAndExcludedCountryViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Market/GetMarketIncludedAndExcludedCountries', marketId).map(data => {
        if (data === null) {
          this.marketIncludedAndExcludedCountriesListDto = [];
        } else {
          this.marketIncludedAndExcludedCountriesListDto = data.result;
        }
        return this.marketIncludedAndExcludedCountriesListDto;
      });
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof Error) {
       errorMessage = `An error occurred : ${err.error.message}`;
    } else {
      errorMessage = `Server returned code : ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return Observable.throw(errorMessage);
  }

}
