import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CONSTANTS } from '../../../../common/constants';

@Component({
  selector: 'app-promotions-list',
  templateUrl: './promotions-list.component.html',
  styleUrls: ['./promotions-list.component.css']
})
export class PromotionsListComponent implements OnInit {
  operation: string;
  isRead: boolean;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  constructor(private router: Router, 
    private activatedRoute: ActivatedRoute, 
    ) { }

  ngOnInit() {
  }
  private createPromotion(){
    this.router.navigate(['../promotion', 0, this.create], { relativeTo: this.activatedRoute });
  }
}
