import { Injectable } from '@angular/core';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { Observable } from 'rxjs/Observable';
import { HotelDataService } from './hotel-data.service';
import { MealPlanViewModel } from '../../../viewmodel/associatemealplanviewmodel/mealplanviewmodel';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class AssociateMealplanDataService {

  mealPlanDto: MealPlanViewModel[];

  constructor(private authenticatedHttpService: AuthenticatedHttpService, private portalService: PortalService,
    private hotelDataService: HotelDataService ) { }

  isMealPlanExits(): Observable<any> {
    const id = this.hotelDataService.hotelId;
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/MealPlan/GetIsMealPlanExist/', id);
  }

  addMealPlan(associatedMealPlans: MealPlanViewModel[]): Observable<number> {
    // console.log(JSON.stringify(facilities));
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/MealPlan/CreateMealPlan/', associatedMealPlans)
      .do(data => console.log('All: '))
      .catch(this.handleError)  ;
  }

  getMealPlan(hotelId): Observable<MealPlanViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/MealPlan/GetMealPlan/', hotelId).map( data => {
       this.mealPlanDto = data.result;
      console.log('mealPlanDto', this.mealPlanDto);
      return this.mealPlanDto;
    });
  }

  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof Error) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return Observable.throw(errorMessage);
  }
}
