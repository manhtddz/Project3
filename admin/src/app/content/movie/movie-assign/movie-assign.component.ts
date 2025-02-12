import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Theater } from '../../../interfaces/theater.interface';
import { Movie } from '../../../interfaces/movie.interface';
import { Showtime } from '../../../interfaces/showtime.interface';
import { Seat } from '../../../interfaces/seat.interface';
import { Date } from '../../../interfaces/date.interface';
import { MovieService } from '../../../services/movie.service';
import { TheaterService } from '../../../services/theater.service';
import { ShowtimeService } from '../../../services/showtime.service';
import { SeatService } from '../../../services/seat.service';
import { DateService } from '../../../services/date.service';
import { TicketService } from '../../../services/ticket.service';

@Component({
  selector: 'app-movie-assign',
  templateUrl: './movie-assign.component.html',
  styleUrl: './movie-assign.component.css'
})
export class MovieAssignComponent {
  response: Movie;
  constructor(private activatedRoute: ActivatedRoute, private movieService: MovieService, private theaterService: TheaterService,
    private showtimeService: ShowtimeService, private seatService: SeatService, private dateService: DateService, private ticketService: TicketService) { }
  theaters: Theater[];
  theaterId: number;
  showtimes: Showtime[];
  showtimeId: number;
  dates: Date[];
  dateId: number;
  seats: Seat[];

  createResponse = {
    isModified: false,
    error: {
      notFoundErrorMessage: ""
    }
  }
  Create() {
    for (var seat of this.seats) {
      var inputData = {
        movieId: this.response.id,
        seatId: seat.id,
        theaterId: this.theaterId,
        showtimeId: this.showtimeId,
        dateId: this.dateId,
        userId: 0
      };
      this.ticketService.createTicket(inputData).subscribe({
        next: (res: any) => {
          this.createResponse = res
        }
      });
    }
    var activateMovieData = {
      name: this.response.name,
      shopId: this.response.shopId,
      genreId: this.response.genreId,
      image: this.response.image,
      price: this.response.price,
      description: this.response.description,
      active: true
    }
    this.movieService.updateMovie(this.response.id, activateMovieData).subscribe({
      next: (res: any) => {
      }
    })

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.movieService.getMovie(+params.get('id')!).subscribe(
        (result: any) => {
          this.response = result
        }
      )
    }
    )

    this.theaterService.getAllTheaters().subscribe(
      (results: any) => {

        this.theaters = results
      }
    );
    this.dateService.getAllDates().subscribe(
      (results: any) => {

        this.dates = results
      }
    );
    this.showtimeService.getAllShowtimes().subscribe(
      (results: any) => {

        this.showtimes = results
      }
    );
    this.seatService.getAllSeats().subscribe(
      (results: any) => {

        this.seats = results
      }
    );
  }
}
