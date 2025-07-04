import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintTableBundleComponent } from './print-table-bundle.component';

describe('PrintTableBundleComponent', () => {
  let component: PrintTableBundleComponent;
  let fixture: ComponentFixture<PrintTableBundleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintTableBundleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintTableBundleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
