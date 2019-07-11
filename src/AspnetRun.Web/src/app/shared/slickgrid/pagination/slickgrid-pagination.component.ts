import { Component, Input } from '@angular/core';
import { GridOption } from 'angular-slickgrid';
import { SlickgridTableComponent } from '../table/slickgrid-table.component';

@Component({
  selector: 'ar-slickgrid-pagination',
  templateUrl: './slickgrid-pagination.component.html',
  styleUrls: ['./slickgrid-pagination.component.css']
})
export class SlickgridPaginationComponent {
  @Input('pageCount') pageCount = 1;
  @Input('pageNumber') pageNumber = 1;

  totalItems = 0;
  processing = false;

  // Reference to the real pagination component
  realPagination = true;
  gridComponent: SlickgridTableComponent;

  _gridPaginationOptions: GridOption;
  @Input()
  set gridPaginationOptions(gridPaginationOptions: GridOption) {
    this._gridPaginationOptions = gridPaginationOptions;

    // The backendServiceApi is itself the SlickgridTableComponent (This is a hack)
    this.gridComponent = <SlickgridTableComponent>this.gridPaginationOptions.backendServiceApi.service;
  }
  get gridPaginationOptions(): GridOption {
    return this._gridPaginationOptions;
  }

  changeToFirstPage(event: any) {
    this.pageNumber = 1;
    this.onPageChanged(event, this.pageNumber);
  }

  changeToLastPage(event: any) {
    this.pageNumber = this.pageCount;
    this.onPageChanged(event, this.pageNumber);
  }

  changeToNextPage(event: any) {
    if (this.pageNumber < this.pageCount) {
      this.pageNumber++;
      this.onPageChanged(event, this.pageNumber);
    }
  }

  changeToPreviousPage(event: any) {
    if (this.pageNumber > 1) {
      this.pageNumber--;
      this.onPageChanged(event, this.pageNumber);
    }
  }

  changeToCurrentPage(event: any) {
    this.pageNumber = event.currentTarget.value;
    if (this.pageNumber < 1) {
      this.pageNumber = 1;
    } else if (this.pageNumber > this.pageCount) {
      this.pageNumber = this.pageCount;
    }

    this.onPageChanged(event, this.pageNumber);
  }

  onPageChanged(event?: Event, pageNumber?: number) {
    this.gridComponent.processOnPaginationChanged(event, { newPage: pageNumber, pageSize: -1 });
  }
}
