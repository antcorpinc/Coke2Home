import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RateCategoryInfoComponent } from './rate-category-info.component';

describe('RateCategoryInfoComponent', () => {
  let component: RateCategoryInfoComponent;
  let fixture: ComponentFixture<RateCategoryInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RateCategoryInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RateCategoryInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
