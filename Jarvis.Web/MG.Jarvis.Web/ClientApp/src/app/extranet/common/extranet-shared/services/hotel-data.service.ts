import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { HotelDetailsViewModel } from '../../../viewmodel/hoteldetailsviewmodel/hoteldetailsviewmodel';
import { Observable } from 'rxjs/Observable';
import { PortalService } from '../../../../common/shared/services/portal.service';

@Injectable()
export class HotelDataService {
  private _hotelData: HotelDetailsViewModel;
  get hotelDetails(): HotelDetailsViewModel {
    return this._hotelData;
  }
  set hotelDetails(hotel: HotelDetailsViewModel) {
    this._hotelData = hotel;
  }

  get hotelId(): number {
    if (this._hotelData.hotelId !== undefined) {
      return this._hotelData.hotelId;
    } else {
      return 0; }
  }

  constructor(private authenticatedHttpService: AuthenticatedHttpService, private portalService: PortalService) { }

  addHotelDetails(hotelDetails: HotelDetailsViewModel): Observable<number> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/HotelManagement/CreateHotel/', hotelDetails);
  }
  getHotel(hotelId: number): Observable<HotelDetailsViewModel> {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/hotelmanagement/gethotel?=' + hotelId);
  }

  getHotelsList() {
    return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
      + 'api/HotelManagement/GetAllHotels/');
  }

  deleteHotel(hotelId: number): Observable<boolean> {
    return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/HotelManagement/DeleteHotelByHotelId/', hotelId);
}
}
