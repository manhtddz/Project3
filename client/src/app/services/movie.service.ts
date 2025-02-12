import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Movies';

  constructor(private http: HttpClient) { }

  getPagingMovies(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingMovies/' + startIndex + '/' + limit)
  }
  getLengthOfMovies(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfMovies')
  }
  getPagingSearchMovies(startIndex: number, limit: number, searchText: string): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingSearchMovies/' + startIndex + '/' + limit + '/' + searchText)
  }
  getLengthOfSearchMovies(searchText: string): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfSearchMovies/' + searchText)
  }
  getMovie(id: number): Observable<any> {
   
    return this.http.get<any>(this.apiUrl + '/GetMovieById/' + id)
  }

  updateMovie(id: number, inputData: object) {
    return this.http.put<any>(this.apiUrl + '/UpdateMovie/' + id, inputData)
  }

  createMovie(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateMovie', inputData)
  }

  deleteMovie(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteMovie/' + id)
  }
}
