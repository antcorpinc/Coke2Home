import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router/src/interfaces';
import { BackofficeLookupService } from './backoffice-lookup';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router/src/router_state';
import { RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { DepartmentViewModel } from '../../../viewmodel/usersviewmodel/departmentviewmodel';


@Injectable()
export class DepartmentResolverService implements Resolve<DepartmentViewModel[]> {
  constructor(private backOfficeLookupService: BackofficeLookupService) { }
  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<DepartmentViewModel[]> {
    return this.backOfficeLookupService.getDepartments();
  }

}
