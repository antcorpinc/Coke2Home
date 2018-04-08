import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { MatDialogRef, MatDialog } from '@angular/material';
import { EditPhotoDialogComponent } from './edit-photo-dialog/edit-photo-dialog.component';
import { MarketDialogComponent } from './market-dialog/market-dialog.component';
import { ContractTemplateTypeComponent } from './contract-template-type/contract-template-type.component';
import { CopyTemplateViewModel } from './../../../viewmodel/templates/copy-template/copytemplateviewmodel';
import { CopyTemplateComponent } from './copy-template/copy-template.component';

@Injectable()
export class DialogsService {

    constructor(private dialog: MatDialog) { }

    public confirm(title: string, message: string): Observable<boolean> {

        let dialogRef: MatDialogRef<ConfirmDialogComponent>;
        dialogRef = this.dialog.open(ConfirmDialogComponent);
        dialogRef.componentInstance.title = title;
        dialogRef.componentInstance.message = message;
        return dialogRef.afterClosed();
    }

    public openModal(): Observable<boolean> {

        let dialogRef: MatDialogRef<EditPhotoDialogComponent>;
        dialogRef = this.dialog.open(EditPhotoDialogComponent);
        return dialogRef.afterClosed();
    }

    public market(title: string, country: any, continent: any): Observable<boolean> {

        let dialogRef: MatDialogRef<MarketDialogComponent>;

        dialogRef = this.dialog.open(MarketDialogComponent);
        dialogRef.componentInstance.title = title;
        dialogRef.componentInstance.countries = country;
        dialogRef.componentInstance.continents = continent;

        return dialogRef.afterClosed();
    }

    public openContractTemplateModal(): Observable<boolean> {
      let dialogRef: MatDialogRef<ContractTemplateTypeComponent>;
      dialogRef = this.dialog.open(ContractTemplateTypeComponent);
      return dialogRef.afterClosed();
  }

    public openCopyModal(templateId, templateName, templatesList): Observable<CopyTemplateViewModel> {

        let dialogRef: MatDialogRef<CopyTemplateComponent>;
        dialogRef = this.dialog.open(CopyTemplateComponent);
        dialogRef.componentInstance.templateName = templateName;
        dialogRef.componentInstance.templateId = templateId;
        dialogRef.componentInstance.templateList = templatesList;
        return dialogRef.afterClosed();
    }

}
