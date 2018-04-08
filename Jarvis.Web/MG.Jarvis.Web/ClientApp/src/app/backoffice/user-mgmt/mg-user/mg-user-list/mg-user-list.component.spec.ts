import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MgUserListComponent } from './mg-user-list.component';

describe('MgUserListComponent', () => {
  let component: MgUserListComponent;
  let fixture: ComponentFixture<MgUserListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MgUserListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MgUserListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
