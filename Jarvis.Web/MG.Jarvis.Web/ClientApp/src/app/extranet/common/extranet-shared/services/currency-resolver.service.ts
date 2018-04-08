import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { CurrencyViewModel } from '../../../../common/viewmodels/currencyviewmodel';
import { ExtranetLookupService } from './extranet-lookup';
import { Observable } from 'rxjs/Observable';
import { LookupService } from '../../../../common/shared/services/lookup.service';

@Injectable()
export class CurrencyResolverService implements Resolve<CurrencyViewModel[]> {

  constructor(private lookupService: LookupService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<CurrencyViewModel[]> {
    return this.lookupService.getCurrency();
  }

}
