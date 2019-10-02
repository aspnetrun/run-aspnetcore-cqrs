import { NgModule } from '@angular/core';

import { SharedModule } from 'src/app/shared/shared.module';
import { CustomerRoutingModule } from './customer-routing.module';
import { FilterTextboxComponent } from './customer-list/filter-textbox/filter-textbox.component';

@NgModule({
  imports: [
    CustomerRoutingModule,
    SharedModule,
  ], 
  declarations: [CustomerRoutingModule.components, FilterTextboxComponent]
})
export class CustomerModule { 
  
}
