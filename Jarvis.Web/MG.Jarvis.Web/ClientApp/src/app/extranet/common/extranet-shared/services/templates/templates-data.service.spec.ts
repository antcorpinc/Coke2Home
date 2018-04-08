import { TestBed, inject } from '@angular/core/testing';

import { TemplatesDataService } from './templates-data.service';

describe('TemplatesDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplatesDataService]
    });
  });

  it('should be created', inject([TemplatesDataService], (service: TemplatesDataService) => {
    expect(service).toBeTruthy();
  }));
});
