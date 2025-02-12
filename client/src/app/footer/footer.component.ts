import { Component } from '@angular/core';
import { TypeService } from '../services/type.service';
import { Type } from '../interfaces/type.interface';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {

  constructor(private typeService: TypeService) {

  }
  types: Type[];
  ngOnInit() {
    this.typeService.getAllTypes().subscribe(
      (result: any) => {
        this.types = result;
      }
    )
  }
}
