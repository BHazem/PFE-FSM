import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BundleDetailsComponent } from './Pages/bundle-details/bundle-details.component';
import { BundlePrintComponent } from './Pages/bundle-print/bundle-print.component';
import { CategPharmaciesComponent } from './Pages/categ-pharmacies/categ-pharmacies.component';
import { CategorypageComponent } from './Pages/categorypage/categorypage.component';
import { HomeComponent} from './Pages/home/home.component';
import { PharmacyMedicationComponent } from './Pages/pharmacy-medication/pharmacy-medication.component';
import { PharmacyinformationsComponent } from './Pages/pharmacyinformations/pharmacyinformations.component';


const routes: Routes = [
  {path:'' , component: HomeComponent },
  {path:'PharmacyInformations/:Drug_ID/:Pharmacy_ID', component: PharmacyinformationsComponent},
  {path:'PharmacyMedications/:Drug_ID', component: PharmacyMedicationComponent},
  {path:'Category/:category', component: CategorypageComponent},
  {path:'BundleInformations/:pharmacy', component: BundlePrintComponent},
  {path:'BundleItems', component: BundleDetailsComponent},
  {path:'pharmaciesInformations/:Drug_id', component: CategPharmaciesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
