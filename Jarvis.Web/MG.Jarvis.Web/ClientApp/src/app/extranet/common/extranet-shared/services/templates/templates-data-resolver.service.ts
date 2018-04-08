import { TemplatesDataService } from './templates-data.service';
import { Templateslistviewmodel } from './../../../../viewmodel/templates/templatedetailviewmodel';
import { Injectable } from '@angular/core';
import { ExtranetLookupService } from '../extranet-lookup';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class TemplatesDataResolverService implements Resolve<Templateslistviewmodel[]> {

    constructor(private templatesDataService: TemplatesDataService) { }

    resolve(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<Templateslistviewmodel[]> {
        return this.templatesDataService.getTemplatesList();
    }
}
