import { Component } from '@angular/core';
import { CategoryService } from '../../../services/category.service';
import { Type } from '../../../interfaces/type.interface';
import { TypeService } from '../../../services/type.service';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrl: './category-create.component.css'
})
export class CategoryCreateComponent {
  constructor(private categoryService: CategoryService, private typeService: TypeService) {

  }
  types: Type[];

  ngOnInit(): void {
    this.typeService.getAllTypes().subscribe(
      (result: any) => {
        this.types = result
      }
    )
  }
  name: string = "";
  image: string = "";
  typeId: number = 0;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: "",
      typeError: ""
    }
  }
  create() {
    var inputData = {
      typeId: this.typeId,
      name: this.name,
      image: this.image
    }
    this.categoryService.createCategory(inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }
}
