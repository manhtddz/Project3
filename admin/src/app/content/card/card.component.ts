import { Component } from '@angular/core';
import { MovieService } from '../../services/movie.service';
import { TicketService } from '../../services/ticket.service';
import { ProductService } from '../../services/product.service';
import { FeedbackService } from '../../services/feedback.service';

@Component({
  selector: 'card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  constructor(private movieService: MovieService, private ticketService: TicketService,
    private productService: ProductService, private feedbackService: FeedbackService) { }

  movieQty: number;
  totalIncome: number;
  productQty: number;
  feedbackQty: number;
  ngOnInit() {
    this.movieService.getLengthOfMovies().subscribe(
      (result: any) => {
        this.movieQty = result
      }
    )
    this.ticketService.getTotalIncome().subscribe(
      (result: any) => {
        this.totalIncome = result
      }
    )
    this.productService.getLengthOfProducts().subscribe(
      (result: any) => {
        this.productQty = result
      }
    )
    this.feedbackService.getFeedbackQty().subscribe(
      (result: any) => {
        this.feedbackQty = result
      }
    )
  }
}
