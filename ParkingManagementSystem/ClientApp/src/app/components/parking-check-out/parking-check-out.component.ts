import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ParkingService } from 'src/app/services/parking.service';

@Component({
  selector: 'app-parking-check-out',
  templateUrl: './parking-check-out.component.html',
  styleUrls: ['./parking-check-out.component.css']
})
export class ParkingCheckOutComponent implements OnInit {
  parkingControl: FormControl;

constructor(private parkingService: ParkingService, private authenticationService: AuthenticationService, 
  private router: Router) {
  if (!this.authenticationService.isLogin) {
    this.router.navigate(["/login"]);
  }
 }
  ngOnInit() {
    this.parkingControl = new FormControl('', Validators.required);
  }

  save() {
    this.parkingService.checkOut(this.parkingControl.value);
  }

}
