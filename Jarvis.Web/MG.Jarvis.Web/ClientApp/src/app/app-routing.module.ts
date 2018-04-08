import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import {DashboardComponent} from './common/core/dashboards/dashboard/dashboard.component';
import {HotelAdminDashboardComponent} from './common/core/dashboards/hotel-admin-dashboard/hotel-admin-dashboard.component';
import { AgentDashboardComponent} from './common/core/dashboards/agent-dashboard/agent-dashboard.component';

import { DashboardBackofficeComponent } from './backoffice/common/backoffice-shared/dashboard-backoffice/dashboard-backoffice.component';
import { DashboardExtranetComponent } from './extranet/common/extranet-shared/dashboard-extranet/dashboard-extranet.component';
import {UnauthorizedComponent} from './framework/fw/unauthorized/unauthorized.component';
// import {ErrorhandlerComponent} from './framework/fw/errorhandler/errorhandler.component';

export const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent},
  // { path: 'hoteladmindashboard', component: HotelAdminDashboardComponent},
  { path: 'agentdashboard', component: AgentDashboardComponent}, // TODO Remove later
 // { path: 'dashboardbackoffice', component: DashboardBackofficeComponent },

  // { path: 'handleerror', component: ErrorhandlerComponent },
  { path: 'backofficedashboard', component: DashboardBackofficeComponent },
  { path: 'extranetdashboard', component: DashboardExtranetComponent },
  { path: 'unauthorized', component: UnauthorizedComponent },

  { path: 'contractmgmt', loadChildren: './extranet/contract-mgmt/contracts/contracts.module#ContractsModule' } ,
  { path: 'hotelmgmt', loadChildren:
  './extranet/hotel-mgmt/hotel-mgmt.module#HotelMgmtModule' } ,
  { path: 'templatemgmt', loadChildren: './extranet/contract-mgmt/templates/templates.module#TemplatesModule' } ,
  { path: 'usermgmt', loadChildren:
  './backoffice/user-mgmt/user-mgmt.module#UserMgmtModule' } ,

  { path: '', component: DashboardComponent },
  { path: '**', component: DashboardComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule {}
