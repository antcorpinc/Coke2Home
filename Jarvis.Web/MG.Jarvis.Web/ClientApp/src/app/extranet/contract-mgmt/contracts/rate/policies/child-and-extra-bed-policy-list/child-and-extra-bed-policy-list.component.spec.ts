import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildAndExtraBedPolicyListComponent } from './child-and-extra-bed-policy-list.component';

describe('ChildAndExtraBedPolicyListComponent', () => {
  let component: ChildAndExtraBedPolicyListComponent;
  let fixture: ComponentFixture<ChildAndExtraBedPolicyListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChildAndExtraBedPolicyListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildAndExtraBedPolicyListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
