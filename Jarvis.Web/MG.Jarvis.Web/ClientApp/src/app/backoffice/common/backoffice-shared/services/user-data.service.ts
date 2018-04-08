import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { MgUsersListViewModel } from '../../../viewmodel/usersviewmodel/mguserlistviewmodel';
import { PortalService } from '../../../../common/shared/services/portal.service';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { BACKOFFICECONSTANTS } from '../../Constants';
import { MgUserViewModel } from '../../../viewmodel/usersviewmodel/mguserviewmodel';
import { AgentInfoViewModel } from '../../../viewmodel/usersviewmodel/agentinfoviewmodel';
import { HotelUserListViewModel } from '../../../viewmodel/usersviewmodel/hoteluserlistviewmodel';
import { Agentuserlistviewmodel } from '../../../viewmodel/usersviewmodel/agentuserlistviewmodel';
import { HotelUserViewModel } from '../../../viewmodel/usersviewmodel/hoteluserinfoviewmodel';
import { ApplicationRoleIdViewModel } from '../../../viewmodel/usersviewmodel/applicationroleidviewmodel';
import { HotelViewModel } from '../../../viewmodel/usersviewmodel/hotelviewmodel';

const userType = BACKOFFICECONSTANTS.userType.mgUser;

@Injectable()
export class UserDataService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private portalService: PortalService,
    private activatedRoute: ActivatedRoute ) { }

    mgUserListDto: MgUsersListViewModel[];
    mgUserDto: MgUserViewModel;
    hotelUserListDto: HotelUserListViewModel[];
    hotelUserDto: HotelUserViewModel;
    agentUserListDto: Agentuserlistviewmodel[];

    getMgUsers(): Observable<MgUsersListViewModel[]> {
      return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
      + 'api/MGUser/Get').map(data => {
            if (data === null) {
                this.mgUserListDto = [];
            } else {
                this.mgUserListDto = data;
            }
            return this.mgUserListDto;
        });
    }

    getHotelUsers(): Observable<HotelUserListViewModel[]> {
      return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
        + 'api/HotelUser/Get').map((response: any) => {
            if (response === null) {
                this.hotelUserListDto = [];
            } else {
                this.hotelUserListDto = response;
            }
            return this.hotelUserListDto;
        });
    }

    getAgentUsers(): Observable<Agentuserlistviewmodel[]> {
      return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
      + 'api/Agent/Get').map(data => {
            if (data === null) {
                this.agentUserListDto = [];
            } else {
                this.agentUserListDto = data;
            }
            return this.agentUserListDto;
        });
    }
    deleteAgentUser(agentUserId: string): Observable<boolean> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
          + 'api/Agent/Delete/', agentUserId);
    }

    deleteMGUser(userId: number): Observable<boolean> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
          + 'api/MGUser/Delete/', userId);
    }
    deleteHotelUser(userId: number): Observable<boolean> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
          + 'api/HotelUser/Delete/', JSON.stringify(userId));
      }


    createMGUser(mgUserViewModel: MgUserViewModel): Observable<number> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
        + 'api/MGUser/Create/', mgUserViewModel);
    }

    updateMGUser(id: string, mgUserViewModel: MgUserViewModel): Observable<number> {
      return this.authenticatedHttpService.put(this.portalService.appSettings.BaseUrls.UserMgmtApi
        + 'api/MGUser/Update/' + id + '/', mgUserViewModel);
    }

    getMGUserById(userId: string): Observable<MgUserViewModel> {
      return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
        + 'api/MGUser/GetById?userId=' + userId).map(data => {
          this.mgUserDto = new MgUserViewModel();
          this.mgUserDto.employeeId = data.employeeId;
          this.mgUserDto.id = data.id;
          this.mgUserDto.userName = data.userName;
          this.mgUserDto.email = data.email;
          this.mgUserDto.profilePictureUri = data.profilePictureUri;
          this.mgUserDto.activationDate = data.activationDate;
          this.mgUserDto.firstName = data.firstName;
          this.mgUserDto.lastName = data.lastName;
          this.mgUserDto.createdBy = data.createdBy;
          data.departments.forEach(element => {
            if (this.mgUserDto.departments == null || this.mgUserDto.departments === undefined ) {
              this.mgUserDto.departments = new Array<string>();
            }
               this.mgUserDto.departments.push(element.id);
          });
          data.userApplicationRole.forEach(element => {
            if (this.mgUserDto.userApplicationRole == null || this.mgUserDto.userApplicationRole === undefined ) {
              this.mgUserDto.userApplicationRole = new Array<ApplicationRoleIdViewModel>();
            }
            const appRoleId: ApplicationRoleIdViewModel = new ApplicationRoleIdViewModel();
            appRoleId.applicationId = element.applicationId;
            appRoleId.roleId = element.roleId;
            this.mgUserDto.userApplicationRole.push(appRoleId);
          });

          return this.mgUserDto;
        });
    }

  createAgentUser(agentInfo: AgentInfoViewModel): Observable<any> {
      return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
        + 'api/agent/Create/', JSON.stringify(agentInfo));
  }

  createHotelUser(hotelUserInfo: HotelUserViewModel ): Observable<number> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
      + 'api/HotelUser/Create/', hotelUserInfo);
  }

  getHotelUserById(userId: string): Observable<HotelUserViewModel> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
      + 'api/HotelUser/GetById?userId=' + userId).map(data => {
        this.hotelUserDto = data;
        this.hotelUserDto.extranetRoleId = data.userApplicationRole[0].roleId;
        this.hotelUserDto.hotelId = data.hotels;
        data.hotels.forEach(element => {
          if (this.hotelUserDto.hotelId == null || this.hotelUserDto.hotelId === undefined ) {
            this.hotelUserDto.hotelId = new Array<number>();
          }
             this.hotelUserDto.hotelId.push(element.id);
        });
        return this.hotelUserDto;
      });
  }

}
