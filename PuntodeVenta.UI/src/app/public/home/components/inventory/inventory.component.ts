import { Component, OnInit } from '@angular/core';
import notify from 'devextreme/ui/notify';
import { PublicService } from 'src/app/public/public.service';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss'],
})
export class InventoryComponent implements OnInit {
  inventory: any;
  products: any;

  readonly allowedPageSizes = [5, 10, 'all'];

  readonly displayModes = [
    { text: "Display Mode 'full'", value: 'full' },
    { text: "Display Mode 'compact'", value: 'compact' },
  ];

  displayMode = 'full';

  showPageSizeSelector = true;

  showInfo = true;

  showNavButtons = true;

  constructor(private publicService: PublicService) {}

  ngOnInit() {
    this.getInventory();
    this.getProducts();
  }

  getInventory() {
    this.publicService.getInventory().subscribe((data) => {
      console.log(data);
      this.inventory = data;
    });
  }

  getProducts() {
    this.publicService.getProducts().subscribe((data) => {
      console.log(data);
      this.products = data;
    });
  }

  createInventory(e: any) {
    const productId = e.data.product.id;
    const quantity = e.data.quantity;

    const dataToSend = {
      productId,
      quantity,
    };

    this.publicService.createInventory(dataToSend).subscribe((response) => {
      console.log(response);
      this.getInventory();
      e.component.refresh();
      notify('Registro Creado', 'success', 3000);
    });
  }

  updateInventory(e: any) {
    const productId = e.data.product.id;
    const quantity = e.data.quantity;
    const id = e.data.id;

    const dataToSend = {
      id,
      productId,
      quantity,
    };

    this.publicService.updateInventory(dataToSend).subscribe((response) => {
      console.log(response);
      this.getInventory();
      e.component.refresh();
      notify('Registro Actualizado', 'success', 3000);
    });
  }

  deleteInventory(e: any) {
    const id = e.data.id;

    const dataToSend = {
      id,
    };

    this.publicService.deleteInventory(dataToSend).subscribe((response) => {
      console.log(response);
      this.getInventory();
      e.component.refresh();
      notify('Registro Eliminado', 'success', 3000);
    });
  }

  getRealQuantity(rowData: any) {
    return rowData.realQuantity;
  }
}
