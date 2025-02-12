import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Shop } from '../../../interfaces/shop.interface';
import { ShopService } from '../../../services/shop.service';

@Component({
  selector: 'app-shop-details',
  templateUrl: './shop-details.component.html',
  styleUrl: './shop-details.component.css'
})
export class ShopDetailsComponent {
  response: Shop;
  constructor(private activatedRoute: ActivatedRoute, private shopService: ShopService) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.shopService.getShop(+params.get('id')!).subscribe(
        (result: any) => {
          this.response = result
        }
      )
    }
    )
  }
}
