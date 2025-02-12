import { Component } from '@angular/core';
import { CategoryService } from '../../../services/category.service';
import { ProductService } from '../../../services/product.service';
import { Category } from '../../../interfaces/category.interface';
import { Shop } from '../../../interfaces/shop.interface';
import { ShopService } from '../../../services/shop.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrl: './product-create.component.css'
})
export class ProductCreateComponent {
  constructor(private categoryService: CategoryService, private shopService: ShopService, private productService: ProductService) {

  }
  shops: Shop[];
  categories: Category[];

  ngOnInit(): void {
    this.shopService.getAllShops().subscribe(
      (result: any) => {
        this.shops = result
      }
    )
    this.categoryService.getAllCategories().subscribe(
      (result: any) => {
        this.categories = result
      }
    )
  }
  name: string = "";
  image: string = "";
  description: string = "";
  price: number = 0;
  shopId: number;
  cateId: number;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: "",
      priceError: "",
      categoryError: "",
      shopError: ""
    }
  }
  create() {
    var inputData = {
      cateId: this.cateId,
      shopId: this.shopId,
      name: this.name,
      description: this.description,
      image: this.image,
      price: this.price
    }
    this.productService.createProduct(inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )
  }
}
