import { Routes } from '@angular/router';
import { MainLayoutComponent } from './Components/Layout/main-layout/main-layout.component';
import { ProductListComponent } from './Components/product-list/product-list.component';
import { AddNewProductComponent } from './Components/add-new-product/add-new-product.component';
import { ProductDetailsComponent } from './Components/product-details/product-details.component';
import { UpdateProductComponent } from './Components/update-product/update-product.component';

export const routes: Routes = [
    
    {
        path:'', 
        component:MainLayoutComponent,
        children:[
            {
                path:'', redirectTo:'products', pathMatch:'full'
            },
            {
                path:'products',  title:'All products',
                component:ProductListComponent,  
            },
            {
                path:'ProductDetails/:id',  title:'product Details',
                 component:ProductDetailsComponent,  
            },
            {
                path:'updateProduct/:id',  title:'product Details',
                 component:UpdateProductComponent,  
            },
            {
                path:'AddProduct',  title:'Add new Product',
                component:AddNewProductComponent,  
            },
            // { 
            //     path:'AddBook', title:'New Books',
            //     component:CreateBookComponent,
            // },
            // {
            //     path:'UpdateBook/:id',
            //     component:UpdateBookComponent,
            // },
            // {
            //     path:'BookDetails/:id',title:'Details',
            //     component:BookDetailsComponent,
            // },
        ]
    },
];
