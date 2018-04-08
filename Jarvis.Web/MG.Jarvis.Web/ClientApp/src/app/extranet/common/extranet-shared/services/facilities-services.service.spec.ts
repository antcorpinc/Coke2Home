import { TestBed, inject } from '@angular/core/testing';

import { FacilitiesServicesService } from './facilities-services.service';

describe('FacilitiesServicesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FacilitiesServicesService]
    });
  });

  it('should be created', inject([FacilitiesServicesService], (service: FacilitiesServicesService) => {
    expect(service).toBeTruthy();
  }));
});
