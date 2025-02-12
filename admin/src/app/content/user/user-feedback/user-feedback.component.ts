import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Feedback } from '../../../interfaces/feedback.interface';
import { FeedbackService } from '../../../services/feedback.service';

@Component({
  selector: 'app-user-feedback',
  templateUrl: './user-feedback.component.html',
  styleUrl: './user-feedback.component.css'
})
export class UserFeedbackComponent {

  feedbacks: Feedback[];
  userId !: any;
  startIndex: number = 0;
  stepIndex: number = 3;
  length: number;
  pageCount: number;
  constructor(private activatedRoute: ActivatedRoute, private feedbackService: FeedbackService) {

  }
  ngOnInit() {

    this.userId = this.activatedRoute.snapshot.paramMap.get('id');
    this.feedbackService.getPagingFeedbacksByUser(this.userId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (result: any) => {
        this.feedbacks = result
      }
    );
    this.feedbackService.getLengthOfFeedbackByUser(this.userId).subscribe(
      (results: any) => {
        this.length = results
        if ((this.length % this.stepIndex) == 0) {
          this.pageCount = (this.length / this.stepIndex)
        } else {
          this.pageCount = Math.ceil((this.length / this.stepIndex))
        }
      }
    );
  }
  prev() {
    if (this.startIndex > 0) {
      this.startIndex--;
    }
    this.feedbackService.getPagingFeedbacksByUser(this.userId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.feedbacks = results
      }
    );
  }
  next() {
    if (this.startIndex < this.pageCount - 1) {
      this.startIndex++;
    }
    this.feedbackService.getPagingFeedbacksByUser(this.userId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.feedbacks = results
      }
    );
  }
}
