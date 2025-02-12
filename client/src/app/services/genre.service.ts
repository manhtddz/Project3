import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Genres';

  constructor(private http: HttpClient) { }

  getPagingGenres(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingGenres/' + startIndex + '/' + limit)
  }
  getLengthOfGenres(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfGenres')
  }
  getAllGenres(): Observable<any> {
    
    return this.http.get<any>(this.apiUrl + '/GetAllGenres')
  }

  getGenre(id: number): Observable<any> {
   
    return this.http.get<any>(this.apiUrl + '/GetGenreById/' + id)
  }

  updateGenre(id: number, inputData: object) {
    return this.http.put<any>(this.apiUrl + '/UpdateGenre/' + id, inputData)
  }

  createGenre(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateGenre', inputData)
  }

  deleteGenre(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteGenre/' + id)
  }
}
