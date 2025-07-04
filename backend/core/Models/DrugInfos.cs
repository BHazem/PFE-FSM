using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
	public class DrugInfos
	{
		public int id_drugpharmacy { get; set; }
		public int? id_pharmacy { get; set; }
		public string pharmacy_name { get; set; }
		public List<Drug_Info_Model> drugInfos { get; set; }
	}
}
