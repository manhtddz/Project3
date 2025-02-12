import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { TypeService } from '../../../services/type.service';

@Component({
  selector: 'app-type-create',
  templateUrl: './type-create.component.html',
  styleUrl: './type-create.component.css'
})
export class TypeCreateComponent implements OnInit {
  constructor(private typeService: TypeService) {
    
  }
  ngOnInit(): void {
    
  }

  name: string = "";
  image: string = "";

  response ={
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: ""
    }
  };
  redirect: string;
  create() {
    var inputData = {
      name: this.name,
      image: this.image
    }
    this.typeService.createType(inputData).subscribe({
      next: (res: any) => {
        this.response = res        
      }
    })
  }
}
