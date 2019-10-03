import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { AuthGuardService } from './core/services/auth-guard.service';
import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';
import { LoginComponent } from './views/login/login.component';
import { RegisterComponent } from './views/register/register.component';
import { LayoutComponent } from './core/layout/layout.component';
import { DashboardComponent } from './views/dashboard/dashboard.component';
import { AboutComponent } from './views/about/about.component';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full', },
  { path: '404', component: P404Component, data: { title: 'Page 404' } },
  { path: '500', component: P500Component, data: { title: 'Page 500' } },
  { path: 'login', component: LoginComponent, data: { title: 'Login Page' } },
  { path: 'register', component: RegisterComponent, data: { title: 'Register Page' } },
  {
    path: '', component: LayoutComponent, data: { title: '' },
    children: [
      { path: 'dashboard', component: DashboardComponent, data: { title: 'Dashboard' } },
      { path: 'product', loadChildren: () => import('./views/product/product.module').then(m => m.ProductModule) },
      { path: 'category', loadChildren: () => import('./views/category/category.module').then(m => m.CategoryModule) },
      { path: 'customer', loadChildren: () => import('./views/customer/customer.module').then(m => m.CustomerModule) },
      { path: 'about', component: AboutComponent, data: { title: 'About' } }
    ],
    canActivateChild: [AuthGuardService],
    canActivate: [AuthGuardService]
  },
  { path: '**', component: P404Component }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules, enableTracing: false })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
