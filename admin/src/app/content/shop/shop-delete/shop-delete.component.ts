import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../../../services/shop.service';

@Component({
  selector: 'app-shop-delete',
  templateUrl: './shop-delete.component.html',
  styleUrl: './shop-delete.component.css'
})
export class ShopDeleteComponent {
  constructor(private activatedRoute: ActivatedRoute, private shopService: ShopService) { }
  shopId !: any;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: ""
    }
  }
  ngOnInit() {
    this.shopId = this.activatedRoute.snapshot.paramMap.get('id')
  }

  deleteShop() {
    this.shopService.deleteShop(this.shopId).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }

    )
  }
}
