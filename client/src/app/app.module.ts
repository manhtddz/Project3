import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavHeaderComponent } from './nav-header/nav-header.component';
import { FooterComponent } from './footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { MovieTheaterComponent } from './movie-theater/movie-theater.component';
import { MovieDetailComponent } from './movie-detail/movie-detail.component';
import { ProductsGalleryComponent } from './products-gallery/products-gallery.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavHeaderComponent,
    FooterComponent,
    ProductDetailsComponent,
    MovieTheaterComponent,
    MovieDetailComponent,
    ProductsGalleryComponent,
    ContactUsComponent,
    AboutUsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
