import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectState } from '../../../../common/enums';
import { CONSTANTS } from '../../../../common/constants';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { CancellationPolicyViewModel } from '../../../viewmodel/policiesviewmodel/cancellationpolicyviewmodel';
import { PoliciesDataService } from './../../../common/extranet-shared/services/policies-data.service';
import { UserProfileService } from '../../../../common/shared/services/user-profile.service';

const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;

@Component({
  selector: 'app-cancellation-policies-list',
  templateUrl: './cancellation-policies-list.component.html',
  styleUrls: ['./cancellation-policies-list.component.css']
})
export class CancellationPoliciesListComponent implements OnInit {
  hotelId: number;
  operation: string;
  isRead = true;
  noDataAvailable: boolean;
  cancellationPolicyList: CancellationPolicyViewModel[];
  displayedColumns = ['policyname', 'details', 'status', 'action'];
  dataSource: MatTableDataSource<CancellationPolicyViewModel>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  constructor(private router: Router,
              private policiesDataService: PoliciesDataService,
              private activatedRoute: ActivatedRoute,
              private userProfileService: UserProfileService) { }

  ngOnInit() {
    this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];
    this.getCancellationPolicyList(this.hotelId);
    if (this.operation.toLowerCase().trim() === read) {
      this.isRead = false;
    }
  }
  createcancellationpolicy() {
    this.router.navigate(['../cancellationpolicies', 0, create], { relativeTo: this.activatedRoute});
  }
  getCancellationPolicyList(hotelId) {
    this.policiesDataService.getCancellationPolicyListdto(hotelId).subscribe(policylistdto => {
    if (policylistdto === null) {
      this.noDataAvailable = true;
      this.cancellationPolicyList = [];
    }
    // tslint:disable-next-line:one-line
    else{
      this.cancellationPolicyList = policylistdto;
    }
    this.dataSource = new MatTableDataSource<CancellationPolicyViewModel>(this.cancellationPolicyList);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    });
  }
  CancellationPolicyUpdate(event) {
   const eventData = event.value.split('-');
   const policyId = eventData[0];
   this.operation = eventData[1];
   if (this.operation.trim().toLowerCase() === edit) {
    this.router.navigate(['../cancellationpolicies', policyId,
        this.operation.trim().toLowerCase()], {relativeTo: this.activatedRoute});
   }
   // tslint:disable-next-line:one-line
   else {
    if (confirm('Are you sure you want to delete this Policy?')) {
      this.deletePolicy(policyId);
      this.getCancellationPolicyList(this.hotelId);
    }
   }
  }
  deletePolicy(policyId) {
    // API to delete policy
  }
}
