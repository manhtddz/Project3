import { Component } from '@angular/core';
import { GenreService } from '../../../services/genre.service';

@Component({
  selector: 'app-genre-create',
  templateUrl: './genre-create.component.html',
  styleUrl: './genre-create.component.css'
})
export class GenreCreateComponent {
  constructor(private genreService: GenreService) {
    
  }
  ngOnInit(): void {
    
  }

  name: string = "";

  response ={
    isModified: false,
    error: {
      existedError: "",
      nameError: ""
    }
  };
  create() {
    var inputData = {
      name: this.name
    }
    this.genreService.createGenre(inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    })
  }
}
