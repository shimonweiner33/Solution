import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  veh: Vehicle;
  title = "app";
  
  // types: ticketType[] = [{ name: 'VIP' } ];//, img: '/img/motor' 
  
  // lots = [{type: this.types[0], name: 'suzuki'}]
  
  constructor(private router: Router, private authenticationService: AuthenticationService) {
    if (!this.authenticationService.isLogin) {
      this.router.navigate(['/login']);
    }
  }
  ngOnInit(): void {
    if (this.authenticationService.isLogin && !this.authenticationService.currentUserValue) {
      this.authenticationService.updateCurrentUser();
    }
  }
}
