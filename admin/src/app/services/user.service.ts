import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly apiUrl: string = 'https://localhost:7092/api/Auth';

  // public token: string;
  constructor(private http: HttpClient, private cookieService: CookieService) {
    // var currentUser = JSON.parse(cookieService.get('currentUser'));
    // this.token = currentUser && currentUser.token;
  }
  public token = this.cookieService.get('token');
  getAllUsers(): Observable<any> {
    return this.http.get<any>(this.apiUrl + '/GetAllUsers')
  }
  getPagingUsers(startIndex: number, limit: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' +  this.token });

    return this.http.get<any>(this.apiUrl + '/GetAllPagingUsers/' + startIndex + '/' + limit, { headers: headers })
  }
  getLengthOfUsers(): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' +  this.token });

    return this.http.get<any>(this.apiUrl + '/GetLengthOfUsers', { headers: headers })
  }
  login(inputData: object): Observable<any> {
    return this.http.post(this.apiUrl + '/Login', inputData)
  }
  register(inputData: object): Observable<any> {
    return this.http.post(this.apiUrl + '/Register', inputData)
  }
  getAuthentication(token: string): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' +  token });

    return this.http.get(this.apiUrl + '/GetAuthentication', { headers: headers });
  }
}
