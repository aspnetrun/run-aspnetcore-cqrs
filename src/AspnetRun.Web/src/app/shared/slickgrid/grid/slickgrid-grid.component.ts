import { Component, Input, EventEmitter, Output, ViewChild } from '@angular/core';
import {
  AngularSlickgridComponent, Column, FieldType, GridOption, BackendService,
  BackendServiceOption, FilterChangedArgs, PaginationChangedArgs, SortChangedArgs, Pagination
} from 'angular-slickgrid';
import { SlickgridPaginationComponent } from '../pagination/slickgrid-pagination.component';

let timer: any;
const DEFAULT_FILTER_TYPING_DEBOUNCE = 750;

@Component({
  selector: 'slickgrid-grid',
  templateUrl: './slickgrid-grid.component.html',
  styleUrls: ['./slickgrid-grid.component.css']
})
export class SlickgridGridComponent implements BackendService {
  _columnDefinitions: Column[];
  _gridOptions: GridOption = {
    asyncEditorLoading: false,
    autoEdit: false,
    autoResize: {
      containerId: 'slickgrid-container',
      sidePadding: 0
    },
    // locale: 'fr',
    enableColumnPicker: true,
    enableCellNavigation: true,
    enableRowSelection: true,
    enableCheckboxSelector: false,
    enableFiltering: true,
    forceFitColumns: true,
    enableAutoTooltip: true,
    enableGridMenu: true,
    enablePagination: false
  };
  _dataset: any[];

  get columnDefinitions(): Column[] {
    return this._columnDefinitions;
  }
  @Input('columnDefinitions')
  set columnDefinitions(columnDefinitions: Column[]) {
    this._columnDefinitions = columnDefinitions;
  }

  get gridOptions(): GridOption {
    return this._gridOptions;
  }
  @Input('gridOptions')
  set gridOptions(gridOption: GridOption) {
    //this._gridOptions = gridOption;
  }

  get dataset(): any {
    return this._dataset;
  }
  @Input('dataset')
  set dataset(rawData: any) {
    const dataProvider: any = [];

    for (let index = 0; rawData && index < rawData.length; index++) {
      const row = <Object>rawData[index];
      const idObj = {
        id: row['id'] | index
      };

      let key: string;
      const rowData: any = [];
      for (key in row) {
        if (row.hasOwnProperty(key)) {
          rowData[key] = row[key];
        }
      }
      dataProvider[index] = Object.assign(rowData, idObj);
    }

    this._dataset = dataProvider;
    //this._dataset = rawData;
    this.paginationComponent.processing = false;
  }


  @Input() gridHeight = 100;
  @Input() gridWidth = 600;

  gridHeightString: string;
  gridWidthString: string;

  @ViewChild('angularSlickgrid') angularSlickgrid: AngularSlickgridComponent;

  gridObj: any;
  dataviewObj: any;
  updatedObject: any;
  isMultiSelect = true;
  selectedObjects: any[];
  selectedObject: any;

  options: BackendServiceOption;
  pagination: Pagination;


  @Output('onFilterChanged') onFilterChanged_: EventEmitter<FilterChangedArgs> = new EventEmitter<FilterChangedArgs>();
  @Output('onPaginationChanged') onPaginationChanged_: EventEmitter<PaginationChangedArgs> = new EventEmitter<PaginationChangedArgs>();
  @Output('onSortChanged') onSortChanged_: EventEmitter<SortChangedArgs> = new EventEmitter<SortChangedArgs>();

  sortedGridColumn = '';
  currentPage = 1;
  filteredGridColumns = '';

  // Data


  // Injected functions
  private _onRowDoubleClick: Function = new Function();
  private _onRowClick: Function = new Function();


  private _selectedRow: any;

  // Initialized to a fake pagination object
  private _paginationComponent: any = {
    processing: false,
    realPagination: false
  };

