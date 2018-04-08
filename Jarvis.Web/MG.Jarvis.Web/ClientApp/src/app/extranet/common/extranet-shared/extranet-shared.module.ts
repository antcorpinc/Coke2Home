import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardExtranetComponent } from './dashboard-extranet/dashboard-extranet.component';
import { ExtranetLookupService } from './services/extranet-lookup';
import { HotelDataService } from './services/hotel-data.service';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../../common/material/material.module';
import { Routes, RouterModule } from '@angular/router';
import { FacilitiesServicesService } from './services/facilities-services.service';
import { FacilitiesServicesResolverService } from './services/facilities-services-resolver.service';
import { RoomtypeDataService } from './services/roomtype-data.service';
import { MessageDataService } from './services/message-data.service';
import { RatecategoryDataService } from './services/ratecategory-data.service';
import { RatecategoryDataResolverService } from './services/ratecategory-data-resolver.service';
import { CurrencyResolverService } from './services/currency-resolver.service';
import { MealtypesResolverService } from './services/mealtypes-resolver.service';
import { CuisinetypesResolverService } from './services/cuisinetypes-resolver.service';
import { AssociateMealplanDataService } from './services/associate-mealplan-data.service';
import { TemplatesDataService } from './services/templates/templates-data.service';
import { TemplateHotelFieldsResolverService } from './services/templates/template-hotel-fields-resolver.service';
import { PoliciesDataService } from './services/policies-data.service';
import { PoliciesDataResolverService } from './services/policies-data-resolver.service';
import { TemplateFacilitiesResolverService } from './services/templates/template-facilities-resolver.service';
import { TemplateFacilitiesDataService } from './services/templates/template-facilities-data.service';
import { DialogsModule } from './dialogs/dialogs.module';
import { HotelcurrencyResolverService } from './services/hotelcurrency-resolver.service';
import { ContractTermsResolverService } from './services/templates/contract-terms-resolver.service';
import { ContractTermsDataService } from './services/templates/contract-terms-data.service';
import { TemplateAmenitiesDataService } from './services/templates/template-amenities-data.service';
import { TemplateAmenitiesResolverService } from './services/templates/template-amenities-resolver.service';
import { AmenitiesResolverService } from './services/amenities-resolver.service';
import { AmenitiesDataService } from './services/amenities-data.service';
import { TemplateRoomTypeFieldsResolverService } from './services/templates/template-room-type-fields-resolver.service';
import { TemplateRoomTypeDataService } from './services/templates/template-room-type-data.service';
import { MarketDataService } from './services/market-data.service';
import { TemplatesDataResolverService } from './services/templates/templates-data-resolver.service';
import { ContractDataService } from '../../common/extranet-shared/services/contracts/contract-data.service';
import { ContractHotelDetailsDataService } from './services/contracts/contract-hotel-details-data.service';
import { HotelsNameResolverService } from './services/contracts/hotels-name-resolver.service';
import { TemplateHotelDetailsResolverService } from './services/contracts/template-hotel-details-resolver.service';
import { ContractDataResolverService } from './services/contracts/contract-data-resolver.service';
import { HotelRoomResolverService } from './services/hotelroom-resolver.service';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    RouterModule,
    DialogsModule  // SharedModule
  ],
  declarations: [DashboardExtranetComponent],
  providers: [ExtranetLookupService, HotelDataService, FacilitiesServicesService, FacilitiesServicesResolverService,
    RoomtypeDataService, MessageDataService, RatecategoryDataService, TemplatesDataService, PoliciesDataService,
    CurrencyResolverService, MealtypesResolverService, CuisinetypesResolverService, HotelcurrencyResolverService,
    AssociateMealplanDataService, TemplateHotelFieldsResolverService, TemplateFacilitiesResolverService,
    TemplateFacilitiesDataService, PoliciesDataResolverService,
    ContractTermsDataService, ContractTermsResolverService, TemplateAmenitiesDataService, TemplateAmenitiesResolverService,
    AmenitiesResolverService, AmenitiesDataService, TemplateRoomTypeFieldsResolverService, TemplateRoomTypeDataService,
    RatecategoryDataResolverService, MarketDataService, TemplatesDataResolverService, ContractDataService,
    ContractHotelDetailsDataService, HotelsNameResolverService, TemplateHotelDetailsResolverService,
    ContractDataResolverService, HotelRoomResolverService]
})
export class ExtranetSharedModule { }
