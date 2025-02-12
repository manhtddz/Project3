import { Component } from '@angular/core';
import { TheaterService } from '../../../services/theater.service';

@Component({
  selector: 'app-theater-create',
  templateUrl: './theater-create.component.html',
  styleUrl: './theater-create.component.css'
})
export class TheaterCreateComponent {
  constructor(private theaterService: TheaterService) {
    
  }
  ngOnInit(): void {
    
  }
  name: string = "";
  response ={
    isModified: false,
    error: {
      existedError: "",
      nameError: ""
    }
  };
  create() {
    var inputData = {
      name: this.name
    }
    this.theaterService.createTheater(inputData).subscribe({
      next: (res: any) => {
        this.response = res        
      }
    })
  }
}
