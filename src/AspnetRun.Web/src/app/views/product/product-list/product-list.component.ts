import { Component } from '@angular/core';
import { ProductDataService } from 'src/app/core/services/product-data.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/interfaces';
import { ITabulatorTableOptions } from 'src/app/shared/tabulator-table/tabulator-table';

@Component({
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  gridOptions: ITabulatorTableOptions = {
    data: [],
    columns: [
      { title: "Id", field: "id" },
      { title: "Name", field: "name" },
      { title: "Unit Price", field: "unitPrice" },
      { title: "Category", field: "category.name" },
      { title: "Action", field: "action" },
    ]
  }
  productName: string = '';

  constructor(private dataService: ProductDataService, route: ActivatedRoute) {
    route.params.subscribe(() => {
      this.getProducts();
    });
  }

  getProducts() {
    this.dataService.getProductsByName(this.productName).subscribe((products: IProduct[]) => {
      this.gridOptions.data = products;
    });
  }
}
