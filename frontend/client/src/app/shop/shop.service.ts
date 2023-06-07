import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {Pagination} from "../share/models/pagination";
import {Product} from "../share/models/product";
import {Type} from "../share/models/type";
import {Brand} from "../share/models/brand";

@Injectable({
  providedIn: 'root'
})
export class ShopService {

   baseUrl:string = 'https://localhost:7190/api/';


  constructor(private http:HttpClient) {
  }

  getProducts(brandId?:number,typeId?:number){
    var params = new HttpParams();
    if(brandId)
      params.append('brandId',brandId);
    if(typeId)
      params.append('typeId',typeId);

    return this.http.get<Pagination<Product>>(this.baseUrl+"products",{params});
  }
  getBrands(){

    return this.http.get<Brand[]>(this.baseUrl+"products/brands");
  }
  getTypes(){
    return this.http.get<Type[]>(this.baseUrl+"products/types");
  }


}
