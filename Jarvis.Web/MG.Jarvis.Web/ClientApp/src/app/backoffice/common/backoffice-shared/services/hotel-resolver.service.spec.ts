import { TestBed, inject } from '@angular/core/testing';

import { HotelResolverService } from './hotel-resolver.service';

describe('HotelResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HotelResolverService]
    });
  });

  it('should be created', inject([HotelResolverService], (service: HotelResolverService) => {
    expect(service).toBeTruthy();
  }));
});
