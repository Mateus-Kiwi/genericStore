import { Component, Input } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {
  @Input() product?: Product;

  constructor(private basketService: BasketService){}

  addItemToBasket(){
    if(this.product !== undefined && this.product.quantityStock !== undefined && this.product.quantityStock > 0)
    this.product && this.basketService.addToBasket(this.product);
  }
}
