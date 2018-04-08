import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AmenitiesDataService } from './amenities-data.service';
import { AmenitiesGroupViewModel } from '../../../viewmodel/amenitiesviewmodel/amenitiesgroupviewmodel';
import { RoomTypeViewModel } from '../../../viewmodel/amenitiesviewmodel/roomtypeviewmodel';

@Injectable()
export class HotelRoomResolverService implements Resolve<RoomTypeViewModel[]> {

  constructor(private amenitiesService: AmenitiesDataService) {
  }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<RoomTypeViewModel[]> {

    const hotelId = route.parent.params['id'];
    return this.amenitiesService.getRoomsByHotelId(hotelId);
  }

}
