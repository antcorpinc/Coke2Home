import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { routedContractsComponents, ContractsRoutingModule } from './contracts-routing.module';
import { MaterialModule } from '../../../common/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { ContractUrlNotificationService } from '../../common/extranet-shared/services/contracts/contract-url-notification.service';
import { ContractNameDataService } from '../../common/extranet-shared/services/contracts/contract-name-data.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { ContractsOrderPipe } from '../../common/pipes/contractsOrderPipe';

@NgModule({
  imports: [
    CommonModule,
    ContractsRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule
  ],
  declarations: [routedContractsComponents, ContractsOrderPipe],
  providers: [DatePipe, ContractUrlNotificationService, ContractNameDataService]
})
export class ContractsModule { }
