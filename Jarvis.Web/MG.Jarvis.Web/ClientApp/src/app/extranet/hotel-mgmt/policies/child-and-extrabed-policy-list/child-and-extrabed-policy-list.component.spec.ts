import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildAndExtrabedPolicyListComponent } from './child-and-extrabed-policy-list.component';

describe('ChildAndExtrabedPolicyListComponent', () => {
  let component: ChildAndExtrabedPolicyListComponent;
  let fixture: ComponentFixture<ChildAndExtrabedPolicyListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChildAndExtrabedPolicyListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildAndExtrabedPolicyListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
