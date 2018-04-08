import { Injectable } from '@angular/core';
import { BackofficeLookupService } from './backoffice-lookup';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { MgApplicationViewModel } from '../../../viewmodel/usersviewmodel/mgapplicationlistviewmodel';


@Injectable()
export class ApplicationResolverService implements Resolve<MgApplicationViewModel[]> {

  constructor(private backofficeLookupService: BackofficeLookupService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<MgApplicationViewModel[]> {
      return this.backofficeLookupService.getApplications();
    }
}
