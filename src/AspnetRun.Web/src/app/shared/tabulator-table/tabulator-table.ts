export interface ITabulatorOptions {
    data: any[],
    dataTree?: boolean;
    dataTreeStartExpanded?: boolean;
    columns?: ITabulatorColumn[],
    autoColumns?: boolean;
    resizableColumns?: boolean;
    placeholder?: string; // Awaiting Data, Please Load File
    height?: string; // 311px
    layout?: string; // fitDataFill, fitColumns
    responsiveLayout?: string; // hide, collapse
    persistentLayout?: boolean;
    persistentSort?: boolean;
    persistenceID?: string;
    columnVertAlign?: string; // bottom
    dataLoaded?: (data: any) => void;
    // function(data){ var firstRow = this.getRows()[0]; if(firstRow) { firstRow.freeze(); } }
    rowFormatter?: (row: any) => void;
    movableColumns?: boolean;
    reactiveData?: Boolean;
    validationFailed?: (cell: any, value: any, validators: any) => void;
    // function(cell, value, validators){ }
    movableRows?: boolean;
    movableRowsConnectedTables?: string;
    movableRowsReceiver?: string; // add
    movableRowsSender?: string; // delete
    groupBy?: string; // column name
    groupValues?: string[][];
    pagination?: string; // local
    paginationSize?: number; // 6
    paginationSizeSelector?: number[]; // [3, 6, 8, 10]
    selectable?: boolean;
    rowSelectionChanged?: (data: any, rows: any) => void;
    addRowPos?: string; // bottom
    rowMoved?: (row: any) => void;
    clipboard?: boolean;
    clipboardPasteAction?: string; // replace
    history?: boolean;
    langs?: any;
    rowClick?: (e: any, row: any) => void; // function(e, row){ alert("Row " + row.getIndex() + " Clicked!!!!") }
    rowContext?: (e: any, row: any) => void; // function(e, row){ alert("Row " + row.getIndex() + " Context Clicked!!!!") }
}

export interface ITabulatorColumn {
    title?: string;
    field?: string;
    sorter?: string | ((a: any, b: any) => boolean);
    // string => number, date, string, boolean
    // function => function(a,b){ return String(a).toLowerCase().localeCompare(String(b).toLowerCase()); }
    align?: string; // center, right, left
    width?: number; // 200
    minWidth?: number; // 30
    widthGrow?: number; // 2, 3,
    resizable?: boolean;
    headerSort?: boolean;
    responsive?: number; // 0 /* never hide this colum */, 2 /* hide this column first */
    formatter?: string | ((cell: any, formatterParams: any) => void);
    // string => responsiveCollapse, progress, tickCross, star, rownum, textarea, handle
    // function => /* function(cell, formatterParams){ return "<i class='fa fa-print'></i>"; };*/
    formatterParams?: any; // {stars:6}
    headerVertical?: boolean;
    editable?: boolean;
    frozen?: boolean;
    columns?: ITabulatorColumn[],
    cellClick?: (e: any, cell: any) => any;
    // function(e, cell){alert("Printing row data for: " + cell.getRow().getData().name)}}
    bottomCalc?: string; // avg
    bottomCalcParams?: any; // { precision: 3 }
    editor?: string | boolean | ((cell: any, onRendered: any, success: any, cancel: any) => void);
    // string => input, autocomplete /*editorParams: {allowEmpty:true, showListOnEmpty:true, values:true} */,
    // select /* editorParams:{values:{"male":"Male", "female":"Female", "unknown":"Unknown"}} */
    // boolean
    // function => /* function(cell, onRendered, success, cancel){  }; */
    editorParams?: any;
    validator?: string | string[];
    // string => required,
    // string list => ["min:0", "max:100", "numeric"], ["required", "in:male|female"], ["min:0", "max:5", "integer"], ["minLength:3", "maxLength:10", "string"],
    headerFilter?: string | boolean | ((cell: any, onRendered: any, success: any, cancel: any, editorParams: any) => void);
    // string => input, tickCross
    // boolean
    // function => function(cell, onRendered, success, cancel, editorParams){}
    headerFilterFunc?: string | ((headerValue: any, rowValue: any, rowData: any, filterParams: any) => void);
    // string => ">="
    // function => minMaxFilterFunction(headerValue, rowValue, rowData, filterParams){
    headerFilterParams?: any; // {values:{"male":"Male", "female":"Female", "":""}}
    headerFilterPlaceholder?: string; // at least...
    headerFilterEmptyCheck?: (value: any) => void; // function(value){return value === null}}
    headerSortTristate?: boolean;
    rowHandle?: boolean;
}
