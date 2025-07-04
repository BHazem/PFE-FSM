import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PharmacyinformationsComponent } from './pharmacyinformations.component';

describe('PharmacyinformationsComponent', () => {
  let component: PharmacyinformationsComponent;
  let fixture: ComponentFixture<PharmacyinformationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PharmacyinformationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PharmacyinformationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
