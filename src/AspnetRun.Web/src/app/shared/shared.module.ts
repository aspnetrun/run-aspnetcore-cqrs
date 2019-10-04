import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';
import { NgSelectModule } from '@ng-select/ng-select';
import { AngularSlickgridModule } from 'angular-slickgrid';

import { ValidationMessageComponent } from './validation-message/validation-message.component';
import { CapitalizePipe } from './pipes/capitalize.pipe';
import { TrimPipe } from './pipes/trim.pipe';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ModalModule.forRoot(),
    NgSelectModule,
    AngularSlickgridModule.forRoot({
      enableAutoResize: true,
      autoHeight: false,
      autoResize: {
        maxHeight: 429,
        containerId: 'grid-container',
        sidePadding: 0
      },
      enableFiltering: true,
      pagination: {
        pageSizes: [],
        pageSize: 10,
        totalItems: 0
      },
    }),
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule,
    NgSelectModule,
    AngularSlickgridModule,
    ValidationMessageComponent,
    CapitalizePipe,
    TrimPipe
  ],
  declarations: [
    ValidationMessageComponent,
    CapitalizePipe,
    TrimPipe
  ]
})
export class SharedModule { }
