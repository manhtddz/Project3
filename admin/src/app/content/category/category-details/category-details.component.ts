import { Component } from '@angular/core';
import { Category } from '../../../interfaces/category.interface';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { CategoryService } from '../../../services/category.service';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrl: './category-details.component.css'
})
export class CategoryDetailsComponent {
  response: Category;
  constructor(private activatedRoute: ActivatedRoute, private categoryService: CategoryService) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.categoryService.getCategory(+params.get('id')!).subscribe(
        (result: any) => {
          this.response = result
        }
      )
    }
    )
  }
}
