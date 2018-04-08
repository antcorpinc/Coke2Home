import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardBackofficeComponent } from './dashboard-backoffice.component';

describe('DashboardBackofficeComponent', () => {
  let component: DashboardBackofficeComponent;
  let fixture: ComponentFixture<DashboardBackofficeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardBackofficeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardBackofficeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
