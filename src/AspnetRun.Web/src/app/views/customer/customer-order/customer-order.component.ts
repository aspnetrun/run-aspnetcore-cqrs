import { Component, OnInit } from '@angular/core';
import { IOrder, ICustomer } from 'src/app/shared/interfaces';
import { CustomerDataService } from 'src/app/core/services/customer-data.services';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-customer-order',
  templateUrl: './customer-order.component.html',
  styleUrls: ['./customer-order.component.css']
})
export class CustomerOrderComponent implements OnInit {

  orders: IOrder[] = [];
  customer: ICustomer;
  
  constructor(private route: ActivatedRoute, private dataService: CustomerDataService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      const id = +params['id'];
      this.dataService.getCustomerById(id).subscribe((customer: ICustomer) => {
        this.customer = customer;
      });
    });
  }

  ordersTrackBy(index: number, orderItem: any) {
    return index;
  }

}
