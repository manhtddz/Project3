import { Component } from '@angular/core';
import { Theater } from '../../../interfaces/theater.interface';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { TheaterService } from '../../../services/theater.service';

@Component({
  selector: 'app-theater-details',
  templateUrl: './theater-details.component.html',
  styleUrl: './theater-details.component.css'
})
export class TheaterDetailsComponent {
  response: Theater;
  constructor(private activatedRoute: ActivatedRoute, private theaterService: TheaterService) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.theaterService.getTheater(+params.get('id')!).subscribe(
        (result: any) => {
          this.response = result
        }
      )
    }
    )
  }
}
