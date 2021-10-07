import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ParkingCheckInComponent } from './parking-check-in.component';


describe('ParkingCheckInComponent', () => {
  let component: ParkingCheckInComponent;
  let fixture: ComponentFixture<ParkingCheckInComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParkingCheckInComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParkingCheckInComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
