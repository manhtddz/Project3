import { Component } from '@angular/core';
import { Product } from '../../interfaces/product.interface';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  response: Product[];
  startIndex: number = 0;
  stepIndex: number = 3;
  length: number;
  pageCount: number;
  constructor(private productService: ProductService) { }
  ngOnInit(): void {
    this.productService.getPagingProducts(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.productService.getLengthOfProducts().subscribe(
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

  prev() {
    if (this.startIndex > 0) {
      this.startIndex--;
    }
    this.productService.getPagingProducts(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
  next() {
    if (this.startIndex < this.pageCount - 1) {
      this.startIndex++;
    }
    this.productService.getPagingProducts(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
  output:number = 0;
  moneyConvert(price:number, ev:any){
    var t: HTMLInputElement = ev.target;
    var sl = Number(t.value);   
    this.output = price* sl;
  }
}
