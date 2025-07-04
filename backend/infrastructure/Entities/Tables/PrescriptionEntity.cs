using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Entities.Tables
{
    public class PrescriptionEntity
    {
		public DateTime? date { get; set; }
		public int ID_prescription { get; set; }
		public string Nom_patient { get; set; }
		public string nom_pharmacie { get; set; }
		public string Email_patient { get; set; }
        public PrescriptionEntity() { }

        public PrescriptionEntity(DataRow dataRow)
        {
			date = (dataRow["date"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(dataRow["date"]);
			ID_prescription = Convert.ToInt32(dataRow["ID_prescription"]);
			Nom_patient = (dataRow["Nom_patient"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Nom_patient"]);
			nom_pharmacie = (dataRow["nom_pharmacie"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["nom_pharmacie"]);
			Nom_patient = (dataRow["Email_patient"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Email_patient"]);
		}
    }
}

