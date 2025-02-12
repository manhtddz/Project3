import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Shop';

  constructor(private http: HttpClient) { }

  getPagingShops(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingShops/' + startIndex + '/' + limit)
  }
  getLengthOfShops(): Observable<any>{
    return this.http.get<any>(this.apiUrl + '/GetLengthOfShops')
  }
  getAllShops(): Observable<any> {
    
    return this.http.get<any>(this.apiUrl + '/GetAllShops')
  }

  getShop(id: number): Observable<any> {
   
    return this.http.get<any>(this.apiUrl + '/GetShopById/' + id)
  }

  updateShop(id: number, inputData: object) {
    return this.http.put<any>(this.apiUrl + '/UpdateShop/' + id, inputData)
  }

  createShop(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateShop', inputData)
  }

  deleteShop(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteShop/' + id)
  }
}
