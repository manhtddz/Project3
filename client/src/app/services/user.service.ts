import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly apiUrl: string = 'https://localhost:7092/api/Auth';

  constructor(private http: HttpClient) { }
  getAllUsers(): Observable<any>{
    return this.http.get<any>(this.apiUrl+'/GetAllUsers')
  }
  getPagingUsers(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetAllPagingUsers/' + startIndex + '/' + limit)
  }
  getLengthOfUsers(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfUsers')
  }
}
