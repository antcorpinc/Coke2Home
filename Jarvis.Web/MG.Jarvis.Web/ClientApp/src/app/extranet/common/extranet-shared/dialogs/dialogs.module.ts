import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { DialogsService } from './dialogs.service';
import { MatButtonModule, MatDialogModule } from '@angular/material';
import { EditPhotoDialogComponent } from './edit-photo-dialog/edit-photo-dialog.component';
import { MaterialModule } from '../../../../common/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CopyTemplateComponent } from './copy-template/copy-template.component';
import { MarketDialogComponent } from './market-dialog/market-dialog.component';
import { ContractTemplateTypeComponent } from './contract-template-type/contract-template-type.component';
import { MarketCountryFilterPipe } from '../../../common/pipes/marketcountryfilterpipe';

@NgModule({
  imports: [
    CommonModule,
    MatDialogModule,
    MatButtonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [ConfirmDialogComponent,
    EditPhotoDialogComponent,
    MarketDialogComponent,
    ContractTemplateTypeComponent,
    CopyTemplateComponent,
    MarketCountryFilterPipe],
  exports: [ConfirmDialogComponent,
    EditPhotoDialogComponent,
    MarketDialogComponent,
    ContractTemplateTypeComponent,
    CopyTemplateComponent],
  entryComponents: [ConfirmDialogComponent,
    EditPhotoDialogComponent,
    MarketDialogComponent,
    ContractTemplateTypeComponent,
    CopyTemplateComponent],
  providers: [DialogsService]
})
export class DialogsModule { }
