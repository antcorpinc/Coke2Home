import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelAdminDashboardComponent } from './hotel-admin-dashboard.component';

describe('HotelAdminDashboardComponent', () => {
  let component: HotelAdminDashboardComponent;
  let fixture: ComponentFixture<HotelAdminDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotelAdminDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelAdminDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
