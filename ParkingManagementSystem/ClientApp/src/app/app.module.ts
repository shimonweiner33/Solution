import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatGridListModule, MatOptionModule, MatSelectModule } from '@angular/material';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login/login.component';
import { ParkingCheckInComponent } from './components/parking-check-in/parking-check-in.component';
import { ParkingCheckOutComponent } from './components/parking-check-out/parking-check-out.component';
import { RegisterComponent } from './components/register/register.component';
// import { CounterComponent } from './counter/counter.component';
// import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AuthenticationService } from './services/authentication.service';
import { ParkingService } from './services/parking.service';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    // CounterComponent,
    // FetchDataComponent,
    ParkingCheckInComponent,
    ParkingCheckOutComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatOptionModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatGridListModule,
    MatInputModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'app', pathMatch: 'full' },
      { path: 'home', component: HomeComponent, pathMatch: 'full' },
      { path: 'parking-check-in', component: ParkingCheckInComponent, pathMatch: 'full' },
      { path: 'parking-check-out', component: ParkingCheckOutComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      // { path: 'counter', component: CounterComponent },
      // { path: 'fetch-data', component: FetchDataComponent },
    ]),
    NoopAnimationsModule
  ],
  providers: [ParkingService, AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
