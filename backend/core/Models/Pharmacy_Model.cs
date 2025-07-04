using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
	public class Pharmacy_Model
	{
		public int ID_pharmacy { get; set; }
		public int? Ncpdp_Prov_ID { get; set; }
		public string nom_pharmacy { get; set; }
		public long? phone { get; set; }
		public string adresse { get; set; }
	}
}
