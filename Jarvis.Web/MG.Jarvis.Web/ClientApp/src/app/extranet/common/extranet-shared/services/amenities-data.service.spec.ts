import { TestBed, inject } from '@angular/core/testing';

import { AmenitiesDataService } from './amenities-data.service';

describe('AmenitiesDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AmenitiesDataService]
    });
  });

  it('should be created', inject([AmenitiesDataService], (service: AmenitiesDataService) => {
    expect(service).toBeTruthy();
  }));
});
