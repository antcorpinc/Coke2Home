import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgentUserListComponent } from './agent-user-list.component';

describe('AgentUserListComponent', () => {
  let component: AgentUserListComponent;
  let fixture: ComponentFixture<AgentUserListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgentUserListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgentUserListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
