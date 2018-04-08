import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ContractTermsViewModel } from '../../../../viewmodel/templates/contract-terms/contracttermsviemodel';
import { AuthenticatedHttpService } from '../../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../../common/shared/services/portal.service';
import { HttpErrorResponse } from '@angular/common/http';
import { SaveContractTermsViewModel } from '../../../../viewmodel/templates/contract-terms/saveContractTermsViewModel';
import { ObjectState } from '../../../../../common/enums';

@Injectable()
export class ContractTermsDataService {

  contractTermsGroupDto: ContractTermsViewModel[];

  constructor(private authenticatedHttpService: AuthenticatedHttpService, private portalService: PortalService) { }

  getContractTerms(templateId): Observable<ContractTermsViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/ContractTemplates/GetClauseLibraryFields/', templateId).map( data => {
       this.contractTermsGroupDto = data.result;
      return this.contractTermsGroupDto;
    });
  }

  // addContractTerms(contractTermsGroup: ContractTermsViewModel[], templateId): Observable<number> {
  //   const saveContractTerms: SaveContractTermsViewModel = {
  //     id : templateId,
  //     clauseLibraryFields: contractTermsGroup,
  //     objectState: ObjectState.Unchanged
  //   };
  //   console.log('Country at service', JSON.stringify(contractTermsGroup));
  //   return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
  //     + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', saveContractTerms)
  //     .do(data => console.log('All: '))
  //     .catch(this.handleError)  ;
  // }

  addContractTerms(contractTerms: SaveContractTermsViewModel): Observable<number> {
    // const saveContractTerms: SaveContractTermsViewModel = {
    //   id : templateId,
    //   clauseLibraryFields: contractTermsGroup,
    //   objectState: ObjectState.Unchanged
    // };
    // console.log('Country at service', JSON.stringify(contractTermsGroup));
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', contractTerms)
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
