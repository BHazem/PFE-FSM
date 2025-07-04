using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Entities.Tables
{
    public class PharmacyEntity
    {
		public int ID_pharmacy { get; set; }
		public int? Ncpdp_Prov_ID { get; set; }
		public string nom_pharmacy { get; set; }
		public long? phone { get; set; }
		public string adresse { get; set; }
        public PharmacyEntity() { }

        public PharmacyEntity(DataRow dataRow)
        {
			ID_pharmacy = Convert.ToInt32(dataRow["ID_pharmacy"]);
			Ncpdp_Prov_ID = (dataRow["Ncpdp_Prov_ID"] == System.DBNull.Value) ? (int?)null : Convert.ToInt32(dataRow["Ncpdp_Prov_ID"]);
			nom_pharmacy = (dataRow["nom_pharmacy"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["nom_pharmacy"]);
			phone = (dataRow["phone"] == System.DBNull.Value) ? (long?)null : Convert.ToInt64(dataRow["phone"]);
			adresse = (dataRow["adresse"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["adresse"]);

		}
    }
}

