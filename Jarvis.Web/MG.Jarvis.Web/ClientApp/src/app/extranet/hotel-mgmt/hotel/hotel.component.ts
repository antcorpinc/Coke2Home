import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HotelDetailsViewModel } from '../../viewmodel/hoteldetailsviewmodel/hoteldetailsviewmodel';
import { HotelDataService } from '../../common/extranet-shared/services/hotel-data.service';
import {CONSTANTS} from '../../../common/constants';

@Component({
  selector: 'app-hotel',
  templateUrl: './hotel.component.html',
  styleUrls: ['./hotel.component.css']
})
export class HotelComponent implements OnInit {
  isCreate: boolean;
  hotelId: string;
  operation: string;
  isSideNavDisplay: any;
  hotelDetails: HotelDetailsViewModel = <HotelDetailsViewModel>{};

  hotelName: string;
  hotelLocation: string;
  hotelcode: string;

  read = CONSTANTS.operation.read;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;

  constructor(private route: ActivatedRoute,
    private activatedRoute: ActivatedRoute,
    private hotelDataService: HotelDataService
  ) { }

  ngOnInit() {
    this.isSideNavDisplay = true;
    this.operation = this.route.snapshot.params['operation'];
    console.log('Operation From Hotel' + this.operation);
    this.hotelId = this.activatedRoute.snapshot.params['id'];
    if (this.operation.toLowerCase() !== this.create) {
      this.getHotelDetails(this.hotelId);
    }

    if (this.operation.trim() === this.create) {
      this.isCreate = true;
    }
    window.scrollTo(0, 0);
  }

  showNav() {
    if (this.isSideNavDisplay) {
      this.isSideNavDisplay = false;
    } else { this.isSideNavDisplay = true; }
  }

  private getHotelDetails(hotelId1) {
    this.hotelDataService.getHotel(+hotelId1).subscribe(
      (hotelData) => {
        this.hotelDataService.hotelDetails = hotelData;
        console.log('hotel - ' +
          this.hotelDataService.hotelDetails.hotelName + ' longitude - ' + this.hotelDataService.hotelDetails.longitude);

        if (this.operation.trim() !== this.create) {
          if (this.hotelDataService.hotelDetails !== undefined) {
            this.hotelName = this.hotelDataService.hotelDetails.hotelName;
            this.hotelLocation = this.hotelDataService.hotelDetails.location;
            this.hotelcode = this.hotelDataService.hotelDetails.hotelCode;
          }
        }
      });
  }

}
