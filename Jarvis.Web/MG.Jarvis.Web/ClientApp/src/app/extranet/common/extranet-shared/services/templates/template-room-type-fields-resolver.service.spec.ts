import { TestBed, inject } from '@angular/core/testing';

import { TemplateRoomTypeFieldsResolverService } from './template-room-type-fields-resolver.service';

describe('TemplateRoomTypeFieldsResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateRoomTypeFieldsResolverService]
    });
  });

  it('should be created', inject([TemplateRoomTypeFieldsResolverService], (service: TemplateRoomTypeFieldsResolverService) => {
    expect(service).toBeTruthy();
  }));
});
