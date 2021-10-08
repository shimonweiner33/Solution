import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ParkingService } from 'src/app/services/parking.service';

@Component({
  selector: 'app-parking-check-in',
  templateUrl: './parking-check-in.component.html',
  styleUrls: ['./parking-check-in.component.css']
})
export class ParkingCheckInComponent implements OnInit {
  parkingForm: FormGroup;
  vehicleTypes = ['Motorcycle', 'Private', 'Crossover', 'SUV', 'Van', 'Truck'];
  ticketTypes = ['VIP', 'Value', 'Regular'];

constructor(private fb: FormBuilder, private parkingService: ParkingService) { }
  ngOnInit() {
    this.parkingForm = this.fb.group({
      licencePlateId: ['', Validators.required],
      name: ['', Validators.required],
      phone: ['', Validators.required],
      ticketType: [0, Validators.required],
      vehicleType: [1, Validators.required],
      vehicleHeight: [0, Validators.required],
      vehicleWidth: [0, Validators.required],
      vehicleLength: [0, Validators.required],
    });
  }

  save() {
    const ticketType = this.parkingForm.get('ticketType');
    ticketType.setValue((ticketType.value) + 1);
    this.parkingService.checkIn(this.parkingForm.value);
  }

}