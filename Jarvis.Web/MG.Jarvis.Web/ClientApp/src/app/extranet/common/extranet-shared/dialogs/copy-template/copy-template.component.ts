import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { CopyTemplateViewModel } from './../../../../viewmodel/templates/copy-template/copytemplateviewmodel';
import { TemplatesDataService } from './../../services/templates/templates-data.service';
import { Templateslistviewmodel } from '../../../../viewmodel/templates/templates-details/templateslistviewmodel';


@Component({
  selector: 'app-copy-template',
  templateUrl: './copy-template.component.html',
  styleUrls: ['./copy-template.component.css']
})

export class CopyTemplateComponent implements OnInit {

  templateId: number;
  templateName: string;
  copyTemplateForm: FormGroup;
  copyTemplate: CopyTemplateViewModel = <CopyTemplateViewModel>{};
  templateList: Templateslistviewmodel[];
  uniqueNameError: boolean;

  constructor(public dialogRef: MatDialogRef<CopyTemplateComponent>,
    private templatesDataService: TemplatesDataService) { }

  ngOnInit() {
    this.copyTemplateForm = new FormGroup({
      newTemplateName: new FormControl(this.templateName + '_Copy', Validators.required)
    });
    const randomNumber = Math.floor(Math.random() * 2000);
    this.uniqueTemplateError();
    if (this.uniqueNameError) {
      this.uniqueNameError = false;
      this.copyTemplateForm.controls['newTemplateName'].setValue(this.templateName + '_Copy' + randomNumber);
    }
  }

  createTemplateCopy() {
    if (!this.uniqueNameError) {
      this.copyTemplate.templateId = this.templateId;
      this.copyTemplate.templateName = this.copyTemplateForm.get('newTemplateName').value;
      this.dialogRef.close(this.copyTemplate);
    }
  }

  uniqueTemplateError() {
    for (let i = 0; i < this.templateList.length; i++) {
      if (this.templateList[i].name.toLowerCase() === this.copyTemplateForm.get('newTemplateName').value.toLowerCase()) {
        this.uniqueNameError = true;
        break;
      } else {
        this.uniqueNameError = false;
      }
    }
  }
}
