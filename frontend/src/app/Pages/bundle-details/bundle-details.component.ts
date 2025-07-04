import { Component, OnInit } from '@angular/core';
import {MedicationsService } from '../../medications.service';

@Component({
  selector: 'app-bundle-details',
  templateUrl: './bundle-details.component.html',
  styleUrls: ['./bundle-details.component.css']
})
export class BundleDetailsComponent implements OnInit {


  constructor(private medicService: MedicationsService) { }


  ngOnInit(): void {

  }



}
