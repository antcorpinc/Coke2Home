
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { TemplatesDataService } from './templates-data.service';
import { TemplateHotelInfoViewModel, TemplateViewModel } from '../../../../viewmodel/templates/hotel-info/hotelinfoviewmodel';



const templateViewModel = new TemplateViewModel();
@Injectable()
export class TemplateHotelFieldsResolverService implements Resolve<TemplateHotelInfoViewModel> {
  constructor(private templatesDataService: TemplatesDataService) { }
  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<TemplateHotelInfoViewModel> {
     const templateId: number =  +route.parent.params['id'];
      templateViewModel.id = +templateId;
      if (templateId > 0 && !isNaN(templateId) ) {
        // console.log('templateId- ' + templateId);
      return this.templatesDataService.getTemplateHotelFields(templateViewModel); } else {
        // console.log('templateId- ' + templateId);
      return this.templatesDataService.getInitialHotelFields(); }
}
}
