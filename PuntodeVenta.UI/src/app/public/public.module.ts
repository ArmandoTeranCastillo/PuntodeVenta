import { NgModule } from '@angular/core';
import { SharedModule } from '../core/shared/shared.module';
import { PublicRoutingModule } from './public.routing.module';
import { HomeComponent } from './home/containers/home.component';
import { InventoryComponent } from './home/components/inventory/inventory.component';
import { SalesComponent } from './home/components/sales/sales.component';
import { ProductsComponent } from './home/components/products/products.component';
import { BarcodeComponent } from './home/components/barcode/barcode.component';
import { PublicComponent } from './public.component';
import { HomeRoutingModule } from './home/containers/home.routing.module';
import { PublicService } from './public.service';
import { LoginComponent } from './login/login.component';

@NgModule({
  imports: [SharedModule, PublicRoutingModule, HomeRoutingModule],
  exports: [],
  declarations: [
    PublicComponent,
    HomeComponent,
    InventoryComponent,
    SalesComponent,
    ProductsComponent,
    BarcodeComponent,
    LoginComponent,
  ],
  providers: [PublicService],
})
export class PublicModule {}
