import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from '../../../services/category.service';

@Component({
  selector: 'app-category-delete',
  templateUrl: './category-delete.component.html',
  styleUrl: './category-delete.component.css'
})
export class CategoryDeleteComponent {
  constructor(private activatedRoute: ActivatedRoute, private categoryService: CategoryService) { }
  categoryId !: any;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: "",
      typeError: ""
    }
  }
  ngOnInit() {
    this.categoryId = this.activatedRoute.snapshot.paramMap.get('id')
  }

  deleteCategory() {
    this.categoryService.deleteCategory(this.categoryId).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }

    )
  }
}
