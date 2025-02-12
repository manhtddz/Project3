import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Movies';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token'); 

  getPagingMovies(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingMovies/' + startIndex + '/' + limit)
  }
  getLengthOfMovies(): Observable<any> {
    return this.http.get<any>(this.apiUrl + '/GetLengthOfMovies')
  }

  getMovie(id: number): Observable<any> {
   
    return this.http.get<any>(this.apiUrl + '/GetMovieById/' + id)
  }

  updateMovie(id: number, inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.put<any>(this.apiUrl + '/UpdateMovie/' + id, inputData, { headers: headers })
  }

  createMovie(inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.post<any>(this.apiUrl + '/CreateMovie', inputData, { headers: headers })
  }

  deleteMovie(id: number) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.delete<any>(this.apiUrl + '/DeleteMovie/' + id, { headers: headers })
  }
}
