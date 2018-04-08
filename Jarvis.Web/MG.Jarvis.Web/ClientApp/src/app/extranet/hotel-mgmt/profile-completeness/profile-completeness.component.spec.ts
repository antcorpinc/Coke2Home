import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileCompletenessComponent } from './profile-completeness.component';

describe('ProfileCompletenessComponent', () => {
  let component: ProfileCompletenessComponent;
  let fixture: ComponentFixture<ProfileCompletenessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileCompletenessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileCompletenessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
