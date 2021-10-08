import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  constructor( private router: Router, private authenticationService: AuthenticationService) {
    if (this.authenticationService.isLogin) {
      this.router.navigate(['/home', 1]);
    }
    else {
      this.router.navigate(['/login']);
    }
  }

  logout() {
    this.authenticationService.logout()
    this.authenticationService.isLogin = false;
  }
}
