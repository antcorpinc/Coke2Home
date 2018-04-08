import { TestBed, inject } from '@angular/core/testing';
import { ApplicationResolverService } from './application-resolver.service';



describe('ApplicationtypesResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ApplicationResolverService]
    });
  });

  it('should be created', inject([ApplicationResolverService], (service: ApplicationResolverService) => {
    expect(service).toBeTruthy();
  }));
});
