import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { TypeComponent } from './content/type/type.component';
import { TypeDetailComponent } from './content/type/type-detail/type-detail.component';
import { TypeCreateComponent } from './content/type/type-create/type-create.component';
import { TypeEditComponent } from './content/type/type-edit/type-edit.component';
import { TypeDeleteComponent } from './content/type/type-delete/type-delete.component';
import { CategoryComponent } from './content/category/category.component';
import { CategoryCreateComponent } from './content/category/category-create/category-create.component';
import { CategoryEditComponent } from './content/category/category-edit/category-edit.component';
import { CategoryDeleteComponent } from './content/category/category-delete/category-delete.component';
import { CategoryDetailsComponent } from './content/category/category-details/category-details.component';
import { ShopComponent } from './content/shop/shop.component';
import { ShopCreateComponent } from './content/shop/shop-create/shop-create.component';
import { ShopEditComponent } from './content/shop/shop-edit/shop-edit.component';
import { ShopDetailsComponent } from './content/shop/shop-details/shop-details.component';
import { ShopDeleteComponent } from './content/shop/shop-delete/shop-delete.component';
import { ProductComponent } from './content/product/product.component';
import { ProductDetailsComponent } from './content/product/product-details/product-details.component';
import { ProductEditComponent } from './content/product/product-edit/product-edit.component';
import { ProductCreateComponent } from './content/product/product-create/product-create.component';
import { ProductDeleteComponent } from './content/product/product-delete/product-delete.component';
import { GenreComponent } from './content/genre/genre.component';
import { GenreDetailsComponent } from './content/genre/genre-details/genre-details.component';
import { GenreCreateComponent } from './content/genre/genre-create/genre-create.component';
import { GenreEditComponent } from './content/genre/genre-edit/genre-edit.component';
import { GenreDeleteComponent } from './content/genre/genre-delete/genre-delete.component';
import { TheaterComponent } from './content/theater/theater.component';
import { TheaterDetailsComponent } from './content/theater/theater-details/theater-details.component';
import { TheaterCreateComponent } from './content/theater/theater-create/theater-create.component';
import { TheaterEditComponent } from './content/theater/theater-edit/theater-edit.component';
import { TheaterDeleteComponent } from './content/theater/theater-delete/theater-delete.component';
import { MovieComponent } from './content/movie/movie.component';
import { MovieDetailsComponent } from './content/movie/movie-details/movie-details.component';
import { MovieEditComponent } from './content/movie/movie-edit/movie-edit.component';
import { MovieCreateComponent } from './content/movie/movie-create/movie-create.component';
import { MovieDeleteComponent } from './content/movie/movie-delete/movie-delete.component';
import { MovieAssignComponent } from './content/movie/movie-assign/movie-assign.component';
import { MovieTicketComponent } from './content/movie/movie-ticket/movie-ticket.component';
import { UserComponent } from './content/user/user.component';
import { UserFeedbackComponent } from './content/user/user-feedback/user-feedback.component';
import { CardComponent } from './content/card/card.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    SideBarComponent,
    TypeComponent,
    TypeDetailComponent,
    TypeCreateComponent,
    TypeEditComponent,
    TypeDeleteComponent,
    CategoryComponent,
    CategoryCreateComponent,
    CategoryEditComponent,
    CategoryDeleteComponent,
    CategoryDetailsComponent,
    ShopComponent,
    ShopCreateComponent,
    ShopEditComponent,
    ShopDetailsComponent,
    ShopDeleteComponent,
    ProductComponent,
    ProductDetailsComponent,
    ProductEditComponent,
    ProductCreateComponent,
    ProductDeleteComponent,
    GenreComponent,
    GenreDetailsComponent,
    GenreCreateComponent,
    GenreEditComponent,
    GenreDeleteComponent,
    TheaterComponent,
    TheaterDetailsComponent,
    TheaterCreateComponent,
    TheaterEditComponent,
    TheaterDeleteComponent,
    MovieComponent,
    MovieDetailsComponent,
    MovieEditComponent,
    MovieCreateComponent,
    MovieDeleteComponent,
    MovieAssignComponent,
    MovieTicketComponent,
    UserComponent,
    UserFeedbackComponent,
    CardComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
