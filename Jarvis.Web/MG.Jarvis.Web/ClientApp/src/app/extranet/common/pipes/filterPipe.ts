import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { HotelsListViewModel } from '../../viewmodel/hoteldetailsviewmodel/hotelslistviewmodel';


@Pipe({
  name: 'filter',
})

@Injectable()

export class FilterPipe implements PipeTransform {
  transform(hotelListData: HotelsListViewModel[], searchText: any, searchParameter: any, selectedHotel: any): any {
    let isTrue = false;
    let allHotels: HotelsListViewModel[];
    if (searchText === undefined || searchText === '') {
      return hotelListData;
    }
    if (selectedHotel) {
      allHotels = hotelListData.filter((hotelList) => {
        isTrue = false;
        const hotelArray = hotelList.hotels.filter((hotel) => {
          if ((hotel.hotelName === selectedHotel)) {
            isTrue = true;
            return hotel;
          }
        });
        if (isTrue) {
          hotelList.isExpanded = true;
          hotelList.hotels = hotelArray;
          return hotelList.hotels;
        }
      });
      return allHotels;
    } else if (searchParameter.length >= 3) {
      searchParameter = searchParameter.toLowerCase();
      allHotels = hotelListData.filter((hotelList) => {
        if (hotelList.hotelBrandName && hotelList.hotelBrandName.toLowerCase().includes(searchParameter)) {
          hotelList.isExpanded = true;
          return hotelList;
        } else {
          isTrue = false;
          const hotelArray = hotelList.hotels.filter((hotel) => {
            if ((hotel.hotelCode && hotel.hotelCode.toLowerCase().includes(searchParameter)) ||
              (hotel.hotelName && hotel.hotelName.toLowerCase().includes(searchParameter)) ||
              (hotel.contactPerson && hotel.contactPerson.toLowerCase().includes(searchParameter)) ||
              (hotel.contactNumber && hotel.contactNumber.toLowerCase().includes(searchParameter)) ||
              (hotel.email && hotel.email.toLowerCase().includes(searchParameter)) ||
              (hotel.location && hotel.location.toLowerCase().includes(searchParameter))) {
              isTrue = true;
              return hotel;
            }
          });
          if (isTrue) {
            hotelList.isExpanded = true;
             hotelList.hotels = hotelArray;
            return hotelArray;
          }
        }
      });
      return allHotels;
    } else {
      return hotelListData;
    }
  }
}
