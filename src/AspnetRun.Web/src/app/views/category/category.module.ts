import { NgModule } from '@angular/core';

import { SharedModule } from 'src/app/shared/shared.module';
import { CategoryRoutingModule } from './category-routing.module';

@NgModule({
  imports: [
    CategoryRoutingModule,
    SharedModule,
  ],
  declarations: [CategoryRoutingModule.components]
})
export class CategoryModule { }
