import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { BasketItem } from 'src/app/models/basket';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.scss']
})
export class SummaryComponent {
  @Output() addItem = new EventEmitter<BasketItem>();
  @Output() removeItem = new EventEmitter<{id: number, quantity: number}>();
  @Input() isBasket = true;

  constructor(public basketService: BasketService){}

  addBasketItem(item: BasketItem){
    this.addItem.emit(item);
  }

  removeBasketItem(id: number, quantity = 1){
    this.removeItem.emit({id, quantity}); 
  }
}
