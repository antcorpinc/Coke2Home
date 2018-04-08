import { Injectable } from '@angular/core';
import { ExtranetLookupService } from './extranet-lookup';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { CuisineTypeViewModel } from '../../../viewmodel/associatemealplanviewmodel/cuisinetypeviewmodel';

@Injectable()
export class CuisinetypesResolverService implements Resolve<CuisineTypeViewModel[]> {

  constructor(private extranetLookupService: ExtranetLookupService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<CuisineTypeViewModel[]> {
    return this.extranetLookupService.getCuisineType();
  }

}
