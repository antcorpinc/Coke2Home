import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RateCategoryListComponent } from './rate-category-list.component';

describe('RateCategoryListComponent', () => {
  let component: RateCategoryListComponent;
  let fixture: ComponentFixture<RateCategoryListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RateCategoryListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RateCategoryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
