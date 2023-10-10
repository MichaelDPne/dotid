export interface Dataset {
    mapTitle:string;
    mapSubTitle:string;
    mapDataSource:string;
    denominator:string;
    data:DataPoint[];
}

export interface DataPoint {
    GeoID:string;
    color:string;
    InfoBox:InfoBox;
}

export interface InfoBox {
    Number:string;
}