import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DateService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Dates';

  constructor(private http: HttpClient) { }

  getAllDates(): Observable<any> {
    
    return this.http.get<any>(this.apiUrl + '/GetAllDates')
  }

  getDate(id: number): Observable<any> {
   
    return this.http.get<any>(this.apiUrl + '/GetDateById/' + id)
  }

  getDateByMovie(movieId: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + '/GetDateByMovie/' + movieId)
  }
  // updateDate(id: number, inputData: object) {
  //   return this.http.put<any>(this.apiUrl + '/UpdateDate/' + id, inputData)
  // }

  createDate(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateDate', inputData)
  }

  deleteDate(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteDate/' + id)
  }}
