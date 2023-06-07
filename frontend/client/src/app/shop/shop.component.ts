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

  constructor(private shopService: ShopService) {
  }

  products: Product[] = [];
  brands: Brand[] = [];
  types: Type[] = [];
  brandIdSelected = 0;
  typeIdSelected = 0;
  sortSelected = "";
  sortOptions = [
    {name: "Alphabetical", value: "name"},
    {name: "Price: Low to high", value: "priceAsc"},
    {name: "Price: High to Low", value: "priceDesc"}
  ];

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected).subscribe({
      next: (response) => {
        console.log(response.data);
        this.products = response.data;
      },
      error: (error) => {
        console.log(error)
      },
      complete: () => {
        console.log("completed")
      }
    });
  }

  getBrands() {
    this.shopService.getBrands().subscribe({
      next: (response) => {
        console.log(response);
        this.brands = [{id: 0, name: "all"}, ...response];
      },
      error: (error) => {
        console.log(error)
      },
      complete: () => {
      }
    });
  }

  getTypes() {
    this.shopService.getTypes().subscribe({
      next: (response) => {
        console.log(response);
        this.types = [{id: 0, name: 'all'}, ...response];
      },
      error: (error) => {
        console.log(error)
      },
      complete: () => {
      }
    });
  }

  OnBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    console.log("OnBrandSelected"+brandId);
    this.getProducts();
  }

  OnTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts();
  }

  OnSortSelected(event: any) {
    this.sortSelected = event.target.value;
    console.log("event.target.value : "+event.target.value);
    this.getProducts();
  }
}
