import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CancellationPoliciesComponent } from './cancellation-policies.component';

describe('CancellationPoliciesComponent', () => {
  let component: CancellationPoliciesComponent;
  let fixture: ComponentFixture<CancellationPoliciesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CancellationPoliciesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CancellationPoliciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
