import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IProduct, IPagedList } from 'src/app/shared/interfaces';

@Injectable()
export class ProductDataService {
    constructor(private httpClient: HttpClient) { }

    getProducts(): Observable<IProduct[]> {
        return this.httpClient.get<IProduct[]>(environment.apiUrl + '/Product/GetProducts');
    }

    searchProducts(args: any): Observable<IPagedList<IProduct>> {
        var request = { args: args };

        return this.httpClient.post<IPagedList<IProduct>>(environment.apiUrl + '/Product/SearchProducts', request);
    }

    getProductById(id: number): Observable<IProduct> {
        var request = { id: id };

        return this.httpClient.post<IProduct>(environment.apiUrl + '/Product/GetProductById', request);
    }

    getProductsByName(name: string): Observable<IProduct[]> {
        var request = { name: name };

        return this.httpClient.post<IProduct[]>(environment.apiUrl + '/Product/GetProductsByName', request);
    }

    getProductsByCategoryId(categoryId: string): Observable<IProduct[]> {
        var request = { categoryId: categoryId };

        return this.httpClient.post<IProduct[]>(environment.apiUrl + '/Product/GetProductsByCategoryId', request);
    }

    createProduct(product: IProduct): Observable<IProduct> {
        var request = { product: product };

        return this.httpClient.post<IProduct>(environment.apiUrl + '/Product/CreateProduct', request);
    }

    updateProduct(product: IProduct): Observable<any> {
        var request = { product: product };

        return this.httpClient.post<any>(environment.apiUrl + '/Product/UpdateProduct', request);
    }

    deleteProductById(id: number): Observable<any> {
        var request = { id: id };

        return this.httpClient.post<any>(environment.apiUrl + '/Product/DeleteProductById', request);
    }
}
