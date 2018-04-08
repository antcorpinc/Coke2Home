import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TemplateNameDataService } from '../../../common/extranet-shared/services/templates/template-name-data.service';
import { CONSTANTS } from '../../../../common/constants';
import { Observable } from 'rxjs/Observable';
import { TemplateUrlNotificationService } from '../../../common/extranet-shared/services/templates/template-url-notification.service';
import { TemplatesDataService } from '../../../common/extranet-shared/services/templates/templates-data.service';

const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;
@Component({
  selector: 'app-template-nav-menu',
  templateUrl: './template-nav-menu.component.html',
  styleUrls: ['./template-nav-menu.component.css']
})
export class TemplateNavMenuComponent implements OnInit {
  path: string;
templateName: string;
isRead: boolean;
operation: string;
templateId: number;
isDisabledTab: boolean;
colorClass = '';
state1 = true;
state2 = false;
state3 = false;
state4 = false;
showhotelinfo: boolean;
showRate: boolean;
isNameEditable: boolean;
iscancellationpolicy = false;
templateEnteredName: string;
breadcrumbs: string;
uniqueNameError = false;

chipsList = [
  {
    chipId: 1,
    chipname: 'Hotel Info',
    chipcolor: 'primary',
    chipchild: 'hotelinfo',
    routerLink: 'hoteldetails',
    selected: true
  },
  {
    chipId: 2,
    chipname: 'Rate',
    chipcolor: 'accent',
    chipchild: 'Rate',
    routerLink: 'roomtype',
    selected: false
  },
  {
    chipId: 3,
    chipname: 'Allocations',
    chipcolor: 'accent',
    chipchild: 'allocation',
    routerLink: 'allocation',
    selected: false
  },
  {
    chipId: 4,
    chipname: 'Contract Terms',
    chipcolor: 'accent',
    chipchild: '',
    routerLink: 'contractterms',
    selected: false
  }
];
params: any;
coming: any;
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private templatesDataService: TemplatesDataService,
    public templateNameDataService: TemplateNameDataService,
    public templateUrlNotificationService: TemplateUrlNotificationService
  ) {
    // const url1: Observable<string> = activatedRoute.url.map(segments => segments.join(''));
    // console.log(' activatedRoute.firstChild at Navigation  - ' + activatedRoute.firstChild);

    // console.log('const url: Observable - ' + JSON.stringify(url1));
    //  this.params = this.activatedRoute.params.subscribe(
    //   params => {
    //      this.coming = params[3];
    //     console.log('This is Activated Routes NAV- ' + this.coming); // this consoles the correct true/false value
    //   }
    // );
   }

  ngOnInit() {

    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.templateId = +this.activatedRoute.snapshot.params['id'];
    if (this.operation === create) {
      this.breadcrumbs = 'Create New ';
    } else {
      this.breadcrumbs = 'Edit ';
    }


    // this.templateNameDataService.templateName.subscribe(templateNameEntered => {
    //   this.templateName = templateNameEntered;
    // });
    this.templateUrlNotificationService.urlPath.subscribe(path => {
      if (this.router.url.indexOf('hoteldetails') >= 0) {
        this.isNameEditable = false;
      } else {
        this.isNameEditable = true;
      }
      if (this.router.url.indexOf('cancellationpolicy') >= 0) {
        this.iscancellationpolicy = true;
      } else {
        this.iscancellationpolicy = false;
      }
      if (this.operation.trim().toLocaleLowerCase() === create && this.templateId === 0) {
        this.isDisabledTab = true;
      } else {
        this.isDisabledTab = false;
      }
      this.path = path;
      if ( this.path === 'hoteldetails' || this.path === 'facilitiesservices' ) {
        this.changeChip (this.chipsList[0], this.chipsList);
       } else if (this.path === 'roomtype' || this.path === 'amenities' ||
       this.path === 'mealplan' || this.path === 'ratecategory' || this.path === 'childpolicy'
       || this.path === 'cancellationpolicy') {
        this.changeChip (this.chipsList[1], this.chipsList);
       } else if (this.path === 'allocation') {
        this.changeChip (this.chipsList[2], this.chipsList);
       } else if (this.path === 'contractterms') {
        this.changeChip (this.chipsList[3], this.chipsList);
       }
  });

    if (this.templateName !== '') {
      this.getTemplateName();
    }

    this.showhotelinfo = true;
    this.showRate = false;
}

  getTemplateName() {
    if (this.router.url.indexOf('hoteldetails') >= 0) {
      this.isNameEditable = false;
    } else {
      this.isNameEditable = true;
    }
    this.uniqueTemplateError();
    if (this.uniqueNameError) {
       this.templateNameDataService.changeTemplateName('');
    } else {
       this.templateNameDataService.changeTemplateName(this.templateName);
    }
  }

  uniqueTemplateError() {
    if (this.templateName !== undefined && this.templateName !== null) {
      // console.log('this.templatesDataService.templateListDto - ' + JSON.stringify(this.templatesDataService.templateListDto));
    for (let i = 0; i < this.templatesDataService.templateListDto.length; i++) {
      if (this.templatesDataService.templateListDto[i].name.toLowerCase() === this.templateName.toLowerCase().trim()) {
        this.uniqueNameError = true;
        break;
      } else {
        this.uniqueNameError = false;
      }
    }}
  }

  changeChip(chip, chipsList) {
      if (chip.selected) {
        chip.chipcolor = 'primary';
      } else {
        for (const cc of chipsList) {
         if (cc.chipId !== chip.chipId) {
          cc.selected = false;
          cc.chipcolor = 'accent';
         }
        }
        chip.selected = !chip.selected;
        chip.chipcolor = 'primary';
        if (chip.chipId === 1) {
          this.showhotelinfo = true;
          this.showRate = false;
        } else if (chip.chipId === 2) {
          this.showhotelinfo = false;
          this.showRate = true;
        } else {
          this.showhotelinfo = false;
          this.showRate = false;
        }
      }
}
}
