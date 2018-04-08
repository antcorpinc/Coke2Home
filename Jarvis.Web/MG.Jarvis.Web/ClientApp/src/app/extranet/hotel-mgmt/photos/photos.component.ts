import { DialogsService } from './../../common/extranet-shared/dialogs/dialogs.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {

  result: any;
  constructor(private dialogsService: DialogsService) { }

  ngOnInit() {
  }

  openDialog() {
    this.dialogsService.openModal().subscribe(res => {
      this.result = res;
    });
  }
}
