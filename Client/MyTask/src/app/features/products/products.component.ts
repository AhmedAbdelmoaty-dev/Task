import { Component, inject, OnInit, signal, ViewChild, viewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { Product } from '../../shared/models/product';
import { DatePipe } from '@angular/common';
import { ProductService } from '../../core/services/product.service';
import { Router, RouterLink } from '@angular/router';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';



@Component({
  selector: 'app-products',
  standalone: true,
  imports: [MatPaginatorModule, MatPaginatorModule, DatePipe, MatDialogModule, RouterLink,FormsModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent implements OnInit {
  router = inject(Router)
  
  products = signal<Product[]>([])

  @ViewChild(MatPaginator) paginator!:MatPaginator

  searchKeyword:string=""
  
  totalCount = signal(0);

  includeDeleted=signal<boolean>(false)

  params = signal({
    pageIndex: 1,
    pageSize: 5,
    search: "",
    includeDeleted:false
  });

  productService = inject(ProductService)
  

  ngOnInit(): void {
    this.loadProducts()
  }


  loadProducts() {
     this.productService.getProducts(this.params()).subscribe({
      next: (PagedResult) => {
         this.products.set(PagedResult.productsDtos)
         this.totalCount.set(PagedResult.totalCount) 
      }
    })
  }
  
  
  editProduct(element:Product) {
    this.router.navigate(['/edit',element.id])
  }
  
  deleteProduct(elemnt:Product) {
    if (confirm("are you sure you want to delete this product ?")) {
      this.productService.deleteProduct(elemnt.id).subscribe({
        next:()=> window.location.reload()
      })
    }
  }

   onPageChanged(event: PageEvent) {
    this.params.update(p => ({
      ...p,
      pageIndex: event.pageIndex+1,
      pageSize: event.pageSize
    }));
    this.loadProducts();
  }

  onSearch() {
    this.params.update(p => ({
      ...p,
      search: this.searchKeyword,
      pageIndex:1
    }));
    this.paginator.firstPage();
    this.loadProducts();
  }

  onIncludeDeletedChanged() {
     this.params.update(p => ({
      ...p,
       includeDeleted: this.includeDeleted(),
      pageIndex:1
     }));
   this.paginator.firstPage();
   this.loadProducts() 
  }

  exportToCsv() {
    const products = this.products();

  const header = ['Id', 'Name', 'Price', 'IsDeleted'];
  const rows = products.map(p => [p.id, p.name, p.description, p.price,p.createdAtUtc,p.updatedAtUtc]);
  
  const csvContent =
    [header, ...rows]
      .map(row => row.join(','))
      .join('\n');


  const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
  const url = window.URL.createObjectURL(blob);
  const a = document.createElement('a');
  a.href = url;
  a.download = 'products.csv';
  a.click();
 
  window.URL.revokeObjectURL(url);
  }
}