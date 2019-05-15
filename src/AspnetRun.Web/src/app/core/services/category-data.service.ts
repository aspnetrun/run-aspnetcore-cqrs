import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICategory } from 'src/app/shared/interfaces';

@Injectable()
export class CategoryDataService {
    constructor(private httpClient: HttpClient) { }

    getCategories(): Observable<ICategory[]> {
        return this.httpClient.get<ICategory[]>(environment.apiUrl + '/Category/GetCategories');
    }
}
