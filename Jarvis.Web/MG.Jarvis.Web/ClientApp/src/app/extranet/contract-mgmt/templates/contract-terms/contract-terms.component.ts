import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormArray, FormGroup, Validators, FormControl } from '@angular/forms';
import { TemplateUrlNotificationService } from '../../../common/extranet-shared/services/templates/template-url-notification.service';
import { ContractTermsViewModel } from '../../../viewmodel/templates/contract-terms/contracttermsviemodel';
import { ObjectState } from '../../../../common/enums';
import { ContractTermsDataService } from '../../../common/extranet-shared/services/templates/contract-terms-data.service';
import { MatSnackBar } from '@angular/material';
import { SaveContractTermsViewModel } from '../../../viewmodel/templates/contract-terms/saveContractTermsViewModel';
import { TemplateHotelInfoViewModel } from '../../../viewmodel/templates/hotel-info/hotelinfoviewmodel';

@Component({
  selector: 'app-contract-terms',
  templateUrl: './contract-terms.component.html',
  styleUrls: ['./contract-terms.component.css']
})
export class ContractTermsComponent implements OnInit {

  contractTermsList: ContractTermsViewModel[];
  saveContractTermsList: ContractTermsViewModel[];
  contractTermsForm: FormGroup;
  contractTermList: SaveContractTermsViewModel;
  // templateHotelInfoViewModel: TemplateHotelInfoViewModel;

  constructor(private router: Router,
    private activatedRoute: ActivatedRoute,
    public snackBar: MatSnackBar,
    private contractTermsDataService: ContractTermsDataService,
    private templateUrlNotificationService: TemplateUrlNotificationService
  ) {
      templateUrlNotificationService.changeURLRoute(activatedRoute.snapshot.url[0].path);
  }

  templateId = this.activatedRoute.parent.snapshot.params['id'];
  templateHotelInfoViewModel = this.activatedRoute.snapshot.data['hotelFieldData'];

  ngOnInit() {
    this.getContractTerms();
  }

  getContractTerms() {
    this.contractTermsList = this.activatedRoute.snapshot.data['contractTermsData'];

    this.contractTermsForm = new FormGroup({
      contractTermsGroupArray: this.buildContractTermsGroupsForm(this.contractTermsList)
    });
  }

  get contractTermsGroupArray(): FormArray{
    return <FormArray>this.contractTermsForm.get('contractTermsGroupArray');
  }

  buildContractTermsGroupsForm(contractTermsGroups: ContractTermsViewModel[]): FormArray {
    let groupFormGroup: FormGroup;
    let groupFormArray: FormArray;

    contractTermsGroups.forEach(contractTermsGroup => {
      groupFormGroup = new FormGroup({
        clauseLibraryId: new FormControl(contractTermsGroup.clauseLibraryId),
        description: new FormControl(contractTermsGroup.description),
        isConfigurable: new FormControl(contractTermsGroup.isConfigurable),
        isSelected: new FormControl(contractTermsGroup.isSelected),
        name: new FormControl(contractTermsGroup.name),
        order: new FormControl(contractTermsGroup.order),
        status: new FormControl(contractTermsGroup.status)
      });
      if (groupFormArray === null || groupFormArray === undefined) {
        groupFormArray = new FormArray([groupFormGroup]);
      } else {
        groupFormArray.push(groupFormGroup);
      }
    });

    return groupFormArray;
  }

  saveContractTerms() {

    this.saveContractTermsList = Object.assign([], this.contractTermsList, this.contractTermsForm.value.contractTermsGroupArray);
    this.contractTermList = {
      id: this.templateId,
      name: this.templateHotelInfoViewModel.name,
      clauseLibraryFields: this.saveContractTermsList,
      isPublished: this.templateHotelInfoViewModel.isPublished === true ? true : false,
      objectState: ObjectState.Unchanged
    };

    this.updateObjectState();

    this.contractTermsDataService.addContractTerms(this.contractTermList as SaveContractTermsViewModel)
        .subscribe(data => {
          this.router.navigate(['/templatemgmt/templates']);
          this.snackBar.open('Contract Terms Template Saved Successfully', '',
                              { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
  }

  saveAndPublishContractTerms() {

    this.saveContractTermsList = Object.assign([], this.contractTermsList, this.contractTermsForm.value.contractTermsGroupArray);
    this.contractTermList = {
      id: this.templateId,
      name: this.templateHotelInfoViewModel.name,
      clauseLibraryFields: this.saveContractTermsList,
      isPublished: true,
      objectState: this.templateHotelInfoViewModel.isPublished === false ? ObjectState.Modified : ObjectState.Unchanged
    };

    this.updateObjectState();

    this.contractTermsDataService.addContractTerms(this.contractTermList as SaveContractTermsViewModel)
        .subscribe(data => {
          this.router.navigate(['/templatemgmt/templates']);
          this.snackBar.open('Contract Terms Template Saved Successfully', '',
                              { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          window.scrollTo(0, 0);
        }
      );
  }

  updateObjectState() {
    this.saveContractTermsList.forEach ((contractTerm, contractTermIndex) => {
      if (contractTerm.status === 0) {
        if (contractTerm.isSelected === true) {
          contractTerm.objectState = ObjectState.Added;
        } else {
          contractTerm.objectState = ObjectState.Unchanged;
        }
      } else {
        if (contractTerm.isSelected !== this.checkOriginalObjectState(contractTermIndex)) {
          contractTerm.objectState = ObjectState.Modified;
        } else {
          contractTerm.objectState = ObjectState.Unchanged;
        }
      }
    });
  }

  checkOriginalObjectState(contractTermIndex) {
    return this.contractTermsList[contractTermIndex].isSelected;
  }

  backToList() {
    this.router.navigate(['/templatemgmt/templates']);
  }

}
