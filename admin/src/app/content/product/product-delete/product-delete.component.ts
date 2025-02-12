import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../../services/product.service';

@Component({
  selector: 'app-product-delete',
  templateUrl: './product-delete.component.html',
  styleUrl: './product-delete.component.css'
})
export class ProductDeleteComponent {
  constructor(private activatedRoute: ActivatedRoute, private productService: ProductService) { }
  productId !: any;
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
  ngOnInit() {
    this.productId = this.activatedRoute.snapshot.paramMap.get('id')
  }

  deleteProduct() {
    this.productService.deleteProduct(this.productId).subscribe({
      next: (res: any) => {
        this.response = res
      }
    }

    )
  }
}
