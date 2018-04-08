
export class HotelsListViewModel {
  hotelBrandId: number;
  hotelBrandName: string;
  isExpanded: boolean;
  hotels: Array<HotelDataViewModel>;
}

export class HotelDataViewModel {
  hotelId: number;
  hotelName: string;
  hotelCode: string;
  contactPerson: string;
  contactNumber: string;
  email: string;
  location: string;
  isActive: boolean;
}
