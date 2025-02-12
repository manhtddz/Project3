import { Component } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../interfaces/product.interface';
import { ActivatedRoute } from '@angular/router';
import { Type } from '../interfaces/type.interface';
import { TypeService } from '../services/type.service';

@Component({
  selector: 'app-products-gallery',
  templateUrl: './products-gallery.component.html',
  styleUrl: './products-gallery.component.css'
})
export class ProductsGalleryComponent {
  typeId!: any;
  response: Product[] = [];
  type: Type;

  startIndex: number = 0;
  stepIndex: number = 8;

  length: number;
  pageCount: number;

  searchText: string = "";
  isSearch: boolean = false;
  constructor(private activatedRoute: ActivatedRoute,private productService: ProductService,private typeService: TypeService) { 
   
  }
  ngOnInit(): void {
    this.typeId = this.activatedRoute.snapshot.paramMap.get('typeId')
    this.productService.getPagingProductsByType(this.typeId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.productService.getLengthOfProductsByType(this.typeId).subscribe(
      (results: any) => {
        this.length = results
        if ((this.length % this.stepIndex) == 0) {
          this.pageCount = (this.length / this.stepIndex)
        } else {
          this.pageCount = Math.ceil((this.length / this.stepIndex))
        }
      }
    )
    this.typeService.getType(this.typeId).subscribe(
      (result: any) =>{
        this.type = result;
      }
    )
  }

  typeIdChangeHandler(type:number){
    this.typeId = type
    this.startIndex = 0
    this.productService.getPagingProductsByType(type, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.productService.getLengthOfProductsByType(type).subscribe(
      (results: any) => {
        this.length = results
        if ((this.length % this.stepIndex) == 0) {
          this.pageCount = (this.length / this.stepIndex)
        } else {
          this.pageCount = Math.ceil((this.length / this.stepIndex))
        }
      }
    )
    this.typeService.getType(type).subscribe(
      (result: any) =>{
        this.type = result;
      }
    )
  }

  prev() {
    if (this.startIndex > 0) {
      this.startIndex--;
    }
    if (this.isSearch) {
      this.productService.getPagingSearchProductsByType(this.typeId, this.startIndex * this.stepIndex, this.stepIndex, this.searchText).subscribe(
        (results: any) => {
          this.response = results
        }
      );
    } else {
      this.productService.getPagingProductsByType(this.typeId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
        (results: any) => {
          this.response = results
        }
      );
    }

  }
  next() {
    if (this.startIndex < this.pageCount - 1) {
      this.startIndex++;
    }
    if (this.isSearch) {
      this.productService.getPagingSearchProductsByType(this.typeId, this.startIndex * this.stepIndex, this.stepIndex, this.searchText).subscribe(
        (results: any) => {
          this.response = results
        }
      );
    } else {
      this.productService.getPagingProductsByType(this.typeId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
        (results: any) => {
          this.response = results
        }
      );
    }
  }

  search() {
    this.isSearch = true;
    this.productService.getPagingSearchProductsByType(this.typeId, this.startIndex * this.stepIndex, this.stepIndex, this.searchText).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.productService.getLengthOfSearchProductsByType(this.typeId, this.searchText).subscribe(
      (results: any) => {
        this.length = results
        if ((this.length % this.stepIndex) == 0) {
          this.pageCount = (this.length / this.stepIndex)
        } else {
          this.pageCount = Math.ceil((this.length / this.stepIndex))
        }
      }
    )
  }

  undoSearch() {
    this.isSearch = false;
    this.productService.getPagingProductsByType(this.typeId, this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.productService.getLengthOfProductsByType(this.typeId).subscribe(
      (results: any) => {
        this.length = results
        if ((this.length % this.stepIndex) == 0) {
          this.pageCount = (this.length / this.stepIndex)
        } else {
          this.pageCount = Math.ceil((this.length / this.stepIndex))
        }
      }
    );
    this.searchText = "";
  }

  output:number = 0;
  moneyConvert(price:number, ev:any){
    var t: HTMLInputElement = ev.target;
    var sl = Number(t.value);   
    this.output = price* sl;
  }
}
