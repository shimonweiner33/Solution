import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { cloneDeep } from 'lodash';
import { BehaviorSubject } from 'rxjs';
import { CheckInDetails } from '../models/check-in-details';
import { Vehicles } from '../models/vehicle';
@Injectable({
  providedIn: 'root'
})
export class ParkingService {
  private vehicles : CheckInDetails[] = [];
  private _VehicleListResponse$ = new BehaviorSubject<Vehicles>(null);
  public VehicleList$ = this._VehicleListResponse$.asObservable();

  constructor(private http: HttpClient) { }

  checkIn(checkInDetails: CheckInDetails) {
    checkInDetails = cloneDeep(checkInDetails);
    checkInDetails.ticketType += 1;
    checkInDetails.vehicleType += 1;
    console.log("licencePlateId = " + checkInDetails.licencePlateId)
    return this.http.post<any>(`https://localhost:44394/Parking/CheckIn`, checkInDetails,
      { observe: 'response', withCredentials: true })
  }

  checkOut(licencePlateId: string) {
    const data = JSON.stringify(licencePlateId);
    return this.http.post<any>(`https://localhost:44394/Parking/CheckOut`, data, {headers: new HttpHeaders()
    .set('Content-Type', 'application/json')})
      .subscribe((data: any) => {
        if (data) {
          console.log(data);
        }
      }, err => {

      })
  }

  getParkingState(ticketType: Number) {

    let url = "https://localhost:44394/Parking/GetVehiclesByTicketType"  
    if(ticketType){
      url += "?ticketType="+ticketType
    }
    this.http.get(url).subscribe((res: any) => {
      this._VehicleListResponse$.next(res)

    }, err => {

    })
  }
}
