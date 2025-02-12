import { Component } from '@angular/core';
import { Movie } from '../../interfaces/movie.interface';
import { MovieService } from '../../services/movie.service';
import { DateService } from '../../services/date.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrl: './movie.component.css'
})
export class MovieComponent {
  response: Movie[];
  startIndex: number = 0;
  stepIndex: number = 3;
  length: number;
  pageCount: number;

  dateGenerate: number = 0;
  generateDatesResponse = {
    message: ""
  }
  constructor(private movieService: MovieService, private dateService: DateService) { }
  ngOnInit(): void {
    this.movieService.getPagingMovies(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.movieService.getLengthOfMovies().subscribe(
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

  generateDate(){
    this.dateService.createSomeDates(this.dateGenerate).subscribe(
      (result: any) => {
        this.generateDatesResponse = result;
      }
    )
  }

  prev() {
    if (this.startIndex > 0) {
      this.startIndex--;
    }
    this.movieService.getPagingMovies(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
  next() {
    if (this.startIndex < this.pageCount - 1) {
      this.startIndex++;
    }
    this.movieService.getPagingMovies(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
  output:number = 0;
  moneyConvert(price:number, ev:any){
    var t: HTMLInputElement = ev.target;
    var sl = Number(t.value);   
    this.output = price* sl;
  }
}
