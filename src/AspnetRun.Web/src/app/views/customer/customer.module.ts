import { NgModule } from '@angular/core';

import { SharedModule } from 'src/app/shared/shared.module';
import { CustomerRoutingModule } from './customer-routing.module';
import { FilterTextboxComponent } from './customer-list/filter-textbox/filter-textbox.component';
import { CustomerGridComponent } from './customer-list/customer-grid/customer-grid.component';

@NgModule({
  imports: [
    CustomerRoutingModule,
    SharedModule,
  ], 
  declarations: [CustomerRoutingModule.components, FilterTextboxComponent, CustomerGridComponent]
})
export class CustomerModule { 
  
}
