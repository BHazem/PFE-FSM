using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Entities.Tables
{
    public class DrugEntity
    {
		public float? DDI { get; set; }
		public string form { get; set; }
		public string GPI14 { get; set; }
		public int? ID_category { get; set; }
		public int ID_drug { get; set; }
		public string nom_drug { get; set; }
		public float? strength { get; set; }
		public string strengthUnit { get; set; }

		public DrugEntity() { }

        public DrugEntity(DataRow dataRow)
        {
			DDI = (dataRow["DDI"] == System.DBNull.Value) ? (float?)null : Convert.ToInt64(dataRow["DDI"]);
			form = (dataRow["form"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["form"]);
			GPI14 = (dataRow["GPI14"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["GPI14"]);
			ID_category = (dataRow["ID_category"] == System.DBNull.Value) ? (int?)null : Convert.ToInt32(dataRow["ID_category"]);
			ID_drug = Convert.ToInt32(dataRow["ID_drug"]);
			nom_drug = (dataRow["nom_drug"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["nom_drug"]);
			strength = (dataRow["strength"] == System.DBNull.Value) ? (float?)null : Convert.ToInt64(dataRow["strength"]);
			strengthUnit = (dataRow["strengthUnit"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["strengthUnit"]);
		}
    }
}

