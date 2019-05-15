import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/interfaces';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductDataService } from 'src/app/core/services/product-data.service';

@Component({
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: IProduct = {
    id: null,
    name: '',
    description: '',
    unitPrice: 0,
    category: { id: null }
  };

  constructor(private dataService: ProductDataService, private router: Router, private route: ActivatedRoute) {
    route.params.subscribe(val => {
      const id = +this.route.snapshot.paramMap.get('id');

      if (id !== undefined && id != null && id !== 0) {
        this.dataService.getProductById(id).subscribe((product: IProduct) => {
          if (product != null) {
            this.product = product;
          }
          else {
            this.router.navigate(['/']);
          }
        });
      }
      else {
        this.router.navigate(['/']);
      }
    });
  }

  ngOnInit() {
  }

  close() {
    this.router.navigate(['/product/product-list']);
  }

  update() {
    this.router.navigate(['/product/product-edit/' + this.product.id]);
  }
}
