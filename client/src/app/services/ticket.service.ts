import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  private readonly apiUrl: string = 'https://localhost:7092/api/Tickets';

  constructor(private http: HttpClient) { }
  
  getTicketByMovieDateShowtime(movieId: number, dateId: number, showtimeId: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + '/GetTicketByMovieDateShowtime/' + movieId + '/' + dateId + '/' + showtimeId)
  }
  bookingTicket(ticketId: number, inputData: object): Observable<any> {
    return this.http.put<any>(this.apiUrl + '/BookingTicket/' + ticketId,inputData)
  }
}
