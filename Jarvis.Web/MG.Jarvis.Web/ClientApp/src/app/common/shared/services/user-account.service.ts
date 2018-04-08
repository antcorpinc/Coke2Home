import { Injectable } from '@angular/core';
import {UserAccountApi} from '../../../framework/fw/users/user-account-api';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {PortalService} from './portal.service';
import { AuthenticatedHttpService } from './authenticated-http.service';
import { Location } from '@angular/common';
@Injectable()
export class UserAccountService  implements UserAccountApi {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private http: HttpClient, private portalService: PortalService,
    private location: Location ) { }
  logOut(): void {
    console.log('Invoked logOut');
    this.location.go('/account/logout');
    window.location.reload(true);
  }

  private reloadPage() {
    window.location.href = this.portalService.appSettings.BaseUrls.Web;
    window.location.reload(true);
  }

  changePassword(): boolean {
    console.log('Invoked changePassword');
    // this.http.post(this.portalService.appSettings.BaseUrls.Web + 'Account/Logout', null);
   /*  this.authenticatedHttpService
    .get(this.portalService.appSettings.BaseUrls.Web + 'Account/Logout'); */
    // this.http.get(this.portalService.appSettings.BaseUrls.Web + 'account/logout')
   /* this.http.get(this.portalService.appSettings.BaseUrls.Web + 'account/logout',
   {
    headers: new HttpHeaders().set('Accept', 'text/html')
  }) */
    // .subscribe(() => console.log('Logout response '), (err) => console.log(err));
    return;
  }

}
