import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TemplateUrlNotificationService } from '../../../../../common/extranet-shared/services/templates/template-url-notification.service';

@Component({
  selector: 'app-child-extra-bed',
  templateUrl: './child-extra-bed.component.html',
  styleUrls: ['./child-extra-bed.component.css']
})
export class ChildExtraBedComponent implements OnInit {
  templateId = this.activatedRoute.parent.snapshot.params['id'];

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    private templateUrlNotificationService: TemplateUrlNotificationService) {
    templateUrlNotificationService.changeURLRoute(activatedRoute.snapshot.url[0].path);
  }

  ngOnInit() {
    window.scrollTo(0, 0);
  }

  saveandContinue() {
    this.router.navigate(['/templatemgmt/template', this.templateId, 'edit', 'cancellationpolicy']);
  }

  savePolicy() {
    this.router.navigate(['/templatemgmt/templates']);
  }

  backToList() {
    this.router.navigate(['/templatemgmt/templates']);
  }
}
