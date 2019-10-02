import { Component, OnInit } from '@angular/core';
import { ICustomer, IPagedResults } from 'src/app/shared/interfaces';

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
    
    this.getCustomersPage(1);
  }

  getCustomersPage(page: number) {
    this.dataService.getCustomersPage((page - 1) * this.pageSize, this.pageSize)
        .subscribe((response: IPagedResults<ICustomer[]>) => {
          this.customers = this.filteredCustomers = response.results;
          this.totalRecords = response.totalRecords;
        },
        (err: any) => this.logger.log(err),
        () => this.logger.log('getCustomersPage() retrieved customers for page: ' + page));
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
