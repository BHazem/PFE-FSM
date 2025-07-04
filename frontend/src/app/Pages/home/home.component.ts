import { Component, OnInit, ViewChild } from '@angular/core';
import {MedicationsService } from '../../medications.service';
import {
  debounceTime, distinctUntilChanged, switchMap
} from 'rxjs/operators';
import { Observable, Subject } from 'rxjs';
import {MatPaginator} from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {Location} from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  Categories : any;
  medicate : any[] = [];
  medications$ !: Observable<any[]>;
  selected : any;
  dataSource = new MatTableDataSource;
  private searchTerms = new Subject<string>();

  displayedColumns: string[] = ['Medication','Strength','Strength_Unit','Form','Action','Add_to_bundle'];


  @ViewChild(MatPaginator) paginator?: MatPaginator;

  constructor(private medicService: MedicationsService,
    private _location: Location) {
  }
  /*-------------------Drugs Informations-------------*/
  tableMed(term1 : string){
   this.medicService.GetDrugsByName(term1).subscribe(
      res => {
        this.dataSource.data = res;
        this.dataSource.paginator = this.paginator!;
      });
  }

  search(term: string): void {
    this.searchTerms.next(term);
  }

/*--------------show and hide Input--------------*/
  inputoff(){
    let domEl: HTMLElement | null = document.querySelector('#search-result');
    domEl && (domEl.style.display = 'none');
  }

  inputon(){
    let domEl: HTMLElement | null = document.querySelector('#search-result');
    domEl && (domEl.style.display = 'block');
  }

/*----------------Hide categories and show table-------------*/
  searchs(){
    let domEl: HTMLElement | null = document.querySelector('#categories');
    domEl && (domEl.style.display = 'none');

    let domEl1: HTMLElement | null = document.querySelector('#table');
    domEl1 && (domEl1.style.display = 'block');

    let domEl3: HTMLElement | null = document.querySelector('#backbtn');
    domEl3 && (domEl3.style.display = 'block');
  }
 /*-------Add to bundle----------*/
 onSelect(med: any) {
  this.selected = med;
  this.medicService.table.push(this.selected);

 let domEl: HTMLElement | null = document.querySelector('#add'+this.selected.id_drug);
  domEl && (domEl.style.display = 'none');

  let domEl1: HTMLElement | null = document.querySelector('#Bundle');
  domEl1 && (domEl1.style.visibility = 'visible');
}
/*----------------back---------------*/
backClicked() {
  let domEl1: HTMLElement | null = document.querySelector('#table');
  domEl1 && (domEl1.style.display = 'none');

  let domEl3: HTMLElement | null = document.querySelector('#backbtn');
  domEl3 && (domEl3.style.display = 'none');

  let domEl: HTMLElement | null = document.querySelector('#categories');
    domEl && (domEl.style.display = 'block');
}

  ngOnInit(){
/*---------GetCategories----------*/
    this.medicService.GetCategories()
    .subscribe(data => {
      this.Categories = data
    });

/*-------------search Drugs--------------*/
    this.medications$ = this.searchTerms.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(200),
      // ignore new term if same as previous term
      distinctUntilChanged(),
      // switch to new search observable each time the term changes
      switchMap((term: string) => this.medicService.GetDrugsByName(term)),
    );
  }

}
