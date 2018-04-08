import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildExtraBedComponent } from './child-extra-bed.component';

describe('ChildExtraBedComponent', () => {
  let component: ChildExtraBedComponent;
  let fixture: ComponentFixture<ChildExtraBedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChildExtraBedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildExtraBedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
