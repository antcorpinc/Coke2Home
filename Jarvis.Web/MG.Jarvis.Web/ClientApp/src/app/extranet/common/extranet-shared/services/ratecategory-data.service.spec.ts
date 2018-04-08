import { TestBed, inject } from '@angular/core/testing';

import { RatecategoryDataService } from './ratecategory-data.service';

describe('RatecategoryDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RatecategoryDataService]
    });
  });

  it('should be created', inject([RatecategoryDataService], (service: RatecategoryDataService) => {
    expect(service).toBeTruthy();
  }));
});
