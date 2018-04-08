import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FrameworkBodyComponent } from './framework-body/framework-body.component';
import { ContentComponent } from './content/content.component';
import { TitleBarComponent } from './title-bar/title-bar.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { StatusBarComponent } from './status-bar/status-bar.component';
import { MenuComponent } from './menus/menu/menu.component';
import {MenuService} from './services/menu.service';
import {TopBarService} from './services/top-bar.service';
import { MenuItemComponent } from './menus/menu-item/menu-item.component';
import {RouterModule} from '@angular/router';
import { PopupMenuComponent } from './menus/popup-menu/popup-menu.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { MaterialModule } from '../../common/material/material.module';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import {FormsModule} from '@angular/forms';
import {ReactiveFormsModule} from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    FrameworkBodyComponent,
    ContentComponent,
    TitleBarComponent,
    TopBarComponent,
    StatusBarComponent,
    MenuComponent,
    MenuItemComponent,
    PopupMenuComponent,
    UnauthorizedComponent,
    ChangePasswordComponent
  ],
  providers: [
    MenuService,
    TopBarService
  ],
  exports: [
    FrameworkBodyComponent
  ]
})
export class FwModule {

  // Preventing importing this modules more than once
  // https://angular.io/guide/ngmodule-faq

  constructor( @Optional() @SkipSelf() parentModule: FwModule) {
    if (parentModule) {
      throw new Error(
        'FwModule is already loaded. Import it in the AppModule only');
    }
  }

}
