import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Feedbacks';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token'); 

  getPagingFeedbacksByUser(userId: number, startIndex: number, limit: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetPagingFeedbacksByUser/' + userId + '/' + startIndex + '/' + limit, { headers: headers })
  }
  getLengthOfFeedbackByUser(userId: number): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetLengthOfFeedbackByUser/' + userId, { headers: headers })
  }
  getFeedbackQty(): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/FeedbacksQuantity', { headers: headers })
  }
}
