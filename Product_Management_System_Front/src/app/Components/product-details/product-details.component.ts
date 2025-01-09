import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../Services/product.service';
import { IProductDto } from '../../Models/iproduct-dto';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product?: IProductDto ={
    id:0,
    name:'',
    price:0,
    description :''
  }

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
        next: (res) => {
          this.product = res.entity;
          console.log(res.entity)
        },
        error: (err) => {
          console.error('Error loading product details:', err);
          alert('Could not load product details.');
          this.goBack();
        }
      });
    }
  }

  goBack(): void {
    this.router.navigate(['/products']);
  }
}
