import { Component, EventEmitter, Output, } from '@angular/core';
import { TypeService } from '../services/type.service';
import { Type } from '../interfaces/type.interface';

@Component({
  selector: 'app-nav-header',
  templateUrl: './nav-header.component.html',
  styleUrl: './nav-header.component.css'
})
export class NavHeaderComponent {
  constructor(private typeService: TypeService) { }
  types: Type[];
  typeId:number;
  @Output()
  typeIdChanged:EventEmitter<number> = new EventEmitter<number>();
  ngOnInit(): void {
    this.typeService.getAllTypes().subscribe(
      (results: any) => {
        this.types = results
      }
    );
  }
  setType(id:number){
    this.typeId = id;
    this.typeIdChanged.emit(this.typeId)
  }
}
