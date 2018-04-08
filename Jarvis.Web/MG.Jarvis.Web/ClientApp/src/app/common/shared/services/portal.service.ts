import { Injectable } from '@angular/core';

declare var JarvisAppSettings: any;

export interface IJarvisAppSettings {
  BaseUrls: IBaseUrls;
  AccessToken: string;
  UserFullName: string;
  Name: string;
  FirstName: string;
  IdToken: string; // Todo:Not needed remove later,
  SubjectId: string;
  Disabled: string;
}

export interface IBaseUrls {
  Api: string;
  Auth: string;
  Web: string;
  BackOfficeApi: string;
  ExtranetApi: string;
  UserMgmtApi: string;
}
@Injectable()
export class PortalService {
  public appSettings: IJarvisAppSettings;

  constructor()  {
    this.loadSettings();
    // Todo: Remove this later
    console.log(this.appSettings.Name);
    console.log(this.appSettings.SubjectId);
    console.log(this.appSettings.AccessToken);
    console.log(this.appSettings.BaseUrls.Api);
    console.log(this.appSettings.BaseUrls.BackOfficeApi);
    console.log(this.appSettings.BaseUrls.ExtranetApi);
    console.log(this.appSettings.BaseUrls.UserMgmtApi);
    console.log(this.appSettings.FirstName);
    console.log(this.appSettings.IdToken);
    console.log('Disabled ' + this.appSettings.Disabled);
    // ~Todo: Remove this later
  }

  private loadSettings() {
    this.appSettings = {
      BaseUrls : {
        Api: JarvisAppSettings.BaseUrls.Api,
        Auth: JarvisAppSettings.BaseUrls.Auth,
        Web: JarvisAppSettings.BaseUrls.Web,
        BackOfficeApi: JarvisAppSettings.BaseUrls.BackOfficeApi,
        ExtranetApi: JarvisAppSettings.BaseUrls.ExtranetApi,
        UserMgmtApi: JarvisAppSettings.BaseUrls.UserMgmtApi
      },
      AccessToken: JarvisAppSettings.AccessToken,
      UserFullName: '',
      Name: JarvisAppSettings.Name,
      FirstName: JarvisAppSettings.FirstName,
      IdToken: JarvisAppSettings.IdToken,
      SubjectId: JarvisAppSettings.SubjectId,
      Disabled: JarvisAppSettings.Disabled
    };
  }
}
