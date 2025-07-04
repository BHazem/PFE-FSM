using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Handlers
{
	public class Prescription
	{
		public static core.Models.response Insert(string name_patient , string pharmaci_name , List<int> ids , string email)
		{
			/*var drugPrescription = new Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity();*/
			try
			{
				var response = new Models.response();
				var idPrescription = Infrastructure.Data.Access.Tables.PrescriptionAccess.Insert(new Infrastructure.Data.Entities.Tables.PrescriptionEntity()
				{
					date = DateTime.Now,
					Nom_patient = name_patient,
					Email_patient = email,
					 nom_pharmacie = pharmaci_name
				});

				response.id_prescription = idPrescription;
				var drugPrescriptions = new List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity>();
				foreach (var pd in ids)
				{
					drugPrescriptions.Add(new Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity()
					{
						ID_drugpharmacy = pd,
						ID_prescription = idPrescription
					});
				}

				int res = Infrastructure.Data.Access.Tables.DrugPrescriptionAccess.Insert(drugPrescriptions);

				return response;
			}
			catch(Exception e)
			{
				throw e;
			}

		}
	}
}
