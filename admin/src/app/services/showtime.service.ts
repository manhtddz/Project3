import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShowtimeService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Showtimes';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token'); 

  getAllShowtimes(): Observable<any> {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.get<any>(this.apiUrl + '/GetAllShowtimes', { headers: headers })
  }


}
