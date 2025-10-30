import { Routes } from '@angular/router';
import { ProductsComponent } from './features/products/products.component';
import { EditProductComponent } from './features/edit-product/edit-product.component';
import { CreateProductComponent } from './features/create-product/create-product.component';

export const routes: Routes = [
    { path: '', component: ProductsComponent },
    { path: 'edit/:id', component: EditProductComponent },
    {path:'create',component:CreateProductComponent}
];
