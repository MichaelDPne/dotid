import { Component } from '@angular/core';
import { MapComponent } from './map/map.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'dotid coding challenge';

  /* NB: I would normally use standalone components for a larger application for this purpose I left it with no lazy loading
  and no standalone components
  */
}