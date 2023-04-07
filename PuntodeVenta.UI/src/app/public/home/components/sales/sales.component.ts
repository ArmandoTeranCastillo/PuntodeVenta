import { Component, OnInit } from '@angular/core';
import { PublicService } from 'src/app/public/public.service';
import { confirm } from 'devextreme/ui/dialog';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.scss'],
})
export class SalesComponent implements OnInit {
  inventory: any;
  sales: any;
  partialClosure: any;
  totalClosure: any;

  readonly allowedPageSizes = [5, 10, 'all'];

  readonly displayModes = [
    { text: "Display Mode 'full'", value: 'full' },
    { text: "Display Mode 'compact'", value: 'compact' },
  ];

  displayMode = 'full';

  showPageSizeSelector = true;

  showInfo = true;

  showNavButtons = true;

  popupVisible = false; // variable para controlar la visibilidad del popup
  columns: any[] = []; // las columnas que quieres mostrar en el datagrid

  constructor(private publicService: PublicService) {}

  ngOnInit() {
    this.getSales();
    this.getInventory();
  }

  getSales() {
    this.publicService.getSales().subscribe((sales) => {
      console.log(sales);
      this.sales = sales;
    });
  }

  createSale(e: any) {
    const inventoryId = e.data.inventory.id;
    const quantitySold = e.data.quantitySold;
    const registered = false;
    const date = new Date();

    const dataToSend = {
      inventoryId,
      quantitySold,
      registered,
      date,
    };

    console.log(dataToSend);

    this.publicService.createSale(dataToSend).subscribe(
      (response) => {
        console.log(response);
        this.getSales();
        e.component.refresh();
        notify('Registro Creado', 'success', 3000);
      },
      (error) => {
        notify(error, 'error', 3000);
      }
    );
  }

  updateSale(e: any) {
    const inventoryId = e.data.inventory.id;
    const quantitySold = e.data.quantitySold;
    const registered = false;
    const date = new Date();
    const id = e.data.id;

    const dataToSend = {
      id,
      inventoryId,
      quantitySold,
      registered,
      date,
    };

    this.publicService.updateSale(dataToSend).subscribe(
      (response) => {
        console.log(response);
        this.getSales();
        e.component.refresh();
        notify('Registro Actualizado', 'success', 3000);
      },
      (error) => {
        notify(error, 'error', 3000);
      }
    );
  }

  deleteSale(e: any) {
    const id = e.data.id;

    const dataToSend = {
      id,
    };

    this.publicService.deleteSale(dataToSend).subscribe(
      (response) => {
        console.log(response);
        this.getSales();
        e.component.refresh();
        notify('Registro Eliminado', 'success', 3000);
      },
      (error) => {
        notify(error, 'error', 3000);
      }
    );
  }

  getInventory() {
    this.publicService.getInventory().subscribe((inventory) => {
      console.log(inventory);
      this.inventory = inventory;
    });
  }

  getPartialClosure(e: any) {
    let result = confirm('<i>Seguro que quieres cerrar la caja?</i>', '');
    result.then((dialogResult) => {
      if (dialogResult) {
        this.publicService.getPartialClosure().subscribe(
          (response) => {
            this.partialClosure = response;
            this.showPopup();
            this.getSales();
            e.component.refresh();
            notify('Caja Cerrada', 'success', 3000);
          },
          (error) => {
            notify(error, 'error', 3000);
          }
        );
      }
    });
  }

  getTotalClosure(e: any) {
    let result = confirm('<i>Seguro que quieres cerrar la caja?</i>', '');
    result.then((dialogResult) => {
      if (dialogResult) {
        this.publicService.getTotalClosure().subscribe(
          (response) => {
            this.totalClosure = response;
            this.showPopup();
            this.getSales();
            e.component.refresh();
            notify('Caja Cerrada', 'success', 3000);
          },
          (error) => {
            notify(error, 'error', 3000);
          }
        );
      }
    });
  }

  showPopup() {
    this.popupVisible = true;
  }

  closePopup() {
    this.popupVisible = false;
  }

  onPopupHidden() {
    // aquí puedes hacer algo cuando el popup se cierra
  }
}
