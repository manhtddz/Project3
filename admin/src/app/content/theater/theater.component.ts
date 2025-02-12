import { Component } from '@angular/core';
import { TheaterService } from '../../services/theater.service';
import { Theater } from '../../interfaces/theater.interface';

@Component({
  selector: 'app-theater',
  templateUrl: './theater.component.html',
  styleUrl: './theater.component.css'
})
export class TheaterComponent {
  response: Theater[];
  startIndex: number = 0;
  stepIndex: number = 3;
  length: number;
  pageCount: number;
  constructor(private theaterService: TheaterService) { }
  ngOnInit(): void {
    this.theaterService.getPagingTheaters(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.theaterService.getLengthOfTheaters().subscribe(
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
    this.theaterService.getPagingTheaters(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
  next() {
    if (this.startIndex < this.pageCount - 1) {
      this.startIndex++;
    }
    this.theaterService.getPagingTheaters(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
}
