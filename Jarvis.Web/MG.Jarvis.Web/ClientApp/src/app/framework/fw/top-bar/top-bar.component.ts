import { Component, OnInit } from '@angular/core';
import { TopBarService} from '../services/top-bar.service';
import { UserAccountApi } from '../users/user-account-api';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {
  FirstName: string;
  LastName: string;
  Applications: Array<string>;
  constructor(public topBarService: TopBarService , private userAccountApi: UserAccountApi) {

   }

  ngOnInit() {
   }

   onApplicationChange($event) {
   this.topBarService.onAppChange($event);
    }

    logOut() {
      this.userAccountApi.logOut();
    }

}
