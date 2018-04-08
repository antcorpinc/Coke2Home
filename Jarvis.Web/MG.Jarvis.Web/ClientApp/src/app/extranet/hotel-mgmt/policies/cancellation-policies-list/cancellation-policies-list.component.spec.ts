import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CancellationPoliciesListComponent } from './cancellation-policies-list.component';

describe('CancellationPoliciesListComponent', () => {
  let component: CancellationPoliciesListComponent;
  let fixture: ComponentFixture<CancellationPoliciesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CancellationPoliciesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CancellationPoliciesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
