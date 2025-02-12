import { Component } from '@angular/core';
import { Genre } from '../../../interfaces/genre.interface';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { GenreService } from '../../../services/genre.service';

@Component({
  selector: 'app-genre-details',
  templateUrl: './genre-details.component.html',
  styleUrl: './genre-details.component.css'
})
export class GenreDetailsComponent {
  response: Genre;
  constructor(private activatedRoute: ActivatedRoute, private genreService: GenreService) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.genreService.getGenre(+params.get('id')!).subscribe(
        (result: any) => {
          this.response = result
        }
      )
    }
    )
  }
}
