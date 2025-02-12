import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../../../services/shop.service';
import { Shop } from '../../../interfaces/shop.interface';

@Component({
  selector: 'app-shop-edit',
  templateUrl: './shop-edit.component.html',
  styleUrl: './shop-edit.component.css'
})
export class ShopEditComponent {
  shop: Shop;
  shopId !: any;
  response = {
    isModified: false,
    error: {
      existedError: "",
      logoError: "",
      nameError: "",
      phoneError: "",
      emailError: "",
      addressError: ""
    }
  }
  constructor(private activatedRoute: ActivatedRoute, private shopService: ShopService) {

  }
  editShop() {
    var inputData = {
      name: this.shop.name,
      logo: this.shop.logo,
      description: this.shop.description,
      phone: this.shop.phone,
      email: this.shop.email,
      address: this.shop.address
    }
    this.shopService.updateShop(this.shopId, inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }

  ngOnInit() {

    this.shopId = this.activatedRoute.snapshot.paramMap.get('id')
    this.shopService.getShop(this.shopId).subscribe(
      (result: any) => {
        this.shop = result
      }
    )
  }
}
