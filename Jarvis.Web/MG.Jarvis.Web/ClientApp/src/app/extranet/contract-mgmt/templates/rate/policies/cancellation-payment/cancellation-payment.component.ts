import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TemplateUrlNotificationService } from '../../../../../common/extranet-shared/services/templates/template-url-notification.service';

@Component({
  selector: 'app-cancellation-payment',
  templateUrl: './cancellation-payment.component.html',
  styleUrls: ['./cancellation-payment.component.css']
})
export class CancellationPaymentComponent implements OnInit {
  templateId = this.activatedRoute.parent.snapshot.params['id'];
  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private templateUrlNotificationService: TemplateUrlNotificationService) {
    templateUrlNotificationService.changeURLRoute(activatedRoute.snapshot.url[0].path);
  }

  ngOnInit() {
    window.scrollTo(0, 0);
  }

  private saveandContinue() {
    this.router.navigate(['/templatemgmt/template', this.templateId, 'edit', 'ratecategory']);
  }

  saveCancellationPolicy() {
    this.router.navigate(['/templatemgmt/templates']);
  }

  backToList() {
    this.router.navigate(['/templatemgmt/templates']);
  }
}
