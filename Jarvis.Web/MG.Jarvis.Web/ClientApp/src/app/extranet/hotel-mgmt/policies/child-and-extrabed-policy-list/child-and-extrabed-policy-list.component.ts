import { ChildAndExtraBedPolicyComponent } from './../child-and-extra-bed-policy/child-and-extra-bed-policy.component';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectState } from '../../../../common/enums';
import { MatTableDataSource } from '@angular/material';
import { ChildAndExtraBedPolicyViewModel } from './../../../viewmodel/policiesviewmodel/childandextrabedpolicyviewmodel';
import { ChildAndExtraBedPolicyListViewmodel } from './../../../viewmodel/policiesviewmodel/childandextrabedpolicylistviewmodel';
import { HotelCurrencyViewModel } from './../../../viewmodel/common/hotelcurrencyviewmodel';
import { ExtranetLookupService } from './../../../common/extranet-shared/services/extranet-lookup';
import { PoliciesDataService } from './../../../common/extranet-shared/services/policies-data.service';
import { CONSTANTS } from '../../../../common/constants';
import { EXTRANETCONSTANTS } from '../../../common/constants';

@Component({
  selector: 'app-child-and-extrabed-policy-list',
  templateUrl: './child-and-extrabed-policy-list.component.html',
  styleUrls: ['./child-and-extrabed-policy-list.component.css']
})
export class ChildAndExtrabedPolicyListComponent implements OnInit {
  operation: string;
  hotelId: number;
  childAndExtrabedPolicyList: ChildAndExtraBedPolicyListViewmodel[];
  childAndExtrabedPolicyArray: ChildAndExtraBedPolicyViewModel;
  hotelCurrency: HotelCurrencyViewModel[];
  displayedColumns = ['policyName', 'details', 'action'];
  dataSource: MatTableDataSource<ChildAndExtraBedPolicyListViewmodel>;
  privileges: string[];
  isRead: boolean;
  noRoomsPresent: boolean;
  currencyCode: string;
  noDataAvailable: boolean;
  edit = CONSTANTS.operation.edit;
  read = CONSTANTS.operation.read;
  create = CONSTANTS.operation.create;
  isFree = EXTRANETCONSTANTS.policies.isFree;
  isPaid = EXTRANETCONSTANTS.policies.isPaid;
  
  constructor(private router: Router,
    private policiesDataService: PoliciesDataService,
    private extranetLookupService: ExtranetLookupService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    window.scrollTo(0, 0);
    this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.getChildAndExtraBedpolicyDetails();
    this.getChildAndExtraBedpolicyList(this.hotelId);
    this.getCurrencyByHotelId(this.hotelId);
    if (this.operation.toLowerCase().trim() === this.read) {
      this.isRead = true;
    }
  }

  getChildAndExtraBedpolicyList(hotelId: number) {
    this.policiesDataService.getChildAndExtraBedpolicyList(hotelId).subscribe((childAndExtrabedPolicyList) => {
      this.childAndExtrabedPolicyList = childAndExtrabedPolicyList;
      this.dataSource = new MatTableDataSource<ChildAndExtraBedPolicyListViewmodel>(childAndExtrabedPolicyList);
      if(this.childAndExtrabedPolicyList === null){
        this.noDataAvailable = true;
      }
    });
  }

  getChildAndExtraBedpolicyDetails() {
    this.childAndExtrabedPolicyArray = this.activatedRoute.snapshot.data['childAndExtraBedPolicyData'];
    if(this.childAndExtrabedPolicyArray[0].maxChildAndExtraBedPerRoomList.length === 0) {
      this.noRoomsPresent = true;
    } else{
      this.noRoomsPresent = false;
    }
  }

  getCurrencyByHotelId(hotelId: number) {
    this.extranetLookupService.getCurrencyByHotelId(hotelId).subscribe((hotelCurrency) => {
      this.hotelCurrency = hotelCurrency;
      this.currencyCode = this.hotelCurrency[0].currencyCode;
    });
  }

  createchildextrabedpolicy() {
    this.router.navigate(['../childandextrabedpolicy', 0, this.create], { relativeTo: this.activatedRoute });
  }

  GoPolicyUpdate(e) {
    const val = e.value.split('-');
    const hotelId = val[0];
    this.operation = val[1];
    if (this.operation.trim().toLowerCase() === this.edit) {
      this.router.navigate(['../childandextrabedpolicy', hotelId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
    }
  }
}




