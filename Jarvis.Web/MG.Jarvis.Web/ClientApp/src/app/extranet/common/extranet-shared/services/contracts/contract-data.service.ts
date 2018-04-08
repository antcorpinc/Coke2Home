import { Injectable } from '@angular/core';
import { ContractType } from '../../../../../common/enums';
import { AuthenticatedHttpService } from '../../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../../common/shared/services/portal.service';
import { ContractStepsViewModel } from '../../../../viewmodel/contracts/contractstepsviewmodel';
import { Observable } from 'rxjs/Observable';
import { ContractsListViewModel } from '../../../../viewmodel/contracts/contractslistviewmodel';

@Injectable()
export class ContractDataService {
  private _contractType: ContractType;
  private _templateId: number;
  private _showFacility: boolean;
  private _showamenity: boolean;
  templateStep: ContractStepsViewModel;

  get contractType(): ContractType {
    return this._contractType;
  }
  set contractType(value: ContractType) {
    this._contractType = value;
  }
  get templateId(): number {
    return this._templateId;
  }
  set templateId(value: number) {
    this._templateId = value;
  }

  get showamenity(): boolean {
    return this._showamenity;
  }
  set showamenity(value: boolean) {
    this._showamenity = value;
  }
  get showFacility(): boolean {
    return this._showFacility;
  }
  set showFacility(value: boolean) {
    this._showFacility = value;
  }
  constructor(private authenticatedHttpService: AuthenticatedHttpService, private portalService: PortalService) { }

  contractListDto: ContractsListViewModel[];

  getPublishedTemplates() {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/GetPublishedTemplatesForContractCreation/');
  }

  getContractsList(): Observable<ContractsListViewModel[]> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/Contracts/getallcontracts').map(data => {
        if (data === null) {
          this.contractListDto = [];
        } else {
          this.contractListDto = data.result;
        }
        return this.contractListDto;
      });
  }
  getTemplateSteps(templateId: number): Observable<ContractStepsViewModel> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/ContractTemplates/GetCountOfFacilitiesAndAmenitiesForSelectedTemplate/', templateId).map(data => {
        this.templateStep = data.result;
        return this.templateStep;
      });
  }

}
