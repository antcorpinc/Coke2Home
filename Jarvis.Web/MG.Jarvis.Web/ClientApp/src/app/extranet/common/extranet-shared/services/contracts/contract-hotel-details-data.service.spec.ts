import { TestBed, inject } from '@angular/core/testing';

import { ContractHotelDetailsDataService } from './contract-hotel-details-data.service';

describe('ContractHotelDetailsDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContractHotelDetailsDataService]
    });
  });

  it('should be created', inject([ContractHotelDetailsDataService], (service: ContractHotelDetailsDataService) => {
    expect(service).toBeTruthy();
  }));
});
