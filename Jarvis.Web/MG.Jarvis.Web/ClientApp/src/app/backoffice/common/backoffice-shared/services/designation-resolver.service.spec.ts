import { TestBed, inject } from '@angular/core/testing';

import { DesignationResolverService } from './designation-resolver.service';

describe('DesignationResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DesignationResolverService]
    });
  });

  it('should be created', inject([DesignationResolverService], (service: DesignationResolverService) => {
    expect(service).toBeTruthy();
  }));
});
