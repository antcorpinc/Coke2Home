import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractNavMenuComponent } from './contract-nav-menu.component';

describe('ContractNavMenuComponent', () => {
  let component: ContractNavMenuComponent;
  let fixture: ComponentFixture<ContractNavMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContractNavMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContractNavMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
