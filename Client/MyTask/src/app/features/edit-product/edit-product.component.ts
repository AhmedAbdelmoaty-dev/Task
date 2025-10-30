import { Component, effect, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductService } from '../../core/services/product.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Product } from '../../shared/models/product';

@Component({
  selector: 'app-edit-product',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.scss'
})
export class EditProductComponent {

  fb = inject(FormBuilder)

  productsService = inject(ProductService)

  route = inject(ActivatedRoute);

  router=inject(Router)

  product = signal<Product | null>(null)
  
  editForm = this.fb.group({
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
          this.editForm.patchValue({
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
    if (this.editForm.invalid) return;
    this.productsService.updateProduct(id, this.editForm.value)
      .subscribe({
        next:()=>this.router.navigate([""])
      })
  }
}
