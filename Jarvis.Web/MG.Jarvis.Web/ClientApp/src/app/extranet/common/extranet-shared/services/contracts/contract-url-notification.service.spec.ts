import { TestBed, inject } from '@angular/core/testing';

import { ContractUrlNotificationService } from './contract-url-notification.service';

describe('ContractUrlNotificationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContractUrlNotificationService]
    });
  });

  it('should be created', inject([ContractUrlNotificationService], (service: ContractUrlNotificationService) => {
    expect(service).toBeTruthy();
  }));
});
