import { Component, effect, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductService } from '../../core/services/product.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Product } from '../../shared/models/product';

@Component({
  selector: 'app-create-product',
  standalone: true,
  imports: [ReactiveFormsModule,RouterLink],
  templateUrl: './create-product.component.html',
  styleUrl: './create-product.component.scss'
})
export class CreateProductComponent {
  fb = inject(FormBuilder)
  
    productsService = inject(ProductService)
  
    route = inject(ActivatedRoute);
  
    router=inject(Router)
  
    product = signal<Product | null>(null)
    
    createForm = this.fb.group({
      sku: [this.product()?.sku, Validators.required],
      name: [this.product()?.name, [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      description: [this.product()?.description],
      price: [this.product()?.price, Validators.min(0)]
    })
  
    constructor() {
      effect(() => {
        const id = this.route.snapshot.paramMap.get('id');
        if (id) {
          this.productsService.getProductById(+id).subscribe(product => {
            this.product.set(product)
            this.createForm.patchValue({
              sku: product.sku,
              name: product.name,
              description: product.description,
              price: product.price
            })
            
          })
        }
      })
    }
    
    
    onSubmit() {
      const id = this.route.snapshot.paramMap.get('id');
      if (this.createForm.invalid) return;
      this.productsService.createProduct(this.createForm.value)
        .subscribe({
          next:()=>this.router.navigate([""])
        })
    }
}
