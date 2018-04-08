import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { TemplatesDataService } from './templates-data.service';
import { TemplateViewModel } from '../../../../viewmodel/templates/hotel-info/hotelinfoviewmodel';
import { TemplateRoomtypeinfoviewmodel } from '../../../../viewmodel/templates/room-type/roomtypeinfoviewmodel';
import { TemplateRoomTypeDataService } from './template-room-type-data.service';

const templateViewModel = new TemplateViewModel();
const templateRoomtypeinfoviewmodel = new TemplateRoomtypeinfoviewmodel();

@Injectable()
export class TemplateRoomTypeFieldsResolverService implements Resolve<TemplateRoomtypeinfoviewmodel> {
  constructor(private roomTypeDataService: TemplateRoomTypeDataService) { }
  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<TemplateRoomtypeinfoviewmodel> {
     const templateId: number =  +route.parent.params['id'];
      templateViewModel.id = +templateId;
      return this.roomTypeDataService.getTemplateRoomTypeFields(templateViewModel);
}
}
