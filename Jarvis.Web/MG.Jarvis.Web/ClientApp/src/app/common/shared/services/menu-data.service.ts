import { Injectable } from '@angular/core';
import {UserDetailsViewModel, FeaturePermissionViewModel} from '../../viewmodels/userdetailsviewmodel';
import { forEach } from '@angular/router/src/utils/collection';
import {MenuService, IMenuItem, MenuItems} from '../../../framework/fw/services/menu.service';
import {TopBarService} from '../../../framework/fw/services/top-bar.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

export interface IMenuDataService {
  InitializeMenuData(userDetails: UserDetailsViewModel);
}

@Injectable()
export class MenuDataService implements IMenuDataService {
  private _userDetails: UserDetailsViewModel;
  constructor(private menuService: MenuService
    , private topBarService: TopBarService) {
      // Subscribe to the event when the top bar application changes
      this.topBarService.appChange$.subscribe((app) => this.UpdateApp(app));
   }

  UpdateApp(appName) {
    this.TransformMenuData(appName);
   }

  InitializeMenuData(userDetails: UserDetailsViewModel) {
    console.log('InitializeMenuData');
    this._userDetails = userDetails;
    if (userDetails.applicationPermissions.length > 0) {
      const app = userDetails.applicationPermissions[0].name;
      const translatedMenu = this.TransformMenuData(app);
     console.log('Translated Menus' + JSON.stringify(translatedMenu));
    }
  }

   TransformMenuData(app: string, role?: string) {
    const appPermission = this._userDetails.applicationPermissions.find(x => x.name.trim() === app.trim());
    if (appPermission != null) {
      const appRole = appPermission.role;
    }
    const featureListData: Array<FeaturePermissionViewModel> = appPermission.featuresList;
    let  parentsMenuData: Array<FeaturePermissionViewModel> = new Array<FeaturePermissionViewModel>();
    if (featureListData != null && featureListData.length > 0) {
        // Top Level Menus
       parentsMenuData = featureListData.filter(val => val.parentFeatureId == null );
      parentsMenuData.forEach(parentMenuItem => {
       this.buildTreeviewMenu(parentMenuItem, featureListData);
      });
    }
   console.log('Parent Menu Data' + JSON.stringify(parentsMenuData));
   const translatedMenus =  this.translateModelToMenusRecursively(parentsMenuData);
   console.log('TranslatedMenus' + JSON.stringify(translatedMenus));
   this.menuService.items = translatedMenus;
   return translatedMenus;
  }

  private translateModelToMenusRecursively(featurePermissionViewModel: Array<FeaturePermissionViewModel>) {
    const translatedMenus: Array<MenuItems> = new Array<MenuItems>();
    featurePermissionViewModel.forEach(element => {

      const tempMenuItem: MenuItems = new MenuItems();
        tempMenuItem.icon = element.icon;
        tempMenuItem.route = element.route;
        tempMenuItem.text = element.label;

      if (element.subFeaturePermissionViewModel != null && element.subFeaturePermissionViewModel.length > 0) {
        tempMenuItem.submenu = this.translateModelToMenusRecursively(element.subFeaturePermissionViewModel);
      }
      // tslint:disable-next-line:one-line
      else {
        tempMenuItem.submenu = null;
      }
      translatedMenus.push(tempMenuItem);
    });
    return translatedMenus;
  }

   private buildTreeviewMenu(parentMenuItem: FeaturePermissionViewModel ,
     menuData: Array<FeaturePermissionViewModel>) {
    let menuItems: Array<FeaturePermissionViewModel>;
    // Get all child menu Items for the Parent
    menuItems = menuData.filter(menu => menu.parentFeatureId === parentMenuItem.featureTypeId);
    if (menuItems != null && menuItems.length > 0) {
      parentMenuItem.subFeaturePermissionViewModel = new Array<FeaturePermissionViewModel>();
      this.AddAdditionalMenuAttributes(parentMenuItem, true);
      menuItems.forEach((childMenu) => {
      parentMenuItem.subFeaturePermissionViewModel.push(childMenu) ;
      this.buildTreeviewMenu(childMenu, menuData);
        });
    }
    // tslint:disable-next-line:one-line
    else {
      this.AddAdditionalMenuAttributes(parentMenuItem, false);
      }
    }

private AddAdditionalMenuAttributes(menuItem: FeaturePermissionViewModel, parent?: boolean):
 FeaturePermissionViewModel  {
  if (menuItem != null) {
     menuItem.icon =  this.getIconforMenuFeature(menuItem.typeName);
    if (parent === false)    {
      menuItem.route = this.getRoutforMenuFeature(menuItem.typeName);
    } else {
      menuItem.route = null; }

  }
  return menuItem;
}
private getIconforMenuFeature(feature: string): string {
  if (feature.toUpperCase() === 'EXTRANETDASHBOARD') {
    return 'fa fa-tachometer';
  }else if (feature.toUpperCase() === 'BACKOFFICEDASHBOARD') {
  return 'fa fa-tachometer';
  }else if (feature.toUpperCase() === 'CONTRACT') {
  return 'fa fa-pencil';
  } else if (feature.toUpperCase() === 'AGENCYMANAGEMENT')  {
    return 'fa fa-users';
  } else if (feature.toUpperCase() === 'REPORTS')  {
    return 'fa fa-file-text-o';
  } else if (feature.toUpperCase() === 'MASTERDATA')  {
     return 'fa fa-database';
  } else if (feature.toUpperCase() === 'HOTELMANAGEMENT')  {
    return 'fa fa-user';
  } else if (feature.toUpperCase() === 'FINANCEMANAGEMENT') {
    return 'fa fa-usd';
  } else if (feature.toUpperCase() === 'RESERVATIONMANAGEMENT') {
    return 'fa fa-calendar-check-o';
  } else if (feature.toUpperCase() === 'REVENUEMANAGEMENT') {
    return 'fa fa-line-chart';
  } else if (feature.toUpperCase() === 'SUPPLIERMANAGEMENT') {
    return 'fa fa-users';
  } else if (feature.toUpperCase() === 'USERMANAGEMENT') {
    return 'fa fa-users';
  } else if (feature.toUpperCase() === 'TOOLSMANAGEMENT') {
    return 'fa fa-cogs';
  } else if (feature.toUpperCase() === 'REPORTSMANAGEMENT') {
    return 'fa fa-file-text-o';
  } else {
    return null;
  }
}

private getRoutforMenuFeature(feature: string): string {
  if (feature.toUpperCase() === 'HOTELPROFILE') {
    return 'hotelmgmt/hotels';
  }else if (feature.toUpperCase() === 'EXTRANETDASHBOARD') {
    return 'extranetdashboard';
  }else if (feature.toUpperCase() === 'BACKOFFICEDASHBOARD') {
    return 'backofficedashboard';
    }else if (feature.toUpperCase() === 'TEMPLATES') {
      return 'templatemgmt/templates';
    } else if (feature.toUpperCase() === 'MGUSER') {
      return 'usermgmt/mgusers';
    } else if (feature.toUpperCase() === 'CONTRACTS') {
      return 'contractmgmt/contracts';
    } else if (feature.toUpperCase() === 'AGENTSUSER') {
      return 'usermgmt/agentusers';
    } else if (feature.toUpperCase() === 'HOTELSUPPLIERUSER') {
    return 'usermgmt/hoteluserslist';
    } else {
    return null;
  }
}
}
