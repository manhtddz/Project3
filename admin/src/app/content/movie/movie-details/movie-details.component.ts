import { Component } from '@angular/core';
import { Movie } from '../../../interfaces/movie.interface';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { MovieService } from '../../../services/movie.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrl: './movie-details.component.css'
})
export class MovieDetailsComponent {
  response: Movie;
  constructor(private activatedRoute: ActivatedRoute, private movieService: MovieService) { }
  output:number = 0;
  moneyConvert(price:number, ev:any){
    var t: HTMLInputElement = ev.target;
    var sl = Number(t.value);   
    this.output = price* sl;
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
  }
}
