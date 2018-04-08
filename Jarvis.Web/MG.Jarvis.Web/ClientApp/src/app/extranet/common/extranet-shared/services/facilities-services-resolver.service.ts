import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { FacilityGroupViewModel } from '../../../viewmodel/facilitiesservicesviewmodel/facilitygroupviewmodel';
import { FacilitiesServicesService } from './facilities-services.service';

@Injectable()
export class FacilitiesServicesResolverService implements Resolve<FacilityGroupViewModel[]> {

  constructor(private facilitiesServicesService: FacilitiesServicesService) {
  }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<FacilityGroupViewModel[]> {

    const hotelId = route.parent.params['id'];
    return this.facilitiesServicesService.getFacilitiesAndServices(hotelId);
  }

}
