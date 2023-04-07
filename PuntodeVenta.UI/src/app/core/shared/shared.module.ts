import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { VigilanteGuard } from 'src/app/vigilante.guard';
import { NotFoundComponent } from './components/not-found.component';
import { DxDrawerModule } from 'devextreme-angular';
import { DxDataGridModule } from 'devextreme-angular';
import { DxButtonModule } from 'devextreme-angular';
import { DxSelectBoxModule } from 'devextreme-angular';
import { DxDateBoxModule } from 'devextreme-angular';
import { DxToolbarModule } from 'devextreme-angular';
import { DxListModule } from 'devextreme-angular';
import { DxScrollViewModule } from 'devextreme-angular';
import { DxTextBoxModule } from 'devextreme-angular';
import { DxValidatorModule } from 'devextreme-angular';
import { DxPopupModule } from 'devextreme-angular';

@NgModule({
  imports: [
    HttpClientModule,
    RouterModule,
    CommonModule,
    DxDrawerModule,
    DxDataGridModule,
    DxButtonModule,
    DxSelectBoxModule,
    DxDateBoxModule,
    DxToolbarModule,
    DxListModule,
    DxScrollViewModule,
    DxTextBoxModule,
    DxValidatorModule,
    DxPopupModule,
  ],
  exports: [
    HttpClientModule,
    RouterModule,
    CommonModule,
    DxDrawerModule,
    DxDataGridModule,
    DxButtonModule,
    DxSelectBoxModule,
    DxDateBoxModule,
    DxToolbarModule,
    DxListModule,
    DxScrollViewModule,
    DxTextBoxModule,
    DxValidatorModule,
    DxPopupModule,
  ],
  declarations: [NotFoundComponent],
  providers: [VigilanteGuard],
})
export class SharedModule {}
