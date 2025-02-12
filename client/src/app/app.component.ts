import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  constructor(private router: Router){
    this.router.navigateByUrl('/home');
  }
  title = 'client';
  output:number = 0;
  moneyConvert(price:number, ev:any){
    var t: HTMLInputElement = ev.target;
    var sl = Number(t.value);   
    this.output = price* sl;
  }
}
