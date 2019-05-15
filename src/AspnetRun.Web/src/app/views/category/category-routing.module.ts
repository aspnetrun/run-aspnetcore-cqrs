import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CategoryListComponent } from './category-list/category-list.component';

const routes: Routes = [
  {
    path: '',
    data: { title: 'Category' },
    children: [
      { path: '', redirectTo: 'category-list' },
      { path: 'category-list', component: CategoryListComponent, data: { title: 'List' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryRoutingModule {
  static components = [CategoryListComponent];
}
