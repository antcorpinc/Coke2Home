import { TestBed, inject } from '@angular/core/testing';

import { ContractTermsResolverService } from './contract-terms-resolver.service';

describe('ContractTermsResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContractTermsResolverService]
    });
  });

  it('should be created', inject([ContractTermsResolverService], (service: ContractTermsResolverService) => {
    expect(service).toBeTruthy();
  }));
});
