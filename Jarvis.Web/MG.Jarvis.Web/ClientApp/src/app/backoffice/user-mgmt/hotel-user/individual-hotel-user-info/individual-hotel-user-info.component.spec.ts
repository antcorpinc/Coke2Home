import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndividualHotelUserInfoComponent } from './individual-hotel-user-info.component';

describe('IndividualHotelUserInfoComponent', () => {
  let component: IndividualHotelUserInfoComponent;
  let fixture: ComponentFixture<IndividualHotelUserInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndividualHotelUserInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndividualHotelUserInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
