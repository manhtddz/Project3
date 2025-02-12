import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TypeComponent } from './content/type/type.component';
import { TypeDetailComponent } from './content/type/type-detail/type-detail.component';
import { TypeEditComponent } from './content/type/type-edit/type-edit.component';
import { TypeDeleteComponent } from './content/type/type-delete/type-delete.component';
import { TypeCreateComponent } from './content/type/type-create/type-create.component';
import { CategoryComponent } from './content/category/category.component';
import { CategoryDetailsComponent } from './content/category/category-details/category-details.component';
import { CategoryEditComponent } from './content/category/category-edit/category-edit.component';
import { CategoryDeleteComponent } from './content/category/category-delete/category-delete.component';
import { CategoryCreateComponent } from './content/category/category-create/category-create.component';
import { ShopComponent } from './content/shop/shop.component';
import { ShopDetailsComponent } from './content/shop/shop-details/shop-details.component';
import { ShopEditComponent } from './content/shop/shop-edit/shop-edit.component';
import { ShopDeleteComponent } from './content/shop/shop-delete/shop-delete.component';
import { ShopCreateComponent } from './content/shop/shop-create/shop-create.component';
import { ProductComponent } from './content/product/product.component';
import { ProductDetailsComponent } from './content/product/product-details/product-details.component';
import { ProductEditComponent } from './content/product/product-edit/product-edit.component';
import { ProductDeleteComponent } from './content/product/product-delete/product-delete.component';
import { ProductCreateComponent } from './content/product/product-create/product-create.component';
import { GenreComponent } from './content/genre/genre.component';
import { GenreDetailsComponent } from './content/genre/genre-details/genre-details.component';
import { GenreEditComponent } from './content/genre/genre-edit/genre-edit.component';
import { GenreDeleteComponent } from './content/genre/genre-delete/genre-delete.component';
import { GenreCreateComponent } from './content/genre/genre-create/genre-create.component';
import { TheaterComponent } from './content/theater/theater.component';
import { TheaterDetailsComponent } from './content/theater/theater-details/theater-details.component';
import { TheaterEditComponent } from './content/theater/theater-edit/theater-edit.component';
import { TheaterDeleteComponent } from './content/theater/theater-delete/theater-delete.component';
import { TheaterCreateComponent } from './content/theater/theater-create/theater-create.component';
import { MovieComponent } from './content/movie/movie.component';
import { MovieDetailsComponent } from './content/movie/movie-details/movie-details.component';
import { MovieEditComponent } from './content/movie/movie-edit/movie-edit.component';
import { MovieDeleteComponent } from './content/movie/movie-delete/movie-delete.component';
import { MovieCreateComponent } from './content/movie/movie-create/movie-create.component';
import { MovieAssignComponent } from './content/movie/movie-assign/movie-assign.component';
import { MovieTicketComponent } from './content/movie/movie-ticket/movie-ticket.component';
import { UserComponent } from './content/user/user.component';
import { UserFeedbackComponent } from './content/user/user-feedback/user-feedback.component';

const routes: Routes = [
  { path: 'dashboard', component: TypeComponent },
  { path: 'type/:id/details', component: TypeDetailComponent },
  { path: 'type/:id/edit', component: TypeEditComponent },
  { path: 'type/:id/delete', component: TypeDeleteComponent },
  { path: 'type/create', component: TypeCreateComponent },
  { path: 'redirectDashboard', redirectTo: 'dashboard' },

  { path: 'category', component: CategoryComponent },
  { path: 'category/:id/details', component: CategoryDetailsComponent },
  { path: 'category/:id/edit', component: CategoryEditComponent },
  { path: 'category/:id/delete', component: CategoryDeleteComponent },
  { path: 'category/create', component: CategoryCreateComponent },
  { path: 'redirectCategory', redirectTo: 'category' },


  { path: 'shop', component: ShopComponent },
  { path: 'shop/:id/details', component: ShopDetailsComponent },
  { path: 'shop/:id/edit', component: ShopEditComponent },
  { path: 'shop/:id/delete', component: ShopDeleteComponent },
  { path: 'shop/create', component: ShopCreateComponent },
  { path: 'redirectShop', redirectTo: 'shop' },

  { path: 'product', component: ProductComponent },
  { path: 'product/:id/details', component: ProductDetailsComponent },
  { path: 'product/:id/edit', component: ProductEditComponent },
  { path: 'product/:id/delete', component: ProductDeleteComponent },
  { path: 'product/create', component: ProductCreateComponent },
  { path: 'redirectProduct', redirectTo: 'product' },

  { path: 'genre', component: GenreComponent },
  { path: 'genre/:id/details', component: GenreDetailsComponent },
  { path: 'genre/:id/edit', component: GenreEditComponent },
  { path: 'genre/:id/delete', component: GenreDeleteComponent },
  { path: 'genre/create', component: GenreCreateComponent },
  { path: 'redirectGenre', redirectTo: 'genre' },

  { path: 'theater', component: TheaterComponent },
  { path: 'theater/:id/details', component: TheaterDetailsComponent },
  { path: 'theater/:id/edit', component: TheaterEditComponent },
  { path: 'theater/:id/delete', component: TheaterDeleteComponent },
  { path: 'theater/create', component: TheaterCreateComponent },
  { path: 'redirectTheater', redirectTo: 'theater' },

  { path: 'movie', component: MovieComponent },
  { path: 'movie/:id/details', component: MovieDetailsComponent },
  { path: 'movie/:id/edit', component: MovieEditComponent },
  { path: 'movie/:id/delete', component: MovieDeleteComponent },
  { path: 'movie/create', component: MovieCreateComponent },
  { path: 'movie/:id/assign', component: MovieAssignComponent },
  { path: 'movie/:id/ticket', component: MovieTicketComponent },
  { path: 'redirectMovie', redirectTo: 'movie' },

  { path: 'user', component: UserComponent },
  { path: 'user/:id/feedback', component: UserFeedbackComponent },
  { path: 'redirectUser', redirectTo: 'user' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
