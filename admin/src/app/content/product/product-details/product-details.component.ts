import { Component } from '@angular/core';
import { Product } from '../../../interfaces/product.interface';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ProductService } from '../../../services/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {
  response: Product;
  constructor(private activatedRoute: ActivatedRoute, private productService: ProductService) { }
  output:number = 0;
  moneyConvert(price:number, ev:any){
    var t: HTMLInputElement = ev.target;
    var sl = Number(t.value);   
    this.output = price* sl;
  }
  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.productService.getProduct(+params.get('id')!).subscribe(
        (result: any) => {
          this.response = result
        }
      )
    }
    )
  }
}
