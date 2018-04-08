import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelUserInfoComponent } from './hotel-user-info.component';

describe('HotelUserInfoComponent', () => {
  let component: HotelUserInfoComponent;
  let fixture: ComponentFixture<HotelUserInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotelUserInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelUserInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
