using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Handlers
{
	public class Drug
	{
		public static List<core.Models.Search_Drug_Model> GetDrugs(string name_drug)
		{
			var searchedDrugs = new List<core.Models.Search_Drug_Model>();
			try
			{
				if (name_drug != "")
				{
					var Drugs = Infrastructure.Data.Access.Tables.DrugAccess.Get(name_drug);
					if (Drugs.Count() != 0)
					{
						foreach (Infrastructure.Data.Entities.Tables.DrugEntity drug in Drugs)
						{
							searchedDrugs.Add(new core.Models.Search_Drug_Model()
							{
								id_drug = drug.ID_drug,
								drug_name = drug.nom_drug,
								 ddi = drug.DDI,
								  form = drug.form,
								   strength = drug.strength,
								    strengthUnit = drug.strengthUnit
							});
						}
						return searchedDrugs;
					}
					else
					{
						return new List<core.Models.Search_Drug_Model>();
					}
				}
				else
				{
					return new List<core.Models.Search_Drug_Model>();
				}
				
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public static List<core.Models.Category_Drugs_Model> GetDrugsByCategorie(int id)
		{
			try
			{
				var Drugs = Infrastructure.Data.Access.Tables.DrugAccess.GetDrugByCategory(id);
				var DrugsCategory = new List<core.Models.Category_Drugs_Model>();

				if (Drugs.Count() != 0)
				{
					foreach (var drug in Drugs)
					{
						DrugsCategory.Add(new core.Models.Category_Drugs_Model()
						{
							Id_drug = drug.ID_drug,
							drug_name = drug.nom_drug,
							form = drug.form,
							strength = drug.strength,
							strengthUnit = drug.strengthUnit,
							ddi= drug.DDI
						});
					}
				}
				return DrugsCategory;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public static core.Models.Category_Drugs_Model GetDrugsByID(int id)
		{
			try
			{
				var Drug = Infrastructure.Data.Access.Tables.DrugAccess.Get(id);
				var DrugBYID = new core.Models.Category_Drugs_Model();


							DrugBYID.Id_drug = Drug.ID_drug;
							DrugBYID.drug_name = Drug.nom_drug;
							DrugBYID.form = Drug.form;
							DrugBYID.strength = Drug.strength;
							DrugBYID.strengthUnit = Drug.strengthUnit;
							DrugBYID.ddi = Drug.DDI;
					
					
				return DrugBYID;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
