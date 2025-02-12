import { Component } from '@angular/core';
import { Movie } from '../interfaces/movie.interface';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-movie-theater',
  templateUrl: './movie-theater.component.html',
  styleUrl: './movie-theater.component.css'
})
export class MovieTheaterComponent {
  response: Movie[];

  startIndex: number = 0;
  stepIndex: number = 8;

  length: number;
  pageCount: number;

  searchText: string = "";
  isSearch: boolean = false;
  constructor(private movieService: MovieService) { }
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

  prev() {
    if (this.startIndex > 0) {
      this.startIndex--;
    }
    if (this.isSearch) {
      this.movieService.getPagingSearchMovies(this.startIndex * this.stepIndex, this.stepIndex, this.searchText).subscribe(
        (results: any) => {
          this.response = results
        }
      );
    } else {
      this.movieService.getPagingMovies(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
        (results: any) => {
          this.response = results
        }
      );
    }

  }
  next() {
    if (this.startIndex < this.pageCount - 1) {
      this.startIndex++;
    }
    if (this.isSearch) {
      this.movieService.getPagingSearchMovies(this.startIndex * this.stepIndex, this.stepIndex, this.searchText).subscribe(
        (results: any) => {
          this.response = results
        }
      );
    } else {
      this.movieService.getPagingMovies(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
        (results: any) => {
          this.response = results
        }
      );
    }
  }

  search() {
    this.isSearch = true;
    this.movieService.getPagingSearchMovies(this.startIndex * this.stepIndex, this.stepIndex, this.searchText).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.movieService.getLengthOfSearchMovies(this.searchText).subscribe(
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

  undoSearch() {
    this.isSearch = false;
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
    );
    this.searchText = "";
  }
}
