import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContractComponent } from './contract/contract.component';
import { ContractListComponent } from './contract-list/contract-list.component';
import { ContractNavMenuComponent } from './contract-nav-menu/contract-nav-menu.component';
import { ContractTermsComponent } from './contract-terms/contract-terms.component';
import { AllocationsComponent } from './allocations/allocations.component';
import { HotelDetailsComponent } from './hotel-info/hotel-details/hotel-details.component';
import { FacilitiesServicesComponent } from './hotel-info/facilities-services/facilities-services.component';
import { AmenitiesComponent } from './rate/amenities/amenities.component';
import { RoomTypeInfoComponent } from './rate/room-type/room-type-info/room-type-info.component';
import { RoomTypeListComponent } from './rate/room-type/room-type-list/room-type-list.component';
import { MealPlanComponent } from './rate/meal-plan/meal-plan.component';
import { CancellationPoliciesComponent } from './rate/policies/cancellation-policies/cancellation-policies.component';
import { CancellationPolicyListComponent } from './rate/policies/cancellation-policy-list/cancellation-policy-list.component';
import { ChildAndExtraBedPolicyComponent } from './rate/policies/child-and-extra-bed-policy/child-and-extra-bed-policy.component';
import { ChildAndExtraBedPolicyListComponent } from './rate/policies/child-and-extra-bed-policy-list/child-and-extra-bed-policy-list.component';
import { PolicyListComponent } from './rate/policies/policy-list/policy-list.component';
import { RateCategoryListComponent } from './rate/rate-category/rate-category-list/rate-category-list.component';
import { RateCategoryInfoComponent } from './rate/rate-category/rate-category-info/rate-category-info.component';
import { RedirectComponent } from './redirect/redirect.component';
import { HotelsNameResolverService } from '../../common/extranet-shared/services/contracts/hotels-name-resolver.service';
import { TemplateHotelDetailsResolverService } from '../../common/extranet-shared/services/contracts/template-hotel-details-resolver.service';
import { ContractDataResolverService } from '../../common/extranet-shared/services/contracts/contract-data-resolver.service';

const routes: Routes = [
  { path: '', redirectTo: 'contracts', pathMatch: 'full' },
  { path: 'contracts', component: ContractListComponent, resolve: { contractListData: ContractDataResolverService } },
  { path: 'redirect/:contractid', component: RedirectComponent },
  {
    path: 'contract/:id/:operation',
    component: ContractComponent,
    children: [
      { path: '', redirectTo: 'hoteldetails', pathMatch: 'full' },
      {
        path: 'hoteldetails', component: HotelDetailsComponent,
        resolve: { hotelsName: HotelsNameResolverService }
      },
      { path: 'facilitiesservices', component: FacilitiesServicesComponent },
      { path: 'roomtype', component: RoomTypeInfoComponent },
      { path: 'roomtype/:id/:operation', component: RoomTypeInfoComponent },
      {
        path: 'amenities',
        component: AmenitiesComponent
      },
      {
        path: 'mealplan',
        component: MealPlanComponent
      },
      {
        path: 'policylist',
        component: PolicyListComponent
      },
      {
        path: 'childandextrabedpolicy/:id/:operation',
        component: ChildAndExtraBedPolicyComponent
      },
      {
        path: 'cancellationpolicies/:id/:operation',
        component: CancellationPoliciesComponent
      },
      { path: 'allocations', component: AllocationsComponent },
      { path: 'contractterms', component: ContractTermsComponent },
      { path: 'ratecategory', component: RateCategoryListComponent },
      {
        path: 'ratecategory/:id/:operation',
        component: RateCategoryInfoComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContractsRoutingModule { }

export const routedContractsComponents = [
  HotelDetailsComponent,
  FacilitiesServicesComponent,
  ContractComponent,
  AllocationsComponent,
  ContractListComponent,
  ContractNavMenuComponent,
  ContractTermsComponent,
  RoomTypeListComponent,
  RoomTypeInfoComponent,
  AmenitiesComponent,
  MealPlanComponent,
  RateCategoryListComponent,
  RateCategoryInfoComponent,
  CancellationPolicyListComponent,
  ChildAndExtraBedPolicyComponent,
  CancellationPoliciesComponent,
  ChildAndExtraBedPolicyListComponent,
  PolicyListComponent,
  RedirectComponent
];
