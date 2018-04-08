import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
declare var google: any;

@Component({
  selector: 'app-mapsdialog',
  templateUrl: './mapsdialog.component.html',
  styleUrls: ['./mapsdialog.component.css']
})
export class MapsdialogComponent implements OnInit {
  overlays: any[];
  orgLat: any;
  orgLng: any;
  constructor(public mapdialogRef: MatDialogRef<MapsdialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
      this.orgLat = this.data.latitude;
      this.orgLng = this.data.longitude;
      mapdialogRef.disableClose = true;
    }
    ngOnInit() {
      let mapOptions: any;
      let mapLat: number;
      let mapLng: number;
      let gmap: any;
      let marker: any;
      // console.log('Data received at dialog: ' + JSON.stringify(this.data));
      const mapDiv = document.getElementById('mapCanvas');
      mapOptions = {
        center: new google.maps.LatLng(this.orgLat, this.orgLng),
        zoom: 16,
        mapTypeId: google.maps.MapTypeId.ROADMAP
      };
      gmap = new google.maps.Map(mapDiv, mapOptions) ;
      marker = new google.maps.Marker({
        position: new google.maps.LatLng(this.orgLat, this.orgLng),
        map: gmap
      }) ;
    gmap.addListener('click', function(e){
      mapLat = e.latLng.lat().toFixed(6);
      mapLng = e.latLng.lng().toFixed(6);
      marker.setPosition(e.latLng);
      localStorage.setItem('retLat', JSON.stringify({Lat: mapLat}));
      localStorage.setItem('retLng', JSON.stringify({Lng: mapLng}));
      });
  }
    closeMap() {
      const localLat = JSON.parse(localStorage.getItem('retLat'));
      const localLng = JSON.parse(localStorage.getItem('retLng'));
      if (localLat && localLng) {
        this.mapdialogRef.close(JSON.stringify({Lat: localLat.Lat, Lng: localLng.Lng}));
      }
      // tslint:disable-next-line:one-line
      else {
        // this.mapdialogRef.close(JSON.stringify({Lat: this.orgLat, Lng: this.orgLng}));
        this.mapdialogRef.close('unselected');
      }
    }
}
