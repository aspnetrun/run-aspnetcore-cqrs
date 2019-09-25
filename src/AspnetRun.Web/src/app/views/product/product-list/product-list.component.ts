import { Component, OnInit } from '@angular/core';

import { AngularGridInstance, Column, GridOption, FieldType, GraphqlService, GraphqlResult } from 'angular-slickgrid';

import { ProductDataService } from 'src/app/core/services/product-data.service';

const GRAPHQL_QUERY_DATASET_NAME = 'products';

@Component({
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  angularGrid: AngularGridInstance;
  columnDefinitions: Column[];
  gridOptions: GridOption;
  dataset = [];

  constructor(private dataService: ProductDataService) {
  }

  ngOnInit(): void {
    this.columnDefinitions = [
      { id: 'id', field: 'id', name: 'Id', filterable: true, sortable: true, type: FieldType.number },
      { id: 'name', field: 'name', name: 'Name', filterable: true, sortable: true, type: FieldType.string },
      { id: 'unitPrice', field: 'unitPrice', name: 'Unit Price', filterable: true, sortable: true, type: FieldType.number },
      { id: 'category.id', field: 'category.id', name: 'Category', filterable: true, sortable: true, type: FieldType.string },
    ];

    this.gridOptions = {
      enableFiltering: true,
      enableCellNavigation: true,
      pagination: {
        pageSizes: [10, 15, 20, 30, 50],
        pageSize: 10,
        totalItems: 0
      },
      backendServiceApi: {
        service: new GraphqlService(),
        options: {
          columnDefinitions: this.columnDefinitions,
          datasetName: GRAPHQL_QUERY_DATASET_NAME,
          isWithCursor: false,
          keepArgumentFieldDoubleQuotes: true
        },
        process: (query) => this.getProducts(query),
      }
    };;
  }

  angularGridReady(angularGrid: AngularGridInstance) {
    this.angularGrid = angularGrid;
  }

  getProducts(query: string): Promise<GraphqlResult> {
    return new Promise((resolve, reject) => {
      this.dataService.getProductsByName("")
        .toPromise()
        .then(
          products => {
            var result = {
              data: {
                [GRAPHQL_QUERY_DATASET_NAME]: {
                  nodes: products,
                  pageInfo: {
                    hasNextPage: true
                  },
                  totalCount: 100
                }
              }
            };

            resolve(result);
          }
        );
    });
  }
}
