import { Component } from '@angular/core';
import { Shop } from '../../interfaces/shop.interface';
import { ShopService } from '../../services/shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent {
  response: Shop[];
  startIndex: number = 0;
  stepIndex: number = 3;
  length: number;
  pageCount: number;
  constructor(private shopService: ShopService) { }
  ngOnInit(): void {
    this.shopService.getPagingShops(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
    this.shopService.getLengthOfShops().subscribe(
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

  prev(){
    if(this.startIndex > 0){
      this.startIndex--;
    }
    this.shopService.getPagingShops(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
      (results: any) => {
        this.response = results
      }
    );
  }
  next(){
      if(this.startIndex < this.pageCount - 1){
        this.startIndex++;
      }
      this.shopService.getPagingShops(this.startIndex * this.stepIndex, this.stepIndex).subscribe(
        (results: any) => {
          this.response = results
        }
      );
  }
}
