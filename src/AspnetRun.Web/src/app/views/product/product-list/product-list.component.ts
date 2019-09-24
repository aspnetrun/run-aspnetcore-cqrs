import { Component, OnInit } from '@angular/core';
import { ProductDataService } from 'src/app/core/services/product-data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IProduct } from 'src/app/shared/interfaces';

@Component({
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  productList: { products: IProduct[], pageCount: number } = { products: [], pageCount: 1 };

  constructor(private dataService: ProductDataService, private router: Router, route: ActivatedRoute) {
    route.params.subscribe(() => {
      this.getProducts();
    });
  }

  ngOnInit(): void {
  }

  getProducts() {
    this.dataService.getProductsByName("").subscribe((products: IProduct[]) => {
      this.productList.products = products;
    });
  }
}
