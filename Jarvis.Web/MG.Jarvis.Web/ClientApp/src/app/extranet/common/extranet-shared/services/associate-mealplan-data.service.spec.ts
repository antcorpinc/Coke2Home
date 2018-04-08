import { TestBed, inject } from '@angular/core/testing';

import { AssociateMealplanDataService } from './associate-mealplan-data.service';

describe('AssociateMealplanDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssociateMealplanDataService]
    });
  });

  it('should be created', inject([AssociateMealplanDataService], (service: AssociateMealplanDataService) => {
    expect(service).toBeTruthy();
  }));
});
