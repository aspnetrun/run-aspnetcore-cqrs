import { Component } from '@angular/core';
import { CategoryDataService } from 'src/app/core/services/category-data.service';
import { ActivatedRoute } from '@angular/router';
import { ICategory } from 'src/app/shared/interfaces';

@Component({
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent {
  categories: ICategory[];

  constructor(private dataService: CategoryDataService, route: ActivatedRoute) {
    route.params.subscribe(() => {
      this.getCategories();
    });
  }

  getCategories() {
    this.dataService.getCategories().subscribe((categories: ICategory[]) => {
      this.categories = categories;
    });
  }
}
