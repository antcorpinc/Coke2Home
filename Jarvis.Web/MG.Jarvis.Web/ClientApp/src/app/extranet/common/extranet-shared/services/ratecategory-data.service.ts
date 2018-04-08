import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { RoomListViewModel } from '../../../viewmodel/ratecategoryviewmodel/roomlistviewmodel';
import { CancellationPolicyListViewModel } from '../../../viewmodel/ratecategoryviewmodel/CancellationPolicyListViewModel';
import { MealTypeViewModel } from '../../../viewmodel/associatemealplanviewmodel/MealTypeViewModel';
import { RateCategoryListViewModel } from '../../../viewmodel/ratecategoryviewmodel/RateCategoryListViewModel';
import { RateCategoryInfoViewModel } from '../../../viewmodel/ratecategoryviewmodel/RateCategoryInfoViewModel';

@Injectable()
export class RatecategoryDataService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private portalService: PortalService,
    private activatedRoute: ActivatedRoute) { }

    rateCategoryListDto: RateCategoryListViewModel[];
    roomListDto: RoomListViewModel[];
    cancellationPolicyListDto: CancellationPolicyListViewModel[];
    mealListDto: MealTypeViewModel[];
    rateInfoDto: RateCategoryInfoViewModel;

    getRateCategory(hotelId): Observable<RateCategoryListViewModel[]> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/RatesCategory/GetRateCategory', hotelId).map(data => {
          if (data === null) {
            this.rateCategoryListDto = [];
          } else {
            this.rateCategoryListDto = data.result;
          }
          return this.rateCategoryListDto;
        });
    }

    getRooms(hotelId): Observable<RoomListViewModel[]> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/room/GetRoomsByHotelId', hotelId).map(data => {
          if (data === null) {
            this.roomListDto = [];
          } else {
            this.roomListDto = data.result;
          }
          return this.roomListDto;
        });
    }

    getCancellationPolicies(hotelId): Observable<CancellationPolicyListViewModel[]> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/policies/GetCancellationPolicy', hotelId).map(data => {
          if (data === null) {
            this.cancellationPolicyListDto = [];
          } else {
            this.cancellationPolicyListDto = data.result;
          }
          return this.cancellationPolicyListDto;
        });
    }

    getMeal(): Observable<MealTypeViewModel[]> {
      return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/MealPlan/GetMeals').map(data => {
          if (data === null) {
            this.mealListDto = [];
          } else {
            this.mealListDto = data.result;
          }
          return this.mealListDto;
        });
    }

    getRateDetails(rateId: number): Observable<RateCategoryInfoViewModel> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/RatesCategory/GetRateCategoryById', rateId).map(data => {
          this.rateInfoDto = data.result;
          return this.rateInfoDto;
      });
    }

    addRateCategory(roomtypes: RateCategoryInfoViewModel): Observable<any> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/RatesCategory/CreateRateCategory', roomtypes)
        .do(data => console.log('All: '))
        .catch(this.handleError)  ;
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
