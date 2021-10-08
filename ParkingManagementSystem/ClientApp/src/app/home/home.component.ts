import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { ParkingService } from '../services/parking.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  veh: Vehicle;
  title = "app";
  vehicleList: Vehicle[] = [];
  
  // types: ticketType[] = [{ name: 'VIP' } ];//, img: '/img/motor' 
  
  // lots = [{type: this.types[0], name: 'suzuki'}]
  
  constructor(private router: Router, private authenticationService: AuthenticationService, private parkingService: ParkingService) {
    if (!this.authenticationService.isLogin) {
      this.router.navigate(['/login']);
    }
  }
  ngOnInit(): void {
    if (this.authenticationService.isLogin && !this.authenticationService.currentUserValue) {
      this.authenticationService.updateCurrentUser();
    }
    this.getParkingState()
    // this.vehicles


    this.parkingService.VehicleList$.subscribe((vehicles: any) => {
      this.vehicleList = vehicles ? vehicles : [];
      //this.filteredVehicleList = this.vehicleList;
    });
  }

  getParkingState() {
    this.parkingService.getParkingState(null);
  }
}
