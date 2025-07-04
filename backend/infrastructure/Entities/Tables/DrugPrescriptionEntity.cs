using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Entities.Tables
{
    public class DrugPrescriptionEntity
    {
		public int? ID_drugpharmacy { get; set; }
		public int ID_drugPrescription { get; set; }
		public int? ID_prescription { get; set; }

        public DrugPrescriptionEntity() { }

        public DrugPrescriptionEntity(DataRow dataRow)
        {
			ID_drugpharmacy = (dataRow["ID_drugpharmacy"] == System.DBNull.Value) ? (int?)null : Convert.ToInt32(dataRow["ID_drugpharmacy"]);
			ID_drugPrescription = Convert.ToInt32(dataRow["ID_drugPrescription"]);
			ID_prescription = (dataRow["ID_prescription"] == System.DBNull.Value) ? (int?)null : Convert.ToInt32(dataRow["ID_prescription"]);
        }
    }
}

