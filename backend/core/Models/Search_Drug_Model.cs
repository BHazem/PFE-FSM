using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
	public class Search_Drug_Model
	{
		public string drug_name { get; set; }
		public int id_drug { get; set; }
		public float? ddi { get; set; }
		public float? strength { get; set; }
		public string form { get; set; }
		public string strengthUnit { get; set; }
	}
}
