import { Component, OnInit } from '@angular/core';
// import { AuthenticatedHttpService } from '../../../../services/authenticated-http.service';
import {AuthenticatedHttpService} from '../../../shared/services/authenticated-http.service';
import {PortalService} from '../../../shared/services/portal.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  testData: any;
  err: any;

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
  private portalService: PortalService) { }

  ngOnInit() {
    console.log('Init Dashboard Component');
  }


  OnButtonClick() {
    // this.authenticatedHttpService.getTest()
    // this.authenticatedHttpService.get()
    // this.authenticatedHttpService.getBackofficeTest('api/Users/test')
    this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.BackOfficeApi
     + 'api/Users/test'
    )
      .subscribe(test => {
        this.testData = test;
        console.log('Returned From New Auth Service is ' + JSON.stringify(this.testData));
      },
      error => this.err = <any>error);
  }

   OnExtranetButtonClick() {
    // this.authenticatedHttpService.getTest()
    // this.authenticatedHttpService.get()
    // this.authenticatedHttpService.getExtranetTest('api/Hotels/test')
    this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Hotels/test'
    )
      .subscribe(test => {
        this.testData = test;
        console.log('Returned From Service with Extranet Call ' + JSON.stringify(this.testData));
      },
      error => this.err = <any>error);
  }
}
