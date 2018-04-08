import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildAndExtraBedPolicyComponent } from './child-and-extra-bed-policy.component';

describe('ChildAndExtraBedPolicyComponent', () => {
  let component: ChildAndExtraBedPolicyComponent;
  let fixture: ComponentFixture<ChildAndExtraBedPolicyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChildAndExtraBedPolicyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildAndExtraBedPolicyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
