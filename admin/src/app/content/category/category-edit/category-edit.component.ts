import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from '../../../services/category.service';
import { Category } from '../../../interfaces/category.interface';
import { TypeService } from '../../../services/type.service';
import { Type } from '../../../interfaces/type.interface';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrl: './category-edit.component.css'
})
export class CategoryEditComponent {
  category: Category;
  types: Type[];
  categoryId !: any;
  typeId: number;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: "",
      typeError: ""
    }
  }
  constructor(private activatedRoute: ActivatedRoute, private categoryService: CategoryService, private typeService: TypeService) {

  }
  editCategory() {
    var inputData = {
      typeId: this.typeId,
      name: this.category.name,
      image: this.category.image,
    }
    this.categoryService.updateCategory(this.categoryId, inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
    
  }

  ngOnInit() {

    this.categoryId = this.activatedRoute.snapshot.paramMap.get('id')
    this.categoryService.getCategory(this.categoryId).subscribe(
      (result: any) => {
        this.category = result
        this.typeId = this.category.typeId
      }
    )
    this.typeService.getAllTypes().subscribe(
      (result: any)=>{
        this.types = result
      }
    )
    
  }
}
