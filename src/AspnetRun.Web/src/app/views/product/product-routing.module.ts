import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductDeleteModalComponent } from './product-delete/product-delete-modal.component';

const routes: Routes = [
  {
    path: '',
    data: { title: 'Product' },
    children: [
      { path: '', redirectTo: 'product-list' },
      { path: 'product-list', component: ProductListComponent, data: { title: 'List' } },
      { path: 'product-detail/:id', component: ProductDetailComponent, data: { title: 'Detail' } },
      { path: 'product-edit', component: ProductEditComponent, data: { title: 'New' } },
      { path: 'product-edit/:id', component: ProductEditComponent, data: { title: 'Edit' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule {
  static components = [ProductListComponent, ProductDetailComponent, ProductEditComponent, ProductDeleteModalComponent];
}
