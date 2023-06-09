import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {Product} from "../share/models/product";
import {ShopService} from "./shop.service";
import {Type} from "../share/models/type";
import {Brand} from "../share/models/brand";
import {ShopParams} from "../share/models/shopParams";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
 @ViewChild('search') searchTerm?:ElementRef;
  products: Product[] = [];
  brands: Brand[] = [];
  types: Type[] = [];
  shopParams: ShopParams = new ShopParams();
  sortOptions = [
    {name: "Alphabetical", value: "name"},
    {name: "Price: Low to high", value: "priceAsc"},
    {name: "Price: High to Low", value: "priceDesc"}
  ];
  totalCount = 0;

  constructor(private shopService: ShopService) {

  }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: (response) => {
        console.log(response);
        this.products = response.data;
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.count;
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
    this.shopParams.brandId = brandId;
    console.log("OnBrandSelected" + brandId);
    this.getProducts();
  }

  OnTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.getProducts();
  }

  OnSortSelected(event: any) {
    this.shopParams.sort = event.target.value;
    console.log("event.target.value : " + event.target.value);
    this.getProducts();
  }

  OnPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }
  OnSearch(){
   this.shopParams.search=this.searchTerm?.nativeElement.value;
   this.getProducts();
  }

  OnReset() {
    if(this.searchTerm)this.searchTerm.nativeElement.value="";
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
