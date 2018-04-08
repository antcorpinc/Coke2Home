import { AssociateMealplanDataService } from './../../../../common/extranet-shared/services/associate-mealplan-data.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TemplateUrlNotificationService } from '../../../../common/extranet-shared/services/templates/template-url-notification.service';
import { MealTypeViewModel } from './../../../../viewmodel/associatemealplanviewmodel/mealtypeviewmodel';
import { CuisineTypeViewModel } from './../../../../viewmodel/associatemealplanviewmodel/cuisinetypeviewmodel';
import { CurrencyViewModel } from './../../../../../common/viewmodels/currencyviewmodel';

@Component({
  selector: 'app-meal-plan',
  templateUrl: './meal-plan.component.html',
  styleUrls: ['./meal-plan.component.css']
})
export class MealPlanComponent implements OnInit {

  templateId = this.activatedRoute.parent.snapshot.params['id'];
  mealTypes: MealTypeViewModel[];
  cuisineTypes: CuisineTypeViewModel[];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private templateUrlNotificationService: TemplateUrlNotificationService,
    private mealplanService: AssociateMealplanDataService) {
    templateUrlNotificationService.changeURLRoute(activatedRoute.snapshot.url[0].path);
  }

  ngOnInit() {
    window.scrollTo(0, 0);
    this.getMealPlans();
  }

  saveMealPlan() {
    this.router.navigate(['/templatemgmt/templates']);
  }

  private saveandContinue() {
    this.router.navigate(['/templatemgmt/template', this.templateId, 'edit', 'childpolicy']);
  }

  backToList() {
    this.router.navigate(['/templatemgmt/templates']);
  }

  getMealPlans() {
    this.mealTypes = this.activatedRoute.snapshot.data['mealTypesData'];
    this.cuisineTypes = this.activatedRoute.snapshot.data['cuisineTypesData'];
  }
}
