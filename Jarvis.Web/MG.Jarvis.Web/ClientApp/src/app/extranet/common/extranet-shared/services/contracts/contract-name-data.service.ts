import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class ContractNameDataService {
  private contractNameSource = new BehaviorSubject<string>('');
  contractName = this.contractNameSource.asObservable();

  constructor() { }

  changeContractName(contractName: string) {
    this.contractNameSource.next(contractName);
  }

}
