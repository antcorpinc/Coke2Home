import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-edit-photo-dialog',
  templateUrl: './edit-photo-dialog.component.html',
  styleUrls: ['./edit-photo-dialog.component.css']
})
export class EditPhotoDialogComponent {

  public title: string;
  public message: string;

  constructor(public dialogRef: MatDialogRef<EditPhotoDialogComponent>) {

  }

}

