import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ShopComponent} from './shop.component';
import {ProductItemComponent} from './product-item/product-item.component';
import {FormsModule} from "@angular/forms";
import {ShareModule} from "../share/share.module";
import {ProductDetailsComponent} from './product-details/product-details.component';
import {RouterModule} from "@angular/router";
import {ShopRoutingModule} from './shop-routing.module';


@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    ProductDetailsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ShareModule,
    ShopRoutingModule
  ]
})
export class ShopModule {
}
