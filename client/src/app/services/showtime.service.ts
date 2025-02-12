import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShowtimeService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Showtimes';

  constructor(private http: HttpClient) { }

  getAllShowtimes(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetAllShowtimes')
  }

  getShowtimesByMovieAndDate(movieId: number, dateId: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + '/GetShowtimesByMovieAndDate/' + movieId + '/' + dateId)
  }
}
