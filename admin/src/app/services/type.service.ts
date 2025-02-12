import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TypeService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Types';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token');

  getPagingTypes(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingTypes/' + startIndex + '/' + limit)
  }
  getLengthOfTypes(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfTypes')
  }
  getAllTypes(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetAllTypes')
  }

  getType(id: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetTypeById/' + id)
  }

  updateType(id: number, inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.put<any>(this.apiUrl + '/UpdateType/' + id, inputData, { headers: headers })
  }

  createType(inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.post<any>(this.apiUrl + '/CreateType', inputData, { headers: headers })
  }

  deleteType(id: number) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.delete<any>(this.apiUrl + '/DeleteType/' + id, { headers: headers })
  }
}
