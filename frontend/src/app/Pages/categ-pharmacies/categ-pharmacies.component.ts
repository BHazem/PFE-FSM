import { Component, OnInit, ViewChild } from '@angular/core';
import {MedicationsService } from '../../medications.service';
import { ActivatedRoute } from '@angular/router';
import {MatPaginator} from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-categ-pharmacies',
  templateUrl: './categ-pharmacies.component.html',
  styleUrls: ['./categ-pharmacies.component.css']
})
export class CategPharmaciesComponent implements OnInit {

  dataSource = new MatTableDataSource;
  Drug  : any;
  constructor(private medicService: MedicationsService,
    private route: ActivatedRoute) { }
    displayedColumns: string[] = ['Pharmacy','Cash_Price','Coupon_Available','Delivery_Type','Timeframe','Action'];
    @ViewChild(MatPaginator) paginator?: MatPaginator;

/*-------------get Drug Pharmacies-----------*/
getDrugPharmacies()
{
  const id =+ this.route.snapshot.paramMap.get('Drug_id')!;
  this.medicService.getDrugPharmacies(id).subscribe(
    res => {
      this.dataSource.data = res;
      this.dataSource.paginator = this.paginator!;
    });
}
/*--------------Get Drug By ID-----------*/
getDrugByID(){
  const id =+ this.route.snapshot.paramMap.get('Drug_id')!;
  this.medicService.getDrugByID(id).subscribe(
    res => {this.Drug = res;
    });
}
  ngOnInit() {
    this.getDrugByID();
    this.getDrugPharmacies();
}
}
