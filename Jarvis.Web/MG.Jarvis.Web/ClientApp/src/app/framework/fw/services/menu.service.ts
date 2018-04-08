import { Injectable} from '@angular/core';

export interface IMenuItem {
  text: string;
  icon: string;
  route: string;
  submenu: Array<IMenuItem>;
}

export class MenuItems implements  IMenuItem {
  text: string;
  icon: string;
  route: string;
  submenu: MenuItems[];

}

@Injectable()
export class MenuService {
    items: Array<IMenuItem>;
}
