import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Pages/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import { PharmacyMedicationComponent } from './Pages/pharmacy-medication/pharmacy-medication.component';
import { PharmacyinformationsComponent } from './Pages/pharmacyinformations/pharmacyinformations.component';
import { CategorypageComponent } from './Pages/categorypage/categorypage.component';
import { BundleDetailsComponent } from './Pages/bundle-details/bundle-details.component';
import { BundleTableComponent } from './Components/bundle-table/bundle-table.component';
import { PrintTableBundleComponent } from './Components/print-table-bundle/print-table-bundle.component';
import { BundlePrintComponent } from './Pages/bundle-print/bundle-print.component';
import { HttpClientModule  } from '@angular/common/http';
import { CategPharmaciesComponent } from './Pages/categ-pharmacies/categ-pharmacies.component';
import {MatTreeModule} from '@angular/material/tree';
import {MatExpansionModule} from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';

const material =[
MatTableModule,
MatPaginatorModule,
MatTreeModule,
MatExpansionModule,
MatListModule
]

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PharmacyMedicationComponent,
    PharmacyinformationsComponent,
    CategorypageComponent,
    BundleDetailsComponent,
    BundleTableComponent,
    PrintTableBundleComponent,
    BundlePrintComponent,
    CategPharmaciesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    material,
    HttpClientModule
  ],
  exports:[material],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
