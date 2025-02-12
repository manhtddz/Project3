import { Component } from '@angular/core';
import { Type } from '../../interfaces/type.interface';
import { TypeService } from '../../services/type.service';

@Component({
  selector: 'type',
  templateUrl: './type.component.html',
  styleUrl: './type.component.css'
})
export class TypeComponent {
  response: Type[];
  startIndex: number = 0;
  stepIndex: number = 3;
  length: number;
  pageCount: number;
  constructor(private typeService: TypeService) { }
  ngOnInit(): void {
    this.typeService.getPagingTypes(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.typeService.getLengthOfTypes().subscribe(
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
    this.typeService.getPagingTypes(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
  next() {
    if (this.startIndex < this.pageCount - 1) {
      this.startIndex++;
    }
    this.typeService.getPagingTypes(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
}
