import { Injectable } from '@angular/core';
import { TemplatesDataService } from '../templates/templates-data.service';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { TemplateHotelInfoViewModel, TemplateViewModel } from '../../../../viewmodel/templates/hotel-info/hotelinfoviewmodel';
import { ContractDataService } from './contract-data.service';

@Injectable()
export class TemplateHotelDetailsResolverService {

  constructor(private templatesDataService: TemplatesDataService,
              private contractDataService: ContractDataService) { }

  templateViewModel: TemplateViewModel;
  templateId = this.contractDataService.templateId;

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<TemplateHotelInfoViewModel> {

    this.templateViewModel = {
        id: this.templateId
    };
    return this.templatesDataService.getTemplateHotelFields(this.templateViewModel);
  }
}
