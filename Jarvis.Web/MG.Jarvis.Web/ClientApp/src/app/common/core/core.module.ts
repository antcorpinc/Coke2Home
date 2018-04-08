import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboards/dashboard/dashboard.component';
import { HotelAdminDashboardComponent } from './dashboards/hotel-admin-dashboard/hotel-admin-dashboard.component';
import { AgentDashboardComponent } from './dashboards/agent-dashboard/agent-dashboard.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [DashboardComponent, HotelAdminDashboardComponent, AgentDashboardComponent]
})
export class CoreModule { }
