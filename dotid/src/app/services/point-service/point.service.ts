import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map, forkJoin, catchError, of, EMPTY } from 'rxjs';

import { environment } from 'src/environments/environment';

import { GeoData } from 'src/app/models/point.model';
import { decodePoints } from 'src/app/helpers/decoder';
import { Dataset } from 'src/app/models/dataset.model';
import { GeoJsonObject } from 'geojson';

@Injectable({
  providedIn: 'root'
})
export class PointService {

  constructor(
    private readonly http: HttpClient
  ) { 

  }

  getPoints = ():Observable<GeoData> => {
    return this.http.get<GeoData>(environment.geo);
  }

  getData = ():Observable<Dataset> => {
    return this.http.get<Dataset>(environment.data);
  }

  getMapData = ():Observable<GeoJsonObject[]> => {
    return forkJoin([this.getPoints(), this.getData()])
    .pipe(
      map(([points, data]) => {
        return points.shapes.map(s => ( 
          {
            type:"Feature",
            properties:{
              "id":s.id,
              "color":data.data.filter(data => data.GeoID === s.id)[0]?.color,
              "tooltip":data.data.filter(data => data.GeoID === s.id)[0]?.InfoBox?.Number
            },
            geometry: {
              type:"Polygon",
              coordinates: [decodePoints(s.points)?.map(d => [d.lng, d.lat])]
            }
          }
          ))
      }));
  }

}