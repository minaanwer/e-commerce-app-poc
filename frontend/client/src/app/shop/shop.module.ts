import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import {FormsModule} from "@angular/forms";
import {ShareModule} from "../share/share.module";



@NgModule({
  declarations: [
    ShopComponent,
      ProductItemComponent
  ],
    imports: [
        CommonModule,
        FormsModule,
        ShareModule
    ],
  exports:[
    ShopComponent
  ]
})
export class ShopModule { }
