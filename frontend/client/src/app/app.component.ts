import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Product} from "./models/Product";
import {Pagination} from "./models/pagination";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements  OnInit{
  title = 'Client App';
  products:Product[]= [];

  constructor(private http:HttpClient) {

  }

  ngOnInit(): void {
    this.http.get<Pagination<Product>>('https://localhost:7190/api/Products?PageSize=50').subscribe({
      next: (response) => this.products = response.data,
      error:(error: any) => console.log(error),
      complete:()=>{
        console.log("completed")
      }
    });
  }


}
