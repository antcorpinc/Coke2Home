import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HotelDetailsComponent } from './hotel-info/hotel-details/hotel-details.component';
import { TemplateComponent } from './template/template.component';
import { AllocationsComponent } from './allocations/allocations.component';
import { TemplateListComponent } from './template-list/template-list.component';
import { TemplateNavMenuComponent } from './template-nav-menu/template-nav-menu.component';
import { ContractTermsComponent } from './contract-terms/contract-terms.component';
import { RoomTypeComponent } from './rate/room-type/room-type.component';
import { AmenitiesComponent } from './rate/amenities/amenities.component';
import { MealPlanComponent } from './rate/meal-plan/meal-plan.component';
import { RateCategoryComponent } from './rate/rate-category/rate-category.component';
import { ChildExtraBedComponent } from './rate/policies/child-extra-bed/child-extra-bed.component';
import { CancellationPaymentComponent } from './rate/policies/cancellation-payment/cancellation-payment.component';
import { FacilitiesServicesComponent } from './hotel-info/facilities-services/facilities-services.component';
import { TemplateHotelFieldsResolverService } from '../../common/extranet-shared/services/templates/template-hotel-fields-resolver.service';
import { RedirectComponent } from './redirect/redirect.component';
import { TemplateFacilitiesResolverService } from '../../common/extranet-shared/services/templates/template-facilities-resolver.service';
import { MealtypesResolverService } from './../../common/extranet-shared/services/mealtypes-resolver.service';
import { CuisinetypesResolverService } from './../../common/extranet-shared/services/cuisinetypes-resolver.service';
import { CurrencyResolverService } from './../../common/extranet-shared/services/currency-resolver.service';
import { TemplateRoomTypeFieldsResolverService } from '../../common/extranet-shared/services/templates/template-room-type-fields-resolver.service';
import { ContractTermsResolverService } from '../../common/extranet-shared/services/templates/contract-terms-resolver.service';
import { TemplateAmenitiesResolverService } from '../../common/extranet-shared/services/templates/template-amenities-resolver.service';
import { TemplatesDataResolverService } from './../../common/extranet-shared/services/templates/templates-data-resolver.service';

const routes: Routes = [
    { path: '', redirectTo: 'templates', pathMatch: 'full' },
    { path: 'templates', component: TemplateListComponent, resolve: { templateListData: TemplatesDataResolverService } },
    { path: 'redirect/:tempid', component: RedirectComponent },
    {
        path: 'template/:id/:operation', component: TemplateComponent,
        children: [
            { path: '', redirectTo: 'hoteldetails', pathMatch: 'full' },
            {
                path: 'hoteldetails', component: HotelDetailsComponent,
                resolve: { hotelFieldData: TemplateHotelFieldsResolverService }
            },
            {
                path: 'facilitiesservices',
                component: FacilitiesServicesComponent,
                resolve: { facilityData: TemplateFacilitiesResolverService }
            },
            {
                path: 'roomtype', component: RoomTypeComponent,
                resolve: { roomTypeData: TemplateRoomTypeFieldsResolverService }
            },
            {
                path: 'amenities',
                component: AmenitiesComponent,
                resolve: { amenitiesData: TemplateAmenitiesResolverService }
            },
            {
                path: 'mealplan', component: MealPlanComponent,
                resolve: {
                    currencyData: CurrencyResolverService, mealTypesData: MealtypesResolverService,
                    cuisineTypesData: CuisinetypesResolverService
                }
            },
            { path: 'childpolicy', component: ChildExtraBedComponent },
            { path: 'cancellationpolicy', component: CancellationPaymentComponent },
            { path: 'ratecategory', component: RateCategoryComponent },
            { path: 'allocation', component: AllocationsComponent },
            {
                path: 'contractterms',
                component: ContractTermsComponent,
                resolve: { contractTermsData: ContractTermsResolverService, hotelFieldData: TemplateHotelFieldsResolverService }
            },
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TemplatesRoutingModule { }

export const routedTemplateComponents = [
    HotelDetailsComponent,
    FacilitiesServicesComponent,
    TemplateComponent,
    AllocationsComponent,
    TemplateListComponent,
    TemplateNavMenuComponent,
    ContractTermsComponent,
    RoomTypeComponent,
    AmenitiesComponent,
    MealPlanComponent,
    RateCategoryComponent,
    ChildExtraBedComponent,
    CancellationPaymentComponent,
    RedirectComponent
];
