import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {Pagination} from "../share/models/pagination";
import {Product} from "../share/models/product";
import {Type} from "../share/models/type";
import {Brand} from "../share/models/brand";

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl: string = 'https://localhost:7190/api/';

  constructor(private http: HttpClient) {}

  getProducts(brandId?: number, typeId?: number, sort?: string) {
    let params = new HttpParams();
    let param ="?";
    if (brandId) {
      param+=("brandId="+brandId+"&");
      params.append('brandId', brandId);
    }
    if (typeId) {
      param += ("typeId=" + typeId+"&");
      params.append('typeId', typeId);
    }
    if (sort) {
      param+=("sort="+sort);
      params.append('sort', sort);
    }
    if(param=="?") param="";
    console.log("param"+ param)
    return this.http.get<Pagination<Product>>(this.baseUrl + "Products"+param);
  }

  getBrands() {
    return this.http.get<Brand[]>(this.baseUrl + "products/brands");
  }

  getTypes() {
    return this.http.get<Type[]>(this.baseUrl + "products/types");
  }

}
