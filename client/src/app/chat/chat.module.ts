import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatComponent } from './chat.component';
import { ProductItemComponent } from '../shop/product-item/product-item.component';
import { ProductDetailsComponent } from '../shop/product-details/product-details.component';
import { ChatRoutingModule } from './chat-routing.module';
import { SharedModule } from '../shared/shared.module';
import { SectionHeaderComponent } from '../core/section-header/section-header.component';
import { NavBarComponent } from '../core/nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';



@NgModule({
    declarations: [
    ChatComponent,
    SectionHeaderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    SharedModule,
    ChatRoutingModule
  ]
})
export class ChatModule { }
