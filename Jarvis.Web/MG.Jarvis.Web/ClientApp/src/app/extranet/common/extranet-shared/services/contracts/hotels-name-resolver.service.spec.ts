import { TestBed, inject } from '@angular/core/testing';

import { HotelsNameResolverService } from './hotels-name-resolver.service';

describe('HotelsNameResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HotelsNameResolverService]
    });
  });

  it('should be created', inject([HotelsNameResolverService], (service: HotelsNameResolverService) => {
    expect(service).toBeTruthy();
  }));
});
