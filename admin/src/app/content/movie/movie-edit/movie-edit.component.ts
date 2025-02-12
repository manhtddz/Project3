import { Component } from '@angular/core';
import { Genre } from '../../../interfaces/genre.interface';
import { Shop } from '../../../interfaces/shop.interface';
import { Movie } from '../../../interfaces/movie.interface';
import { ActivatedRoute } from '@angular/router';
import { GenreService } from '../../../services/genre.service';
import { ShopService } from '../../../services/shop.service';
import { MovieService } from '../../../services/movie.service';

@Component({
  selector: 'app-movie-edit',
  templateUrl: './movie-edit.component.html',
  styleUrl: './movie-edit.component.css'
})
export class MovieEditComponent {
  genres: Genre[];
  shops: Shop[];
  movieId !: any;
  movie: Movie;
  genreId: number;
  shopId: number;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: "",
      genreError: "",
      shopError: "",
      priceError: ""
    }
  }
  constructor(private activatedRoute: ActivatedRoute, private genreService: GenreService, private shopService: ShopService, private movieService: MovieService) {

  }
  editMovie() {
    var inputData = {
      genreId: this.genreId,
      shopId: this.shopId,
      name: this.movie.name,
      description: this.movie.description,
      image: this.movie.image,
      price: this.movie.price,
      active: this.movie.active
    }
    this.movieService.updateMovie(this.movieId, inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )

  }

  ngOnInit() {

    this.movieId = this.activatedRoute.snapshot.paramMap.get('id')
    this.movieService.getMovie(this.movieId).subscribe(
      (result: any) => {
        this.movie = result
        this.shopId = this.movie.shopId
        this.genreId = this.movie.genreId
      }
    )
    this.genreService.getAllGenres().subscribe(
      (result: any) => {
        this.genres = result
      }
    )
    this.shopService.getAllShops().subscribe(
      (result: any) => {
        this.shops = result
      }
    )
  }
}
