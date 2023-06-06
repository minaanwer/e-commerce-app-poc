import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Pagination} from "../share/models/pagination";
import {Product} from "../share/models/product";

@Injectable({
  providedIn: 'root'
})
export class ShopService {

   baseUrl:string = 'https://localhost:7190/api/';


  constructor(private http:HttpClient) {

  }
  getProducts(){
    return this.http.get<Pagination<Product>>(this.baseUrl+"products");
  }


}
