import * as cuid from "cuid"

export interface RootObject {
    id: string
    items: BasketItem[]
  }
  
  export interface BasketItem {
    id: number
    productName: string
    price: number
    quantity: number
    pictureUrl: string
    brand: string
    type: string
  }
  
  export class Basket implements Basket {
    id = cuid();
    items: BasketItem[] = [];
  }