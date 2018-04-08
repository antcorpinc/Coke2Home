import { TestBed, inject } from '@angular/core/testing';

import { TemplateFacilitiesDataService } from './template-facilities-data.service';

describe('TemplateFacilitiesDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateFacilitiesDataService]
    });
  });

  it('should be created', inject([TemplateFacilitiesDataService], (service: TemplateFacilitiesDataService) => {
    expect(service).toBeTruthy();
  }));
});
