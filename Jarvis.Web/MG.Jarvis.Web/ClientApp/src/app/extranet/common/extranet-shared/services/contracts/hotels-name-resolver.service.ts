import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ContractHotelDetailsDataService } from './contract-hotel-details-data.service';
import { HotelsNameList } from '../../../../viewmodel/contracts/hoteldetails/hotelsnamelist';

@Injectable()
export class HotelsNameResolverService {

  constructor(private contractHotelDetailsDataService: ContractHotelDetailsDataService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<HotelsNameList[]> {

    const hotelId = route.parent.params['id'];
    return this.contractHotelDetailsDataService.getAllHotelsName();
  }
}
