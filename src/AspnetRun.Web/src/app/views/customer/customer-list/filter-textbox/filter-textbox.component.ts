import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'cm-filter-textbox',
  templateUrl: './filter-textbox.component.html',
  styleUrls: ['./filter-textbox.component.css']
})
export class FilterTextboxComponent {

  filterText: string
  
  @Output()
  changed: EventEmitter<string> = new EventEmitter<string>();

  filterChanged(event: any) {
    event.preventDefault();
    this.changed.emit(this.filterText); // Raise changed event
  }  

}
