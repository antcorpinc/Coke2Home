import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RateCategoryComponent } from './rate-category.component';

describe('RateCategoryComponent', () => {
  let component: RateCategoryComponent;
  let fixture: ComponentFixture<RateCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RateCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RateCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
