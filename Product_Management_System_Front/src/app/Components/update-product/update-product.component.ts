import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../Services/product.service';
import { IProductDto } from '../../Models/iproduct-dto';
import { IResultView } from '../../Models/iresult-view';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-product',
  imports:[ CommonModule,
    FormsModule ],
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {
  product: IProductDto = {
    id: 0,
    name: '',
    description: '',
    price: 0
  };
  isSubmitted = false;
  errorMessage: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.loadProductDetails();
  }

  loadProductDetails(): void {
    const productId = this.route.snapshot.paramMap.get('id');
    if (productId) {
      this.productService.getProductById(+productId).subscribe({
        next: (response) => {
          if (response.isSuccess && response.entity) {
            this.product = response.entity;
          } else {
            this.errorMessage = response.message || 'Product not found.';
          }
        },
        error: (err) => {
          console.error('Error loading product details:', err);
          this.errorMessage = 'An error occurred while loading product details.';
        }
      });
    } else {
      this.errorMessage = 'Invalid product ID.';
    }
  }

  onSubmit(): void {
    this.isSubmitted = true;
    if (this.product.name && this.product.price > 0 && this.product.description) {
      this.productService.updateProduct(this.product.id, this.product).subscribe({
        next: (response: IResultView<IProductDto>) => {
          if (response.isSuccess) {
            alert('Product updated successfully!');
            this.router.navigate(['/products']);
          } else {
            this.errorMessage = response.message || 'Failed to update the product.';
          }
        },
        error: (error) => {
          console.error('Error updating product:', error);
          this.errorMessage = 'Failed to update the product. Please try again.';
        }
      });
    } else {
      this.errorMessage = 'Please fix the errors in the form.';
    }
  }
}
