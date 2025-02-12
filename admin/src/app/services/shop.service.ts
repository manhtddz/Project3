import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Shop';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token'); 

  getPagingShops(startIndex: number, limit: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetPagingShops/' + startIndex + '/' + limit, { headers: headers })
  }
  getLengthOfShops(): Observable<any>{
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetLengthOfShops', { headers: headers })
  }
  getAllShops(): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetAllShops', { headers: headers })
  }

  getShop(id: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetShopById/' + id, { headers: headers })
  }

  updateShop(id: number, inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.put<any>(this.apiUrl + '/UpdateShop/' + id, inputData, { headers: headers })
  }

  createShop(inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.post<any>(this.apiUrl + '/CreateShop', inputData, { headers: headers })
  }

  deleteShop(id: number) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.delete<any>(this.apiUrl + '/DeleteShop/' + id, { headers: headers })
  }
}
