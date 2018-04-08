import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { HotelsListViewModel } from '../../viewmodel/hoteldetailsviewmodel/hotelslistviewmodel';
import { HotelDataService } from '../../common/extranet-shared/services/hotel-data.service';
import { AutoCompleteModule } from 'primeng/primeng';
import { CONSTANTS } from '../../../common/constants';
import { UserProfileService } from '../../../common/shared/services/user-profile.service';
import { DialogsService } from '../../common/extranet-shared/dialogs/dialogs.service';

@Component({
  selector: 'app-hotel-list',
  templateUrl: './hotel-list.component.html',
  styleUrls: ['./hotel-list.component.css']
})

export class HotelListComponent implements OnInit {
  operation: string;
  hotelList: HotelsListViewModel[];
  isDesc = false;
  column: string;
  filteredHotels: any[];
  pagesize = 2;
  currentpage = 1;
  direction: number;
  searchParameter = '';
  searchText: string;
  selectedHotel: '';
  privileges: string[];
  isDeleted: boolean;
  actions: string;
  result: any;
  deleteView = false;
  createView = false;
  readView = false;
  noDataAvailable: boolean;

  read = CONSTANTS.operation.read;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;

  constructor(private router: Router,
    private hotelDataService: HotelDataService,
    private userProfileService: UserProfileService,
    private dialogsService: DialogsService,
    private changeDetectorRefs: ChangeDetectorRef) { }

  ngOnInit() {
    this.getHotelsList();
    this.isDesc = false;
    this.getPrivileges();
  }

  getHotelsList() {
    this.hotelDataService.getHotelsList().subscribe((hotelList) => {
      this.hotelList = hotelList.result;
      if(hotelList.length === 0){
        this.noDataAvailable = true;
      }
    });
    this.changeDetectorRefs.detectChanges();
  }

  private createHotel() {
    this.router.navigate(['hotelmgmt/hotel', 0, this.create]);
  }

  getPrivileges() {
    this.privileges = this.userProfileService.GetUserPermissionsForFeature
      (CONSTANTS.application.extranet, CONSTANTS.featuretypeid.HotelProfile);
    for (const privilege of this.privileges) {
      if (privilege === 'VW') {
        this.readView = true;
      } else if (privilege === 'CR') {
        this.createView = true;
      } else if (privilege === 'DE') {
        this.deleteView = true;
      }
    }
  }

  filterHotelSingle(event) {
    const query = event.query;
    this.filteredHotels = this.filterHotel(query, this.hotelList);
  }

  filterHotel(query, hotels: any[]): any[] {
    const filtered: any[] = [];
    for (let i = 0; i < hotels.length; i++) {
      const hotel = hotels[i].hotels;
      for (let j = 0; j < hotel.length; j++) {
        query = query.toLowerCase();
        if (hotel[j].hotelName && hotel[j].hotelName.toLowerCase().includes(query) ||
          hotel[j].hotelCode && hotel[j].hotelCode.toLowerCase().includes(query) ||
          hotel[j].contactPerson && hotel[j].contactPerson.toLowerCase().includes(query) ||
          hotel[j].contactNumber && hotel[j].contactNumber.toLowerCase().includes(query) ||
          hotel[j].email && hotel[j].email.toLowerCase().includes(query) ||
          hotel[j].location && hotel[j].location.toLowerCase().includes(query)) {
          if (filtered.length <= 9) {
            filtered.push(hotel[j]);
          }
        }
      }
    } return filtered;
  }

  sort(property) {
    this.isDesc = !this.isDesc;
    this.column = property;
    this.direction = this.isDesc ? 1 : -1;
  }

  onSelectHotel(event) {
    this.selectedHotel = event.hotelName;
  }

  onSearch(searchText) {
    this.searchParameter = searchText;
  }

  onEveryKey() {
    if (this.searchText.length <= 3) {
      this.getHotelsList();
      this.searchParameter = '';
      this.selectedHotel = '';
    }
  }

  onPageChange(event) {
    this.pagesize = event.value;
  }

  GoHotelUpdate(value) {
    const val = value.split('-');
    const hotelId = this.operation = val[0];
    this.operation = val[1];
    if (this.operation.trim().toLowerCase() === this.edit) {
      this.router.navigate(['hotelmgmt/hotel', hotelId, this.operation.trim().toLowerCase(), 'profilecompl']);
    }
  }

  deleteHotel(hotelId) {
    this.hotelDataService.deleteHotel(hotelId).subscribe((isDeleted) => {
      this.isDeleted = isDeleted;
      this.getHotelsList();
      this.searchText = '';
      this.searchParameter = '';
      this.selectedHotel = '';
    });
  }

  GoHotelDelete(value) {
    const val = value.split('-');
    const hotelId = val[0];
    this.dialogsService
      .confirm('Confirm', 'Are you sure you want to delete this Hotel?').subscribe(res => {
        this.result = res;
        if (this.result) {
          this.deleteHotel(hotelId);
          this.searchText = '';
          this.searchParameter = '';
          this.selectedHotel = '';
        } else {
          this.actions = null;
        }
      });
  }
}
