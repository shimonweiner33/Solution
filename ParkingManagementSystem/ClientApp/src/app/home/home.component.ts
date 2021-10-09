import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CheckInDetails } from '../models/check-in-details';
import { AuthenticationService } from '../services/authentication.service';
import { ParkingService } from '../services/parking.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  title = "app";
  vehicleLists: CheckInDetails[] = [];
  
  
  // types: ticketType[] = [{ name: 'VIP' } ];//, img: '/img/motor' 
  
  // lots = [{type: this.types[0], name: 'suzuki'}]
  
  constructor(private router: Router, private authenticationService: AuthenticationService, private parkingService: ParkingService) {
    if (!this.authenticationService.isLogin) {
      this.router.navigate(['/login']);
    }
  }
  ngOnInit(): void {

    for (let index = 0; index < 5; index++) {
      if (index % 5 === 1) {
        const car:CheckInDetails = {
          licencePlateId: '111111',
          name: 'shimon',
          phone: 'sdfdsf',
          ticketType: 2,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        }
        this.vehicleLists.push(car);

      }

      if (index % 5 === 2) {
        const car:CheckInDetails = {
          licencePlateId: '22222',
          name: 'shimon',
          phone: 'sdfdsf',
          ticketType: 1,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        }
        this.vehicleLists.push(car);

      }
      
      if (index % 5 === 3) {
        const car:CheckInDetails = {
          licencePlateId: '33333',
          name: 'shimon',
          phone: 'sdfdsf',
          ticketType: 3,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        }
        this.vehicleLists.push(car);
      }

      if (index % 5 === 4) {
        const car:CheckInDetails = {
          licencePlateId: '444444',
          name: 'shimon',
          phone: 'sdfdsf',
          ticketType: 3,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        }
        this.vehicleLists.push(car);
      }

      if (index % 5 === 0) {
        const car:CheckInDetails = {
          licencePlateId: '55555',
          name: 'shimon',
          phone: 'sdfdsf',
          ticketType: 3,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        }
        this.vehicleLists.push(car);
      }

      // if (index % 10 === 0) {
      //   this.vehicleLists.push(undefined);

      // }
      
    }
    this.createFive()
    if (this.authenticationService.isLogin && !this.authenticationService.currentUserValue) {
      this.authenticationService.updateCurrentUser();
    }

    this.getParkingState()
    // this.vehicles


    this.parkingService.VehicleList$.subscribe((vehicles: any) => {
      this.vehicleLists = vehicles ? vehicles.Vehicles : [];
      //this.filteredVehicleList = this.vehicleList;
    });
  }

  async createFive() {
    await Promise.all([
      this.parkingService.checkIn(this.vehicleLists[0]),
      this.parkingService.checkIn(this.vehicleLists[1]),
      this.parkingService.checkIn(this.vehicleLists[2]),
      this.parkingService.checkIn(this.vehicleLists[3]),
      this.parkingService.checkIn(this.vehicleLists[4])]);
    this.getParkingState();
  }

  getParkingState() {
    this.parkingService.getParkingState(null);
  }
}
