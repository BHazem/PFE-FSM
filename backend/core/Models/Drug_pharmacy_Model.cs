using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
	public class Drug_pharmacy_Model
	{
		public int? id_pharmacy { get; set; }
		public string pharmacy_name { get; set; }
		public float? cash_price { get; set; }
		public string coupon { get; set; }
		public string delivery_type { get; set; }
		public string timeframe { get; set; }
	
	}
}
