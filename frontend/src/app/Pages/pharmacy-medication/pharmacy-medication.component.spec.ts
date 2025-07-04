import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PharmacyMedicationComponent } from './pharmacy-medication.component';

describe('PharmacyMedicationComponent', () => {
  let component: PharmacyMedicationComponent;
  let fixture: ComponentFixture<PharmacyMedicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PharmacyMedicationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PharmacyMedicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
