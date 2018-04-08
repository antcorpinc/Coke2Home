import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { BackofficeLookupService } from './backoffice-lookup';
import { MgRoleViewModel } from '../../../viewmodel/usersviewmodel/mgrolelistviewmodel';
import { CONSTANTS } from '../../../../common/constants';

@Injectable()
export class RoleResolverService {
  applicationName = CONSTANTS.application.extranet;
  constructor( private backofficeLookupService: BackofficeLookupService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<MgRoleViewModel[]> {
      return this.backofficeLookupService.getRolesByApplicationName(this.applicationName);
    }
}
