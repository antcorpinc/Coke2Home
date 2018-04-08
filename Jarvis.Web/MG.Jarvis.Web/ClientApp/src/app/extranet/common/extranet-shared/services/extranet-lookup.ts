import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { MealTypeViewModel } from '../../../viewmodel/associatemealplanviewmodel/mealtypeviewmodel';
import { Observable } from 'rxjs/Observable';
import { CuisineTypeViewModel } from '../../../viewmodel/associatemealplanviewmodel/cuisinetypeviewmodel';
import { HotelCurrencyViewModel } from './../../../viewmodel/common/hotelcurrencyviewmodel';



@Injectable()
export class ExtranetLookupService {

  mealtypeDto: MealTypeViewModel[];
  cuisineTypeDto: CuisineTypeViewModel[];
  hotelCurrencyDto: HotelCurrencyViewModel[];

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private portalService: PortalService) {
  }

  getMeals(): Observable<MealTypeViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/MealPlan/GetMeals/').map(data => {
        this.mealtypeDto = data.result;
        return this.mealtypeDto;
      });
  }

  getCuisineType(): Observable<CuisineTypeViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/MealPlan/GetCuisineType/').map(data => {
        this.cuisineTypeDto = data.result;
        return this.cuisineTypeDto;
      });
  }

  getCurrencyByHotelId(hotelId: number): Observable<HotelCurrencyViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/PaymentData/GetCurrencyByHotelId', hotelId).map(data => {
        this.hotelCurrencyDto = data.result;
        return this.hotelCurrencyDto;
      });
  }
}
