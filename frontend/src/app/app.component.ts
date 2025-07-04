import { Component, OnInit } from '@angular/core';
import {MedicationsService } from '../app/medications.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit{
  title = 'pfeoff';
  opened = false;
  Table : any[] = [];
  selected : any;
  drugs : any;
  constructor(private medicService: MedicationsService) { }

  toggleSidebar() {
    this.opened = !this.opened;
    let domEl: HTMLElement | null = document.querySelector('#mySidebar');
    domEl && (domEl.style.width = '300px');
    if (this.opened) {
      this.toggleside();
    }
  }

  /*-----------------remove from bundle---------------*/
  delete(med : any){
    this.selected = med;
    const index = this.Table.indexOf(this.selected)!;
    this.Table.splice(index, 1);


    let domEl: HTMLElement | null = document.querySelector('#add'+this.selected.id_drug);
    domEl && (domEl.style.display = 'block');

    if(this.Table.length == 0){
      let domEl1: HTMLElement | null = document.querySelector('#Bundle');
    domEl1 && (domEl1.style.visibility = 'hidden');
    }
}

  toggleside() {
    let domEl: HTMLElement | null = document.querySelector('#mySidebar');
    domEl && (domEl.style.width = '0px');
  }

  get(){
 this.medicService.getDrugsPharmacies1().subscribe(
   res =>{
     this.drugs = res;
     this.medicService.publish(this.drugs);
   }
 )
  }


  ngOnInit(){
    this.Table = this.medicService.table;
    if(this.medicService.BundleVariable == 1){
      let domEl1: HTMLElement | null = document.querySelector('#Bundle');
    domEl1 && (domEl1.style.visibility = 'hidden');
    }else if((this.Table.length != 0)&&(this.medicService.BundleVariable == 0)){
      let domEl1: HTMLElement | null = document.querySelector('#Bundle');
    domEl1 && (domEl1.style.visibility = 'visible');
    }
  }
}
