import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Product} from "../../share/models/product";
 import {environment} from "../../../enviroment/environment";

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent {
  baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) {

  }

  get404Error(){
    console.log("get404Error");
    this.http.get<Product>(this.baseUrl+"products/42").subscribe({
      next:(response)=>{
        console.log(response);
      },
      error:(error)=>{
        console.log(error);
      },
      complete:()=>{}
    });
  }

  get500Error(){
    this.http.get<Product>(this.baseUrl+"Buggy/servererror").subscribe({
      next:(response)=>{
        console.log(response);
      },
      error:(error)=>{
        console.log(error);
      },
      complete:()=>{}
    });
  }


  get400Error(){
    this.http.get<Product>(this.baseUrl+"Buggy/badrequest").subscribe({
      next:(response)=>{
        console.log(response);
      },
      error:(error)=>{
        console.log(error);
      },
      complete:()=>{}
    });
  }

  get400ValidationError(){
    this.http.get<Product>(this.baseUrl+"products/dfdfdf").subscribe({
      next:(response)=>{
        console.log(response);
      },
      error:(error)=>{
        console.log(error);
      },
      complete:()=>{}
    });
  }

}
