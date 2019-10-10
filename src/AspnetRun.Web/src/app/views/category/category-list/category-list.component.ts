import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { AngularGridInstance, Column, GridOption, GraphqlService, GraphqlResult, Filters, Formatters, OnEventArgs, FieldType } from 'angular-slickgrid';

import { CategoryDataService } from 'src/app/core/services/category-data.service';
import { PageService } from 'src/app/core/services/page.service';


const GRAPHQL_QUERY_DATASET_NAME = 'categories';


@Component({
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  angularGrid: AngularGridInstance;
  columnDefinitions: Column[];
  gridOptions: GridOption;
  dataset = [];

  constructor(private dataService: CategoryDataService, private router: Router, private pageService: PageService) {
  }

  ngOnInit(): void {
    this.columnDefinitions = [
      {
        id: 'edit',
        field: 'id',
        excludeFromColumnPicker: true,
        excludeFromGridMenu: true,
        excludeFromHeaderMenu: true,
        formatter: Formatters.editIcon,
        minWidth: 30,
        maxWidth: 30,
        onCellClick: (e: Event, args: OnEventArgs) => {
          this.router.navigate(['/category/category-detail/' + args.dataContext.id]);
        }
      },
      { id: 'id', field: 'id', name: 'Id', filterable: true, sortable: true, maxWidth: 200, type: FieldType.number, filter: { model: Filters.inputNumber } },
      { id: 'name', field: 'name', name: 'Name', filterable: true, sortable: true },
      { id: 'description', field: 'description', name: 'description', filterable: true, sortable: true },
    ];

    this.gridOptions = {
      backendServiceApi: {
        service: new GraphqlService(),
        options: {
          columnDefinitions: this.columnDefinitions,
          datasetName: GRAPHQL_QUERY_DATASET_NAME
        },
        process: (query) => this.getCategories(),
      }
    };;
  }

  angularGridReady(angularGrid: AngularGridInstance) {
    this.angularGrid = angularGrid;
  }

  getCategories(): Observable<GraphqlResult> {
    var args = this.pageService.getPageArgs(this.angularGrid);

    return this.dataService.searchCategories(args)
      .pipe(map(
        page => {
          var result: GraphqlResult = {
            data: {
              [GRAPHQL_QUERY_DATASET_NAME]: {
                nodes: page.items,
                pageInfo: {
                  hasNextPage: page.hasNextPage
                },
                totalCount: page.totalCount
              }
            }
          };

          return result;
        }));
  }
}
