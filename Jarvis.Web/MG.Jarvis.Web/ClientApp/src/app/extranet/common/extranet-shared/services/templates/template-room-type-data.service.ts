import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../../common/shared/services/portal.service';
import { TemplateHotelInfoViewModel, TemplateViewModel } from '../../../../viewmodel/templates/hotel-info/hotelinfoviewmodel';
import { Observable } from 'rxjs/Observable';
import { TemplateRoomtypeinfoviewmodel } from '../../../../viewmodel/templates/room-type/roomtypeinfoviewmodel';

@Injectable()
export class TemplateRoomTypeDataService {
  templateRoomtypeinfoviewmodel: TemplateRoomtypeinfoviewmodel;

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private portalService: PortalService) { }

  public getTemplateRoomTypeFields(templateViewModel: TemplateViewModel): Observable<TemplateRoomtypeinfoviewmodel> {
  console.log('getTemplateRoomTypeFields');
  return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/ContractTemplates/GetRoomFields/', templateViewModel).map( data => {
      this.templateRoomtypeinfoviewmodel = data.result;
        return this.templateRoomtypeinfoviewmodel;
    });
  }

  saveTemplateRoomTypeFields(templateRoomtypeinfoviewmodel: TemplateRoomtypeinfoviewmodel): Observable<any> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', templateRoomtypeinfoviewmodel);
  }
}
