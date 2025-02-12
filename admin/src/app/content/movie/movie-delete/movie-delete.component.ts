import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { MovieService } from '../../../services/movie.service';
import { Movie } from '../../../interfaces/movie.interface';
import { Ticket } from '../../../interfaces/ticket.interface';
import { TicketService } from '../../../services/ticket.service';

@Component({
  selector: 'app-movie-delete',
  templateUrl: './movie-delete.component.html',
  styleUrl: './movie-delete.component.css'
})
export class MovieDeleteComponent {
  constructor(private activatedRoute: ActivatedRoute, private movieService: MovieService, private ticketService: TicketService) { }
  movieId !: any;
  movie: Movie;
  tickets: Ticket[];
  deleteResponse = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: "",
      genreError: "",
      shopError: "",
      priceError: "",
    }
  }
  disableResponse = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: "",
      genreError: "",
      shopError: "",
      priceError: "",
    }
  }
  ngOnInit() {
    this.movieId = this.activatedRoute.snapshot.paramMap.get('id');
    this.movieService.getMovie(this.movieId).subscribe(
      (result: any) => {

        this.movie = result
      }
    )
    this.ticketService.getTicketByMovie(this.movieId).subscribe(
      (results: any) => {
        this.tickets = results
      }
    )
  }

  deleteMovie() {
    this.movieService.deleteMovie(this.movieId).subscribe({
      next: (res: any) => {
        this.deleteResponse = res
      }
    }
    )
  }
  disableMovie() {
    var inputData = {
      genreId: this.movie.genreId,
      shopId: this.movie.shopId,
      name: this.movie.name,
      description: this.movie.description,
      image: this.movie.image,
      price: this.movie.price,
      active: false
    }
    this.movieService.updateMovie(this.movieId, inputData).subscribe({
      next: (res: any) => {
        this.disableResponse = res
      }
    });
    this.tickets.forEach(element => {
      this.ticketService.deleteTicket(element.id).subscribe({
        next: (res: any) => {
        }
      })
    });
  }
}
