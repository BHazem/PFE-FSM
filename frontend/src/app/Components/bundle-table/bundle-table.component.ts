import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MedicationsService } from '../../medications.service';

@Component({
  selector: 'app-bundle-table',
  templateUrl: './bundle-table.component.html',
  styleUrls: ['./bundle-table.component.css']
})
export class BundleTableComponent implements OnInit {



  @ViewChild(MatPaginator) paginator?: MatPaginator;
  dataSource = new MatTableDataSource;
  drugpharmacies : any;

  displayedColumns: string[] = [
    'Pharmacy',
    'Insurance',
    'Cash',
    'Delivery_Type',
    'Timeframe',
    'Action',
  ];

  constructor(private medicService: MedicationsService) {}

  /*-------------get Total Cash Price ------------------*/
  getTotalPrice(element : any){
    var k : number =0;
    for(var i:number =0 ; i<element.drugInfos.length;i++){
       k += element.drugInfos[i].cash_price;
    }
    return k;
  }
  /*--------get delivery Type-------------*/
  getDeliveryType(element : any){
    var delivery : string = element.drugInfos[0].delivery_type;
    for(var i:number =1 ; i<element.drugInfos.length;i++){
      if(delivery == element.drugInfos[i].delivery_type){
        continue;
      }else{
        delivery = "--";
        break;
      }
    }
    return delivery;
  }
  /*--------get TimeFrame-------------*/
  getTimeframe(element : any){
    var Timeframe : string = element.drugInfos[0].timeframe;
    for(var i:number =1 ; i<element.drugInfos.length;i++){
      if(Timeframe == element.drugInfos[i].timeframe){
        continue;
      }else{
        Timeframe = "--";
        break;
      }
    }
    return Timeframe;
  }
  /*--------get coupon-------------*/
  getcoupon(element : any){
    var coupon : string = element.drugInfos[0].coupon;
    for(var i:number =1 ; i<element.drugInfos.length;i++){
      if(coupon == element.drugInfos[i].coupon){
        continue;
      }else{
        coupon = "--";
        break;
      }
    }
    return coupon;
  }
  /*------------get drug Informations-------------*/
  getInformations(element : any){
    return element.drugInfos;
  }

  ngOnInit() {
    if(this.medicService.i == 1){
      this.medicService.getDrugsPharmacies1().subscribe(
        res => {
          this.drugpharmacies = res
          this.medicService.i == 0;
        }
      );
    }

    this.medicService.getObservable().subscribe((data)=>{
      this.drugpharmacies = data
    })
  }
}
