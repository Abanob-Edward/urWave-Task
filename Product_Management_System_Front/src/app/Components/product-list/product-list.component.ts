import { ProductService } from './../../Services/product.service';
import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { IProductDto } from '../../Models/iproduct-dto';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { RouterLink } from '@angular/router';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
@Component({
  standalone: true,
  selector: 'app-product-list',
  imports: [FormsModule,CommonModule ,TableModule,RouterLink],

  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit  { 
  products: IProductDto[] = [];
  searchTerm: string = '';
  filteredProducts: IProductDto[] = []; // // Copy of products for filtering

  constructor(private ProductService :ProductService, private dialog: MatDialog){}

 
  ngOnInit(){
    this.getAllProducts();
  }
  SortByID(){
    this.getAllProducts('id');
  }
  SortByName(){
    this.getAllProducts('name');
  }
  SortByPrice(){
    this.getAllProducts('price');
  }
  getAllProducts(sortedCol:string='id'){
    this.ProductService.getAllWithPaging(10, 1,sortedCol,'asc')
    .subscribe(prd => {
      this.products = prd.entities;
      this.filteredProducts = [...this.products]; // Set filteredProducts to the fetched products 
      console.log(prd.entities)
    });
  }
  filterProducts(): void {
    const search = this.searchTerm.toLowerCase();
    this.filteredProducts = this.products.filter(product =>
      product.name.toLowerCase().includes(search) ||
      product.description?.toLowerCase().includes(search) ||
      product.price.toString().includes(search)
    );
  }
  // confirmDelete(productId: number): void {
  //   const confirmation = confirm('Are you sure you want to delete this product?');
  //   if (confirmation) {
  //     this.ProductService.deleteProduct(productId).subscribe({
  //       next: (response: string) => {
  //         alert(response); // Success notification
  //         this.loadProducts(); // Refresh the product list
  //       },
  //       error: (error) => {
  //         console.error('Error deleting product:', error);
  //         alert('Failed to delete the product. Please try again.');
  //       }
  //     });
  //   }
  // } 
  loadProducts(): void {
     this.getAllProducts();
  }
  openConfirmDialog(productId: number): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '300px',
      data: { message: 'Are you sure you want to delete this product?' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.ProductService.deleteProduct(productId).subscribe({
          next: (response: string) => {
            alert(response);
            this.loadProducts(); // Refresh the product list
          },
          error: (error) => {
            console.error('Error deleting product:', error);
            alert('Failed to delete the product. Please try again.');
          }
        });
      }
    });
  }
}

