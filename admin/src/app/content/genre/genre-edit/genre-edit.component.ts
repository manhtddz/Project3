import { Component } from '@angular/core';
import { Genre } from '../../../interfaces/genre.interface';
import { ActivatedRoute } from '@angular/router';
import { GenreService } from '../../../services/genre.service';

@Component({
  selector: 'app-genre-edit',
  templateUrl: './genre-edit.component.html',
  styleUrl: './genre-edit.component.css'
})
export class GenreEditComponent {
  genre: Genre;
  genreId !: any;
  response = {
    isModified: false,
    error: {
      existedError: "",
      nameError: ""
    }
  }
  constructor(private activatedRoute: ActivatedRoute, private genreService: GenreService) {

  }
  editGenre() {
    var inputData = {
      name: this.genre.name
    }
    this.genreService.updateGenre(this.genreId, inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }

  ngOnInit() {

    this.genreId = this.activatedRoute.snapshot.paramMap.get('id')
    this.genreService.getGenre(this.genreId).subscribe(
      (result: any) => {
        this.genre = result
      }
    )
  }
}
