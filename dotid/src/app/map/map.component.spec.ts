import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PointService } from '../services/point-service/point.service';
import { MapComponent } from './map.component';
import { GeoJsonObject } from 'geojson';
import { of } from 'rxjs';
import { GeoData, MapData } from '../models/point.model';
import { Dataset } from '../models/dataset.model';

describe('MapComponent', () => {
  let component: MapComponent;
  let fixture: ComponentFixture<MapComponent>;

  const polygon = {
    "id": "6",
    "shapes": [
        {
            "id": "2118001",
            "points" : "kwntZr`kfFqBLsCmWzOcAxClWoLt@"
        }]
  } as GeoData;

  const data = {
    mapTitle:'Test',
    mapSubTitle:'Test',
    mapDataSource:'Test',
    denominator:'Test',
    data: [
      {
        GeoID:'2118001',
        color:'#ff0000',
        InfoBox: {
          Number:'Test'
        }
      }
    ]
  } as Dataset;

  const mapData = {
      type:"Feature",
      properties:{
        "id":'test',
        "color":'test',
        "tooltip":'test'
      },
      geometry: {
        type:"Polygon",
        coordinates: [[0,0]]
      }
  } as GeoJsonObject;

  let mock:jasmine.SpyObj<PointService>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MapComponent ],
      imports:[HttpClientTestingModule],
      providers: [{ provide: PointService, useValue: mock}]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', waitForAsync(() => {

    const pointsSpy = mock.getPoints.and.returnValue(of(polygon));
    const dataSpy = mock.getData.and.returnValue(of(data));
    const mapDataSpy = mock.getMapData.and.returnValue(of([mapData]));

    fixture.detectChanges();

    expect(component).toBeTruthy();

  }));
});
