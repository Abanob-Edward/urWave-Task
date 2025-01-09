import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ProductService } from '../../Services/product.service';
import { IAddOrUpdateProductDto } from '../../Models/iadd-or-update-product-dto';

@Component({
  selector: 'app-add-new-product',
  imports: [FormsModule, CommonModule],
  templateUrl: './add-new-product.component.html',
  styleUrls: ['./add-new-product.component.css']
})
export class AddNewProductComponent {
  product: IAddOrUpdateProductDto = {
    name: '',
    description: '',
    price: 0
  };

  isSubmitted = false;
  errorMessage = '';

  constructor(private productService: ProductService) {}

  onSubmit(productForm: NgForm): void {
    this.isSubmitted = true;
    if (productForm.valid) {
      this.productService.addProduct(this.product).subscribe({
        next: (response) => {
          alert('Product added successfully!');
          this.resetForm(productForm);
        },
        error: (error) => {
          console.error('Error adding product:', error);
          this.errorMessage = 'Failed to add the product. Please try again.';
        }
      });
    } else {
      this.errorMessage = 'Please fix the errors in the form.';
    }
  }

  resetForm(productForm: NgForm): void {
    this.product = {
      name: '',
      description: '',
      price: 0
    };
    this.isSubmitted = false;
    this.errorMessage = '';
    productForm.resetForm();
  }
}
