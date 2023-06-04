import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements  OnInit{
  title = 'Client App';

  constructor(private http:HttpClient) {

  }

  ngOnInit(): void {
    this.http.get('https://localhost:7190/api/Products').subscribe({
      next: (response: any) => console.log(response),
      error:(error: any) => console.log(error),
      complete:()=>{
        console.log("completed")
      }
    });

  }


}
