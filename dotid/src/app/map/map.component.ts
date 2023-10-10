import { Component, OnInit } from '@angular/core';
import * as L from 'leaflet';
import { PointService } from '../services/point-service/point.service';
import { take } from 'rxjs';

@Component({
  selector: 'ideng-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent {

  constructor(
    private readonly pointService: PointService
  ){
  }

  
  ngOnInit(): void {
    var leafMap = L.map('map').setView([-37.8833298, 145.166666], 13);
    
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'}).addTo(leafMap);


    this.pointService.getMapData()
    .pipe(
      take(1),
      ).subscribe(mapData => {
        L.geoJSON(mapData, {
          'style': (feature) => {
            return {color:'#000000', weight:1, fillColor: feature?.properties['color']};
          }, onEachFeature: (feature,layer)=> {
            layer.bindTooltip(feature.properties['tooltip'])
          }
        }).addTo(leafMap);
      });

  }
}
