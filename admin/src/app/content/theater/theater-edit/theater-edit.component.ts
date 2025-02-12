import { Component } from '@angular/core';
import { Theater } from '../../../interfaces/theater.interface';
import { ActivatedRoute } from '@angular/router';
import { TheaterService } from '../../../services/theater.service';

@Component({
  selector: 'app-theater-edit',
  templateUrl: './theater-edit.component.html',
  styleUrl: './theater-edit.component.css'
})
export class TheaterEditComponent {
  theater: Theater;
  theaterId !: any;
  response = {
    isModified: false,
    error: {
      existedError: "",
      nameError: ""
    }
  }
  constructor(private activatedRoute: ActivatedRoute, private theaterService: TheaterService) {

  }
  editTheater() {
    var inputData = {
      name: this.theater.name
    }
    this.theaterService.updateTheater(this.theaterId, inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }

  ngOnInit() {

    this.theaterId = this.activatedRoute.snapshot.paramMap.get('id')
    this.theaterService.getTheater(this.theaterId).subscribe(
      (result: any) => {
        this.theater = result
      }
    )
  }
}
