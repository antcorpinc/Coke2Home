import { Injectable } from '@angular/core';
import { HotelsNameList } from '../../../../viewmodel/contracts/hoteldetails/hotelsnamelist';
import { Observable } from 'rxjs/Observable';
import { AuthenticatedHttpService } from '../../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../../common/shared/services/portal.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ContractHotelDetailsViewModel } from '../../../../viewmodel/contracts/hoteldetails/contracthoteldetailsviewmodel';
import { StaticContractHotelDetailsVieModel } from '../../../../viewmodel/contracts/hoteldetails/staticcontracthoteldetailsviewmodel';

@Injectable()
export class ContractHotelDetailsDataService {

  hotelsNameList: HotelsNameList[];

  constructor(private authenticatedHttpService: AuthenticatedHttpService, private portalService: PortalService) { }

  getAllHotelsName(): Observable<HotelsNameList[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/HotelManagement/GetAllHotelNames/').map( data => {
       this.hotelsNameList = data.result;
      return this.hotelsNameList;
    });
  }

  addNonMgContract(nonMgContractDetails: ContractHotelDetailsViewModel): Observable<number> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Contracts/CreateNonMGContract/', nonMgContractDetails)
      .do(data => console.log('All: '))
      .catch(this.handleError)  ;
  }

  addDynamicContract(dynamicContractDetails: ContractHotelDetailsViewModel): Observable<number> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Contracts/CreateMGDynamicContract/', dynamicContractDetails)
      .do(data => console.log('All: '))
      .catch(this.handleError)  ;
  }

  addStaticContract(staticContractDetails: StaticContractHotelDetailsVieModel): Observable<number> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Contracts/CreateStaticContract/', staticContractDetails)
      .do(data => console.log('All: '))
      .catch(this.handleError)  ;
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
