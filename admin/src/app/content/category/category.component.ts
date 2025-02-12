import { Component } from '@angular/core';
import { Category } from '../../interfaces/category.interface';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {
  response: Category [];
  startIndex: number = 0;
  stepIndex: number = 3;
  length: number;
  pageCount: number;
  constructor(private categoryService: CategoryService) { }
  ngOnInit(): void {
    this.categoryService.getPagingCategories(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.categoryService.getLengthOfCategories().subscribe(
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

  prev(){
    if(this.startIndex > 0){
      this.startIndex--;
    }
    this.categoryService.getPagingCategories(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
  next(){
      if(this.startIndex < this.pageCount - 1){
        this.startIndex++;
      }
      this.categoryService.getPagingCategories(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
        (results: any) => {
            this.response = results
        }
      );
  }
}
