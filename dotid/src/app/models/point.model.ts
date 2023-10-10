import { LatLng } from "leaflet";

export interface GeoData {

    shapes:GeoShape[];
}

export interface GeoShape {
    id:string;
    points:string;
}

export interface Point {
    latitide:number;
    longitude:number;
}

export interface Polygon {
    id:string;
    points:Point[];
}

export interface MapData {
    id:string;
    points:LatLng[];
    color:string;
    rollOver:string;
}

export interface GeoJson {
    type:string;
    properties:{},
    geometry: {
        type:string;
        coordinates:LatLng[]
    }
}