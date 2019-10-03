
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { NgForm } from '@angular/forms';

import { ICustomer, IState } from 'src/app/shared/interfaces';
import { CustomerDataService } from 'src/app/core/services/customer-data.services';

@Component({  
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {

  customer: ICustomer = 
    {
      id: 0,
      firstName: '',
      lastName: '',
      gender: '',
      address: '',
      city: '',
      state: {
        abbreviation: '',
        name: ''
      }
    };

  states: IState[];
  errorMessage: string;
  deleteMessageEnabled: boolean;
  operationText = 'Insert';
  @ViewChild('customerForm', { static : true }) customerForm: NgForm;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private dataService: CustomerDataService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      const id = +params['id'];
      if (id !== 0) {
        this.operationText = 'Update';
        this.getCustomer(id);
      }
    });
  }

  getCustomer(id: number) {
    this.dataService.getCustomerById(id).subscribe((customer : ICustomer) => { 
      this.customer = customer 
    });
  }

}
