import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ContractTermsViewModel } from '../../../../viewmodel/templates/contract-terms/contracttermsviemodel';
import { ContractTermsDataService } from './contract-terms-data.service';

@Injectable()
export class ContractTermsResolverService implements Resolve<ContractTermsViewModel[]> {

  constructor(private contractTermsDataService: ContractTermsDataService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<ContractTermsViewModel[]> {

    const templateId = route.parent.params['id'];
    return this.contractTermsDataService.getContractTerms(templateId);
  }

}
