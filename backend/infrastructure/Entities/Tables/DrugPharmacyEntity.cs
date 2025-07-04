using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Entities.Tables
{
    public class DrugPharmacyEntity
    {
		public float cash_price { get; set; }
		public string coupon { get; set; }
		public string delivery_type { get; set; }
		public int ID_drug { get; set; }
		public int ID_drugpharmacy { get; set; }
		public int ID_pharmacy { get; set; }
		public string timeframe { get; set; }

        public DrugPharmacyEntity() { }

        public DrugPharmacyEntity(DataRow dataRow)
        {
			cash_price = Convert.ToSingle(dataRow["cash_price"]);
			coupon = (dataRow["coupon"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["coupon"]);
			delivery_type = (dataRow["delivery_type"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["delivery_type"]);
			ID_drug =  Convert.ToInt32(dataRow["ID_drug"]);
			ID_drugpharmacy = Convert.ToInt32(dataRow["ID_drugpharmacy"]);
			ID_pharmacy =  Convert.ToInt32(dataRow["ID_pharmacy"]);
			timeframe = (dataRow["timeframe"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["timeframe"]);
        }
    }
}

