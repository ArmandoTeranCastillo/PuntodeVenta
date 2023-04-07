import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { VigilanteGuard } from 'src/app/vigilante.guard';
import { InventoryComponent } from '../components/inventory/inventory.component';
import { BarcodeComponent } from '../components/barcode/barcode.component';
import { ProductsComponent } from '../components/products/products.component';
import { SalesComponent } from '../components/sales/sales.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    children: [
      { path: '', redirectTo: 'inventory', pathMatch: 'full' },
      {
        path: 'inventory',
        component: InventoryComponent,
        canActivate: [VigilanteGuard],
      },
      {
        path: 'barcode',
        component: BarcodeComponent,
        canActivate: [VigilanteGuard],
      },
      {
        path: 'products',
        component: ProductsComponent,
        canActivate: [VigilanteGuard],
      },
      {
        path: 'sales',
        component: SalesComponent,
        canActivate: [VigilanteGuard],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
