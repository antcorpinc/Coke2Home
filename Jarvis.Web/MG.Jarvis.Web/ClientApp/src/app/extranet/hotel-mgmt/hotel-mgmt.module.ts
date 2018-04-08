import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HotelRoutingModule, routedHotelComponents} from './hotel-mgmt-routing.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { MaterialModule } from '../../common/material/material.module';
import {NgxPaginationModule} from 'ngx-pagination';
import { OrderPipe } from '../common/pipes/orderpipe';
import { FilterPipe } from '../common/pipes/filterPipe';
import { GMapModule } from 'primeng/primeng';
import { DialogModule } from '../../../../node_modules/primeng/components/dialog/dialog';
import { MapsdialogComponent } from './mapsdialog/mapsdialog.component';
import {AutoCompleteModule} from 'primeng//components/autocomplete/autocomplete';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    HotelRoutingModule,
    NgxPaginationModule,
    GMapModule,
    DialogModule,
    AutoCompleteModule
    ],
  declarations: [ routedHotelComponents,
                  OrderPipe,
                  FilterPipe,
                  MapsdialogComponent,
                ],
  entryComponents: [MapsdialogComponent]
})

export class HotelMgmtModule { }
