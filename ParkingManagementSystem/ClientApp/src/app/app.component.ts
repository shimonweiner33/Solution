import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent{
  title = 'app';
  constructor(private router: Router,  private authenticationService: AuthenticationService) {
    if (this.authenticationService.isLogin) {
      this.router.navigate(['/login']);
    }
  }
}