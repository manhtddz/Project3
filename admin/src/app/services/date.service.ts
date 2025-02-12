import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, input } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DateService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Dates';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token');

  getAllDates(): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetAllDates', { headers: headers })
  }

  getDate(id: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetDateById/' + id)
  }

  createSomeDates(dateQty: number) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.post<any>(this.apiUrl + '/CreateSomeDates/' + dateQty, {}, { headers: headers })
  }

  deleteDate(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteDate/' + id)
  }
}
