import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssociateMealPlanComponent } from './associate-meal-plan.component';

describe('AssociateMealPlanComponent', () => {
  let component: AssociateMealPlanComponent;
  let fixture: ComponentFixture<AssociateMealPlanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssociateMealPlanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssociateMealPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
