import { Injectable } from '@angular/core';
import { BackofficeLookupService } from './backoffice-lookup';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { HotelNameViewModel } from '../../../viewmodel/usersviewmodel/hotelnameviewmodel';

@Injectable()
export class HotelResolverService {

  constructor(private backOfficeLookUpService: BackofficeLookupService) { }

  resolve(route: ActivatedRouteSnapshot,
          state: RouterStateSnapshot): Observable<HotelNameViewModel[]> {
            return this.backOfficeLookUpService.getIndividualHotels();
          }
}
