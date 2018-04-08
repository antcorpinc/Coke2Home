import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CONSTANTS } from '../../../../common/constants';
import { TemplateUrlNotificationService } from '../../../common/extranet-shared/services/templates/template-url-notification.service';

const read = CONSTANTS.operation.read;
const edit = CONSTANTS.operation.edit;
const create = CONSTANTS.operation.create;

@Component({
  selector: 'app-allocations',
  templateUrl: './allocations.component.html',
  styleUrls: ['./allocations.component.css']
})
export class AllocationsComponent implements OnInit {

  constructor(private router: Router,  private activatedRoute: ActivatedRoute,
    private templateUrlNotificationService: TemplateUrlNotificationService
  ) {
      templateUrlNotificationService.changeURLRoute(activatedRoute.snapshot.url[0].path);
  }

  templateId = this.activatedRoute.parent.snapshot.params['id'];

  ngOnInit() {
    window.scrollTo(0, 0);
  }

  saveAllocation() {
    this.router.navigate(['/templatemgmt/templates']);
  }

  backToList() {
    this.router.navigate(['/templatemgmt/templates']);
 }

  saveAndContinueAllocation() {
    this.router.navigate(['/templatemgmt/template', this.templateId, edit, 'contractterms']);
  }

}
