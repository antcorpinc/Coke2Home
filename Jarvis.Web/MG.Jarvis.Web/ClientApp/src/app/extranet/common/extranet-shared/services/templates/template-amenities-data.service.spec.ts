import { TestBed, inject } from '@angular/core/testing';

import { TemplateAmenitiesDataService } from './template-amenities-data.service';

describe('TemplateAmenitiesDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateAmenitiesDataService]
    });
  });

  it('should be created', inject([TemplateAmenitiesDataService], (service: TemplateAmenitiesDataService) => {
    expect(service).toBeTruthy();
  }));
});
