import { Injectable} from '@angular/core';
import { Subject} from 'rxjs/Subject';

export interface IAppRole {
  application: string;
  role: string;
}
export interface ITopBarItem {
  firstName: string;
  lastName: string;
  profileLink?: string;
  applications?: Array<IAppRole>;
  appRole: Map<string, string>;
  activeApplcation?: string;
  activeRole?: string;
}
export class TopBarItemViewModel implements ITopBarItem {
  constructor() {
    this.appRole = new Map<string, string>();
  }
  firstName: string;
  lastName: string;
  profileLink?: string;
  applications?: IAppRole[];
  appRole: Map<string, string>;
  activeApplcation?: string;
  activeRole?: string;
}
export interface ITopBarService {
  setTopBarItem(item: ITopBarItem);
  getTopBarItem(): ITopBarItem;
}


@Injectable()
export class TopBarService  implements ITopBarService  {
  private appChangeSource = new Subject<null>();
  appChange$ = this.appChangeSource.asObservable();

  _item: ITopBarItem;
  getTopBarItem(): ITopBarItem {
    return this._item;
  }
  setTopBarItem(item: TopBarItemViewModel) {
    this._item = item;

    console.log('From TopBar service' + this._item.firstName);
  }

  onAppChange($event): void {
    this.appChangeSource.next($event.target.value);
}

}
