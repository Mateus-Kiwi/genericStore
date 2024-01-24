import { Component } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { BasketItem } from 'src/app/models/basket';
import { Icon } from 'ionicons/dist/types/components/icon/icon';

@Component({
  selector: 'app-nav-tab-mobile',
  templateUrl: './nav-tab-mobile.component.html',
  styleUrls: ['./nav-tab-mobile.component.scss']
})
export class NavTabMobileComponent {
  constructor(public basketService: BasketService, public accountService:AccountService){}

  getCount(items: BasketItem[]){
    return items.reduce((sum, item) => sum + item.quantity, 0);
  }
}
