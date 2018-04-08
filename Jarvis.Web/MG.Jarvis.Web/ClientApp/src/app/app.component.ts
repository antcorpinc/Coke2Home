import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/map'; // Todo Rxjs into Shared module
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Observable';
import { Http, Response } from '@angular/http'; // Todo: Remove this later
import {MenuService} from './framework/fw/services/menu.service';
import {UserProfileService} from './common/shared/services/user-profile.service';
import { PortalService} from './common/shared/services/portal.service';

import {initialMenuItems} from './app.menu';
import {Router, Route} from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
 title = 'app';
  constructor(private menuService: MenuService,
              private userProfileService: UserProfileService,
              private portalService: PortalService,
              private router: Router) {

    //  menuService.items = initialMenuItems;

  }
 ngOnInit() {
     this.InitializeApplication();
    }

   InitializeApplication() {
    /*  if (this.portalService.appSettings.Disabled.toUpperCase() === 'TRUE' ) {
      this.router.navigate(['/unauthorized']);
     } else { */
      this.userProfileService.GetUserProfileAsync(this.portalService.appSettings.SubjectId);
    // }
  }
}
