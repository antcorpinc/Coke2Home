import { Injectable } from '@angular/core';
import {UserDetailsViewModel} from '../../viewmodels/userdetailsviewmodel';
import {Router, Route} from '@angular/router';
import {TopBarService} from '../../../framework/fw/services/top-bar.service';

export interface IStateService {
  SetAppState(app: string, role: string);
  InitializeState(userDetails: UserDetailsViewModel);
}
//  This StateService is used only for complex route navigation .
// Ex. Initiallly when the application load , When the application is changed from the UI
@Injectable()
export class StateService implements IStateService {
  private _userDetails: UserDetailsViewModel;

  constructor( private router: Router,
    private topBarService: TopBarService) {
      // Subscribe to the event when the top bar application changes
      this.topBarService.appChange$.subscribe((app) => this.UpdateApp(app));
  }
  InitializeState(userDetails: UserDetailsViewModel) {
    this._userDetails = userDetails;
    if (userDetails.applicationPermissions.length > 0) {
      const app = userDetails.applicationPermissions[0].name;
      this.SetAppState(app);
    }
  }

  UpdateApp(appName) {
    this.SetAppState(appName);
   }

  SetAppState(app: string, role?: string) {
    const appPermission = this._userDetails.applicationPermissions.find(x => x.name === app);
    if (appPermission != null) {
      const appRole = appPermission.role;

      if ( app.toUpperCase() === 'EXTRANET') {
        this.router.navigate(['/extranetdashboard']);
      }
      if (app.toUpperCase() === 'BACKOFFICE') {
        this.router.navigate(['/backofficedashboard']);
      }

    }

    // Todo: Inject the TopService component Add Conditions to route to the right component

  }
}
