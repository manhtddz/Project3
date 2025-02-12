import { Component } from '@angular/core';
import { GenreService } from '../../services/genre.service';
import { Genre } from '../../interfaces/genre.interface';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrl: './genre.component.css'
})
export class GenreComponent {
  response: Genre[];
  startIndex: number = 0;
  stepIndex: number = 3;
  length: number;
  pageCount: number;
  constructor(private genreService: GenreService) { }
  ngOnInit(): void {
    this.genreService.getPagingGenres(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.genreService.getLengthOfGenres().subscribe(
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
    this.genreService.getPagingGenres(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
  next() {
    if (this.startIndex < this.pageCount - 1) {
      this.startIndex++;
    }
    this.genreService.getPagingGenres(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
}
