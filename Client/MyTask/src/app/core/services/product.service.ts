import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CreateProduct, PagedResult, Product, ProductQuery, UpdateProduct } from '../../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl = 'http://localhost:5143/api/products'
  
  private _http = inject(HttpClient)
  
  getProducts(query: ProductQuery) {
    console.log(query)
    let params = new HttpParams()
    
    if (query.search !== undefined) {
     params = params.set('search',query.search)
    }

    if (query.pageSize !== undefined) {
     params = params.set('pageSize',query.pageSize)
    } 
    
    if (query.pageIndex !== undefined) {
     params = params.set('pageIndex',query.pageIndex)
    }
    
    if (query.includeDeleted !== false) {
      params = params.set('includeDeleted',query.includeDeleted)
    }
    console.log(params)
   return this._http.get<PagedResult>(this.baseUrl,{params})
  }

  getProductById(id:number) {
    return this._http.get<Product>(`${this.baseUrl}/${id}`)
  }
  
  createProduct(createProductDto:any) {
    return this._http.post(this.baseUrl,createProductDto)
  }

  updateProduct(id:any, updateProductDto: any) {
     return this._http.put(`${this.baseUrl}/${id}`,updateProductDto)
  }

  deleteProduct(id: number) {
    return this._http.delete(`${this.baseUrl}/${id}`)
  }
}
