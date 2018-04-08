import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ContractDataService } from './contract-data.service';
import { ContractsListViewModel } from '../../../../viewmodel/contracts/contractslistviewmodel';

@Injectable()
export class ContractDataResolverService implements Resolve<ContractsListViewModel[]> {

  constructor(private contractsDataService: ContractDataService) { }

  resolve(route: ActivatedRouteSnapshot,
      state: RouterStateSnapshot): Observable<ContractsListViewModel[]> {
      return this.contractsDataService.getContractsList();
  }
}
