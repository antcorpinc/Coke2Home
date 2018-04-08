import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelUserListComponent } from './hotel-user-list.component';

describe('HotelUserListComponent', () => {
  let component: HotelUserListComponent;
  let fixture: ComponentFixture<HotelUserListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotelUserListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelUserListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
