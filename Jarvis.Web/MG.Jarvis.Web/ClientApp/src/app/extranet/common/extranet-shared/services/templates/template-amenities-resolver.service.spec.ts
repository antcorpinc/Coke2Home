import { TestBed, inject } from '@angular/core/testing';

import { TemplateAmenitiesResolverService } from './template-amenities-resolver.service';

describe('TemplateAmenitiesResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateAmenitiesResolverService]
    });
  });

  it('should be created', inject([TemplateAmenitiesResolverService], (service: TemplateAmenitiesResolverService) => {
    expect(service).toBeTruthy();
  }));
});
