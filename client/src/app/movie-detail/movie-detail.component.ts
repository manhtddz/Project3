import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Movie } from '../interfaces/movie.interface';
import { Date } from '../interfaces/date.interface';
import { Showtime } from '../interfaces/showtime.interface';
import { Ticket } from '../interfaces/ticket.interface';
import { MovieService } from '../services/movie.service';
import { TicketService } from '../services/ticket.service';
import { ShowtimeService } from '../services/showtime.service';
import { DateService } from '../services/date.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrl: './movie-detail.component.css'
})
export class MovieDetailComponent {
  response: Movie;
  movieId !: any;

  constructor(private activatedRoute: ActivatedRoute, private movieService: MovieService, private ticketService: TicketService,
    private showtimeService: ShowtimeService, private dateService: DateService
  ) { }
  dates: Date[];
  dateId: number = 0;


  showtimes: Showtime[];
  showtimeId: number = 0;

  tickets: Ticket[];
  ticketId: number = 0;

  userEmail: string = "";

  bookingResponse = {
    isModified: false,
    error: {
      notFoundErrorMessage: ""
    }

  }
  dateChanged() {
    this.showtimeService.getShowtimesByMovieAndDate(this.movieId, this.dateId).subscribe(
      (results: any) => {
        this.showtimes = results
      }
    );
  }
  
  findTicket() {
    this.ticketId = 0;
    this.ticketService.getTicketByMovieDateShowtime(this.response.id, this.dateId, this.showtimeId).subscribe(
      (results: any) => {
        this.tickets = results
        this.tickets.sort(function (a, b) {
          if (a.seatId > b.seatId) return 1;
          if (a.seatId < b.seatId) return -1;
          return 0;
        }
        )
      }
    )
  }
  chooseTicket(id: number) {
    this.ticketId = id
  }
  book() {
    var inputData = {
      email: this.userEmail
    }
    this.ticketService.bookingTicket(this.ticketId, inputData).subscribe(
      (result: any) => {
        this.bookingResponse = result
      }
    )
  }
  output: number = 0;
  moneyConvert(price: number, ev: any) {
    var t: HTMLInputElement = ev.target;
    var sl = Number(t.value);
    this.output = price * sl;
  }
  ngOnInit() {
    this.movieId = this.activatedRoute.snapshot.paramMap.get('id')
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.movieService.getMovie(+params.get('id')!).subscribe(
        (result: any) => {
          this.response = result
        }
      )
    }
    )
    this.dateService.getDateByMovie(this.movieId).subscribe(
      (results: any) => {
        this.dates = results
      }
    );

  }

}
