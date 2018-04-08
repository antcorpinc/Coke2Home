import { TestBed, inject } from '@angular/core/testing';

import { TemplateHotelDetailsResolverService } from './template-hotel-details-resolver.service';

describe('TemplateHotelDetailsResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateHotelDetailsResolverService]
    });
  });

  it('should be created', inject([TemplateHotelDetailsResolverService], (service: TemplateHotelDetailsResolverService) => {
    expect(service).toBeTruthy();
  }));
});
