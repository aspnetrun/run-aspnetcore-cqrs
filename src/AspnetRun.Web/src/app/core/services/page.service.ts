import { Injectable } from '@angular/core';
import { AngularGridInstance } from 'angular-slickgrid';

@Injectable()
export class PageService {
    getPageArgs(angularGrid: AngularGridInstance): any {
        if (angularGrid) {
            var filteringOptions = angularGrid.backendService.options.filteringOptions;
            var sortingOptions = angularGrid.backendService.options.sortingOptions;
            var paginationOptions = angularGrid.backendService.getCurrentPagination();

            return {
                pageIndex: paginationOptions ? paginationOptions.pageNumber : 1,
                pageSize: paginationOptions ? paginationOptions.pageSize : 10,
                filteringOptions: filteringOptions,
                sortingOptions: sortingOptions
            };
        }
        else {
            return {
                pageIndex: 1,
                pageSize: 10
            };
        }
    }
}
