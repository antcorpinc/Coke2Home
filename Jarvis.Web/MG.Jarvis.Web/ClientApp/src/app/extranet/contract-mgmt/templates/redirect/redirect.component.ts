import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CONSTANTS } from '../../../../common/constants';

const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;

@Component({
  selector: 'app-redirect',
  templateUrl: './redirect.component.html',
  styleUrls: ['./redirect.component.css']
})
export class RedirectComponent implements OnInit {
  tempid: any;
  isRead: boolean;
  operation: string;
  hotelId: string;
  constructor(private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.tempid = this.activatedRoute.snapshot.params['tempid'];
    console.log('Redirect component tempid - ' + this.tempid);
    this.router.navigate(['/templatemgmt/template', this.tempid, edit, 'facilitiesservices']);
  }

}
