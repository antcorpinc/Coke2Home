import { TestBed, inject } from '@angular/core/testing';

import { TemplateHotelFieldsResolverService } from './template-hotel-fields-resolver.service';

describe('TemplateHotelFieldsResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateHotelFieldsResolverService]
    });
  });

  it('should be created', inject([TemplateHotelFieldsResolverService], (service: TemplateHotelFieldsResolverService) => {
    expect(service).toBeTruthy();
  }));
});
