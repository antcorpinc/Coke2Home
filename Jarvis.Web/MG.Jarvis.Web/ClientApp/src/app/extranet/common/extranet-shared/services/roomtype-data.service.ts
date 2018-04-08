import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { HotelDetailsViewModel } from '../../../viewmodel/hoteldetailsviewmodel/hoteldetailsviewmodel';
import { RoomTypeListViewModel } from '../../../viewmodel/roomtypeviewmodel/roomtypelistviewmodel';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HotelDataService } from './hotel-data.service';
import { RoomTypeViewModel } from '../../../viewmodel/roomtypeviewmodel/RoomTypeViewModel';
import { SizeMeasureViewModel } from '../../../viewmodel/roomtypeviewmodel/SizeMeasureViewModel';
import { BedsViewModel } from '../../../viewmodel/roomtypeviewmodel/BedsViewModel';
import { OccupancyViewModel } from '../../../viewmodel/roomtypeviewmodel/OccupancyViewModel';
import { HotelRoomTypeViewModel } from '../../../viewmodel/roomtypeviewmodel/HotelRoomTypeViewModel';
import { HttpErrorResponse } from '@angular/common/http';


@Injectable()
export class RoomtypeDataService {
  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private portalService: PortalService,
    private activatedRoute: ActivatedRoute,
    private hotelDataService: HotelDataService) { }
  roomTypeDto: RoomTypeViewModel[];
  sizeMeasureDto: SizeMeasureViewModel[];
  bedsDto: BedsViewModel[];
  occupancyDto: OccupancyViewModel[];
  roomTypeListDto: RoomTypeListViewModel[];
  roomInfoDto: HotelRoomTypeViewModel;

  getRooms(hotelId): Observable<RoomTypeListViewModel[]> {
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

  getRoomTypes(): Observable<RoomTypeViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/room/GetRoomType').map(data => {
        this.roomTypeDto = data.result;
        return this.roomTypeDto;
      });
  }

  getSizeMeasure(): Observable<SizeMeasureViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/room/GetSizeMeasure').map(data => {
        this.sizeMeasureDto = data.result;
        return this.sizeMeasureDto;
      });
  }

  getBeds(): Observable<BedsViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/room/GetBed').map(data => {
        this.bedsDto = data.result;
        return this.bedsDto;
      });
  }

  getOccupancy(): Observable<OccupancyViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/room/GetOccupancy').map(data => {
        this.occupancyDto = data.result;
        return this.occupancyDto;
      });
  }

  addRoom(roomtypes: HotelRoomTypeViewModel): Observable<number> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/room/CreateRoomType', roomtypes)
      .do(data => console.log('All: '))
      .catch(this.handleError)  ;
  }

  getRoom(roomId: number): Observable<HotelRoomTypeViewModel> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/room/GetRoomDetailsByRoomId', roomId).map(data => {
        this.roomInfoDto = data.result;
        return this.roomInfoDto;
    });
  }

  deleteRoomBedRelation(id: number): Observable<number> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/room/DeleteRoomBedRelationById ', id)
      .do(data => console.log('All: '))
      .catch(this.handleError)  ;
  }

  deleteroom(roomeId: number): Observable<boolean> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/room/DeleteRoomById', roomeId);
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof Error) {
       errorMessage = `An error occurred 1: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code 1: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return Observable.throw(errorMessage);
  }

}
