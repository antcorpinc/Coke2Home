import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { Observable } from 'rxjs/Observable';
import { MgApplicationViewModel } from '../../../viewmodel/usersviewmodel/mgapplicationlistviewmodel';
import { MgRoleViewModel } from '../../../viewmodel/usersviewmodel/mgrolelistviewmodel';
import { DepartmentViewModel } from '../../../viewmodel/usersviewmodel/departmentviewmodel';
import { DesignationViewModel } from '../../../viewmodel/usersviewmodel/designationviewmodel';
import { AgencyViewModel } from '../../../viewmodel/usersviewmodel/agencyviewmodel';
import { BranchViewModel } from '../../../viewmodel/usersviewmodel/branchviewmodel';
import { HotelNameViewModel } from '../../../viewmodel/usersviewmodel/hotelnameviewmodel';


@Injectable()
export class BackofficeLookupService {
departmentsDto: DepartmentViewModel[];
applicationsDto: MgApplicationViewModel[];
rolesDto: MgRoleViewModel[];
hotelsDto: HotelNameViewModel[] = [];
designationDto: DesignationViewModel[];
branchDto: BranchViewModel[] = [];
agencyDto: AgencyViewModel[] = [];


constructor(private authenticatedHttpService: AuthenticatedHttpService,
  private portalService: PortalService
 ) {

}

getApplications(): Observable<MgApplicationViewModel[]> {
  return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi + 'api/Application/Get').map( data => {
     this.applicationsDto = data;
     console.log('Applications at service', this.applicationsDto);
    return this.applicationsDto;
});
}

getRolesByApplicationId(applicationId): Observable<MgRoleViewModel[]> {
  return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
    + 'api/Role/GetByApplicationId?applicationId=' + applicationId).map( data => {
     this.rolesDto = data;
     console.log('Roles at service', this.rolesDto);
    return this.rolesDto;
});
}

getDepartments(): Observable<DepartmentViewModel[]> {
  return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi + 'api/Department/Get').map( data => {
     this.departmentsDto = data;
    return this.departmentsDto;
});
}

getRolesByApplicationName(applicationName: string): Observable<MgRoleViewModel[]> {
  return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
      + 'api/Role/GetByApplicationName?applicationName=' + applicationName).map( data => {
     this.rolesDto = data;
    return this.rolesDto;
});
}

getHotelsByBrands(): Observable<HotelNameViewModel[]> {
  return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/HotelManagement/GetAllHotelNames').map( data => {
     this.hotelsDto = data.result;
    return this.hotelsDto;
});
}

getHotelsByBrandIds(brandIds: number[]): Observable<HotelNameViewModel[]> {
  return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/HotelManagement/GetHotelNamesByBrandIds?ids=' + brandIds).map( data => {
     this.hotelsDto = data;
    return this.hotelsDto;
});
}

getAgencies(): Observable<AgencyViewModel[]> {
  return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.BackOfficeApi
  + 'api/Agency/Get').map(
  // return this.authenticatedHttpService.get('http://172.27.127.102:5000/api/Agency/Get').map(
    data => {
      data.result.forEach(element => {
        this.agencyDto.push(element.mgAgency);
    });
    return this.agencyDto;
});
}

getAgencyBranches(id: number): Observable<BranchViewModel[]> {
   return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.BackOfficeApi
    + 'api/Branch/GetBranchByAgancyId?agencyId=' + id).map(
  // console.log('getBranches - Agency ID: ', id);
  //  return this.authenticatedHttpService.get('http://172.27.127.102:5000/api/Branch/GetBranchByAgancyId?agencyId=' + id).map(
    data => {
        data.result.forEach(element => {
          this.branchDto.push(element.mgBranch);
        });
    return this.branchDto;
  });
}
getIndividualHotels(): Observable<HotelNameViewModel[]> {
  return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
    + 'api/HotelManagement/GetHotelsWithoutBrands').map(
     data => {
    this.hotelsDto = data.result;
    return this.hotelsDto;
});
}

getDesignationByType(userType: string): Observable<DesignationViewModel[]> {
  return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
  + 'api/Miscellaneous/GetDesignation/', JSON.stringify(userType)).map( data => {
    this.designationDto = data.result;
    return this.designationDto;
  });
}

}
