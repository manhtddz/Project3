import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { MovieTheaterComponent } from './movie-theater/movie-theater.component';
import { MovieDetailComponent } from './movie-detail/movie-detail.component';
import { ProductsGalleryComponent } from './products-gallery/products-gallery.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'movieTheater', component: MovieTheaterComponent },
  { path: 'product/:id/details', component: ProductDetailsComponent },
  { path: 'movie/:id/details', component: MovieDetailComponent },
  { path: 'product/:typeId/gallery', component: ProductsGalleryComponent },
  { path: 'contact', component: ContactUsComponent },
  { path: 'aboutUs', component: AboutUsComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
