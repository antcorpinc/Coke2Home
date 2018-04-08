import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AmenitiesGroupViewModel } from '../../../../viewmodel/templates/amenities/amenitiesgroupviewmodel';
import { TemplateAmenitiesDataService } from './template-amenities-data.service';

@Injectable()
export class TemplateAmenitiesResolverService implements Resolve<AmenitiesGroupViewModel[]> {

  constructor(private templateAmenitiesDataService: TemplateAmenitiesDataService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<AmenitiesGroupViewModel[]> {

    const templateId = route.parent.params['id'];
    return this.templateAmenitiesDataService.getTemplateAmenities(templateId);
  }

}
