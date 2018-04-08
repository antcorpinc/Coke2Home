import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CancellationPolicyListComponent } from './cancellation-policy-list.component';

describe('CancellationPolicyListComponent', () => {
  let component: CancellationPolicyListComponent;
  let fixture: ComponentFixture<CancellationPolicyListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CancellationPolicyListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CancellationPolicyListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
