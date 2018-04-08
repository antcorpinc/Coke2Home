import { Injectable } from '@angular/core';
import { RatecategoryDataService } from './ratecategory-data.service';
import { RoomListViewModel } from '../../../viewmodel/ratecategoryviewmodel/roomlistviewmodel';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class RatecategoryDataResolverService implements Resolve<RoomListViewModel[]> {

  constructor(private ratecategoryDataService: RatecategoryDataService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<RoomListViewModel[]> {
    const hotelId = route.parent.params['id'];
    return this.ratecategoryDataService.getRooms(hotelId);
}

}
