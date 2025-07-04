using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Handlers
{
	public class Pharmacy
	{
		public static List<core.Models.Drug_pharmacy_Model> Getpharmacies(int id_drug)
		{
			try
			{
				var DrugPharmacy = Infrastructure.Data.Access.Tables.DrugPharmacyAccess.Get(id_drug);
				var DrugPharmacies = new List<core.Models.Drug_pharmacy_Model>();
				
				var Pharmacies = Infrastructure.Data.Access.Tables.PharmacyAccess.Get(DrugPharmacy.Select(x => x.ID_pharmacy).Distinct().ToList());
				
				foreach (Infrastructure.Data.Entities.Tables.DrugPharmacyEntity drug in DrugPharmacy)
				{
					var Pharmacy = Pharmacies.Find(x => x.ID_pharmacy == drug.ID_pharmacy);
					DrugPharmacies.Add(new core.Models.Drug_pharmacy_Model()
					{
						id_pharmacy = drug.ID_pharmacy ,
						pharmacy_name = Pharmacy.nom_pharmacy,
						delivery_type = drug.delivery_type,
						coupon = drug.coupon,
						cash_price = Convert.ToInt32(drug.cash_price),
						timeframe = drug.timeframe
					});
				}
				return DrugPharmacies;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public static core.Models.Pharmacy_Model GetpharmacieByID(int id_Pharmacy)
		{
			try
			{
				var DrugPharmacy = Infrastructure.Data.Access.Tables.PharmacyAccess.Get(id_Pharmacy);
				var DrugPharmacies = new core.Models.Pharmacy_Model();

				DrugPharmacies.ID_pharmacy = DrugPharmacy.ID_pharmacy;
				DrugPharmacies.nom_pharmacy = DrugPharmacy.nom_pharmacy;
				DrugPharmacies.phone = DrugPharmacy.phone;
				DrugPharmacies.Ncpdp_Prov_ID = DrugPharmacy.Ncpdp_Prov_ID;
				DrugPharmacies.adresse = DrugPharmacy.adresse;

				return DrugPharmacies;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public static List<core.Models.Prescription_Drug_Pharmacy_Model> GetDrugPharmacyByID(int id_drug,int id_Pharmacy)
		{
			try
			{
				var DrugPharmacy = Infrastructure.Data.Access.Tables.DrugPharmacyAccess.GetDrugPharmacy(id_drug, id_Pharmacy);
				var drug = Infrastructure.Data.Access.Tables.DrugAccess.Get(id_drug);
				var DrugPharmacies = new List<core.Models.Prescription_Drug_Pharmacy_Model>();

				DrugPharmacies.Add(new core.Models.Prescription_Drug_Pharmacy_Model() {
				
				id_drug_pharmacy = DrugPharmacy.ID_drugpharmacy,
				drug_name = drug.nom_drug,
				cash_price = DrugPharmacy.cash_price,
				coupon = DrugPharmacy.coupon,
				delivery_type = DrugPharmacy.delivery_type,
				timeframe = DrugPharmacy.timeframe
			});
				
				return DrugPharmacies;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static List<core.Models.DrugInfos> GetDrusPharmacies(List<int> id_drugs)
		{
			try
			{
				var drugPharmacies = Infrastructure.Data.Access.Tables.DrugPharmacyAccess.Get(id_drugs);
				var Pharmacies = Infrastructure.Data.Access.Tables.PharmacyAccess.Get(drugPharmacies.Select(x => x.ID_pharmacy).Distinct().ToList());
				var DrugPharmacy = new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
				

				var DrugPharmacy1 = new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
				var drugs = Infrastructure.Data.Access.Tables.DrugAccess.Get();
				int l = 0;

				var DrugPharmacies = new List<core.Models.DrugInfos>();
				var DrugPharmacies2 = new List<core.Models.DrugInfos>();

				for (int i = 0; i<drugPharmacies.Count()-1;i++)
				{
					 DrugPharmacy = drugPharmacies.FindAll(x => x.ID_pharmacy == drugPharmacies[i].ID_pharmacy);
					if(DrugPharmacy.Count() == id_drugs.Count())
					{
						foreach (var fff in DrugPharmacy) {
							if(DrugPharmacy1.Find(x => x == fff) == null)
							{
								DrugPharmacy1.Add(fff);
							}
						}
					}
				}

				foreach (var drugPhar in DrugPharmacy1)
				{
					
					
					var list = new List<core.Models.Drug_Info_Model>();
					var pharmacy = Pharmacies.Find(x => x.ID_pharmacy == drugPhar.ID_pharmacy);
					var DrugPharmacy2 = DrugPharmacy1.FindAll(x => x.ID_pharmacy == drugPhar.ID_pharmacy);

					foreach(var item in DrugPharmacy2)
					{
						var drug1 = drugs.Find(x => x.ID_drug == item.ID_drug);
						if(list.Find(x => x.Drug_name == drug1.nom_drug) == null)
						{
							list.Add(new core.Models.Drug_Info_Model()
							{
								Drug_name = drug1.nom_drug,
								cash_price = item.cash_price,
								coupon = item.coupon,
								delivery_type = item.delivery_type,
								timeframe = item.timeframe
							});
						}
					}
					if (DrugPharmacies.Find(x => x.id_pharmacy == pharmacy.ID_pharmacy) == null)
					{
						DrugPharmacies.Add(new core.Models.DrugInfos()
						{
							id_pharmacy = pharmacy.ID_pharmacy,
							pharmacy_name = pharmacy.nom_pharmacy,
							drugInfos = list
						});
					}
				}	
				return DrugPharmacies;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}


		public static core.Models.DrugInfos GetDrusPharmaciesBYID(List<int> id_drugs ,int id_pharmacy)
		{
			try
			{
				var drugPharmacies = Infrastructure.Data.Access.Tables.DrugPharmacyAccess.Get(id_drugs);
				var Pharmacies = Infrastructure.Data.Access.Tables.PharmacyAccess.Get(drugPharmacies.Select(x => x.ID_pharmacy).Distinct().ToList());
				var DrugPharmacy = new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
				var drug9 = Infrastructure.Data.Access.Tables.DrugPharmacyAccess.Get();

				var DrugPharmacy1 = new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
				var drugs = Infrastructure.Data.Access.Tables.DrugAccess.Get();
				int l = 0;

				var DrugPharmacies = new List<core.Models.DrugInfos>();
				var DrugPharmacies2 = new List<core.Models.DrugInfos>();

				for (int i = 0; i < drugPharmacies.Count() - 1; i++)
				{
					DrugPharmacy = drugPharmacies.FindAll(x => x.ID_pharmacy == drugPharmacies[i].ID_pharmacy);
					if (DrugPharmacy.Count() == id_drugs.Count())
					{
						foreach (var fff in DrugPharmacy)
						{
							if (DrugPharmacy1.Find(x => x == fff) == null)
							{
								DrugPharmacy1.Add(fff);
							}
						}
					}
				}

				foreach (var drugPhar in DrugPharmacy1)
				{


					var list = new List<core.Models.Drug_Info_Model>();
					var pharmacy = Pharmacies.Find(x => x.ID_pharmacy == drugPhar.ID_pharmacy);
					var DrugPharmacy2 = DrugPharmacy1.FindAll(x => x.ID_pharmacy == drugPhar.ID_pharmacy);
					
					foreach (var item in DrugPharmacy2)
					{
						var drug1 = drugs.Find(x => x.ID_drug == item.ID_drug);
						var drug2 = drug9.Find(x => x.ID_drug == item.ID_drug && x.ID_pharmacy == id_pharmacy);
						if (list.Find(x => x.Drug_name == drug1.nom_drug) == null)
						{
							list.Add(new core.Models.Drug_Info_Model()
							{	
								id_drugPharmacy = drug2.ID_drugpharmacy,
								Drug_name = drug1.nom_drug,
								cash_price = item.cash_price,
								coupon = item.coupon,
								delivery_type = item.delivery_type,
								timeframe = item.timeframe
							});
						}
					}
					if (DrugPharmacies.Find(x => x.id_pharmacy == pharmacy.ID_pharmacy) == null)
					{
						DrugPharmacies.Add(new core.Models.DrugInfos()
						{	
							id_pharmacy = pharmacy.ID_pharmacy,
							pharmacy_name = pharmacy.nom_pharmacy,
							drugInfos = list
						});
					}
				}

				var drugpharma = DrugPharmacies.Find(x => x.id_pharmacy == id_pharmacy);

				return drugpharma;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
