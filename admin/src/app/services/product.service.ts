import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Products';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token'); 

  getPagingProducts(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingProducts/' + startIndex + '/' + limit)
  }
  getLengthOfProducts(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfProducts')
  }

  getProduct(id: number): Observable<any> {
   
    return this.http.get<any>(this.apiUrl + '/GetProductById/' + id)
  }

  updateProduct(id: number, inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.put<any>(this.apiUrl + '/UpdateProduct/' + id, inputData, { headers: headers })
  }

  createProduct(inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.post<any>(this.apiUrl + '/CreateProduct', inputData, { headers: headers })
  }

  deleteProduct(id: number) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.delete<any>(this.apiUrl + '/DeleteProduct/' + id, { headers: headers })
  }}
