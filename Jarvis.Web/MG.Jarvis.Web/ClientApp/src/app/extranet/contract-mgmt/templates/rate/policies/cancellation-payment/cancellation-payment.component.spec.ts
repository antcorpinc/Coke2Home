import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CancellationPaymentComponent } from './cancellation-payment.component';

describe('CancellationPaymentComponent', () => {
  let component: CancellationPaymentComponent;
  let fixture: ComponentFixture<CancellationPaymentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CancellationPaymentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CancellationPaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
