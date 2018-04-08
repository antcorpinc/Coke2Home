import { TestBed, inject } from '@angular/core/testing';

import { MealtypesResolverService } from './mealtypes-resolver.service';

describe('MealtypesResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MealtypesResolverService]
    });
  });

  it('should be created', inject([MealtypesResolverService], (service: MealtypesResolverService) => {
    expect(service).toBeTruthy();
  }));
});
