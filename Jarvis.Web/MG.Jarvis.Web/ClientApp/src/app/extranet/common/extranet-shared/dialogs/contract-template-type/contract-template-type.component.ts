import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { ContractType } from './../../../../../common/enums';
import { ContractDataService } from '../../services/contracts/contract-data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CONSTANTS } from './../../../../../common/constants';
import { PublishedTemplatesListViewModel } from '../../../../viewmodel/contracts/publishedtemplateslistviewmodel';
import { map } from 'rxjs/operators/map';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-contract-template-type',
  templateUrl: './contract-template-type.component.html',
  styleUrls: ['./contract-template-type.component.css']
})
export class ContractTemplateTypeComponent implements OnInit {

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  contractTemplateForm: FormGroup;
  nonMg = ContractType.NonMG;
  mgStatic = ContractType.MGStatic;
  mgDynamic = ContractType.MGDynamic;
  noOfTemplates: number;
  templates: PublishedTemplatesListViewModel[];
  selectedTemplateId: number;
  filteredData: PublishedTemplatesListViewModel[];
  isSearch: boolean;
  isSelected: boolean;

  constructor(public dialogRef: MatDialogRef<ContractTemplateTypeComponent>,
    public contractDataService: ContractDataService,
    public router: Router,
    public activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.isSearch = false;
    this.isSelected = false;
    this.contractTemplateForm = new FormGroup({
      contractType: new FormControl(null, Validators.required),
      templateType: new FormControl(null, Validators.required),
      searchTemplate: new FormControl(null)
    });
    this.getPublishedTemplates();
  }

  isTemplateDisabled(e) {
    if (e.value === this.nonMg) {
      this.contractTemplateForm.get('templateType').setValue(null);
      this.selectedTemplateId = 0;
      this.contractTemplateForm.get('templateType').disable();
    } else {
      if (this.contractTemplateForm.get('templateType').value !== this.mgDynamic) {
        this.contractTemplateForm.get('templateType').enable();
      }
    }
  }

  isTemplateListDisabled(e) {
    if (e.value === this.mgDynamic) {
      this.selectedTemplateId = 0;
    } else {
    }
  }

  searchByTemplate() {
    this.isSearch = true;
    this.filteredData = this.templates.filter(template => {
      if (template.name.toLowerCase().includes(this.contractTemplateForm.get('searchTemplate').value)) {
        return template;
      }
    });
  }

  checkInputCleared() {
    if (this.contractTemplateForm.get('searchTemplate').value.length === 1) {
      this.isSearch = false;
      this.isSelected = false;
      this.selectedTemplateId = 0;
      this.getPublishedTemplates();
    }
  }

  clearSelectedTemplate() {
    this.isSelected = false;
    this.selectedTemplateId = 0;
  }

  selectTemplate(templateId) {
    this.isSelected = true;
    this.selectedTemplateId = templateId;
    this.contractDataService.templateId = templateId;
    this.contractTemplateForm.get('searchTemplate').setValue(null);
    console.log('selectedTemplate: ' + this.contractDataService.templateId);
  }

  openContract() {
    if (this.contractTemplateForm.get('contractType').value === this.nonMg) {
      this.contractDataService.contractType = this.nonMg;
    } else {
      if (this.contractTemplateForm.get('templateType').value === this.mgStatic) {
        this.contractDataService.contractType = this.mgStatic;
      } else {
        this.contractDataService.contractType = this.mgDynamic;
      }
    }
    this.router.navigate(['contractmgmt/contract', 0, this.create]);
    this.dialogRef.close(true);
  }

  getPublishedTemplates() {
    this.contractDataService.getPublishedTemplates().subscribe(templatesList => {
      if (templatesList !== null) {
        this.templates = templatesList.result;
      }
    });
  }

}
