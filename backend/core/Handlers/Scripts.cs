using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Handlers
{
	public class Scripts
	{

		public static int LoadDrugsData()
		{
			try
			{
				var drugsToLoad = new List<Infrastructure.Data.Entities.Tables.DrugEntity>();
				var DrugsFromExcel = Infrastructure.Data.Access.Tables.Feuil1Access.Get();
				var DrugInfo = Infrastructure.Data.Access.Tables.Feuil3Access.Get();
				var categories = Infrastructure.Data.Access.Tables.CategoryAccess.Get();
				var Drug_Info = Infrastructure.Data.Access.Tables.Feuil3Access.Get();

				foreach (var drug in DrugsFromExcel)
				{
					var category = categories.Find(x => x.nom_category==drug.ClassName);
					var drugInfo = DrugInfo.Find(x => x.drug_descriptor_id == drug.DDI);
					if(drug.Gpi != null && drugsToLoad.Find(x => x.DDI == drug.DDI) == null)
					{
						drugsToLoad.Add(new Infrastructure.Data.Entities.Tables.DrugEntity()
						{
							ID_category = category.ID_categroy,
							nom_drug = drug.Expr1,
							DDI = drug.DDI,
							GPI14 = drug.Gpi,
							form = drugInfo.dosage_form,
							strengthUnit = drugInfo.strength_unit_of_measure,
							strength = drugInfo.strength
						});
					}

				}
				int a = Infrastructure.Data.Access.Tables.DrugAccess.Insert(drugsToLoad);
				return a;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public static int LoadDrugPharmacyData()
		{
			try
			{
				var drugPharmacyToLoad = new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
				var Drugs = Infrastructure.Data.Access.Tables.DrugAccess.Get();
				var DrugsFromExcel = Infrastructure.Data.Access.Tables.Feuil1Access.Get();
				var pharmaciesFromExcel = Infrastructure.Data.Access.Tables.Feuil2Access.Get();
				var Pharmacies = Infrastructure.Data.Access.Tables.PharmacyAccess.Get();

				foreach (var drug in DrugsFromExcel)
				{ var DrugByname = Drugs.Find(x => x.nom_drug == drug.Expr1);
					var pharmacyfromDrugExcel = pharmaciesFromExcel.Find(x => x.Name == drug.Name);
					var pharmacy = Pharmacies.Find(x => x.nom_pharmacy == pharmacyfromDrugExcel.Name1);

					drugPharmacyToLoad.Add(new Infrastructure.Data.Entities.Tables.DrugPharmacyEntity()
					{
						 ID_pharmacy = pharmacy.ID_pharmacy,
						  ID_drug = DrugByname.ID_drug,
						   cash_price = drug.PriceToPay,
						    delivery_type = drug.Delivery,
							 coupon = drug.Coupon,
							  timeframe = drug.Timeframe
					});
				}
				int b = Infrastructure.Data.Access.Tables.DrugPharmacyAccess.Insert(drugPharmacyToLoad);
				return b;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
