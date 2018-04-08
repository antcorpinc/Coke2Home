import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardExtranetComponent } from './dashboard-extranet.component';

describe('DashboardExtranetComponent', () => {
  let component: DashboardExtranetComponent;
  let fixture: ComponentFixture<DashboardExtranetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardExtranetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardExtranetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
