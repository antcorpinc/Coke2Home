import { NgModule, Optional, SkipSelf } from '@angular/core';


import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import {PortalService} from './services/portal.service';
import {AuthenticatedHttpService} from './services/authenticated-http.service';
import {UserProfileService} from './services/user-profile.service';
import {MenuDataService} from './services/menu-data.service';
import {TopBarDataService} from './services/top-bar-data.service';
import {StateService} from './services/state.service';
import {LookupService} from './services/lookup.service';
import {UserAccountService} from './services/user-account.service';
import {UserAccountApi} from '../../framework/fw/users/user-account-api';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    FormsModule
  ],
  exports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    FormsModule
  ],
  declarations: [],
  providers: [
    PortalService,
    AuthenticatedHttpService,
    UserProfileService,
    MenuDataService,
    TopBarDataService,
    StateService,
    LookupService,
    UserAccountService,
    { provide: UserAccountApi, useExisting: UserAccountService}
    ]
})
export class SharedModule {
// Preventing importing this modules more than once
  // https://angular.io/guide/ngmodule-faq
  constructor( @Optional() @SkipSelf() parentModule: SharedModule) {
    if (parentModule) {
      throw new Error(
        'SharedModule is already loaded. Import it in the AppModule only');
    }
  }
}
