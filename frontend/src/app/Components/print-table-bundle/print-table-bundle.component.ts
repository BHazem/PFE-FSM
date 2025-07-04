import { AfterViewInit, Component, OnInit} from '@angular/core';
import { MedicationsService } from 'src/app/medications.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-print-table-bundle',
  templateUrl: './print-table-bundle.component.html',
  styleUrls: ['./print-table-bundle.component.css']
})
export class PrintTableBundleComponent implements OnInit {

  DrugsPharmacies : any;
  displayedColumns: string[] = ['Prescription','Insurance','Cash','Delivery_Type','Timeframe'];

  constructor(private medicService: MedicationsService,
    private route: ActivatedRoute) { }

/*---------get drugs pharmacies------- */
get()
{
  const id =+ this.route.snapshot.paramMap.get('pharmacy')!;
  this.medicService.getDrugsPharmaciesBYID(id).subscribe(
    res =>{
      this.DrugsPharmacies = res;
    }
  );
}

  ngOnInit() {
    this.get();
  }

}
