import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MgUserInfoComponent } from './mg-user-info.component';

describe('MgUserInfoComponent', () => {
  let component: MgUserInfoComponent;
  let fixture: ComponentFixture<MgUserInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MgUserInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MgUserInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
