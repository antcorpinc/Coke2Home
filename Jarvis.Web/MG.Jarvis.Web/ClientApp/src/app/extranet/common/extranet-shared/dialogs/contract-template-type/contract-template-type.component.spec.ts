import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractTemplateTypeComponent } from './contract-template-type.component';

describe('ContractTemplateTypeComponent', () => {
  let component: ContractTemplateTypeComponent;
  let fixture: ComponentFixture<ContractTemplateTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContractTemplateTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContractTemplateTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
