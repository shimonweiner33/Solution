import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  
  veh: Vehicle;
  
  types: ticketType[] = [{ name: 'VIP' } ];//, img: '/img/motor' 
  
  lots = [{type: this.types[0], name: 'suzuki'}]
  
  
  ngOnInit(): void {
    this
  }
}
