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
  currentUser = "";
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
    if (
      this.authenticationService.isLogin &&
      !this.authenticationService.currentUserValue
    ) {
      this.authenticationService.updateCurrentUser();
    }

    this.getParkingState();

    this.parkingService.VehicleList$.subscribe((vehicles: any) => {
      this.vehicleLists = vehicles ? vehicles.Vehicles : [];
    });
    this.authenticationService.currentUser$.subscribe((currentUser: any) => {
      if(!currentUser){
        if (!this.authenticationService.isLogin) {
          this.router.navigate(["/login"]);
        }
      }
      else{
        this.currentUser = currentUser
      }
    });
    //this.fillVehicleList();
  }

  fillVehicleList() {
    this.vehicleListsForTest = []

    const vehicle1: CheckInDetails = {
      licencePlateId: "11111111",
      name: "David",
      phone: "0545566666",
      ticketType: 3,
      vehicleType: 1,
      vehicleHeight: 123,
      vehicleWidth: 234,
      vehicleLength: 2345,
    };
    this.vehicleListsForTest.push(vehicle1);

    const vehicle2: CheckInDetails = {
      licencePlateId: "2222222",
      name: "Erez",
      phone: "0545444444",
      ticketType: 3,
      vehicleType: 1,
      vehicleHeight: 123,
      vehicleWidth: 234,
      vehicleLength: 2345,
    };
    this.vehicleListsForTest.push(vehicle2);

    const vehicle3: CheckInDetails = {
      licencePlateId: "3333333",
      name: "Yoram",
      phone: "0545555666",
      ticketType: 3,
      vehicleType: 1,
      vehicleHeight: 123,
      vehicleWidth: 234,
      vehicleLength: 2345,
    };
    this.vehicleListsForTest.push(vehicle3);

    const vehicle4: CheckInDetails = {
      licencePlateId: "444444",
      name: "Daniel",
      phone: "0545555666",
      ticketType: 3,
      vehicleType: 1,
      vehicleHeight: 123,
      vehicleWidth: 234,
      vehicleLength: 2345,
    };
    this.vehicleListsForTest.push(vehicle4);

    const vehicle5: CheckInDetails = {
      licencePlateId: "555555",
      name: "Eli",
      phone: "0545555666",
      ticketType: 3,
      vehicleType: 1,
      vehicleHeight: 123,
      vehicleWidth: 234,
      vehicleLength: 2345,
    };
    this.vehicleListsForTest.push(vehicle5);
  }
  async createFive() {
    this.fillVehicleList();

    await Promise.all([
      this.parkingService.checkIn(this.vehicleListsForTest[0]),
      this.parkingService.checkIn(this.vehicleListsForTest[1]),
      this.parkingService.checkIn(this.vehicleListsForTest[2]),
      this.parkingService.checkIn(this.vehicleListsForTest[3]),
      this.parkingService.checkIn(this.vehicleListsForTest[4]),

      // this.parkingService.checkIn(this.vehicleListsForTest[3]),
      //  this.parkingService.checkIn(this.vehicleListsForTest[4]), 
    ]);
    this.getParkingState();
  }

  getParkingState() {
    this.parkingService.getParkingState(null);
  }
}
