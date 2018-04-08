import { Injectable } from '@angular/core';
import {Router, Route} from '@angular/router';

import {PortalService} from './portal.service';
import {AuthenticatedHttpService} from './authenticated-http.service';
import { TopBarDataService} from './top-bar-data.service';
import { StateService} from './state.service';
import {MenuDataService} from './menu-data.service';
import {UserDetailsViewModel} from '../../viewmodels/userdetailsviewmodel';

// import {TopBarService} from '../../../framework/fw/services/top-bar.service';

export class UserInfo {
  FirstName: string;
  LastName: string;
}

export interface IUserProfileService {
  GetUserProfileAsync(id: string ); // Change name to Initialize User Profile.
}

@Injectable()
export class UserProfileService implements IUserProfileService {

   userDetails: any;
   userDetailsDto: UserDetailsViewModel;
   basicUserInfo: UserInfo;
  constructor(private authenticatedHttpService: AuthenticatedHttpService,
              private portalService: PortalService, private router: Router,
              private topBarDataService: TopBarDataService,
              private stateService: StateService,
              private menuDataService: MenuDataService,
         //     private topBarService: TopBarService
  ) {
    this.userDetailsDto = new UserDetailsViewModel();
   // topBarService.appChange$.subscribe((app)=> this.UpdateApp(app));
  }
/*   UpdateApp(appName) {
    console.log('AppName:' + appName);
    this.menuDataService.TransformTopBarData(appName);
   } */

  GetUserProfileAsync(id: string) {
     this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.BackOfficeApi
    + 'api/Users/' +  id).subscribe((user) => {

      this.userDetails = user;
      this.userDetailsDto = user;
      if (this.userDetailsDto) {
      console.log('From User DEtails DTO' + this.userDetailsDto);
      if (this.userDetailsDto.disabled) {
        this.router.navigate(['/unauthorized']);
      } else {
      this.SetBasicUserInfo(this.userDetails);
      // Give it all information that is needed to display the TopBar component
      this.topBarDataService.InitializeTopBarData(this.userDetailsDto);
      // Give it all information that is needed to display the Menu component
      this.menuDataService.InitializeMenuData(this.userDetailsDto);
     // Todo: Whenever the app refreshes - the menu service & State service listens
      // Create a State Service to route to the right View
     // this.router.navigate(['/agentdashboard']); // Todo : Change accordingly.
        this.stateService.InitializeState(this.userDetailsDto);
      }
      }
    },
    (err: any) => {
      console.log(err);
    },
    () => console.log('GetUserProfile() retrieved user details ')
  );
}
SetBasicUserInfo(userDetails: any) {
  this.basicUserInfo = new UserInfo();
  this.basicUserInfo.FirstName = this.userDetails.firstName;
  this.basicUserInfo.LastName = this.userDetails.lastName;
}
GetBasicUserInfo() {
  return this.basicUserInfo;
}

GetUserPermissionsForFeature(applicationName: string, featureTypeId: number) {
  let priviligesArray = Array<string>();
   const apps = this.userDetailsDto.applicationPermissions
  .filter(app => app.name.toUpperCase() === applicationName.toUpperCase());
  if ( apps != null && apps.length > 0) {
    const priv = apps[0].featuresList.find(fea => fea.featureTypeId === featureTypeId )
                        .privileges;
    // const privArray = priv.split('|');
    priviligesArray = priv.split('|');
    return priviligesArray;
  }
  return null;
}
}
