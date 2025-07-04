import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BundleTableComponent } from './bundle-table.component';

describe('BundleTableComponent', () => {
  let component: BundleTableComponent;
  let fixture: ComponentFixture<BundleTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BundleTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BundleTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
