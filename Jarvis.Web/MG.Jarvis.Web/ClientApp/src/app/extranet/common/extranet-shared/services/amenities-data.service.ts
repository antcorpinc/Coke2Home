import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { Observable } from 'rxjs/Observable';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { AmenitiesGroupViewModel } from '../../../viewmodel/amenitiesviewmodel/amenitiesgroupviewmodel';
import { RoomTypeViewModel } from '../../../viewmodel/amenitiesviewmodel/roomtypeviewmodel';
import { HotelDataService } from './hotel-data.service';
import { AmenitiesHotelViewModel } from '../../../viewmodel/amenitiesviewmodel/amenitieshotelviewmodel';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class AmenitiesDataService {

  amenitiesGroupDto: AmenitiesGroupViewModel[];
  roomTypeListDto: RoomTypeViewModel[];

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private portalService: PortalService,
    private hotelDataService: HotelDataService) { }

  getAmenities(hotelId): Observable<AmenitiesGroupViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Amenities/GetRoomFacilityGroups/', hotelId).map(data => {
        this.amenitiesGroupDto = data.result;
        return this.amenitiesGroupDto;
      });
  }

  addAmenities(amenitiesGroup: AmenitiesGroupViewModel[]): Observable<number> {
    const amenities: AmenitiesHotelViewModel = {
      hotelId: this.hotelDataService.hotelId,
      facilityGroupList: amenitiesGroup
    };
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Amenities/CreateRoomFacilityRelation/', amenities)
      .do(data => console.log('All:'))
      .catch(this.handleError);
  }

  isAmenitiesExits(): Observable<any> {
    const id = this.hotelDataService.hotelId;
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Amenities/IsAmenitiesExits/', id);
  }

  getRoomsByHotelId(hotelId): Observable<RoomTypeViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/room/GetRoomsByHotelId', hotelId).map(data => {
        if (data === null) {
          this.roomTypeListDto = [];
        } else {
          this.roomTypeListDto = data.result;
        }
        return this.roomTypeListDto;
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
    return Observable.throw(errorMessage);
  }
}
