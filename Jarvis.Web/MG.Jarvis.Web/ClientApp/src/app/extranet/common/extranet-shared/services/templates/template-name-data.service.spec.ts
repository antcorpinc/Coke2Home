import { TestBed, inject } from '@angular/core/testing';

import { TemplateNameDataService } from './template-name-data.service';

describe('TemplateNameDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateNameDataService]
    });
  });

  it('should be created', inject([TemplateNameDataService], (service: TemplateNameDataService) => {
    expect(service).toBeTruthy();
  }));
});
