import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileCompletenessComponent } from './profile-completeness/profile-completeness.component';
import { HotelNavMenuComponent } from './hotel-nav-menu/hotel-nav-menu.component';
import { HotelListComponent } from './hotel-list/hotel-list.component';
import { HotelDetailsComponent } from './hotel-details/hotel-details.component';
import { HotelComponent } from './hotel/hotel.component';
import { FacilitiesServicesComponent } from './facilities-services/facilities-services.component';
import { AmenitiesComponent } from './amenities/amenities.component';
import { PoliciesListComponent } from '../hotel-mgmt/policies/policies-list/policies-list.component';
import { AssociateMealPlanComponent } from './associate-meal-plan/associate-meal-plan.component';
import { MapsdialogComponent } from './mapsdialog/mapsdialog.component';
import { RedirectComponent } from './redirect/redirect.component';
import { RoomTypeListComponent } from './room-type/room-type-list/room-type-list.component';
import { PoliciesDataResolverService } from './../common/extranet-shared/services/policies-data-resolver.service';
import { FacilitiesServicesResolverService } from '../common/extranet-shared/services/facilities-services-resolver.service';
import { MessageListComponent } from './message/message-list/message-list.component';
import { MessageInfoComponent } from './message/message-info/message-info.component';
import { RoomTypeInfoComponent } from './room-type/room-type-info/room-type-info.component';
import { ChildAndExtraBedPolicyComponent } from './policies/child-and-extra-bed-policy/child-and-extra-bed-policy.component';
import { CancellationPoliciesComponent } from './policies/cancellation-policies/cancellation-policies.component';
import { ChildAndExtrabedPolicyListComponent } from './policies/child-and-extrabed-policy-list/child-and-extrabed-policy-list.component';
import { CancellationPoliciesListComponent } from './policies/cancellation-policies-list/cancellation-policies-list.component';
import { CurrencyResolverService } from '../common/extranet-shared/services/currency-resolver.service';
import { MealtypesResolverService } from '../common/extranet-shared/services/mealtypes-resolver.service';
import { CuisinetypesResolverService } from '../common/extranet-shared/services/cuisinetypes-resolver.service';
import { RateCategoryInfoComponent } from './rate-category/rate-category-info/rate-category-info.component';
import { RateCategoryListComponent } from './rate-category/rate-category-list/rate-category-list.component';
import { PromotionsListComponent } from './promotions/promotions-list/promotions-list.component';
import { CreatePromotionComponent } from './promotions/create-promotion/create-promotion.component';
import { PhotosComponent } from './photos/photos.component';
import { HotelcurrencyResolverService } from '../common/extranet-shared/services/hotelcurrency-resolver.service';
import { RatecategoryDataResolverService } from '../common/extranet-shared/services/ratecategory-data-resolver.service';
import { AmenitiesResolverService } from '../common/extranet-shared/services/amenities-resolver.service';
import { HotelRoomResolverService } from '../common/extranet-shared/services/hotelroom-resolver.service';
import { AllocationsInfoComponent } from './allocations/allocations-info/allocations-info.component';

export const hotelRoutes: Routes =
  [
    { path: '', redirectTo: 'hotels', pathMatch: 'full' },
    { path: 'hotels', component: HotelListComponent },
    { path: 'redirect/:hotelid', component: RedirectComponent },
    {
      path: 'hotel/:id/:operation', component: HotelComponent,
      children: [
        { path: '', redirectTo: 'hoteldetails', pathMatch: 'full' },
        { path: 'profilecompl', component: ProfileCompletenessComponent },
        { path: 'hoteldetails', component: HotelDetailsComponent },
        {
          path: 'facilitiesservices',
          component: FacilitiesServicesComponent,
          resolve: { facilityData: FacilitiesServicesResolverService }
        },
        { path: 'photos', component: PhotosComponent }, // TODO - Will be change with actual Component
        { path: 'roomtypelist', component: RoomTypeListComponent },
        { path: 'roomtype/:id/:operation', component: RoomTypeInfoComponent },
        {
          path: 'amenities',
          component: AmenitiesComponent,
          resolve: { amenitiesData: AmenitiesResolverService, roomData: HotelRoomResolverService }
        },
        {
          path: 'mealplan',
          component: AssociateMealPlanComponent,
          resolve: {
            currencyData: CurrencyResolverService, mealTypesData: MealtypesResolverService,
            cuisineTypesData: CuisinetypesResolverService, HotelCurrencyData: HotelcurrencyResolverService
          }
        },
        {
          path: 'policieslist',
          component: PoliciesListComponent,
          resolve: { childAndExtraBedPolicyData: PoliciesDataResolverService }
        },
        { path: 'ratecategory', component: RateCategoryListComponent },
        {
          path: 'ratecategory/:id/:operation',
          component: RateCategoryInfoComponent,
          resolve: { roomTypesData: RatecategoryDataResolverService }
        },
        { path: 'allocation', component: AllocationsInfoComponent },
        { path: 'promotionlist', component: PromotionsListComponent },
        { path: 'promotion/:id/:operation', component: CreatePromotionComponent },
        { path: 'messagelist', component: MessageListComponent },
        { path: 'message/:id/:operation', component: MessageInfoComponent },
        {
          path: 'childandextrabedpolicy/:id/:operation',
          component: ChildAndExtraBedPolicyComponent,
          resolve: { childAndExtraBedPolicyData: PoliciesDataResolverService }
        }
        , { path: 'cancellationpolicies/:id/:operation', component: CancellationPoliciesComponent }
      ]
    },
  ];

@NgModule({
  imports: [RouterModule.forChild(hotelRoutes)],
  exports: [RouterModule]
})
export class HotelRoutingModule { }

export const routedHotelComponents = [
  HotelListComponent,
  ProfileCompletenessComponent,
  HotelNavMenuComponent,
  HotelDetailsComponent,
  HotelComponent,
  FacilitiesServicesComponent,
  RoomTypeListComponent,
  AmenitiesComponent,
  PoliciesListComponent,
  AssociateMealPlanComponent,
  RateCategoryListComponent,
  MapsdialogComponent,
  RedirectComponent,
  RoomTypeInfoComponent,
  MessageListComponent,
  MessageInfoComponent,
  ChildAndExtrabedPolicyListComponent,
  ChildAndExtraBedPolicyComponent,
  CancellationPoliciesListComponent,
  CancellationPoliciesComponent,
  RateCategoryInfoComponent,
  PromotionsListComponent,
  CreatePromotionComponent,
  PhotosComponent,
  AllocationsInfoComponent
];


