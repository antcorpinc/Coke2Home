import { IMenuItem } from '../../framework/fw/services/menu.service';


export class FeaturePermissionViewModel {
  constructor() {
    this.subFeaturePermissionViewModel = new Array<FeaturePermissionViewModel>();
    this.submenu = new Array<IMenuItem>();
  }
   featureTypeId: number;
   typeName: string;
   label: string;
   parentFeatureId?: number;
   order?: number;
   privileges: string;
   icon: string;
   route: string;
   subFeaturePermissionViewModel: Array<FeaturePermissionViewModel>;
   submenu: Array<IMenuItem>;
  }

  export class ApplicationPermissionViewModel {
    constructor() {
      this.featurePermissions = new Map<number, FeaturePermissionViewModel>();
      this.featuresList = new Array<FeaturePermissionViewModel>();
    }
     name: string;
     role: string;
     featurePermissions: Map<number, FeaturePermissionViewModel>;
     featuresList: Array<FeaturePermissionViewModel>;
    }

export class UserDetailsViewModel {
    constructor() {
      this.applicationPermissions = new Array<ApplicationPermissionViewModel>();
    }
    id: string;
    firstName: string;
    lastName: string;
    isSuperUser: boolean;
    userType: number;
    disabled: boolean;
    userName: string;
    email: string;
    applicationPermissions: Array<ApplicationPermissionViewModel>;
}
