import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'product', pathMatch: 'full', },
  { path: 'product', loadChildren: './views/product/product.module#ProductModule' },
  { path: 'category', loadChildren: './views/category/category.module#CategoryModule' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules, enableTracing: false })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
