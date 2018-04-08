import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserMgmtRoutingModule, routedUserComponents } from './user-mgmt-routing.module';
import { ReactiveFormsModule, FormsModule} from '@angular/forms';
import { MaterialModule } from '../../common/material/material.module';
import { BackofficeLookupService } from '../common/backoffice-shared/services/backoffice-lookup';
import { DepartmentResolverService } from '../common/backoffice-shared/services/department-resolver.service';
import { DatePipe } from '@angular/common';
import { ApplicationResolverService } from '../common/backoffice-shared/services/application-resolver.service';
import { AgentUserInfoComponent } from './agent-user/agent-user-info/agent-user-info.component';
import { AgentUserListComponent } from './agent-user/agent-user-list/agent-user-list.component';
import { HotelUserListComponent } from './hotel-user/hotel-user-list/hotel-user-list.component';
import { HotelUserInfoComponent } from './hotel-user/hotel-user-info/hotel-user-info.component';
import { IndividualHotelUserInfoComponent } from './hotel-user/individual-hotel-user-info/individual-hotel-user-info.component';
import { DesignationResolverService } from '../common/backoffice-shared/services/designation-resolver.service';
import { RoleResolverService } from '../common/backoffice-shared/services/role-resolver.service';
import { HotelTypeComponent } from './hotel-user/hotel-type/hotel-type.component';
import { SupplierUserInfoComponent } from './hotel-user/supplier-user-info/supplier-user-info.component';
import { HotelResolverService } from '../common/backoffice-shared/services/hotel-resolver.service';


// import { RoleResolverService } from '../common/backoffice-shared/services/role-resolver.service';

@NgModule({
  imports: [
    CommonModule,
    UserMgmtRoutingModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule
  ],
  declarations: [routedUserComponents, AgentUserInfoComponent,
                 AgentUserListComponent, HotelUserListComponent,
                 HotelUserInfoComponent,
                  IndividualHotelUserInfoComponent,
                  HotelTypeComponent,
                  SupplierUserInfoComponent],
  providers: [BackofficeLookupService, DepartmentResolverService,
              ApplicationResolverService, DesignationResolverService,
      RoleResolverService, DatePipe, HotelResolverService]
})
export class UserMgmtModule { }
