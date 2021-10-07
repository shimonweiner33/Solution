import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';
  constructor(private router: Router,  private authenticationService: AuthenticationService) {
    if (this.authenticationService.isLogin) {
      let mainRoom = 1;
      this.router.navigate(['/post-list', mainRoom]);
    }
    else {
      this.router.navigate(['/login']);
    }
  }
}