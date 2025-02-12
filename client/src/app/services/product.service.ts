import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Products';

  constructor(private http: HttpClient) { }

  getPagingProducts(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingProducts/' + startIndex + '/' + limit)
  }
  getLengthOfProducts(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfProducts')
  }
  getPagingProductsByType(typeId: number, startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingProductsByType/' + typeId + '/' + startIndex + '/' + limit)
  }
  getLengthOfProductsByType(typeId: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfProductsByType/' + typeId)
  }
  getPagingSearchProductsByType(typeId: number, startIndex: number, limit: number, searchText: string): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingSearchProductsByType/' + typeId + '/' + startIndex + '/' + limit + '/' + searchText)
  }
  getLengthOfSearchProductsByType(typeId: number, searchText: string): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfSearchProductsByType/' + typeId + '/' + searchText)
  }

  getProduct(id: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetProductById/' + id)
  }

  updateProduct(id: number, inputData: object) {
    return this.http.put<any>(this.apiUrl + '/UpdateProduct/' + id, inputData)
  }

  createProduct(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateProduct', inputData)
  }

  deleteProduct(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteProduct/' + id)
  }
}
