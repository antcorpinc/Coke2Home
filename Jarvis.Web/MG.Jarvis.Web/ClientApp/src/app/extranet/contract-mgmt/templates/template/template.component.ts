import { Component, OnInit } from '@angular/core';
import { CONSTANTS } from '../../../../common/constants';
import { ActivatedRoute } from '@angular/router';
import { TemplatesDataService } from '../../../common/extranet-shared/services/templates/templates-data.service';
import { TemplateViewModel } from '../../../viewmodel/templates/hotel-info/hotelinfoviewmodel';
import { TemplateNameDataService } from '../../../common/extranet-shared/services/templates/template-name-data.service';

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styleUrls: ['./template.component.css']
})
export class TemplateComponent implements OnInit {
  read = CONSTANTS.operation.read;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  isCreate: boolean;
  templateId: string;
  templateName: string;
  operation: string;
  // templateViewModel: TemplateViewModel;
  constructor(
    private activatedRoute: ActivatedRoute,
    private templateDataService: TemplatesDataService,
    public templateNameDataService: TemplateNameDataService
  ) {}

  ngOnInit() {
    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.templateId = this.activatedRoute.snapshot.params['id'];
    // console.log('Operation From Template ' + this.operation +'  this.templateId ' +
    //     this.templateId );

  // Need to check ***
    // if (this.operation.toLowerCase() !== this.create) {
    //   this.getTemplateDetails(this.templateId);
    // }
    // this.getTemplateDetails(this.templateId);
  }

  private getTemplateDetails(templateId) {
    console.log('I M at getTemplateDetails from Template component');
   /*
    const templateViewModel = new TemplateViewModel();
    templateViewModel.id = +templateId;
    this.templateDataService
      .getTemplateHotelFields(templateViewModel)
      .subscribe((templateData) => {
         this.templateDataService.templateHotelFieldsDetails =    templateData;
        this.templateName = this.templateDataService.templateHotelFieldsDetails.name;
        this.templateNameDataService.changeTemplateName(this.templateName);
      });*/
      this.templateDataService.templateHotelFieldsDetails = this.activatedRoute.snapshot.data[
        'hotelFieldData'
      ];
      this.templateName = this.templateDataService.templateHotelFieldsDetails.name;
  }
}
