import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { confirm } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  navigation: any[] = [
    { id: 1, text: 'Inventario', icon: 'box', path: 'home/inventory' },
    { id: 2, text: 'Productos', icon: 'product', path: 'home/products' },
    { id: 3, text: 'Ventas', icon: 'money', path: 'home/sales' },
  ];

  constructor(private router: Router) {}

  ngOnInit() {
    this.router.navigate(['/home', 'inventory']);
  }

  exitPage() {
    let result = confirm('<i>Seguro que quieres salir?</i>', '');
    result.then((dialogResult) => {
      if (dialogResult) {
        this.router.navigate(['/login']);
      }
    });
  }

  isDrawerOpen: boolean = false;
  buttonOptions: any = {
    icon: 'menu',
    onClick: () => {
      this.isDrawerOpen = !this.isDrawerOpen;
    },
  };
}
