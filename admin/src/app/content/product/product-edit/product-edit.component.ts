import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from '../../../services/category.service';
import { ProductService } from '../../../services/product.service';
import { Category } from '../../../interfaces/category.interface';
import { ShopService } from '../../../services/shop.service';
import { Product } from '../../../interfaces/product.interface';
import { Shop } from '../../../interfaces/shop.interface';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrl: './product-edit.component.css'
})
export class ProductEditComponent {
  categories: Category[];
  shops: Shop[];
  productId !: any;
  product: Product;
  cateId: number;
  shopId: number;
  response = {
    isModified: false,
    error: {
      existedError: "",
      imageError: "",
      nameError: "",
      categoryError: "",
      shopError: "",
      priceError: "",
    }
  }
  constructor(private activatedRoute: ActivatedRoute, private categoryService: CategoryService, private shopService: ShopService, private productService: ProductService) {

  }
  editProduct() {
    var inputData = {
      cateId: this.cateId,
      shopId: this.shopId,
      name: this.product.name,
      description: this.product.description,
      image: this.product.image,
      price: this.product.price
    }
    this.productService.updateProduct(this.productId, inputData).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }
    )

  }

  ngOnInit() {

    this.productId = this.activatedRoute.snapshot.paramMap.get('id')
    this.productService.getProduct(this.productId).subscribe(
      (result: any) => {
        this.product = result
        this.shopId = this.product.shopId
        this.cateId = this.product.categoryId
      }
    )
    this.categoryService.getAllCategories().subscribe(
      (result: any) => {
        this.categories = result
      }
    )
    this.shopService.getAllShops().subscribe(
      (result: any) => {
        this.shops = result
      }
    )
  }
}
