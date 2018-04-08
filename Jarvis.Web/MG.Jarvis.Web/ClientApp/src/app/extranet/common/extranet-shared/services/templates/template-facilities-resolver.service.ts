import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { FacilityGroupViewModel } from '../../../../viewmodel/facilitiesservicesviewmodel/facilitygroupviewmodel';
import { TemplateFacilitiesDataService } from './template-facilities-data.service';

@Injectable()
export class TemplateFacilitiesResolverService implements Resolve<FacilityGroupViewModel[]> {

  constructor(private templateFacilitiesDataService: TemplateFacilitiesDataService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<FacilityGroupViewModel[]> {

    const templateId = route.parent.params['id'];
    return this.templateFacilitiesDataService.getTemplateFacilitiesAndServices(templateId);
  }

}
