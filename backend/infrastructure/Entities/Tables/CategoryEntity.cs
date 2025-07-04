using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Entities.Tables
{
    public class CategoryEntity
    {
		public string GPI4 { get; set; }
		public int ID_categroy { get; set; }
		public string nom_category { get; set; }

        public CategoryEntity() { }

        public CategoryEntity(DataRow dataRow)
        {
			GPI4 = (dataRow["GPI4"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["GPI4"]);
			ID_categroy = Convert.ToInt32(dataRow["ID_categroy"]);
			nom_category = Convert.ToString(dataRow["nom_category"]);
        }
    }
}

