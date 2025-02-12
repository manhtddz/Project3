import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TypeService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Types';

  constructor(private http: HttpClient) { }

  getPagingTypes(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingTypes/' + startIndex + '/' + limit)
  }
  getLengthOfTypes(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetLengthOfTypes')
  }
  getAllTypes(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetAllTypes')
  }

  getType(id: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetTypeById/' + id)
  }

  updateType(id: number, inputData: object) {
    return this.http.put<any>(this.apiUrl + '/UpdateType/' + id, inputData)
  }

  createType(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateType', inputData)
  }

  deleteType(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteType/' + id)
  }
}
