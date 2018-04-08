import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { BackofficeLookupService } from './backoffice-lookup';
import { DesignationViewModel } from '../../../viewmodel/usersviewmodel/designationviewmodel';
import { Observable } from 'rxjs/Observable';
import { CONSTANTS } from '../../../../common/constants';

@Injectable()
export class DesignationResolverService {
  type = CONSTANTS.userType.hoteluser;
  constructor(private backofficeLookupService: BackofficeLookupService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<DesignationViewModel[]> {
      return this.backofficeLookupService.getDesignationByType(this.type);
    }

}
