import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../../common/shared/services/portal.service';
import { TemplateHotelInfoViewModel, TemplateViewModel } from '../../../../viewmodel/templates/hotel-info/hotelinfoviewmodel';
import { Observable } from 'rxjs/Observable';
import { CopyTemplateViewModel } from './../../../../viewmodel/templates/copy-template/copytemplateviewmodel';
import { Templateslistviewmodel } from '../../../../viewmodel/templates/templates-details/templateslistviewmodel';


@Injectable()
export class TemplatesDataService {
  templateHotelInfoViewModel: TemplateHotelInfoViewModel;
  private _templateListDto: Templateslistviewmodel[];
  private _templateHotelFieldsDetails: TemplateHotelInfoViewModel;
  get templateHotelFieldsDetails(): TemplateHotelInfoViewModel {
    return this._templateHotelFieldsDetails;
  }
  set templateHotelFieldsDetails(template: TemplateHotelInfoViewModel) {
    this._templateHotelFieldsDetails = template;
  }

  get templateListDto(): Templateslistviewmodel[] {
    return this._templateListDto;
  }
  set templateListDto(template: Templateslistviewmodel[]) {
    this._templateListDto = template;
  }

  constructor(private authenticatedHttpService: AuthenticatedHttpService, private portalService: PortalService) { }

  getTemplatesList() {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/GetContractTemplates/');
  }
  // templateListDto: Templateslistviewmodel[];
  /*
  getTemplatesList(): Observable<any> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/GetContractTemplates/').map(data => {
        if (data === null) {
            this.templateListDto = [];
        } else {
            this.templateListDto = data.result;
        }
        return this.templateListDto;
    });
  }*/

  getInitialHotelFields(): Observable<TemplateHotelInfoViewModel> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/GetHotelFields/').map(data => {
        this.templateHotelInfoViewModel = data.result;
        return this.templateHotelInfoViewModel;
      });
  }

  saveTemplateHotelFields(templateHotelInfoViewModel: TemplateHotelInfoViewModel): Observable<any> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', templateHotelInfoViewModel);
  }

  getTemplateHotelFields(templateViewModel: TemplateViewModel): Observable<TemplateHotelInfoViewModel> {
    // console.log('I m at getTemplateHotelFields');
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/GetHotelFields/', templateViewModel).map(data => {
        this.templateHotelInfoViewModel = data.result;
        return this.templateHotelInfoViewModel;
      });
  }

  copyTemplate(copiedTemplate: CopyTemplateViewModel): Observable<any> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/CreateTemplateCopy/', copiedTemplate);
  }

  deleteTemplate(templateId: number): Observable<boolean> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/DeleteTemplate/', templateId);
  }

//   checkTemplateName(templateList: Templateslistviewmodel[], templateName: string): boolean {
//     templateList.find ( template => template.)
// return false;
//   }
}
