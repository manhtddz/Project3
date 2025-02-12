import { Component } from '@angular/core';
import { ShopService } from '../../../services/shop.service';
import { MovieService } from '../../../services/movie.service';
import { GenreService } from '../../../services/genre.service';
import { Shop } from '../../../interfaces/shop.interface';
import { Genre } from '../../../interfaces/genre.interface';

@Component({
  selector: 'app-movie-create',
  templateUrl: './movie-create.component.html',
  styleUrl: './movie-create.component.css'
})
export class MovieCreateComponent {
  constructor(private genreService: GenreService, private shopService: ShopService, private movieService: MovieService) {

  }
  shops: Shop[];
  genres: Genre[];

  ngOnInit(): void {
    this.shopService.getAllShops().subscribe(
      (result: any) => {
        this.shops = result
      }
    )
    this.genreService.getAllGenres().subscribe(
      (result: any) => {
        this.genres = result
      }
    )
  }
  name: string = "";
  image: string = "";
  description: string = "";
  price: number = 0;
  shopId: number;
  genreId: number;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: "",
      genreError:"",
      shopError:"",
      priceError:""
    }
  }
  create() {
    var inputData = {
      genreId: this.genreId,
      shopId: this.shopId,
      name: this.name,
      description: this.description,
      image: this.image,
      price: this.price,
      active: false
    }
    this.movieService.createMovie(inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }
}
