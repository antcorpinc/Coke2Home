import { TestBed, inject } from '@angular/core/testing';

import { TemplateRoomTypeDataService } from './template-room-type-data.service';

describe('TemplateRoomTypeDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplateRoomTypeDataService]
    });
  });

  it('should be created', inject([TemplateRoomTypeDataService], (service: TemplateRoomTypeDataService) => {
    expect(service).toBeTruthy();
  }));
});
