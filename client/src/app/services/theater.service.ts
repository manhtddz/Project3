import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TheaterService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Theaters';

  constructor(private http: HttpClient) { }

  getPagingTheaters(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingTheaters/' + startIndex + '/' + limit)
  }
  getLengthOfTheaters(): Observable<any>{
    return this.http.get<any>(this.apiUrl + '/GetLengthOfTheaters')
  }
  getAllTheaters(): Observable<any> {
    
    return this.http.get<any>(this.apiUrl + '/GetAllTheaters')
  }

  getTheater(id: number): Observable<any> {
   
    return this.http.get<any>(this.apiUrl + '/GetTheaterById/' + id)
  }

  updateTheater(id: number, inputData: object) {
    return this.http.put<any>(this.apiUrl + '/UpdateTheater/' + id, inputData)
  }

  createTheater(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateTheater', inputData)
  }

  deleteTheater(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteTheater/' + id)
  }
}
