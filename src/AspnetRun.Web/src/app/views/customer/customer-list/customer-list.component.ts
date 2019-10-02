import { Component, OnInit } from '@angular/core';
import { ICustomer } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  title: string
  filterText: string
  customers: ICustomer[] = []
  filteredCustomers: ICustomer[] = []

  totalRecords: number = 0;
  pageSize: number = 10;

  constructor() { }

  ngOnInit() {
    this.title = 'Customers'
    this.filterText = ''
    
    
  }

  filterChanged(data: string) {
    if (data && this.customers) {
      data = data.toUpperCase();
      const props = ['firstName', 'lastName', 'city', 'state.name'];
      //this.filteredCustomers = this.filterService.filter<ICustomer>(this.customers, data, props);
    } else {
      this.filteredCustomers = this.customers;
    }
  }

}
