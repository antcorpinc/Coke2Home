import { TestBed, inject } from '@angular/core/testing';

import { RatecategoryDataResolverService } from './ratecategory-data-resolver.service';

describe('RatecategoryDataResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RatecategoryDataResolverService]
    });
  });

  it('should be created', inject([RatecategoryDataResolverService], (service: RatecategoryDataResolverService) => {
    expect(service).toBeTruthy();
  }));
});
