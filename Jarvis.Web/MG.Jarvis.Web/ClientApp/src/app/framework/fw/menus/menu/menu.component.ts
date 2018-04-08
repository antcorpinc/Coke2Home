import { Component, OnInit } from '@angular/core';
import {MenuService} from '../../services/menu.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  // menuService declared as public since it is used in template rather than this file
  constructor(public menuService: MenuService) { }

  ngOnInit() {
  }

}
