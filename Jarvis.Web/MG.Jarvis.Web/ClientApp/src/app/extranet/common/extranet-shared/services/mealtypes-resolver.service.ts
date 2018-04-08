import { Injectable } from '@angular/core';
import { MealTypeViewModel } from '../../../viewmodel/associatemealplanviewmodel/mealtypeviewmodel';
import { ExtranetLookupService } from './extranet-lookup';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class MealtypesResolverService implements Resolve<MealTypeViewModel[]> {

  constructor(private extranetLookupService: ExtranetLookupService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<MealTypeViewModel[]> {
    return this.extranetLookupService.getMeals();
  }

}
