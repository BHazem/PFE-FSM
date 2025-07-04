import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BundlePrintComponent } from './bundle-print.component';

describe('BundlePrintComponent', () => {
  let component: BundlePrintComponent;
  let fixture: ComponentFixture<BundlePrintComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BundlePrintComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BundlePrintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
