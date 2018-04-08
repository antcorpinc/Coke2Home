import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardBackofficeComponent } from './dashboard-backoffice/dashboard-backoffice.component';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../../common/material/material.module';
import { BackofficeLookupService } from './services/backoffice-lookup';
import { UserDataService } from './services/user-data.service';
import { DialogsModule } from './dialogs/dialogs.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    DialogsModule
  ],
  declarations: [DashboardBackofficeComponent],
  providers: [BackofficeLookupService, UserDataService]
})
export class BackofficeSharedModule { }
