import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CheckInDetails, Vehicles } from '../models/check-in-details';

@Injectable({
  providedIn: 'root'
})
export class ParkingService {
  private vehicles : CheckInDetails[] = [];
  private _VehicleListResponse$ = new BehaviorSubject<Vehicles>(null);
  public VehicleList$ = this._VehicleListResponse$.asObservable();

  constructor(private http: HttpClient) { }

  checkIn(checkInDetails: CheckInDetails) {
    return this.http.post<any>(`https://localhost:44394/Parking/CheckIn`, checkInDetails,
      { observe: 'response', withCredentials: true })
      .subscribe((data: any) => {
        if (data) {
          console.log(data);
        }
      }, err => {

      })
  }

  checkOut(licencePlateId: string) {
    const data = JSON.stringify(licencePlateId);
    return this.http.post<any>(`https://localhost:44394/Parking/CheckOut`, data, {headers: new HttpHeaders().set('Content-Type', 'application/json')})
      //{ observe: 'response', withCredentials: true })
      .subscribe((data: any) => {
        if (data) {
          console.log(data);
        }
      }, err => {

      })
  }

  // getParkingState() {
  //   return this.http.get<CheckInDetails[]>(`https://localhost:44394/Parking/GetVehiclesByTicketType`)
  //   .subscribe((data: CheckInDetails[]) => {
  //       if (data) {
  //         this.vehicles = data;
  //         console.log(data);
  //       }
  //     }, err => {

  //     })
  // }


  getParkingState(ticketType: Number) {

    //this._VehicleListResponse$.next(null)
    let url = "https://localhost:44394/Parking/GetVehiclesByTicketType"  
    if(ticketType){
      url += "?ticketType="+ticketType
    }
    this.http.get(url).subscribe((res: Vehicles) => {
      this._VehicleListResponse$.next(res)

    }, err => {

    })
  }
}
