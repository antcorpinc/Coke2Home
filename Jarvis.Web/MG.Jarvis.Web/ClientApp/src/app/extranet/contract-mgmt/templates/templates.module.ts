import { NgModule, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TemplatesRoutingModule, routedTemplateComponents } from './templates-routing.module';
import { MaterialModule } from '../../../common/material/material.module';
import { DatePipe } from '@angular/common';
import { TemplateNameDataService } from '../../common/extranet-shared/services/templates/template-name-data.service';
import { TemplateUrlNotificationService } from '../../common/extranet-shared/services/templates/template-url-notification.service';

@NgModule({
  imports: [
    CommonModule,
    TemplatesRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [routedTemplateComponents],
  providers: [DatePipe, TemplateNameDataService, TemplateUrlNotificationService]
})

export class TemplatesModule { }
