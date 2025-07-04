using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Entities.Tables
{
    public class Feuil3Entity
    {
		public string bioequivalence_code { get; set; }
		public string brand_name_code { get; set; }
		public string controlled_substance_code { get; set; }
		public string dosage_form { get; set; }
		public float? drug_descriptor_id { get; set; }
		public string drug_name { get; set; }
		public float? efficacy_code { get; set; }
		public float? form_type_code { get; set; }
		public float? generic_product_identifier { get; set; }
		public float? internal_external_code { get; set; }
		public float? kdc { get; set; }
		public string kdc_flag { get; set; }
		public float? last_change_date { get; set; }
		public string legend_indicator_code { get; set; }
		public float? local_systemic_flag { get; set; }
		public float? maintenance_drug_code { get; set; }
		public string multi_source_code { get; set; }
		public string name_source_code { get; set; }
		public float? new_drug_descriptor_identifier { get; set; }
		public float? representative_gpi_flag { get; set; }
		public float? representative_kdc_flag { get; set; }
		public string reserve { get; set; }
		public string route_of_administration { get; set; }
		public string screenable_flag { get; set; }
		public float? single_combination_code { get; set; }
		public float? strength { get; set; }
		public string strength_unit_of_measure { get; set; }
		public string transaction_code { get; set; }

        public Feuil3Entity() { }

        public Feuil3Entity(DataRow dataRow)
        {
			bioequivalence_code = (dataRow["bioequivalence_code"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["bioequivalence_code"]);
			brand_name_code = (dataRow["brand_name_code"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["brand_name_code"]);
			controlled_substance_code = (dataRow["controlled_substance_code"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["controlled_substance_code"]);
			dosage_form = (dataRow["dosage_form"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["dosage_form"]);
			drug_descriptor_id = (dataRow["drug_descriptor_id"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["drug_descriptor_id"]);
			drug_name = (dataRow["drug_name"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["drug_name"]);
			efficacy_code = (dataRow["efficacy_code"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["efficacy_code"]);
			form_type_code = (dataRow["form_type_code"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["form_type_code"]);
			generic_product_identifier = (dataRow["generic_product_identifier"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["generic_product_identifier"]);
			internal_external_code = (dataRow["internal_external_code"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["internal_external_code"]);
			kdc = (dataRow["kdc"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["kdc"]);
			kdc_flag = (dataRow["kdc_flag"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["kdc_flag"]);
			last_change_date = (dataRow["last_change_date"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["last_change_date"]);
			legend_indicator_code = (dataRow["legend_indicator_code"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["legend_indicator_code"]);
			local_systemic_flag = (dataRow["local_systemic_flag"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["local_systemic_flag"]);
			maintenance_drug_code = (dataRow["maintenance_drug_code"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["maintenance_drug_code"]);
			multi_source_code = (dataRow["multi_source_code"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["multi_source_code"]);
			name_source_code = (dataRow["name_source_code"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["name_source_code"]);
			new_drug_descriptor_identifier = (dataRow["new_drug_descriptor_identifier"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["new_drug_descriptor_identifier"]);
			representative_gpi_flag = (dataRow["representative_gpi_flag"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["representative_gpi_flag"]);
			representative_kdc_flag = (dataRow["representative_kdc_flag"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["representative_kdc_flag"]);
			reserve = (dataRow["reserve"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["reserve"]);
			route_of_administration = (dataRow["route_of_administration"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["route_of_administration"]);
			screenable_flag = (dataRow["screenable_flag"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["screenable_flag"]);
			single_combination_code = (dataRow["single_combination_code"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["single_combination_code"]);
			strength = (dataRow["strength"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["strength"]);
			strength_unit_of_measure = (dataRow["strength_unit_of_measure"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["strength_unit_of_measure"]);
			transaction_code = (dataRow["transaction_code"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["transaction_code"]);
        }
    }
}

