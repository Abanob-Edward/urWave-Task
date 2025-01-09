import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResultDataList } from '../Models/iresult-data-list';
import { Observable } from 'rxjs';
import { IProductDto } from '../Models/iproduct-dto';
import { IAddOrUpdateProductDto } from '../Models/iadd-or-update-product-dto';
import { IResultView } from '../Models/iresult-view';



@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl = 'https://localhost:7026/api/Product'; 
  constructor(private http: HttpClient) { }
  getProductById(id: number): Observable<IResultView<IProductDto>> {
    return this.http.get<IResultView<IProductDto>>(`${this.baseUrl}/GetProductByID/${id}`);
  }
  getAllWithPaging(
    items: number = 10,
    pageNumber: number = 1,
    sortColumn: string = 'id',
    sortOrder: string = 'asc'
  ): Observable<IResultDataList<IProductDto>> {
    const queryParams = {
      items,
      pageNumber,
      sortColumn,
      sortOrder,
    };
//    const url = `${this.baseUrl}/GetAllWithPaging?items=${items}&pageNumber=${pageNumber}&sortColumn=${sortColumn}&sortOrder=${sortOrder}`;

    return this.http.get<IResultDataList<IProductDto>>(`${this.baseUrl}/GetAllWithPaging`, { params: queryParams });
  }
  updateProduct(id: number, product: IProductDto): Observable<IResultView<IProductDto>> {
    return this.http.put<IResultView<IProductDto>>(`${this.baseUrl}/UpdateProduct/${id}`, product);
  }
  
  addProduct(product: IAddOrUpdateProductDto): Observable<any> {
    return this.http.post(`${this.baseUrl}/AddProduct`, product);
  }
 
  deleteProduct(id: number): Observable<string> {
    return this.http.delete(`${this.baseUrl}/SoftDelete/${id}`, { responseType: 'text' });
  }
}
