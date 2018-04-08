import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { FacilityGroupViewModel } from '../../../../viewmodel/facilitiesservicesviewmodel/facilitygroupviewmodel';
import { AuthenticatedHttpService } from '../../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../../common/shared/services/portal.service';
import { HttpErrorResponse } from '@angular/common/http';
import { FacilitiesViewModel } from '../../../../viewmodel/facilitiesservicesviewmodel/facilitiesviewmodel';
import { TemplateFacilitiesViewModel } from '../../../../viewmodel/templates/facilities/templatefacilitiesviewmodel';
import { ObjectState } from '../../../../../common/enums';

@Injectable()
export class TemplateFacilitiesDataService {

  templateFacilityGroupDto: FacilityGroupViewModel[];

  constructor(private authenticatedHttpService: AuthenticatedHttpService, private portalService: PortalService) { }

  getTemplateFacilitiesAndServices(templateId): Observable<FacilityGroupViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/ContractTemplates/GetHotelFacilityFields/', templateId).map( data => {
       this.templateFacilityGroupDto = data.result;
      return this.templateFacilityGroupDto;
    });
  }

  addFacilities(templateFacilitiesGroup: FacilityGroupViewModel[], templateId): Observable<number> {
    const templateFacilities: TemplateFacilitiesViewModel = {
      id : templateId,
      hotelFacilityFields: templateFacilitiesGroup,
      objectState: ObjectState.Unchanged
    };
    console.log('Country at service', JSON.stringify(templateFacilities));
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', templateFacilities)
      .do(data => console.log('All: '))
      .catch(this.handleError)  ;
  }

  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof Error) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return Observable.throw(errorMessage);
  }
}
