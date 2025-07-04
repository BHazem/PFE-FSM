import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient,HttpHeaders} from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { Subject } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class MedicationsService {
  private CategorieUrl = 'https://localhost:44348/api/PrescriptionMarketplace/GetCategories';
  private categorieUrl ='https://localhost:44348/api/PrescriptionMarketplace/GetCategoryByID';
  private SearchDrugsUrl = 'https://localhost:44348/api/PrescriptionMarketplace/GetdDrugs';
  private CategorieDrugsUrl = 'https://localhost:44348/api/PrescriptionMarketplace/GetDrugsByCategories';
  private DrugPharmaciesUrl = 'https://localhost:44348/api/PrescriptionMarketplace/Getpharmacies';
  private DrugByIDUrl = 'https://localhost:44348/api/PrescriptionMarketplace/GetDrugByID';
  private PharmacyByIDUrl = 'https://localhost:44348/api/PrescriptionMarketplace/GetPharmacyById';
  private Prescription_DrugPharmacyUrl = 'https://localhost:44348/api/PrescriptionMarketplace/GetDrugPharmacyByID';
  private DrugsPharmaciesUrl = 'https://localhost:44348/api/PrescriptionMarketplace/GetDrugsPharmacies';
  private DrugsPharmaciesBYIDUrl = 'https://localhost:44348/api/PrescriptionMarketplace/GetDrusPharmaciesBYID';
  private sendEmailUrl='https://localhost:44348/api/PrescriptionMarketplace/SendEmail';
  private postPresUrl = 'https://localhost:44348/api/PrescriptionMarketplace/Post';

  table : any[] = [];
  drugs : any[]= [];
  i : number = 0;
  BundleVariable : number =0;

  private Subject = new Subject<any>();

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  publish(data: any) {
    this.Subject.next(data);
  }

getObservable(): Subject<any> {
    return this.Subject;
}

/*--------------Get Categories--------------*/
GetCategories():Observable<any[]>{
  return this.http.get<any[]>(this.CategorieUrl).pipe(
    catchError(this.handleError<any[]>('GetCategories', []))
  );
}
/*-------------Search Drugs---------------*/
GetDrugsByName (term : string):Observable<any[]>
{
  if (!term.trim()) {
    return of([]);
  }
  return this.http.get<any[]>(`${this.SearchDrugsUrl}/?drug_name=${term}`).pipe(
    catchError(this.handleError<any[]>('GetDrugsByName', []))
  );
}
/*---------------catch Error----------------*/
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
  /*---------------Get drugs by category---------------*/
  getCategoryDrugs(id : number):Observable<any[]>
  {
    return this.http.get<any[]>(`${this.CategorieDrugsUrl}/?id_category=${id}`).pipe(
      catchError(this.handleError<any[]>('getCategoryDrugs', []))
    );
  }
  /*------------Get categorie by id----------------*/
  getCategorybyID(id : number):Observable<any[]>
  {
    return this.http.get<any[]>(`${this.categorieUrl}/?id_categorie=${id}`).pipe(
      catchError(this.handleError<any[]>('getCategorybyID', []))
    );
  }
  /*--------------Get Drug By ID--------------*/
  getDrugByID(id : number):Observable<any[]>{
    return this.http.get<any[]>(`${this.DrugByIDUrl}/?id_Drug=${id}`).pipe(
      catchError(this.handleError<any[]>('getDrugByID', []))
    );
  }
  /*-----------------Get Drug Pharmacies -----------------*/
  getDrugPharmacies(drug_id : number):Observable<any[]>
  {
    return this.http.get<any[]>(`${this.DrugPharmaciesUrl}/?id_drug=${drug_id}`).pipe(
      catchError(this.handleError<any[]>('getDrugPharmacies', []))
    );
  }
  /*------------GEt Pharmacy by id-------------*/
  getPharmacyByID(pharmacy_id : number):Observable<any[]>
  {
    return this.http.get<any[]>(`${this.PharmacyByIDUrl}/?id_Pharmacy=${pharmacy_id}`).pipe(
      catchError(this.handleError<any[]>('getPharmacyByID', []))
    );
  }
/*-----------Get drug pharmacy by id-----------*/
getDrugPharmacybyID(id_drug: number , id_pharmacy:number):Observable<any[]>
{
  return this.http.get<any[]>(`${this.Prescription_DrugPharmacyUrl}/?id_drug=${id_drug}&id_pharmacy=${id_pharmacy}`).pipe(
    catchError(this.handleError<any[]>('getDrugPharmacybyID', []))
  );
}
/*----------------get Drugs Pharmacies--------------*/
getDrugsPharmacies1():Observable<any[]>
{
  var url ="?"
  for(let item of this.table){
    url +="ids="+item.id_drug+"&";
  }
  return this.http.get<any[]>(`${this.DrugsPharmaciesUrl}/`+`${url}`).pipe(
    catchError(this.handleError<any[]>('getDrugsPharmacies', []))
  );
}
/*----------------get Drugs Pharmacies by id--------------*/
getDrugsPharmaciesBYID(i : number):Observable<any[]>
{
  var Url1 ="?"
  for(let item of this.table){
    Url1 +="ids="+item.id_drug+"&";
  }
  return this.http.get<any[]>(`${this.DrugsPharmaciesBYIDUrl}/`+`${Url1}`+`&id_pharmacy2=${i}`).pipe(
    catchError(this.handleError<any[]>('getDrugsPharmacies', []))
  );
}
/*------------send Email--------*/
sendEmail(email : any):Observable<any>{
  return this.http.get<any>(`${this.sendEmailUrl}/?email=${email}`).pipe(
    catchError(this.handleError<any>('sendEmail'))
  );
}
Post(name_patient : any , pharmacie_name : any , Ids : any , email : any){
  var Url1 ="&"
    Url1 +="ids="+Ids;
 return this.http.post(`${this.postPresUrl}/?patient_name=${name_patient}&pharmacie_name=${pharmacie_name}&email=${email}`+`${Url1}`,this.httpOptions).pipe(
  catchError(this.handleError<any>('Post'))
);
}

Post1(name_patient : any , pharmacie_name : any , Ids : number[] , email : any){
  var Url1 ="&"
  for(let item of Ids){
    Url1 +="ids="+item+"&";
  }
 return this.http.post(`${this.postPresUrl}/?patient_name=${name_patient}&pharmacie_name=${pharmacie_name}&email=${email}`+`${Url1}`,this.httpOptions).pipe(
  catchError(this.handleError<any>('Post'))
);
}
  constructor( private http: HttpClient) { }
}
