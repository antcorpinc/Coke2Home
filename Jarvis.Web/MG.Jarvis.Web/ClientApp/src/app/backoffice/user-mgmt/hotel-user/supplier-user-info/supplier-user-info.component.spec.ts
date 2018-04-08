import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierUserInfoComponent } from './supplier-user-info.component';

describe('SupplierUserInfoComponent', () => {
  let component: SupplierUserInfoComponent;
  let fixture: ComponentFixture<SupplierUserInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupplierUserInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupplierUserInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
