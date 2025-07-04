import { Component, OnInit, ViewChild } from '@angular/core';
import {MedicationsService } from '../../medications.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ElementRef } from '@angular/core';
import html2canvas from 'html2canvas';
import  jspdf from 'jspdf';
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
pdfMake.vfs = pdfFonts.pdfMake.vfs;
import htmlToPdfmake from 'html-to-pdfmake';
import { drugpharmacie } from 'src/medications';


@Component({
  selector: 'app-pharmacyinformations',
  templateUrl: './pharmacyinformations.component.html',
  styleUrls: ['./pharmacyinformations.component.css']
})
export class PharmacyinformationsComponent implements OnInit {
  @ViewChild('prescription',{static : true}) el! : ElementRef<HTMLImageElement>;
  drug : any;
  s:any;
  response : any;
  objet : drugpharmacie= {nom_pharmacie:"", patient_name:"", Email_patient:"", IDS_drugPharmacy:[]} ;
  pharmacy: any;
  drugpharmacy: any[] =[];
  public today = Date.now();
  displayedColumns: string[] = ['Prescription','Coupon','Cash','Delivery_Type','Timeframe'];

  constructor(private medicService: MedicationsService,
    private route: ActivatedRoute,
    private location: Location) { }

    ngOnInit(){
      this.getDrugpharmacybyID();
      this.getPharmacyByID();
  }

 /*------------get Date-------------*/
  utcTime(): void {
    setInterval(() => {
         this.today = Date.now();
       }, 100);
}

/*--------------go back-------------*/
  goBack(){
    this.location.back();
  }

/*------------get Pharmacy by id--------------*/
getPharmacyByID(){
  const id =+ this.route.snapshot.paramMap.get('Pharmacy_ID')!;
  this.medicService.getPharmacyByID(id).subscribe(
    res => {
      this.pharmacy = res;
    }
  );
}

/*-------------get drug pharmacy by id-------------*/
getDrugpharmacybyID()
{
  const id =+ this.route.snapshot.paramMap.get('Pharmacy_ID')!;
  const id1 =+ this.route.snapshot.paramMap.get('Drug_ID')!;
  this.medicService.getDrugPharmacybyID(id1,id).subscribe(
    res1 => {
      this.drugpharmacy = res1;
    }
  );
}
/*-------------send Email-------------*/
sendEmail(email : string){
  this.medicService.sendEmail(email).subscribe(
    res =>{
      this.s = res;
        alert(this.s.response);
    }
  )
}

@ViewChild('prescription') pdfTable: ElementRef;

postPrescription( patientName : string , Email : string){
  this.objet.patient_name = patientName;
  this.objet.Email_patient = Email;
  for(let item of this.drugpharmacy){
    this.objet.IDS_drugPharmacy = item.id_drug_pharmacy;
  }
  this.objet.nom_pharmacie = this.pharmacy.nom_pharmacy;

  this.medicService.Post( this.objet.patient_name,this.objet.nom_pharmacie, this.objet.IDS_drugPharmacy,this.objet.Email_patient).subscribe(
    res => {
    this.response = res
    alert("prescription n°: "+res.id_prescription+" added successfully");
    });
}

postPrescription1(){

  this.objet.IDS_drugPharmacy = this.drugpharmacy;
  this.objet.nom_pharmacie = this.pharmacy.nom_pharmacy;
  for(let item of this.drugpharmacy){
  this.objet.IDS_drugPharmacy = item.id_drug_pharmacy;
  }
  this.medicService.Post(this.objet.patient_name,this.objet.nom_pharmacie, this.objet.IDS_drugPharmacy,this.objet.Email_patient).subscribe(
    res => {
    this.response = res
    alert("prescription n°: "+res.id_prescription+" added successfully");
    });
}

public downloadAsPDF() {
  const doc = new jspdf();
  const pdfTable = this.pdfTable.nativeElement;
  var html = htmlToPdfmake(pdfTable.innerHTML);
  const documentDefinition = { content: html };
  pdfMake.createPdf(documentDefinition).open();
}

  print(){
    window.print();
  }
}
