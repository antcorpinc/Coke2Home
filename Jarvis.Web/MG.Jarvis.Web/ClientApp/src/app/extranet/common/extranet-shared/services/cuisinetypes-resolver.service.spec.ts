import { TestBed, inject } from '@angular/core/testing';

import { CuisinetypesResolverService } from './cuisinetypes-resolver.service';

describe('CuisinetypesResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CuisinetypesResolverService]
    });
  });

  it('should be created', inject([CuisinetypesResolverService], (service: CuisinetypesResolverService) => {
    expect(service).toBeTruthy();
  }));
});
