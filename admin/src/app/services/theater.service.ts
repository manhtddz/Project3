import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TheaterService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Theaters';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token'); 

  getPagingTheaters(startIndex: number, limit: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetPagingTheaters/' + startIndex + '/' + limit, { headers: headers })
  }
  getLengthOfTheaters(): Observable<any>{
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetLengthOfTheaters', { headers: headers })
  }
  getAllTheaters(): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetAllTheaters', { headers: headers })
  }

  getTheater(id: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetTheaterById/' + id, { headers: headers })
  }

  updateTheater(id: number, inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.put<any>(this.apiUrl + '/UpdateTheater/' + id, inputData, { headers: headers })
  }

  createTheater(inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.post<any>(this.apiUrl + '/CreateTheater', inputData, { headers: headers })
  }

  deleteTheater(id: number) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.delete<any>(this.apiUrl + '/DeleteTheater/' + id, { headers: headers })
  }
}
