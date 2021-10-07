import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ParkingService {

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

  showAll() {
    return this.http.get<any>(`https://localhost:44394/Parking/GetVehiclesByTicketType`)
    .subscribe((data: any) => {
        if (data) {
          console.log(data);
        }
      }, err => {

      })
  }
}
