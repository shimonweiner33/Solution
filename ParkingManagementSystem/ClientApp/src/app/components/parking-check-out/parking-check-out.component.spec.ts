import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ParkingCheckOutComponent } from './parking-check-out.component';


describe('ParkingCheckOutComponent', () => {
  let component: ParkingCheckOutComponent;
  let fixture: ComponentFixture<ParkingCheckOutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParkingCheckOutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParkingCheckOutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
