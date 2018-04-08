import { PoliciesDataService } from './policies-data.service';
import { Injectable } from '@angular/core';
import { ChildAndExtraBedPolicyViewModel } from './../../../viewmodel/policiesviewmodel/childandextrabedpolicyviewmodel';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class PoliciesDataResolverService implements Resolve<ChildAndExtraBedPolicyViewModel> {

    constructor(private policiesDataService: PoliciesDataService) { }

    resolve(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<ChildAndExtraBedPolicyViewModel> {
        const hotelId = route.parent.params['id'];
        return this.policiesDataService.getChildAndExtraBedpolicyDetails(hotelId);
    }

}
