import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AmenitiesDataService } from './amenities-data.service';
import { AmenitiesGroupViewModel } from '../../../viewmodel/amenitiesviewmodel/amenitiesgroupviewmodel';

@Injectable()
export class AmenitiesResolverService implements Resolve<AmenitiesGroupViewModel[]> {

  constructor(private amenitiesService: AmenitiesDataService) {
  }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<AmenitiesGroupViewModel[]> {

    const hotelId = route.parent.params['id'];
    return this.amenitiesService.getAmenities(hotelId);
  }

}
