import { TestBed, inject } from '@angular/core/testing';

import { TemplateFacilitiesResolverService } from './template-facilities-resolver.service';

describe('TemplateFacilitiesResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateFacilitiesResolverService]
    });
  });

  it('should be created', inject([TemplateFacilitiesResolverService], (service: TemplateFacilitiesResolverService) => {
    expect(service).toBeTruthy();
  }));
});
