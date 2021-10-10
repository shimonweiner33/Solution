import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { CheckInDetails } from "../models/check-in-details";
import { AuthenticationService } from "../services/authentication.service";
import { ParkingService } from "../services/parking.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit {
  title = "app";
  vehicleLists: CheckInDetails[] = [];
  vehicleListsForTest: CheckInDetails[] = [];


  // types: ticketType[] = [{ name: 'VIP' } ];//, img: '/img/motor'

  // lots = [{type: this.types[0], name: 'suzuki'}]

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private parkingService: ParkingService
  ) {
    if (!this.authenticationService.isLogin) {
      this.router.navigate(["/login"]);
    }
  }
  ngOnInit(): void {

    if (this.authenticationService.isLogin && !this.authenticationService.currentUserValue) {
      this.authenticationService.updateCurrentUser();
    }

    this.getParkingState();

    this.parkingService.VehicleList$.subscribe((vehicles: any) => {
      this.vehicleLists = vehicles ? vehicles.Vehicles : [];
    });
  }

  fillVehicleList() {
    for (let index = 0; index < 5; index++) {
      if (index % 5 === 1) {
        const vehicle: CheckInDetails = {
          licencePlateId: "11111111",
          name: "David",
          phone: "0545566666",
          ticketType: 2,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        };
        this.vehicleListsForTest.push(vehicle);
      }

      if (index % 5 === 2) {
        const vehicle: CheckInDetails = {
          licencePlateId: "2222222",
          name: "Erez",
          phone: "0545444444",
          ticketType: 1,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        };
        this.vehicleListsForTest.push(vehicle);
      }

      if (index % 5 === 3) {
        const vehicle: CheckInDetails = {
          licencePlateId: "3333333",
          name: "Yoram",
          phone: "0545555666",
          ticketType: 3,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        };
        this.vehicleListsForTest.push(vehicle);
      }

      if (index % 5 === 4) {
        const vehicle: CheckInDetails = {
          licencePlateId: "4444444",
          name: "Yehuda",
          phone: "0545454545",
          ticketType: 3,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        };
        this.vehicleListsForTest.push(vehicle);
      }

      if (index % 5 === 0) {
        const vehicle: CheckInDetails = {
          licencePlateId: "5555555",
          name: "Oded",
          phone: "0524333333",
          ticketType: 3,
          vehicleType: 1,
          vehicleHeight: 123,
          vehicleWidth: 234,
          vehicleLength: 2345,
        };
        this.vehicleListsForTest.push(vehicle);
      }
    }
  }
  async createFive() {
    this.fillVehicleList();

    await Promise.all([
      this.parkingService.checkIn(this.vehicleListsForTest[0]),
      this.parkingService.checkIn(this.vehicleListsForTest[1]),
      this.parkingService.checkIn(this.vehicleListsForTest[2]),
      this.parkingService.checkIn(this.vehicleListsForTest[3]),
      this.parkingService.checkIn(this.vehicleListsForTest[4]),
    ]);
    this.getParkingState();
  }

  getParkingState() {
    this.parkingService.getParkingState(null);
  }
}
