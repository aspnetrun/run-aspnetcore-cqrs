import { Component } from '@angular/core';
import { ProductDataService } from 'src/app/core/services/product-data.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/interfaces';

@Component({
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  products: IProduct[];
  productName: string = '';

  constructor(private dataService: ProductDataService, route: ActivatedRoute) {
    route.params.subscribe(() => {
      this.getProducts();
    });
  }

  getProducts() {
    this.dataService.getProductsByName(this.productName).subscribe((products: IProduct[]) => {
      this.products = products;
    });
  }
}
