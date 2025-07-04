using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Entities.Tables
{
    public class Feuil1Entity
    {
		public float? ActiveMacRate { get; set; }
		public float? ActiveRateMacId { get; set; }
		public string BrandName { get; set; }
		public string ClassName { get; set; }
		public string Coupon { get; set; }
		public float? DDI { get; set; }
		public string Delivery { get; set; }
		public float? DrugGpiId { get; set; }
		public float? DrugId { get; set; }
		public string Expr1 { get; set; }
		public string Gpi { get; set; }
		public string Gpi4 { get; set; }
		public float? LowestPrice { get; set; }
		public float? MacFlag { get; set; }
		public string MacPrice { get; set; }
		public string Name { get; set; }
		public float? PharmacyId { get; set; }
		public float PriceToPay { get; set; }
		public float? Rate { get; set; }
		public float? TherapeuticClassId { get; set; }
		public string Timeframe { get; set; }
		public float? Type { get; set; }

        public Feuil1Entity() { }

        public Feuil1Entity(DataRow dataRow)
        {
			ActiveMacRate = (dataRow["ActiveMacRate"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["ActiveMacRate"]);
			ActiveRateMacId = (dataRow["ActiveRateMacId"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["ActiveRateMacId"]);
			BrandName = (dataRow["BrandName"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["BrandName"]);
			ClassName = (dataRow["ClassName"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ClassName"]);
			Coupon = (dataRow["Coupon"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Coupon"]);
			DDI = (dataRow["DDI"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["DDI"]);
			Delivery = (dataRow["Delivery"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Delivery"]);
			DrugGpiId = (dataRow["DrugGpiId"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["DrugGpiId"]);
			DrugId = (dataRow["DrugId"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["DrugId"]);
			Expr1 = (dataRow["Expr1"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Expr1"]);
			Gpi = (dataRow["Gpi"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Gpi"]);
			Gpi4 = (dataRow["Gpi4"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Gpi4"]);
			LowestPrice = (dataRow["LowestPrice"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["LowestPrice"]);
			MacFlag = (dataRow["MacFlag"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["MacFlag"]);
			MacPrice = (dataRow["MacPrice"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["MacPrice"]);
			Name = (dataRow["Name"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Name"]);
			PharmacyId = (dataRow["PharmacyId"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["PharmacyId"]);
			PriceToPay = Convert.ToSingle(dataRow["PriceToPay"]);
			Rate = (dataRow["Rate"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["Rate"]);
			TherapeuticClassId = (dataRow["TherapeuticClassId"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["TherapeuticClassId"]);
			Timeframe = (dataRow["Timeframe"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Timeframe"]);
			Type = (dataRow["Type"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["Type"]);
        }
    }
}

