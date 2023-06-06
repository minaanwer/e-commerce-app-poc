import {Component, OnInit} from '@angular/core';
import {Product} from "../share/models/product";
import {ShopService} from "./shop.service";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit{

  constructor(private shopservice:ShopService) {
  }

  products:Product[] = [] ;

  ngOnInit(): void {

    this.shopservice.getProducts().subscribe({
    next:(response)=>{
      console.log(response.data);
      this.products = response.data;
    },
    error:(error)=>{console.log(error)},
    complete:()=>{}
    });


  }



}
