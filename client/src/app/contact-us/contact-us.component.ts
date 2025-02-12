import { Component } from '@angular/core';
import { FeedbackService } from '../services/feedback.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.css'
})
export class ContactUsComponent {
  constructor(private feedbackService: FeedbackService) { }

  email: string = "";
  feedback: string = "";

  response = {
    isModified: false,
    errors: {
      userEmailError: "",
      emptyFeedbackError: ""
    }
  }
  sentFeedback() {
    var inputData = {
      userEmail: this.email,
      content: this.feedback
    }
    this.feedbackService.createFeedback(inputData).subscribe(
      (result: any) => {
        this.response = result
      }
    )
  }
}
