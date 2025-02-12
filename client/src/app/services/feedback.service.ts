import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Feedbacks';

  constructor(private http: HttpClient) { }
  createFeedback(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateFeedback', inputData)
  }
}
