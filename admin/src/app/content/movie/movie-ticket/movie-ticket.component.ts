import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { MovieService } from '../../../services/movie.service';
import { Movie } from '../../../interfaces/movie.interface';
import { TicketService } from '../../../services/ticket.service';
import { Ticket } from '../../../interfaces/ticket.interface';

@Component({
  selector: 'app-movie-ticket',
  templateUrl: './movie-ticket.component.html',
  styleUrl: './movie-ticket.component.css'
})
export class MovieTicketComponent {
  movieId !: any;
  movie: Movie;
  tickets: Ticket[];
  startIndex: number = 0;
  stepIndex: number = 4;
  length: number;
  pageCount: number;
  constructor(private activatedRoute: ActivatedRoute, private movieService: MovieService, private ticketService: TicketService) { }
  output:number = 0;
  moneyConvert(price:number, ev:any){
    var t: HTMLInputElement = ev.target;
    var sl = Number(t.value);   
    this.output = price* sl;
  }
  ngOnInit() {
    this.movieId = this.activatedRoute.snapshot.paramMap.get('id')
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.movieService.getMovie(+params.get('id')!).subscribe(
        (result: any) => {
          this.movie = result
        }
      )
    }
    )
    this.ticketService.getTicketPagingByMovie(this.movieId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.tickets = results
      }
    );
    this.ticketService.getLengthOfTicketsByMovie(this.movieId).subscribe(
      (results: any) => {
        this.length = results
        if ((this.length % this.stepIndex) == 0) {
          this.pageCount = (this.length / this.stepIndex)
        } else {
          this.pageCount = Math.ceil((this.length / this.stepIndex))
        }
      }
    )
  }
  prev() {
    if (this.startIndex > 0) {
      this.startIndex--;
    }
    this.ticketService.getTicketPagingByMovie(this.movieId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.tickets = results
      }
    );
  }
  next() {
    if (this.startIndex < this.pageCount - 1) {
      this.startIndex++;
    }
    this.ticketService.getTicketPagingByMovie(this.movieId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.tickets = results
      }
    );
  }
}
