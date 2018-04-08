import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateRateCategoryComponent } from './create-rate-category.component';

describe('CreateRateCategoryComponent', () => {
  let component: CreateRateCategoryComponent;
  let fixture: ComponentFixture<CreateRateCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateRateCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateRateCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
