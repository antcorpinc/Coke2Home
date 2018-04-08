import { TestBed, inject } from '@angular/core/testing';

import { ContractNameDataService } from './contract-name-data.service';

describe('ContractNameDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContractNameDataService]
    });
  });

  it('should be created', inject([ContractNameDataService], (service: ContractNameDataService) => {
    expect(service).toBeTruthy();
  }));
});
