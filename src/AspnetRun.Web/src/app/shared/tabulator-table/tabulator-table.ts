export interface ITabulatorTableOptions {
    columns: ITabulatorTableColumn[],
    data: any[],
}

export interface ITabulatorTableColumn {
    title?: string;
    field?: string;
}
