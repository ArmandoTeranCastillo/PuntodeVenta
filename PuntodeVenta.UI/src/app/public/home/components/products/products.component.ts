import { Component, OnInit } from '@angular/core';
import { PublicService } from 'src/app/public/public.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
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
    this.getProducts();
  }

  getProducts() {
    this.publicService.getProducts().subscribe((data) => {
      this.products = data;
    });
  }

  createProduct(e: any) {
    const name = e.data.name;
    const description = e.data.description;
    const unitCost = e.data.unitCost;

    const dataToSend = {
      name,
      description,
      unitCost,
    };

    this.publicService.createProduct(dataToSend).subscribe((data) => {
      this.products = data;
    });
  }

  updateProduct(e: any) {
    const id = e.data.id;
    const name = e.data.name;
    const description = e.data.description;
    const unitCost = e.data.unitCost;

    const dataToSend = {
      id,
      name,
      description,
      unitCost,
    };

    this.publicService.updateProduct(dataToSend).subscribe((data) => {
      this.products = data;
    });
  }

  deleteProduct(e: any) {
    const id = e.data.id;

    const dataToSend = {
      id,
    };

    this.publicService.deleteProduct(dataToSend).subscribe((data) => {
      this.products = data;
    });
  }
}
