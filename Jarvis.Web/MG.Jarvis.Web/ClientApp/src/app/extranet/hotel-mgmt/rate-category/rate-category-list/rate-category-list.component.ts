import { Component, OnInit, ViewChild } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, MatPaginator, MatSort} from '@angular/material';
import { Router, ActivatedRoute } from '@angular/router';
import { CONSTANTS } from '../../../../common/constants';
import { RatecategoryDataService } from '../../../common/extranet-shared/services/ratecategory-data.service';
import { RateCategoryListViewModel } from '../../../viewmodel/ratecategoryviewmodel/RateCategoryListViewModel';


@Component({
  selector: 'app-rate-category-list',
  templateUrl: './rate-category-list.component.html',
  styleUrls: ['./rate-category-list.component.css']
})
export class RateCategoryListComponent implements OnInit {
  read = CONSTANTS.operation.read;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  operation: string;
  isRead: boolean;
  isDeleted: boolean;
  hotelId: string;
  noDataAvailable: boolean;
  ratecategoryList: RateCategoryListViewModel[];
  isButtonEnabledVal: boolean;
  displayedColumns = ['rateCategoryName', 'roomName', 'cancellationPolicy', 'mealPlan', 'market', 'isActive', 'actions'];
  dataSource: MatTableDataSource<RateCategoryListViewModel>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private rateCategoryDataService: RatecategoryDataService) { }

  ngOnInit() {
    this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
    this.operation = this.activatedRoute.parent.snapshot.params['operation'];

    this.getRooms(this.hotelId);
    this.getCancellationPolicies(this.hotelId);
    this.getRateCategory(this.hotelId);

    if (this.operation.toLowerCase().trim() === this.read) {
      this.isRead = true;
    }
  }

  getCancellationPolicies(hotelId) {
    this.rateCategoryDataService.getCancellationPolicies(hotelId).subscribe(policylist => {
      if (policylist.length === 0) {
        this.isButtonEnabledVal = true;
      } else {
        this.isButtonEnabledVal = false;
      }
    });
  }

  getRooms(hotelId) {
    this.rateCategoryDataService.getRooms(hotelId).subscribe(roomListData => {
      if (roomListData.length === 0) {
        this.isButtonEnabledVal = true;
      } else {
        this.isButtonEnabledVal = false;
      }
    });
  }

  createRateCategory() {
    this.router.navigate(['../ratecategory', 0, this.create], { relativeTo: this.activatedRoute });
  }

  getRateCategory(hotelId) {
    this.rateCategoryDataService.getRateCategory(hotelId).subscribe(rateList => {
      this.ratecategoryList = rateList;
      this.dataSource = new MatTableDataSource<RateCategoryListViewModel>(this.ratecategoryList);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      if (rateList.length === 0) {
        this.noDataAvailable = true;
      }
    });
  }

  GoRateUpdate(value) {
    const val = value.split('-');
    const rateId = val[0];
    this.operation = val[1];
    this.router.navigate(['../ratecategory', rateId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
  }

}



