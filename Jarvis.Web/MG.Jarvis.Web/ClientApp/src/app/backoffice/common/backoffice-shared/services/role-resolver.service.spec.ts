import { TestBed, inject } from '@angular/core/testing';

import { RoleResolverService } from './role-resolver.service';

describe('RoleResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RoleResolverService]
    });
  });

  it('should be created', inject([RoleResolverService], (service: RoleResolverService) => {
    expect(service).toBeTruthy();
  }));
});
