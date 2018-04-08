import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomTypeInfoComponent } from './room-type-info.component';

describe('RoomTypeInfoComponent', () => {
  let component: RoomTypeInfoComponent;
  let fixture: ComponentFixture<RoomTypeInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoomTypeInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomTypeInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
