import { TestBed, inject } from '@angular/core/testing';

import { TemplateUrlNotificationService } from './template-url-notification.service';

describe('TemplateUrlNotificationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateUrlNotificationService]
    });
  });

  it('should be created', inject([TemplateUrlNotificationService], (service: TemplateUrlNotificationService) => {
    expect(service).toBeTruthy();
  }));
});
