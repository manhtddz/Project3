import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SeatService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Seats';

  constructor(private http: HttpClient) { }

  getAllSeats(): Observable<any> {
    
    return this.http.get<any>(this.apiUrl + '/GetAllSeats')
  }

  getSeat(id: number): Observable<any> {
   
    return this.http.get<any>(this.apiUrl + '/GetSeatById/' + id)
  }

  updateSeat(id: number, inputData: object) {
    return this.http.put<any>(this.apiUrl + '/UpdateSeat/' + id, inputData)
  }

  createSeat(inputData: object) {
    return this.http.post<any>(this.apiUrl + '/CreateSeat', inputData)
  }

  deleteSeat(id: number) {
    return this.http.delete<any>(this.apiUrl + '/DeleteSeat/' + id)
  }
}
