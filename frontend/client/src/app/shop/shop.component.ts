import {Component, OnInit} from '@angular/core';
import {Product} from "../share/models/product";
import {ShopService} from "./shop.service";
import {Type} from "../share/models/type";
import {Brand} from "../share/models/brand";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  constructor(private shopservice: ShopService) {
  }

  products: Product[] = [];
  brands: Brand[] = [];
  types: Type[] = [];
  brandIdSelected=0;
  typeIdSelected=0;

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopservice.getProducts(this.brandIdSelected,this.typeIdSelected).subscribe({
      next: (response) => {
        console.log(response.data);
        this.products = response.data;
      },
      error: (error) => {
        console.log(error)
      },
      complete: () => {
      }
    });
  }

  getBrands() {
    this.shopservice.getBrands().subscribe({
      next: (response) => {
        console.log(response);
        this.brands = [{id:0,name:"all"},...response];
      },
      error: (error) => {
        console.log(error)
      },
      complete: () => {
      }
    });
  }

  getTypes() {
    this.shopservice.getTypes().subscribe({
      next: (response) => {
        console.log(response);
        this.types = [{id:0,name:'all'},...response];
      },
      error: (error) => {
        console.log(error)
      },
      complete: () => {
      }
    });
  }

 OnBrandSelected(brandId:number){
    this.brandIdSelected = brandId;
    this.getProducts();
 }
  OnTypeSelected(typeId:number){
    this.typeIdSelected = typeId;
    this.getProducts();
  }
}
