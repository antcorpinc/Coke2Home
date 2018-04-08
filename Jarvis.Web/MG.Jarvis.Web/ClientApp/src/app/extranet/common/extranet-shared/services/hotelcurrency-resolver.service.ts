import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ExtranetLookupService } from './extranet-lookup';
import { Observable } from 'rxjs/Observable';
import { HotelCurrencyViewModel } from '../../../viewmodel/common/hotelcurrencyviewmodel';

@Injectable()
export class HotelcurrencyResolverService implements Resolve<HotelCurrencyViewModel[]> {

  constructor(private extranetLookupService: ExtranetLookupService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<HotelCurrencyViewModel[]> {
    const hotelId = route.parent.params['id'];
    return this.extranetLookupService.getCurrencyByHotelId(hotelId);
  }

}