  @Input('pagination')
  set paginationComponent(value: SlickgridPaginationComponent) {
    if (value.realPagination) {
      this._paginationComponent = value;
      this._gridOptions.backendServiceApi = {
        service: this,
        preProcess: () => { },
        process: (query) => {
          return null;
        },
        postProcess: (response) => { }
      };
      this._paginationComponent.gridPaginationOptions = this._gridOptions;
      this.angularSlickgrid.createBackendApiInternalPostProcessCallback(this._gridOptions);
    }
  }

  get paginationComponent(): SlickgridPaginationComponent {
    return this._paginationComponent;
  }

  gridReady(grid) {
    this.gridObj = grid;
  }

  dataviewReady(dataview) {
    this.dataviewObj = dataview;
  }

  /********************************************************/
  /******** Pagination+Sot+Filter service : START *********/
  /********************************************************/
  buildQuery(): string {
    return 'buildQuery...';
  }

  init(serviceOptions: BackendServiceOption, pagination?: Pagination): void {
    this.options = serviceOptions;
    this.pagination = pagination;
  }

  resetPaginationOptions() {
  }

  updateOptions(serviceOptions?: BackendServiceOption) {
    this.options = { ...this.options, ...serviceOptions };
  }

  /**
   * FILTERING EMIT EVENT
   * @param event
   * @param args
   */
  processOnFilterChanged(event: Event, args: FilterChangedArgs): Promise<string> {
    this.filteredGridColumns = '';
    let timing = 0;
    if (event.type === 'keyup' || event.type === 'keydown') {
      timing = DEFAULT_FILTER_TYPING_DEBOUNCE;
      clearTimeout(timer);
    }
    timer = setTimeout(() => {
      this.filteredGridColumns = '';
      for (let idx = 0; idx < this.columnDefinitions.length; idx++) {
        if (args.columnFilters.hasOwnProperty(this.columnDefinitions[idx].field)) {
          this.filteredGridColumns += args.columnFilters[this.columnDefinitions[idx].field].searchTerms[0] + '|';
        } else {
          this.filteredGridColumns += 'All|';
        }
      }

      // Reset to the first page
      this.paginationComponent.pageNumber = 1;
      this.currentPage = 1;

      // dispatch event
      this.onFilterChanged_.emit(args);
    }, timing);

    return null;
  }

  /**
   * PAGINATION EMIT EVENT
   * @param event
   * @param args
   */
  processOnPaginationChanged(event: Event, args: PaginationChangedArgs) {
    this.currentPage = args.newPage;
    this.onPaginationChanged_.emit(args);
    return 'onPaginationChanged';
  }

  /**
   * SORT EMIT EVENT
   * @param event
   * @param args
   */
  processOnSortChanged(event: Event, args: SortChangedArgs) {
    this.sortedGridColumn = '';
    const sortDirection = '|' + args.sortCols[0].sortAsc + '|';
    for (let idx = 0; idx < this.columnDefinitions.length; idx++) {
      if (this.columnDefinitions[idx].field === args.sortCols[0].sortCol.field) {
        this.sortedGridColumn = '' + idx + sortDirection;
      }
    }
    this.onSortChanged_.emit(args);
    return 'onSortChanged';
  }

  getFilteredGridColumns() {
    return this.filteredGridColumns;
  }

  getSortedGridColumn() {
    return this.sortedGridColumn;
  }
  /******** Pagination+Sot+Filter service: END *****************/


  // Getters and Setters
  get selectedRow() {
    return this._selectedRow;
  }
  set selectedRow(row: any) {
    this._selectedRow = row;
  }

  get onRowDoubleClick() {
    return this._onRowDoubleClick;
  }
  set onRowDoubleClick(event: Function) {
    this._onRowDoubleClick = event;
  }

  get onRowClick() {
    return this._onRowClick;
  }
  set onRowClick(event: Function) {
    this._onRowClick = event;
  }
}