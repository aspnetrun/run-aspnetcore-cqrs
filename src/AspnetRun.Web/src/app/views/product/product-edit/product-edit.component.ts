import { Component, OnInit } from '@angular/core';
import { ICategory, IProduct } from 'src/app/shared/interfaces';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductDataService } from 'src/app/core/services/product-data.service';
import { CategoryDataService } from 'src/app/core/services/category-data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';

@Component({
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  // selectedFormValues: { category?: ICategory } = {};
  categories: ICategory[] = [];
  productForm: FormGroup;
  operationText: string = "Create";

  constructor(
    private productDataService: ProductDataService,
    private categoryDataService: CategoryDataService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute) {
    route.params.subscribe(val => {
      this.initializeForm();

      const id = +this.route.snapshot.paramMap.get('id');

      if (id !== undefined && id != null && id !== 0) {

        this.productDataService.getProductById(id).subscribe((product: IProduct) => {
          if (product != null) {
            this.productForm.patchValue(product);

            let categories = this.categoryDataService.getCategories();

            forkJoin([categories]).subscribe(results => {
              this.setFormCategoryData(results[0]);
            });

            this.operationText = 'Update';
          }
          else {
            this.router.navigate(['/product/product-edit']);
          }
        });
      }
      else {
        let categories = this.categoryDataService.getCategories();

        forkJoin([categories]).subscribe(results => {
          this.setFormCategoryData(results[0]);
        });
      }
    });
  }

  ngOnInit() {
  }

  initializeForm() {
    // this.selectedFormValues = {};
    this.categories = [];
    this.productForm = this.formBuilder.group({
      id: [0],
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      description: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      unitPrice: [0, [Validators.required]],
      categoryId: [0, Validators.required],
      selectedcategory: [],
    });
  }

  setFormCategoryData(categories: ICategory[]) {
    this.categories = categories;

    var productCategoryId = this.productForm.get('categoryId').value;
    var productCategory = this.categories.filter(c => c.id === productCategoryId)[0];
    this.productForm.get('selectedcategory').patchValue(productCategory);
  }

  onCategorySelected() {
    var productCategory = this.productForm.get('selectedcategory').value;
    var productCategoryId = productCategory ? productCategory.id : 0;
    this.productForm.get('categoryId').patchValue(productCategoryId);
  }

  saveProduct(product: IProduct) {
    if (product.id > 0) {
      this.productDataService.updateProduct(product).subscribe(() => {
        this.router.navigate(['/product/product-detail/' + product.id]);
      });
    }
    else {
      this.productDataService.createProduct(product).subscribe((savedProduct: IProduct) => {
        this.router.navigate(['/product/product-detail/' + savedProduct.id]);
      });
    }
  }

  close() {
    this.router.navigate(['/product/product-list']);
  }
}
