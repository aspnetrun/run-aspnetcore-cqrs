import { Component, OnInit, ViewChild, AfterViewInit, Input, } from '@angular/core';
import { FilterChangedArgs, PaginationChangedArgs, SortChangedArgs, Column, GridOption } from 'angular-slickgrid';
import { SlickgridTableComponent } from './table/slickgrid-table.component';
import { SlickgridPaginationComponent } from './pagination/slickgrid-pagination.component';

@Component({
  selector: 'ar-slickgrid',
  templateUrl: './slickgrid.component.html',
  styleUrls: ['./slickgrid.component.css']
})
export class SlickgridComponent implements OnInit {

  @Input() columnDefinitions: Column[];
  @Input() gridOptions: GridOption;
  @Input() dataset: any[];
  @Input() pageCount: number;

  @ViewChild('slickgridTable', { static: true }) slickgridTable: SlickgridTableComponent;
  @ViewChild('slickgridPagination', { static: true }) slickgridPagination: SlickgridPaginationComponent;

  ngOnInit() {
    // Link pagination component into the current Grid
    if (this.slickgridPagination) {
      this.slickgridTable.paginationComponent = this.slickgridPagination;
    }
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
      this.slickgridTable.dataset = this.dataset;
      this.slickgridPagination.pageCount = this.pageCount;
    }, 750);
  }
}
