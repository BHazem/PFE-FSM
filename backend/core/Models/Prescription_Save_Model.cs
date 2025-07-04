using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
	public class Prescription_Save_Model
	{
		public Prescription_Save_Model()
		{
			IDS_drugPharmacy = new List<int>();

		}
		public string nom_pharmacie { get; set; }
		public string patient_name { get; set; }
		public string Email_patient { get; set; }
		public List<int> IDS_drugPharmacy { get; set; }
	}
}
