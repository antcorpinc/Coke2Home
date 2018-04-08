import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AuthenticatedHttpService } from '../../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../../common/shared/services/portal.service';
import { AmenitiesGroupViewModel } from '../../../../viewmodel/templates/amenities/amenitiesgroupviewmodel';
import { ObjectState } from '../../../../../common/enums';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class TemplateAmenitiesDataService {

  templateAmenitiesGroupDto: AmenitiesGroupViewModel[];

  constructor(private authenticatedHttpService: AuthenticatedHttpService, private portalService: PortalService) { }

  getTemplateAmenities(templateId): Observable<AmenitiesGroupViewModel[]> {
    const template = {
      id: templateId
    };
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/ContractTemplates/GetRoomFacilityFields/', template).map( data => {
       this.templateAmenitiesGroupDto = data.result.roomFacilityFields;
      return this.templateAmenitiesGroupDto;
    });
  }

  addAmenities(templateAmenitiesGroup: AmenitiesGroupViewModel[], templateId): Observable<number> {
    const templateAmenities = {
      id : templateId,
      roomFacilityFields: templateAmenitiesGroup,
      objectState: ObjectState.Unchanged
    };
    // console.log('Country at service', JSON.stringify(templateAmenities));
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', templateAmenities)
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
