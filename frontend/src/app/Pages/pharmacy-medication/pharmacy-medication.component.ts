import { Component, OnInit, ViewChild } from '@angular/core';
import {MedicationsService } from '../../medications.service';
import {ActivatedRoute} from '@angular/router';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
@Component({
  selector: 'app-pharmacy-medication',
  templateUrl: './pharmacy-medication.component.html',
  styleUrls: ['./pharmacy-medication.component.css']
})
export class PharmacyMedicationComponent implements OnInit {


  dataSource = new MatTableDataSource;
  Drug  : any;
  constructor(private medicService: MedicationsService,
    private route: ActivatedRoute) { }

    displayedColumns: string[] = ['Pharmacy','Cash_Price','Coupon_Available','Delivery_Type','Timeframe','Action'];

    @ViewChild(MatPaginator) paginator?: MatPaginator;

/*-------------get Drug Pharmacies-----------*/
getDrugPharmacies()
{
  const id =+ this.route.snapshot.paramMap.get('Drug_ID')!;
  this.medicService.getDrugPharmacies(id).subscribe(
    res => {
      this.dataSource.data = res;
      this.dataSource.paginator = this.paginator!;
    });
}
/*--------------Get Drug By ID-----------*/
getDrugByID(){
  const id =+ this.route.snapshot.paramMap.get('Drug_ID')!;
  this.medicService.getDrugByID(id).subscribe(
    res => {this.Drug = res;
    });
}
  ngOnInit() {
    this.getDrugByID();
    this.getDrugPharmacies();
  }
}
