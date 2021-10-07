import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ParkingService } from 'src/app/services/parking.service';

@Component({
  selector: 'app-parking-check-out',
  templateUrl: './parking-check-out.component.html',
  styleUrls: ['./parking-check-out.component.css']
})
export class ParkingCheckOutComponent implements OnInit {
  parkingControl: FormControl;

constructor(private parkingService: ParkingService) { }
  ngOnInit() {
    console.log(this.parkingService.showAll());
    this.parkingControl = new FormControl('', Validators.required);
  }

  save() {
    this.parkingService.checkOut(this.parkingControl.value);
  }

}
