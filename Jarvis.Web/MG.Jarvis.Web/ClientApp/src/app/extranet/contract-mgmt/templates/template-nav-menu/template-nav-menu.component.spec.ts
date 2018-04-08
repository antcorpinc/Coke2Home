import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateNavMenuComponent } from './template-nav-menu.component';

describe('TemplateNavMenuComponent', () => {
  let component: TemplateNavMenuComponent;
  let fixture: ComponentFixture<TemplateNavMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateNavMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateNavMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
