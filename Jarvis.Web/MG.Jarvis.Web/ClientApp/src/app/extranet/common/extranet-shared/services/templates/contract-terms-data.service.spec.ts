import { TestBed, inject } from '@angular/core/testing';

import { ContractTermsDataService } from './contract-terms-data.service';

describe('ContractTermsDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContractTermsDataService]
    });
  });

  it('should be created', inject([ContractTermsDataService], (service: ContractTermsDataService) => {
    expect(service).toBeTruthy();
  }));
});
