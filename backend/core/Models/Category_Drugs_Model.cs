using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
	public class Category_Drugs_Model
	{
		public int Id_drug { get; set; }
		public string drug_name { get; set; }
		public float? strength { get; set; }
		public string form { get; set; }
		public string strengthUnit { get; set; }
		public float? ddi { get; set; }
	}
}
