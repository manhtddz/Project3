import { Component } from '@angular/core';
import { Type } from '../../../interfaces/type.interface';
import { ActivatedRoute } from '@angular/router';
import { TypeService } from '../../../services/type.service';

@Component({
  selector: 'app-type-edit',
  templateUrl: './type-edit.component.html',
  styleUrl: './type-edit.component.css'
})
export class TypeEditComponent {
  type: Type;
  typeId !: any;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: ""
    }
  }
  constructor(private activatedRoute: ActivatedRoute, private typeService: TypeService) {

  }
  editType() {
    var inputData = {
      name: this.type.name,
      image: this.type.image,
    }
    this.typeService.updateType(this.typeId, inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }

  ngOnInit() {

    this.typeId = this.activatedRoute.snapshot.paramMap.get('id')
    this.typeService.getType(this.typeId).subscribe(
      (result: any) => {
        this.type = result
      }
    )
  }
}
