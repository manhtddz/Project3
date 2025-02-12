import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TypeService } from '../../../services/type.service';

@Component({
  selector: 'app-type-delete',
  templateUrl: './type-delete.component.html',
  styleUrl: './type-delete.component.css'
})
export class TypeDeleteComponent {
  constructor(private activatedRoute: ActivatedRoute, private typeService: TypeService) { }
  typeId !: any;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: ""
    }
  }
  ngOnInit() {
    this.typeId = this.activatedRoute.snapshot.paramMap.get('id')
  }

  deleteType() {
    this.typeService.deleteType(this.typeId).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }

    )
  }
}
