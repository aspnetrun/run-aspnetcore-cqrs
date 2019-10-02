import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICustomer } from 'src/app/shared/interfaces';

@Injectable()
export class CustomerDataService {
    constructor(private httpClient: HttpClient) { }

    getCustomers(): Observable<ICustomer[]> {
        return this.httpClient.get<ICustomer[]>(environment.apiUrl + '/Customer/GetCustomers');
    }

    getCustomerById(id:number): Observable<ICustomer> {
        var request = { id: id };

        return this.httpClient.post<ICustomer>(environment.apiUrl + '/Customer/GetCustomerById/', request);        
    }  
}
