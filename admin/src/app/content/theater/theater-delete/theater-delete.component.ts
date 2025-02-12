import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TheaterService } from '../../../services/theater.service';

@Component({
  selector: 'app-theater-delete',
  templateUrl: './theater-delete.component.html',
  styleUrl: './theater-delete.component.css'
})
export class TheaterDeleteComponent {
  constructor(private activatedRoute: ActivatedRoute, private theaterService: TheaterService) { }
  theaterId !: any;
  response = {
    isModified: false,
    error: {
      existedError: "",
      nameError: ""
    }
  }
  ngOnInit() {
    this.theaterId = this.activatedRoute.snapshot.paramMap.get('id')
  }

  deleteTheater() {
    this.theaterService.deleteTheater(this.theaterId).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }
}
