import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import Tabulator from 'tabulator-tables';
import { ITabulatorOptions } from './tabulator-table';

@Component({
  selector: 'app-tabulator-table',
  templateUrl: './tabulator-table.component.html',
  styleUrls: ['./tabulator-table.component.scss']
})
export class TabulatorTableComponent implements OnChanges {
  table: Tabulator;

  @Input() options: ITabulatorOptions;
  @Input()
  set data(data) {
    this.options.data = data;
    if (this.table)
      this.table.setData(this.options.data);
  }

  tab = document.createElement('div');

  ngOnChanges(changes: SimpleChanges): void {
    this.drawTable();
  }

  private drawTable(): void {
    this.options.reactiveData = true;
    this.options.layout = "fitColumns";
    this.table = new Tabulator(this.tab, this.options);
    document.getElementById('tabular-table').appendChild(this.tab);
  }
}