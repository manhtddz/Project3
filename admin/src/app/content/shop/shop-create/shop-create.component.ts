import { Component } from '@angular/core';
import { ShopService } from '../../../services/shop.service';

@Component({
  selector: 'app-shop-create',
  templateUrl: './shop-create.component.html',
  styleUrl: './shop-create.component.css'
})
export class ShopCreateComponent {
  constructor(private shopService: ShopService) {

  }
  ngOnInit(): void {

  }
  name : string = "";
  logo: string = "";
  description : string = "";
  phone : string = "";
  email : string = "";
  address : string = "";
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
  create() {
    var inputData = {
      name: this.name,
      logo: this.logo,
      description: this.description,
      phone: this.phone,
      email: this.email,
      address: this.address
    }
    this.shopService.createShop(inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }
}
