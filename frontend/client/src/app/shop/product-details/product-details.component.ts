import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ShopService} from "../shop.service";
import {Product} from "../../share/models/product";
import {ActivatedRoute} from "@angular/router";
import {BreadcrumbService} from "xng-breadcrumb";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit{
  product?:Product;

  constructor(private shopService:ShopService,
              private activatedRoute:ActivatedRoute , private bcService:BreadcrumbService) {
  }

  ngOnInit(): void {
   this.LoadProduct();

  }
  LoadProduct(){
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if(id)
    this.shopService.getProduct(+id).subscribe({
      next:(response)=>
      {
        console.log(response)
        this.product= response;
        this.bcService.set('@productDetails',this.product.name )
      },
      error:(error)=>console.log(error),
      complete:()=>{}
    })
  }


}
