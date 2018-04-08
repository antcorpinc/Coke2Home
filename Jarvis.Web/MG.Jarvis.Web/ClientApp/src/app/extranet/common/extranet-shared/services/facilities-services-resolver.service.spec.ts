import { TestBed, inject } from '@angular/core/testing';

import { FacilitiesServicesResolverService } from './facilities-services-resolver.service';

describe('FacilitiesServicesResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FacilitiesServicesResolverService]
    });
  });

  it('should be created', inject([FacilitiesServicesResolverService], (service: FacilitiesServicesResolverService) => {
    expect(service).toBeTruthy();
  }));
});
