import { Component, OnInit } from '@angular/core';
import { MedicationsService } from 'src/app/medications.service';
import { ActivatedRoute } from '@angular/router';
import {Location} from '@angular/common';
import { drugpharmacie } from 'src/medications';

@Component({
  selector: 'app-bundle-print',
  templateUrl: './bundle-print.component.html',
  styleUrls: ['./bundle-print.component.css']
})
export class BundlePrintComponent implements OnInit {

  objet : drugpharmacie= {nom_pharmacie:"", patient_name:"", Email_patient:"", IDS_drugPharmacy:[]} ;
  pharmacy: any;
  s:any;
  ids : number[] =[];
  DrugsPharmacies : any;
  response : any;
  public today = Date.now();

  constructor(private medicService: MedicationsService,
    private route: ActivatedRoute,
    private _location: Location ) { }

  ngOnInit(): void {
    this.get();
    this.getPharmacyByID();

  }
 /*------------get Date-------------*/
 utcTime(): void {
  setInterval(() => {
       this.today = Date.now();
     }, 100);
}

  print(){
    window.print();
  }
/*------------get Pharmacy by id--------------*/
getPharmacyByID(){
  const id =+ this.route.snapshot.paramMap.get('pharmacy')!;
  this.medicService.getPharmacyByID(id).subscribe(
    res => {
      this.pharmacy = res;
    }
  );
}
/*-----------go back--------*/
backClicked() {
  this._location.back();
  this.medicService.i = 1;
}
/*-----------send Email----------*/
/*-------------send Email-------------*/
sendEmail(email : string){
  this.medicService.sendEmail(email).subscribe(
    res =>{
      this.s = res;
        alert(this.s.response);
    }
  )
}

get()
{
  const id =+ this.route.snapshot.paramMap.get('pharmacy')!;
  this.medicService.getDrugsPharmaciesBYID(id).subscribe(
    res =>{
      this.DrugsPharmacies = res;
    }
  );
}
/*--------------save prescription----------*/
postPrescription( patientName : string , Email : string){
  this.objet.patient_name = patientName;
  this.objet.Email_patient = Email;
  for(let item of this.DrugsPharmacies.drugInfos){
    this.ids.push(item.id_drugPharmacy);
  }
  this.objet.nom_pharmacie = this.pharmacy.nom_pharmacy;

  this.medicService.Post1( this.objet.patient_name,this.objet.nom_pharmacie, this.ids,this.objet.Email_patient).subscribe(
    res => {
    this.response = res
    alert("prescription n°: "+res.id_prescription+" added successfully");
    });
}

postPrescription1(){
  this.objet.IDS_drugPharmacy = this.DrugsPharmacies;
  this.objet.nom_pharmacie = this.pharmacy.nom_pharmacy;
  for(let item of this.DrugsPharmacies.drugInfos){
  this.ids.push(item.id_drugPharmacy);
  }
  this.medicService.Post1(this.objet.patient_name,this.objet.nom_pharmacie, this.ids,this.objet.Email_patient).subscribe(
    res => {
    this.response = res
    alert("prescription n°: "+res.id_prescription+" added successfully");
    });
}

}
