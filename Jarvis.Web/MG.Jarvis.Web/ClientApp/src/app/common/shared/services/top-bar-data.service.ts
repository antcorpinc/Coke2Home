import { Injectable } from '@angular/core';
import {TopBarService, ITopBarItem, TopBarItemViewModel, IAppRole} from '../../../framework/fw/services/top-bar.service';
import {UserDetailsViewModel} from '../../viewmodels/userdetailsviewmodel';

export interface ITopBarDataService {
  InitializeTopBarData(userDetails: UserDetailsViewModel);
}

@Injectable()
export class TopBarDataService implements ITopBarDataService {
  private _userDetails: UserDetailsViewModel;
  private _topBarItem: TopBarItemViewModel;

  constructor(private topBarService: TopBarService) {
  }

  InitializeTopBarData(userDetails: UserDetailsViewModel) {
    this._userDetails = userDetails;
    this.TransformTopBarData();
    this.topBarService.setTopBarItem(this._topBarItem);
  }

  private TransformTopBarData() {
    this._topBarItem = new TopBarItemViewModel();
    const  topBarItemViewModel: TopBarItemViewModel = new TopBarItemViewModel();
    topBarItemViewModel.firstName = this._userDetails.firstName;
    topBarItemViewModel.lastName = this._userDetails.lastName;
    // Todo: Remove this later as we are using applications
    this._userDetails.applicationPermissions.forEach(val => topBarItemViewModel.appRole[val.name] = val.role);
    topBarItemViewModel.applications = new Array<IAppRole>();
    this._userDetails.applicationPermissions.forEach(val =>
      topBarItemViewModel.applications.push({
        application: val.name,
        role: val.role
      })) ;

       this._topBarItem = topBarItemViewModel;
   }
}
