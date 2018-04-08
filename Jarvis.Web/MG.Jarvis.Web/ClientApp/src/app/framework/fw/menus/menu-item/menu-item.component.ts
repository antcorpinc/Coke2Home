import { Component, OnInit, Input, HostBinding, HostListener } from '@angular/core';
import { IMenuItem, MenuService } from '../../services/menu.service';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.css']
})
export class MenuItemComponent implements OnInit {
  @Input() item: IMenuItem;
  @HostBinding('class.parent-is-popup')
  @Input() parentIsPopup = true;
  isActiveRoute = false;

  mouseInItem = false;
  mouseInPopup = false;
  popupLeft = 0;
  popupTop = 34;

  constructor(private router: Router,
    public menuService: MenuService) { }

  ngOnInit() {
    this.checkActiveRoute(this.router.url);

    this.router.events
    .subscribe((event) => {
        if (event instanceof NavigationEnd) {
            this.checkActiveRoute(event.url);
         //   console.log(event.url + ' ' + this.item.route + ' ' + this.isActiveRoute);
        }
    });
  }

  checkActiveRoute(route: string) {
    this.isActiveRoute = (route === '/' + this.item.route);
  }

  onPopupMouseEnter(event): void {
    this.mouseInPopup = true;
    }

  onPopupMouseLeave(event): void {
       this.mouseInPopup = false;
        }

  @HostListener('mouseleave', ['$event'])
        onMouseLeave(event): void {
            this.mouseInItem = false;
                  }

        @HostListener('mouseenter')
        onMouseEnter(): void {
            if (this.item.submenu) {
              this.mouseInItem = true;
              if (this.parentIsPopup) {
                this.popupLeft = 160;
                this.popupTop = 0;
              }
            }
        }
}
