import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { ICustomer } from 'src/app/shared/interfaces';

@Component({
  selector: 'cm-customer-grid',
  templateUrl: './customer-grid.component.html',
  styleUrls: ['./customer-grid.component.css']
  //changeDetection: ChangeDetectionStrategy.OnPush
})
export class CustomerGridComponent implements OnInit {

  @Input() customers: ICustomer[]

  constructor() { }

  ngOnInit() {
  }

}
