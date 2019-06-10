import { Component, OnInit, ViewChild, AfterViewInit, Input, } from '@angular/core';
import { FilterChangedArgs, PaginationChangedArgs, SortChangedArgs, Column, GridOption } from 'angular-slickgrid';
import { SlickgridGridComponent } from './grid/slickgrid-grid.component';
import { SlickgridPaginationComponent } from './pagination/slickgrid-pagination.component';

@Component({
  selector: 'slickgrid',
  templateUrl: './slickgrid.component.html',
  styleUrls: ['./slickgrid.component.css']
})
export class SlickgridComponent implements OnInit, AfterViewInit {

  @Input() columnDefinitions2: Column[];
  @Input() gridOptions2: GridOption;
  @Input() dataset2: any[];

  componentFactory: any;
  @ViewChild('slickgridGrid') slickgridGrid: SlickgridGridComponent;
  @ViewChild('slickgridPagination') slickgridPagination: SlickgridPaginationComponent;

  ngOnInit() {
    // Link pagination component into the current Grid
    if (this.slickgridPagination) {
      this.slickgridGrid.paginationComponent = this.slickgridPagination;
    }

  }

  ngAfterViewInit() {

    setTimeout(() => {
      // Init datagrid example:
      this.slickgridPagination.processing = true;

      this.slickgridGrid.CustomGrid(data_sample.pagination_samples.grid.metadata);
      this.slickgridGrid.gridData = data_sample.pagination_samples.grid.rows;
      this.slickgridPagination.pageCount = data_sample.pagination_samples.grid.rows.maxpage;

      this.slickgridPagination.processing = false;
    }, 0);
  }

  filterChanged(event: FilterChangedArgs) {
    this.slickgridPagination.processing = true;
    this.updateGridData();
  }

  paginationChanged(event: PaginationChangedArgs) {
    this.slickgridPagination.processing = true;
    this.updateGridData();
  }

  sortChanged(event: SortChangedArgs) {
    this.slickgridPagination.processing = true;
    this.updateGridData();
  }


  updateGridData() {

    setTimeout(() => {
      this.slickgridGrid.gridData = data_sample.pagination_samples.grid.rows;
      this.slickgridPagination.pageCount = data_sample.pagination_samples.grid.rows.maxpage;
    }, 750);
  }
}


export const data_sample = {
  'pagination_samples': {
    'grid': {
      'metadata': {
        'columns': {
          'column': [{
            'sort': true,
            'filterable': false,
            'width': 60,
            'dataelement': 'hasNote',
            'heading': 'Note'
          },
          {
            'sort': true,
            'filterable': true,
            'width': 125,
            'dataelement': 'status',
            'heading': 'Status'
          },
          {
            'sort': true,
            'visible': true,
            'filterable': true,
            'width': 125,
            'dataelement': 'currency',
            'heading': 'Currency'
          },
          {
            'sort': true,
            'visible': true,
            'filterable': true,
            'width': 125,
            'dataelement': 'amount',
            'heading': 'Amount'
          },
          {
            'sort': true,
            'visible': true,
            'filterable': true,
            'width': 125,
            'dataelement': 'inputDate',
            'heading': 'Input Date'
          },
          {
            'sort': true,
            'visible': true,
            'filterable': true,
            'width': 125,
            'dataelement': 'inputTime',
            'heading': 'Input Time'
          }]
        }
      },
      'rows': {
        'row': [{
          'currency': {
            'content': 'EUR'
          },
          'amount': {
            'content': '2 203 677,000'
          },
          'startTime': {
            'content': '06/19/2017 11:52:51'
          },
          'inputDate': {
            'content': '06/19/2017'
          },
          'status': {
            'content': 'New'
          },
          'inputTime': {
            'content': '11:52:51'
          },
          'hasNote': {
            'content': 'False'
          }
        },
        {
          'currency': {
            'content': 'USD'
          },
          'amount': {
            'content': '6 203 677,000'
          },
          'startTime': {
            'content': '06/28/2017 10:42:00'
          },
          'inputDate': {
            'content': '06/28/2017'
          },
          'status': {
            'content': 'New'
          },
          'inputTime': {
            'content': '10:40:12'
          },
          'hasNote': {
            'content': 'True'
          }
        }
        ],
        'maxpage': 5
      }
    }
  }
};
