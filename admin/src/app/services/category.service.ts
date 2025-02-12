import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Categories';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  public token = this.cookieService.get('token'); 

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
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.put<any>(this.apiUrl + '/UpdateCategory/' + id, inputData, { headers: headers })
  }

  createCategory(inputData: object) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.post<any>(this.apiUrl + '/CreateCategory', inputData, { headers: headers })
  }

  deleteCategory(id: number) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + this.token });

    return this.http.delete<any>(this.apiUrl + '/DeleteCategory/' + id, { headers: headers })
  }
}
