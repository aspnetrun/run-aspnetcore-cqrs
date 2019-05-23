import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';
import { NgSelectModule } from '@ng-select/ng-select';

import { ControlMessageComponent } from './control-messages/control-message.component';
import { TabulatorTableComponent } from './tabulator-table/tabulator-table.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ModalModule.forRoot(),
    NgSelectModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule,
    NgSelectModule,
    ControlMessageComponent,
    TabulatorTableComponent,
  ],
  declarations: [
    ControlMessageComponent,
    TabulatorTableComponent,
  ]
})
export class SharedModule { }
