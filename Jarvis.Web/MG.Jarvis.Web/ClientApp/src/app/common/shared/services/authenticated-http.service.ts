import { Injectable } from '@angular/core';
import { Http, Headers, Response} from '@angular/http'; // Todo: Remove this later
import {PortalService} from './portal.service';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/merge';


import { HttpClient, HttpErrorResponse, HttpHeaders  , HttpResponse } from '@angular/common/http';

export interface ITokenRefresh {
  access_token: string;
}

@Injectable()
export class AuthenticatedHttpService {
    constructor(private http: Http, private portalService: PortalService,
    private _http: HttpClient
  ) {

  }

   private handleError(err: HttpErrorResponse) {
     console.log(err.message);
     return Observable.throw(err.message);
   }

      get(url): Observable<any> {
    const request = () => {
      console.log('Invoking get with token' + this.portalService.appSettings.AccessToken);
      return this._http.get(url ,
        {
          headers: new HttpHeaders().set('Authorization', 'Bearer ' + this.portalService.appSettings.AccessToken)
        })
        .do(data => console.log('All From new get with headers(url):' + JSON.stringify(data)));
      };
        return this.refreshTokenOnAuthorizationFailure(request);
    }

    post(url, data) {
      const request = () => {
        return this._http.post(url ,
          data,
            {
              headers: new HttpHeaders().set('Authorization', 'Bearer ' + this.portalService.appSettings.AccessToken)
                                        .set('Content-Type', 'application/json')

            });
      };
      return this.refreshTokenOnAuthorizationFailure(request);
    }

    put(url, data) {
      const request = () => {
        return this._http.put(url ,
          data,
            {
              headers: new HttpHeaders().set('Authorization', 'Bearer ' + this.portalService.appSettings.AccessToken)
                                        .set('Content-Type', 'application/json')

            });
      };
      return this.refreshTokenOnAuthorizationFailure(request);
    }

/*    post(url, data) {
    const request = () => {
      const headers = this.createHeaders();
      headers.append('Content-Type', 'application/json');
      return this.http.post(this.apiUrl + url ,
        data,
          {
            headers: headers
          });
    };
    return this.refreshTokenOnAuthorizationFailure(request);
  }
 */


refreshTokenOnAuthorizationFailure(request: () => Observable<any>) {
  return request().catch((err, caught) => {
    // Handle Unauthorized responses
    if (err.status === 401) {
      console.log('Before Calling Refresh Tokens');
      return this.refreshTokens().flatMap(newTokenResponse => {
        if ( !newTokenResponse || !newTokenResponse.access_token) {
          console.log('Unable to get Token ');
          window.location.href = this.portalService.appSettings.BaseUrls.Web + 'Account/Logout';
        return Observable.throw('Could not refresh Auth Token . Redirecting to logoff');
        }
        this.portalService.appSettings.AccessToken = newTokenResponse.access_token;
        return request();
      });
    }
    return Observable.throw(err);

  });
}

  refreshTokens() {
     return this._http.get(this.portalService.appSettings.BaseUrls.Web + 'Account/RefreshTokens')
      .map((r) => <ITokenRefresh>r);
  }
}
