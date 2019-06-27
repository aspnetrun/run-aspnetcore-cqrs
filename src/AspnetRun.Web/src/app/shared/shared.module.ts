import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';
import { NgSelectModule } from '@ng-select/ng-select';
import { AngularSlickgridModule } from 'angular-slickgrid';

import { ControlMessageComponent } from './control-messages/control-message.component';
import { SlickgridComponent } from './slickgrid/slickgrid.component';
import { SlickgridTableComponent } from './slickgrid/table/slickgrid-table.component';
import { SlickgridPaginationComponent } from './slickgrid/pagination/slickgrid-pagination.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ModalModule.forRoot(),
    NgSelectModule,
    AngularSlickgridModule.forRoot(),
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule,
    NgSelectModule,
    AngularSlickgridModule,
    ControlMessageComponent,
    SlickgridComponent,
  ],
  declarations: [
    ControlMessageComponent,
    SlickgridComponent,
    SlickgridTableComponent,
    SlickgridPaginationComponent,
  ]
})
export class SharedModule { }
