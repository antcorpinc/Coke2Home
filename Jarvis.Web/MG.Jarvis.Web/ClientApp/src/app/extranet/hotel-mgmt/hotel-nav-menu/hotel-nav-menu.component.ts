
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RouterLinkActive } from '@angular/router';
@Component({
  selector: 'app-hotel-nav-menu',
  templateUrl: './hotel-nav-menu.component.html',
  styleUrls: ['./hotel-nav-menu.component.css']
})
export class HotelNavMenuComponent implements OnInit {
  isSideNavDisplay: any;
  @Input() operation: string;
  isCreate = false;
  constructor() { }

  ngOnInit() {
    this.isSideNavDisplay = true;
    if (this.operation.trim() === 'create') {
      this.isCreate = true;
    }
    console.log('operation in left nav' + this.operation);
  }
}
