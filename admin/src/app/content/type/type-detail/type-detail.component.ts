import { Component } from '@angular/core';
import { Type } from '../../../interfaces/type.interface';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { TypeService } from '../../../services/type.service';

@Component({
  selector: 'app-type-detail',
  templateUrl: './type-detail.component.html',
  styleUrl: './type-detail.component.css'
})
export class TypeDetailComponent {
  response: Type;
  constructor(private activatedRoute: ActivatedRoute, private typeService: TypeService) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.typeService.getType(+params.get('id')!).subscribe(
        (result: any) => {
          this.response = result
        }
      )
    }
    )
  }
}
