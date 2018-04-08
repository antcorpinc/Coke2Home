import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class TemplateUrlNotificationService {
  private urlPathSource = new BehaviorSubject<string>('');
  urlPath = this.urlPathSource.asObservable();
  constructor() { }
  changeURLRoute(urlpath: string) {
      this.urlPathSource.next(urlpath);
    }
}
