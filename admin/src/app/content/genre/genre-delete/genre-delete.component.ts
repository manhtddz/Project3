import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GenreService } from '../../../services/genre.service';

@Component({
  selector: 'app-genre-delete',
  templateUrl: './genre-delete.component.html',
  styleUrl: './genre-delete.component.css'
})
export class GenreDeleteComponent {
  constructor(private activatedRoute: ActivatedRoute, private genreService: GenreService) { }
  genreId !: any;
  response = {
    isModified: false,
    error: {
      existedError: "",
      nameError: ""
    }
  }
  ngOnInit() {
    this.genreId = this.activatedRoute.snapshot.paramMap.get('id')
  }

  deleteGenre() {
    this.genreService.deleteGenre(this.genreId).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }
}
