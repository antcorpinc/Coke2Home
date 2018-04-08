import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { Observable } from 'rxjs/Observable';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { ChildAndExtraBedPolicyViewModel } from './../../../viewmodel/policiesviewmodel/childandextrabedpolicyviewmodel';
import { ChildAndExtraBedPolicyListViewmodel } from './../../../viewmodel/policiesviewmodel/childandextrabedpolicylistviewmodel';
import { CancellationClausetypemasterviewmodel } from '../../../viewmodel/policiesviewmodel/cancellationclausetypemasterviewmodel';
import { CancellationClausechargesmasterviewmodel } from '../../../viewmodel/policiesviewmodel/cancellationclausechargesmasterviewmodel';
import { CancellationPolicyViewModel } from '../../../viewmodel/policiesviewmodel/cancellationpolicyviewmodel';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class PoliciesDataService {
  private _childAndExtraBedPolicyData: ChildAndExtraBedPolicyViewModel;
    get childAndExtraBedPolicyDetails(): ChildAndExtraBedPolicyViewModel {
        return this._childAndExtraBedPolicyData;
    }
    set childAndExtraBedPolicyDetails(policy: ChildAndExtraBedPolicyViewModel) {
       this._childAndExtraBedPolicyData = policy;
  }

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private portalService: PortalService) { }
  childAndExtraBedPolicyListDto: ChildAndExtraBedPolicyListViewmodel[];
  childAndExtraBedPolicyDto: ChildAndExtraBedPolicyViewModel;

  cancellationClauseTypeDto: CancellationClausetypemasterviewmodel;
  cancellationClauseChargesDto: CancellationClausechargesmasterviewmodel;
  cancellationPolicyViewModelDto: CancellationPolicyViewModel;
  cancellationPolicyViewModelDtoList: CancellationPolicyViewModel[];
  deleteClauseIdInfoDto: any;

  getChildAndExtraBedpolicyDetails(hotelId: number): Observable<ChildAndExtraBedPolicyViewModel> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Policies/GetChildrenAndExtraBedPolicy', hotelId).map(data => {
        if (data === null) {
          this.childAndExtraBedPolicyDto = null;
        } else {
          this.childAndExtraBedPolicyDto = data.result;
        }
        return this.childAndExtraBedPolicyDto;
      });
  }

  getChildAndExtraBedpolicyList(hotelId: number): Observable<ChildAndExtraBedPolicyListViewmodel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Policies/GetChildrenAndExtraBedPolicyListingByHotelId', hotelId).map(data => {
        if (data === null) {
          this.childAndExtraBedPolicyListDto = null;
        } else {
          this.childAndExtraBedPolicyListDto = data.result;
        }
        return this.childAndExtraBedPolicyListDto;
      });
  }
  /* Cancellation Policies */
  getCancellationChargesdto(): Observable<CancellationClausechargesmasterviewmodel> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/policies/GetCancellationCharges').map(data => {
        this.cancellationClauseChargesDto = data.result;
         return this.cancellationClauseChargesDto;
      });
  }
  getCancellationPolicyTypedto(): Observable<CancellationClausetypemasterviewmodel> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/policies/GetCancellationPolicyType').map(data => {
        this.cancellationClauseTypeDto = data.result;
        return this.cancellationClauseTypeDto;
      });
  }
  saveAndUpdateCancellationPolicydto(cancellationPoliciesObj: CancellationPolicyViewModel): Observable<any> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/policies/SaveAndUpdateCancellationPolicy', cancellationPoliciesObj).map(data => {
        // console.log('Data from service-saveAndUpdateCancellationPolicydto: ' + data);
      });
  }

  /* Cancellation Policy List */
  getCancellationPolicyListdto(hotelId: number): Observable<CancellationPolicyViewModel[]> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/policies/GetCancellationPolicy', hotelId).map(data => {
        if (data === null) {
          this.cancellationPolicyViewModelDtoList = null;
        } else {
          this.cancellationPolicyViewModelDtoList = data.result;
        }

        return this.cancellationPolicyViewModelDtoList;
      });
  }

  addChildAndExtrabedPolicy(childAndExtrabedPolicy: ChildAndExtraBedPolicyViewModel): Observable<number>{
  return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/Policies/CreateChildrenAndExtraBedPolicy', childAndExtrabedPolicy)
    .do(data => console.log('All: '))
    .catch(this.handleError)  ;
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof Error) {
       errorMessage = `An error occurred 1: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code 1: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return Observable.throw(errorMessage);
  }
  deletePolicyClause(policyClauseID: number) {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/policies/DeleteCancellationPolicyClause', policyClauseID).map(data => {
            this.deleteClauseIdInfoDto = data.result;
            return this.deleteClauseIdInfoDto;
        });
  }
}
