import { Component, Input, EventEmitter, Output, ViewChild } from '@angular/core';
import {
  AngularSlickgridComponent, Column, GridOption, BackendService,
  BackendServiceOption, FilterChangedArgs, PaginationChangedArgs, SortChangedArgs, Pagination
} from 'angular-slickgrid';
import { SlickgridPaginationComponent } from '../pagination/slickgrid-pagination.component';

let timer: any;
const DEFAULT_FILTER_TYPING_DEBOUNCE = 750;

@Component({
  selector: 'ar-slickgrid-table',
  templateUrl: './slickgrid-table.component.html',
  styleUrls: ['./slickgrid-table.component.css']
})
export class SlickgridTableComponent implements BackendService {
  _columnDefinitions: Column[];
  _gridOptions: GridOption = {
    datasetIdPropertyName: 'rowNumber',
    autoHeight: true,
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
    this._gridOptions = { ...this._gridOptions, ...gridOption };
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
        rowNumber: index
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
    this.paginationComponent.processing = false;
  }

  @ViewChild('angularSlickgrid', { static: true }) angularSlickgrid: AngularSlickgridComponent;

  gridObj: any;
  dataviewObj: any;

  backendServiceOption: BackendServiceOption;
  pagination: Pagination;


  @Output('onFilterChanged') _onFilterChanged: EventEmitter<FilterChangedArgs> = new EventEmitter<FilterChangedArgs>();
  @Output('onPaginationChanged') _onPaginationChanged: EventEmitter<PaginationChangedArgs> = new EventEmitter<PaginationChangedArgs>();
  @Output('onSortChanged') _onSortChanged: EventEmitter<SortChangedArgs> = new EventEmitter<SortChangedArgs>();

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

  init(backendServiceOption: BackendServiceOption, pagination?: Pagination): void {
    this.backendServiceOption = backendServiceOption;
    this.pagination = pagination;
  }

  resetPaginationOptions() {
  }

  updateOptions(backendServiceOption?: BackendServiceOption) {
    this.backendServiceOption = { ...this.backendServiceOption, ...backendServiceOption };
  }

  processOnFilterChanged(event: Event, args: FilterChangedArgs): Promise<string> {
    let timing = 0;
    if (event.type === 'keyup' || event.type === 'keydown') {
      timing = DEFAULT_FILTER_TYPING_DEBOUNCE;
      clearTimeout(timer);
    }
    timer = setTimeout(() => {
      // Reset to the first page
      this.paginationComponent.pageNumber = 1;

      // dispatch event
      this._onFilterChanged.emit(args);
    }, timing);

    return null;
  }

  processOnPaginationChanged(event: Event, args: PaginationChangedArgs) {
    this._onPaginationChanged.emit(args);
    return 'onPaginationChanged';
  }

  processOnSortChanged(event: Event, args: SortChangedArgs) {
    this._onSortChanged.emit(args);
    return 'onSortChanged';
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