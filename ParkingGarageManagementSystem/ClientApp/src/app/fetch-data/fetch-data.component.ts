import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: CheckInDetails[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<CheckInDetails[]>(baseUrl + 'checkInDetails').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface CheckInDetails {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
