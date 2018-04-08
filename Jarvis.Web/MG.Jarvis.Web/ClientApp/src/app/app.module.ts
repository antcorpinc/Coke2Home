
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http'; //  Tobe removed later.
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FwModule } from './framework/fw/fw.module';
import { CoreModule } from './common/core/core.module'; // Tobe removed later.
import { SharedModule } from './common/shared/shared.module';
import {AppRoutingModule} from './app-routing.module';

import { BackofficeSharedModule } from './backoffice/common/backoffice-shared/backoffice-shared.module';
import { ExtranetSharedModule } from './extranet/common/extranet-shared/extranet-shared.module';
import { MaterialModule } from './common/material/material.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    HttpModule, // Todo : To be removed later - We use HttpClientModule
    FwModule,
    CoreModule, // Todo: To be removed later.
    BackofficeSharedModule,
    ExtranetSharedModule,
    MaterialModule,
    // Should be last for Routing
    AppRoutingModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
