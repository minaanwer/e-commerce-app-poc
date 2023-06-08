import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {Pagination} from "../share/models/pagination";
import {Product} from "../share/models/product";
import {Type} from "../share/models/type";
import {Brand} from "../share/models/brand";
import {ShopParams} from "../share/models/shopParams";

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl: string = 'https://localhost:7190/api/';

  constructor(private http: HttpClient) {}

  getProducts(shopParams:ShopParams) {
    let params = new HttpParams();
    let paramAsStr ="?";
    if (shopParams.brandId>0) {
      paramAsStr+=("brandId="+shopParams.brandId+"&");
      params.append('brandId', shopParams.brandId);
    }
    if (shopParams.typeId>0) {
      paramAsStr += ("typeId=" + shopParams.typeId+"&");
      params.append('typeId', shopParams.typeId);
    }
    if (shopParams.sort !="") {
      paramAsStr+=("sort="+shopParams.sort+"&");
      params.append('sort', shopParams.sort);
    }
    paramAsStr+=("pageIndex="+shopParams.pageNumber+"&");
    paramAsStr+=("pageSize="+shopParams.pageSize);

    if(paramAsStr=="?") paramAsStr="";

    console.log("paramAsStr:"+ paramAsStr);

    return this.http.get<Pagination<Product>>(this.baseUrl + "Products"+paramAsStr);
  }

  getBrands() {
    return this.http.get<Brand[]>(this.baseUrl + "products/brands");
  }

  getTypes() {
    return this.http.get<Type[]>(this.baseUrl + "products/types");
  }

}
