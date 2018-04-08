import { TestBed, inject } from '@angular/core/testing';

import { CurrencyResolverService } from './currency-resolver.service';

describe('CurrencyResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CurrencyResolverService]
    });
  });

  it('should be created', inject([CurrencyResolverService], (service: CurrencyResolverService) => {
    expect(service).toBeTruthy();
  }));
});
