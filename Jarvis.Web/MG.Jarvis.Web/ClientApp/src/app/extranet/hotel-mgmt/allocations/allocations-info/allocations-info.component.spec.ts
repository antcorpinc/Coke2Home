import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllocationsInfoComponent } from './allocations-info.component';

describe('AllocationsInfoComponent', () => {
  let component: AllocationsInfoComponent;
  let fixture: ComponentFixture<AllocationsInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllocationsInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllocationsInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
