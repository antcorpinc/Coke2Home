import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelNavMenuComponent } from './hotel-nav-menu.component';

describe('HotelNavMenuComponent', () => {
  let component: HotelNavMenuComponent;
  let fixture: ComponentFixture<HotelNavMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotelNavMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelNavMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
