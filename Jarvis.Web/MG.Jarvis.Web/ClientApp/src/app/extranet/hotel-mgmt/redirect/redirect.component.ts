import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CONSTANTS } from '../../../common/constants';

const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;

@Component({
  selector: 'app-redirect',
  templateUrl: './redirect.component.html',
  styleUrls: ['./redirect.component.css']
})
export class RedirectComponent implements OnInit {
  isRead: boolean;
  operation: string;
  hotelId: string;
  constructor(private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    // this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.hotelId = this.activatedRoute.snapshot.params['hotelid'];
    console.log('Redirect component hotelid - ' + this.hotelId);
     this.router.navigate(['/hotelmgmt/hotel', this.hotelId, edit, 'profilecompl']);
  }

}
