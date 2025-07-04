import { Component, OnInit, ViewChild } from '@angular/core';
import {MedicationsService } from '../../medications.service';
import { ActivatedRoute } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-categorypage',
  templateUrl: './categorypage.component.html',
  styleUrls: ['./categorypage.component.css']
})
export class CategorypageComponent implements OnInit {

name : string="";
id_category : number=0;
medications : any[] = [];
selected : any;
Categorie : any;



@ViewChild(MatPaginator) paginator?: MatPaginator;
dataSource = new MatTableDataSource;

displayedColumns: string[] = ['Drug','Strength','Strength_Unit','Form','Action','Add_to_bundle'];
  constructor(private medicService: MedicationsService,
    private route: ActivatedRoute,
    private http : HttpClient) { }

/*---------GetCategories----------*/
getCategorieName()
{
const id =+ this.route.snapshot.paramMap.get('category')!;
this.medicService.getCategorybyID(id).subscribe(
  res => {
   this.Categorie = res;
  });
}
/*-------------getDrugs By category-----------*/
getCategories()
{
  const id =+ this.route.snapshot.paramMap.get('category')!;
  this.medicService.getCategoryDrugs(id).subscribe(
    res => {
      this.dataSource.data = res;
      this.dataSource.paginator = this.paginator!;
    });
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

ngOnInit(){
  this.name = this.route.snapshot.paramMap.get('categoryName')!;
  this.getCategorieName();
  this.getCategories();
  }
}

