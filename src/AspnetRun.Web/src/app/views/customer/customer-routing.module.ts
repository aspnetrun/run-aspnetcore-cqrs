import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { CustomerEditComponent } from './customer-edit/customer-edit.component';

const routes: Routes = [
  {
    path: '',
    data: { title: 'Customer' },
    children: [
      { path: '', redirectTo: 'customer-list' },
      { path: 'customer-list', component: CustomerListComponent, data: { title: 'List' } },
      { path: 'customer-detail/:id', component: CustomerDetailComponent, data: { title: 'Detail' } },
      { path: 'customer-edit', component: CustomerEditComponent, data: { title: 'New' } },
      { path: 'customer-edit/:id', component: CustomerEditComponent, data: { title: 'Edit' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule {
  static components = [CustomerListComponent, CustomerDetailComponent, CustomerEditComponent];
}