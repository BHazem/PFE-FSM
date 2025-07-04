import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategPharmaciesComponent } from './categ-pharmacies.component';

describe('CategPharmaciesComponent', () => {
  let component: CategPharmaciesComponent;
  let fixture: ComponentFixture<CategPharmaciesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategPharmaciesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategPharmaciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
