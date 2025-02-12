import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Tickets';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token'); 
  createTicket(inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.post<any>(this.apiUrl + '/CreateTicket', inputData, { headers: headers })
  }
  getTicketByMovie(movieId: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetTicketByMovie/' + movieId, { headers: headers })
  }
  getTicketPagingByMovie(movieId: number, startIndex: number, limit: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetTicketPagingByMovie/' + movieId + '/' + startIndex + '/' + limit, { headers: headers })
  }
  getLengthOfTicketsByMovie(movieId: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetLengthOfTicketsByMovie/' + movieId, { headers: headers })
  }
  getTotalIncome(): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/TotalIncome', { headers: headers })
  }
  deleteTicket(id: number) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.delete<any>(this.apiUrl + '/DeleteTicket/' + id, { headers: headers })
  }
}
