import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Categories';

  constructor(private http: HttpClient) { }

  getPagingCategories(startIndex: number, limit: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetPagingCategories/' + startIndex + '/' + limit)
  }
  getLengthOfCategories(): Observable<any>{
    return this.http.get<any>(this.apiUrl + '/GetLengthOfCategories')
  }
  getAllCategories(): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetAllCategories')
  }

  getCategory(id: number): Observable<any> {

    return this.http.get<any>(this.apiUrl + '/GetCategoryById/' + id)
  }

  updateCategory(id: number, inputData: object) {
    return this.http.put<any>(this.apiUrl + '/UpdateCategory/' + id, inputData)
  }

  createCategory(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateCategory', inputData)
  }

  deleteCategory(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteCategory/' + id)
  }
}
