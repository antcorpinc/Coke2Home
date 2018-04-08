import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { Observable } from 'rxjs/Observable';
import { FacilityGroupViewModel } from '../../../viewmodel/facilitiesservicesviewmodel/facilitygroupviewmodel';
import { HotelDataService } from './hotel-data.service';
import { FacilitiesViewModel } from '../../../viewmodel/facilitiesservicesviewmodel/facilitiesviewmodel';
import { HttpErrorResponse } from '@angular/common/http';
@Injectable()
export class FacilitiesServicesService {

  facilityGroupDto: FacilityGroupViewModel[];

  constructor(private authenticatedHttpService: AuthenticatedHttpService, private portalService: PortalService,
                            private hotelDataService: HotelDataService) { }

  getFacilitiesAndServices(hotelId): Observable<FacilityGroupViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/Facilities/GetHotelFacilityGroups/' , hotelId).map( data => {
       this.facilityGroupDto = data.result;
      //  console.log('Country at service', this.facilityGroupDto);
      return this.facilityGroupDto;
    });
  }

  addFacilities(facilitiesGroup: FacilityGroupViewModel[]): Observable<number> {
    const facilities: FacilitiesViewModel = {
      hotelId : this.hotelDataService.hotelId,
      facilityGroupList: facilitiesGroup
    };
    // console.log(JSON.stringify(facilities));
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Facilities/CreateHotelFacilityRelation/', facilities)
      .do(data => console.log('All: '))
      .catch(this.handleError)  ;
  }

  isFacilityExits(): Observable<any> {
    const id = this.hotelDataService.hotelId;
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Facilities/IsHotelFacilityExits/', id);
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
