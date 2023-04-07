import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'PuntodeVenta.UI';
  @HostListener('window:beforeunload', ['$event'])
  beforeunloadHandler(event: Event) {
    localStorage.clear();
  }
}
