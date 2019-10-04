import { Component, OnInit } from '@angular/core';
import { ICustomer } from 'src/app/shared/interfaces';
import { CustomerDataService } from 'src/app/core/services/customer-data.services';

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

  constructor(private dataService: CustomerDataService) { }

  ngOnInit() {
    this.title = 'Customers'
    this.filterText = ''

    this.getCustomers();
    //this.getCustomersPage(1);
  }

  getCustomers() {
    this.dataService.getCustomers().subscribe((customers: ICustomer[]) => {
      this.customers = customers;
      this.filteredCustomers = customers;
    });
  }

  filterChanged(data: string) {
    if (data && this.customers) {
      data = data.toLocaleUpperCase();
      this.filteredCustomers = this.customers.filter(customer => customer.firstName.toLocaleUpperCase().indexOf(data) > -1);
    } else {
      this.filteredCustomers = this.customers;
    }
  }

}
