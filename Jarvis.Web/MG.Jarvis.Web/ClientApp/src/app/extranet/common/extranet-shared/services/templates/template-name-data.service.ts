import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class TemplateNameDataService {
  private templateNameSource = new BehaviorSubject<string>('');
  templateName = this.templateNameSource.asObservable();

  constructor() { }

  changeTemplateName(templateName: string) {
  // console.log('At Data Servise Template name - ' + templateName );
    this.templateNameSource.next(templateName);
  }
}
