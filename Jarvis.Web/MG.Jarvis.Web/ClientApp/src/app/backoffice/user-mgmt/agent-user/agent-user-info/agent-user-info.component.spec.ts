import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgentUserInfoComponent } from './agent-user-info.component';

describe('AgentUserInfoComponent', () => {
  let component: AgentUserInfoComponent;
  let fixture: ComponentFixture<AgentUserInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgentUserInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgentUserInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
