import { Component, OnInit, ViewChild, AfterViewInit, Input, } from '@angular/core';
import { FilterChangedArgs, PaginationChangedArgs, SortChangedArgs, Column, GridOption } from 'angular-slickgrid';
import { SlickgridGridComponent } from './grid/slickgrid-grid.component';
import { SlickgridPaginationComponent } from './pagination/slickgrid-pagination.component';

@Component({
  selector: 'slickgrid',
  templateUrl: './slickgrid.component.html',
  styleUrls: ['./slickgrid.component.css']
})
export class SlickgridComponent implements OnInit {

  @Input() columnDefinitions: Column[];
  @Input() gridOptions: GridOption;
  @Input() dataset: any[];
  @Input() pageCount: number;

  @ViewChild('slickgridGrid') slickgridGrid: SlickgridGridComponent;
  @ViewChild('slickgridPagination') slickgridPagination: SlickgridPaginationComponent;

  ngOnInit() {
    // Link pagination component into the current Grid
    if (this.slickgridPagination) {
      this.slickgridGrid.paginationComponent = this.slickgridPagination;
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
      this.slickgridGrid.dataset = this.dataset;
      this.slickgridPagination.pageCount = this.pageCount;
    }, 750);
  }
}
