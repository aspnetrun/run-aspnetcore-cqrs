import { Component } from '@angular/core';
import { CategoryDataService } from 'src/app/core/services/category-data.service';
import { ActivatedRoute } from '@angular/router';
import { ICategory } from 'src/app/shared/interfaces';
import { ITabulatorOptions } from 'src/app/shared/tabulator-table/tabulator-table';

@Component({
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent {
  gridOptions: ITabulatorOptions = {
    data: [],
    columns: [
      { title: 'Id', field: 'id' },
      { title: 'Name', field: 'name' },
      { title: 'Description', field: 'description' },
    ]
  }

  constructor(private dataService: CategoryDataService, route: ActivatedRoute) {
    route.params.subscribe(() => {
      this.getCategories();
    });
  }

  getCategories() {
    this.dataService.getCategories().subscribe((categories: ICategory[]) => {
      this.gridOptions.data = categories;
    });
  }
}
