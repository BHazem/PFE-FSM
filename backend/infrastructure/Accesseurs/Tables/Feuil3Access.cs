using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Infrastructure.Data.Access.Tables
{

    public class Feuil3Access
    {

        #region Default Methods
        public static Infrastructure.Data.Entities.Tables.Feuil3Entity Get(string bioequivalence_code)
        {
            var dataTable = new DataTable();
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Feuil3] WHERE [bioequivalence_code]=@Id";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", bioequivalence_code); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }

            if (dataTable.Rows.Count > 0)
            {
                return new Infrastructure.Data.Entities.Tables.Feuil3Entity(dataTable.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static List<Infrastructure.Data.Entities.Tables.Feuil3Entity> Get()
        {  
            var dataTable = new DataTable();     
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Feuil3]";
                var sqlCommand = new SqlCommand(query, sqlConnection); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.Feuil3Entity>();
            }
        }
        public static List<Infrastructure.Data.Entities.Tables.Feuil3Entity> Get(List<string> ids)
        {
            if(ids != null && ids.Count > 0)
            {
                int maxQueryNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE ; 
                List<Infrastructure.Data.Entities.Tables.Feuil3Entity> results = null;
                if(ids.Count <= maxQueryNumber)
                {
                    results = get(ids);
                }else
                {
                    int batchNumber = ids.Count / maxQueryNumber;
                    results = new List<Infrastructure.Data.Entities.Tables.Feuil3Entity>();
                    for(int i=0; i<batchNumber; i++)
                    {
                        results.AddRange(get(ids.GetRange(i * maxQueryNumber, maxQueryNumber)));
                    }
                    results.AddRange(get(ids.GetRange(batchNumber * maxQueryNumber, ids.Count-batchNumber * maxQueryNumber)));
                }
                return results;
            }
            return new List<Infrastructure.Data.Entities.Tables.Feuil3Entity>();
        }
        private static List<Infrastructure.Data.Entities.Tables.Feuil3Entity> get(List<string> ids)
        {
            if(ids != null && ids.Count > 0)
            {
                var dataTable = new DataTable();
                using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
                {
                    sqlConnection.Open();
                    var sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    string queryIds = string.Empty;
                    for(int i=0; i<ids.Count; i++)
                    {
                        queryIds += "@Id" + i + ",";
                        sqlCommand.Parameters.AddWithValue("Id" + i, ids[i]);
                    }
                    queryIds = queryIds.TrimEnd(',');

                    sqlCommand.CommandText = "SELECT * FROM [Feuil3] WHERE [bioequivalence_code] IN ("+ queryIds +")";                    
                new SqlDataAdapter(sqlCommand).Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    return toList(dataTable);
                }
                else
                {
                    return new List<Infrastructure.Data.Entities.Tables.Feuil3Entity>();
                }
            }
            return new List<Infrastructure.Data.Entities.Tables.Feuil3Entity>();
        }

        public static int Insert(Infrastructure.Data.Entities.Tables.Feuil3Entity item)
        {
            int response = -1;
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                var sqlTransaction = sqlConnection.BeginTransaction();

                string query = "INSERT INTO [Feuil3] ([bioequivalence_code],[brand_name_code],[controlled_substance_code],[dosage_form],[drug_descriptor_id],[drug_name],[efficacy_code],[form_type_code],[generic_product_identifier],[internal_external_code],[kdc],[kdc_flag],[last_change_date],[legend_indicator_code],[local_systemic_flag],[maintenance_drug_code],[multi_source_code],[name_source_code],[new_drug_descriptor_identifier],[representative_gpi_flag],[representative_kdc_flag],[reserve],[route_of_administration],[screenable_flag],[single_combination_code],[strength],[strength_unit_of_measure],[transaction_code])  VALUES (@bioequivalence_code,@brand_name_code,@controlled_substance_code,@dosage_form,@drug_descriptor_id,@drug_name,@efficacy_code,@form_type_code,@generic_product_identifier,@internal_external_code,@kdc,@kdc_flag,@last_change_date,@legend_indicator_code,@local_systemic_flag,@maintenance_drug_code,@multi_source_code,@name_source_code,@new_drug_descriptor_identifier,@representative_gpi_flag,@representative_kdc_flag,@reserve,@route_of_administration,@screenable_flag,@single_combination_code,@strength,@strength_unit_of_measure,@transaction_code)";

                using(var sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction))
				{

					sqlCommand.Parameters.AddWithValue("bioequivalence_code",item.bioequivalence_code);
					sqlCommand.Parameters.AddWithValue("brand_name_code",item.brand_name_code == null ? (object)DBNull.Value  : item.brand_name_code);
					sqlCommand.Parameters.AddWithValue("controlled_substance_code",item.controlled_substance_code == null ? (object)DBNull.Value  : item.controlled_substance_code);
					sqlCommand.Parameters.AddWithValue("dosage_form",item.dosage_form == null ? (object)DBNull.Value  : item.dosage_form);
					sqlCommand.Parameters.AddWithValue("drug_descriptor_id",item.drug_descriptor_id == null ? (object)DBNull.Value  : item.drug_descriptor_id);
					sqlCommand.Parameters.AddWithValue("drug_name",item.drug_name == null ? (object)DBNull.Value  : item.drug_name);
					sqlCommand.Parameters.AddWithValue("efficacy_code",item.efficacy_code == null ? (object)DBNull.Value  : item.efficacy_code);
					sqlCommand.Parameters.AddWithValue("form_type_code",item.form_type_code == null ? (object)DBNull.Value  : item.form_type_code);
					sqlCommand.Parameters.AddWithValue("generic_product_identifier",item.generic_product_identifier == null ? (object)DBNull.Value  : item.generic_product_identifier);
					sqlCommand.Parameters.AddWithValue("internal_external_code",item.internal_external_code == null ? (object)DBNull.Value  : item.internal_external_code);
					sqlCommand.Parameters.AddWithValue("kdc",item.kdc == null ? (object)DBNull.Value  : item.kdc);
					sqlCommand.Parameters.AddWithValue("kdc_flag",item.kdc_flag == null ? (object)DBNull.Value  : item.kdc_flag);
					sqlCommand.Parameters.AddWithValue("last_change_date",item.last_change_date == null ? (object)DBNull.Value  : item.last_change_date);
					sqlCommand.Parameters.AddWithValue("legend_indicator_code",item.legend_indicator_code == null ? (object)DBNull.Value  : item.legend_indicator_code);
					sqlCommand.Parameters.AddWithValue("local_systemic_flag",item.local_systemic_flag == null ? (object)DBNull.Value  : item.local_systemic_flag);
					sqlCommand.Parameters.AddWithValue("maintenance_drug_code",item.maintenance_drug_code == null ? (object)DBNull.Value  : item.maintenance_drug_code);
					sqlCommand.Parameters.AddWithValue("multi_source_code",item.multi_source_code == null ? (object)DBNull.Value  : item.multi_source_code);
					sqlCommand.Parameters.AddWithValue("name_source_code",item.name_source_code == null ? (object)DBNull.Value  : item.name_source_code);
					sqlCommand.Parameters.AddWithValue("new_drug_descriptor_identifier",item.new_drug_descriptor_identifier == null ? (object)DBNull.Value  : item.new_drug_descriptor_identifier);
					sqlCommand.Parameters.AddWithValue("representative_gpi_flag",item.representative_gpi_flag == null ? (object)DBNull.Value  : item.representative_gpi_flag);
					sqlCommand.Parameters.AddWithValue("representative_kdc_flag",item.representative_kdc_flag == null ? (object)DBNull.Value  : item.representative_kdc_flag);
					sqlCommand.Parameters.AddWithValue("reserve",item.reserve == null ? (object)DBNull.Value  : item.reserve);
					sqlCommand.Parameters.AddWithValue("route_of_administration",item.route_of_administration == null ? (object)DBNull.Value  : item.route_of_administration);
					sqlCommand.Parameters.AddWithValue("screenable_flag",item.screenable_flag == null ? (object)DBNull.Value  : item.screenable_flag);
					sqlCommand.Parameters.AddWithValue("single_combination_code",item.single_combination_code == null ? (object)DBNull.Value  : item.single_combination_code);
					sqlCommand.Parameters.AddWithValue("strength",item.strength == null ? (object)DBNull.Value  : item.strength);
					sqlCommand.Parameters.AddWithValue("strength_unit_of_measure",item.strength_unit_of_measure == null ? (object)DBNull.Value  : item.strength_unit_of_measure);
					sqlCommand.Parameters.AddWithValue("transaction_code",item.transaction_code == null ? (object)DBNull.Value  : item.transaction_code);

                    sqlCommand.ExecuteNonQuery();
                }

                using (var sqlCommand = new SqlCommand("SELECT [bioequivalence_code] FROM [Feuil3] WHERE [bioequivalence_code] = @@IDENTITY", sqlConnection, sqlTransaction))
                {
                    response = int.Parse(sqlCommand.ExecuteScalar()?.ToString() ?? "-1");
                }
           
                sqlTransaction.Commit();

                return response;
            }
        }
        public static int Insert(List<Infrastructure.Data.Entities.Tables.Feuil3Entity> items)
        {
            if (items != null && items.Count > 0)
            {
                int maxParamsNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE / 28; // Nb params per query
                int results=0;
                if(items.Count <= maxParamsNumber)
                {
                    results = insert(items);
                }else
                {
                    int batchNumber = items.Count / maxParamsNumber;
                    for(int i = 0; i < batchNumber; i++)
                    {
                        results += insert(items.GetRange(i * maxParamsNumber, maxParamsNumber));
                    }
                    results += insert(items.GetRange(batchNumber * maxParamsNumber, items.Count - batchNumber * maxParamsNumber));
                }
                return results;
            }

            return -1;
        }
        private static int insert(List<Infrastructure.Data.Entities.Tables.Feuil3Entity> items)
        {
            if (items != null && items.Count > 0)
            {
                int results = -1;
                using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
                {
                    sqlConnection.Open();
                    string query = "";
                    var sqlCommand = new SqlCommand(query, sqlConnection);

                    int i = 0;
                    foreach (var item in items)
                    {
                        i++;
                        query += " INSERT INTO [Feuil3] ([bioequivalence_code],[brand_name_code],[controlled_substance_code],[dosage_form],[drug_descriptor_id],[drug_name],[efficacy_code],[form_type_code],[generic_product_identifier],[internal_external_code],[kdc],[kdc_flag],[last_change_date],[legend_indicator_code],[local_systemic_flag],[maintenance_drug_code],[multi_source_code],[name_source_code],[new_drug_descriptor_identifier],[representative_gpi_flag],[representative_kdc_flag],[reserve],[route_of_administration],[screenable_flag],[single_combination_code],[strength],[strength_unit_of_measure],[transaction_code]) VALUES ( "

							+ "@bioequivalence_code"+ i +","
							+ "@brand_name_code"+ i +","
							+ "@controlled_substance_code"+ i +","
							+ "@dosage_form"+ i +","
							+ "@drug_descriptor_id"+ i +","
							+ "@drug_name"+ i +","
							+ "@efficacy_code"+ i +","
							+ "@form_type_code"+ i +","
							+ "@generic_product_identifier"+ i +","
							+ "@internal_external_code"+ i +","
							+ "@kdc"+ i +","
							+ "@kdc_flag"+ i +","
							+ "@last_change_date"+ i +","
							+ "@legend_indicator_code"+ i +","
							+ "@local_systemic_flag"+ i +","
							+ "@maintenance_drug_code"+ i +","
							+ "@multi_source_code"+ i +","
							+ "@name_source_code"+ i +","
							+ "@new_drug_descriptor_identifier"+ i +","
							+ "@representative_gpi_flag"+ i +","
							+ "@representative_kdc_flag"+ i +","
							+ "@reserve"+ i +","
							+ "@route_of_administration"+ i +","
							+ "@screenable_flag"+ i +","
							+ "@single_combination_code"+ i +","
							+ "@strength"+ i +","
							+ "@strength_unit_of_measure"+ i +","
							+ "@transaction_code"+ i 
                            + "); ";

                            
							sqlCommand.Parameters.AddWithValue("bioequivalence_code" + i, item.bioequivalence_code);
							sqlCommand.Parameters.AddWithValue("brand_name_code" + i, item.brand_name_code == null ? (object)DBNull.Value  : item.brand_name_code);
							sqlCommand.Parameters.AddWithValue("controlled_substance_code" + i, item.controlled_substance_code == null ? (object)DBNull.Value  : item.controlled_substance_code);
							sqlCommand.Parameters.AddWithValue("dosage_form" + i, item.dosage_form == null ? (object)DBNull.Value  : item.dosage_form);
							sqlCommand.Parameters.AddWithValue("drug_descriptor_id" + i, item.drug_descriptor_id == null ? (object)DBNull.Value  : item.drug_descriptor_id);
							sqlCommand.Parameters.AddWithValue("drug_name" + i, item.drug_name == null ? (object)DBNull.Value  : item.drug_name);
							sqlCommand.Parameters.AddWithValue("efficacy_code" + i, item.efficacy_code == null ? (object)DBNull.Value  : item.efficacy_code);
							sqlCommand.Parameters.AddWithValue("form_type_code" + i, item.form_type_code == null ? (object)DBNull.Value  : item.form_type_code);
							sqlCommand.Parameters.AddWithValue("generic_product_identifier" + i, item.generic_product_identifier == null ? (object)DBNull.Value  : item.generic_product_identifier);
							sqlCommand.Parameters.AddWithValue("internal_external_code" + i, item.internal_external_code == null ? (object)DBNull.Value  : item.internal_external_code);
							sqlCommand.Parameters.AddWithValue("kdc" + i, item.kdc == null ? (object)DBNull.Value  : item.kdc);
							sqlCommand.Parameters.AddWithValue("kdc_flag" + i, item.kdc_flag == null ? (object)DBNull.Value  : item.kdc_flag);
							sqlCommand.Parameters.AddWithValue("last_change_date" + i, item.last_change_date == null ? (object)DBNull.Value  : item.last_change_date);
							sqlCommand.Parameters.AddWithValue("legend_indicator_code" + i, item.legend_indicator_code == null ? (object)DBNull.Value  : item.legend_indicator_code);
							sqlCommand.Parameters.AddWithValue("local_systemic_flag" + i, item.local_systemic_flag == null ? (object)DBNull.Value  : item.local_systemic_flag);
							sqlCommand.Parameters.AddWithValue("maintenance_drug_code" + i, item.maintenance_drug_code == null ? (object)DBNull.Value  : item.maintenance_drug_code);
							sqlCommand.Parameters.AddWithValue("multi_source_code" + i, item.multi_source_code == null ? (object)DBNull.Value  : item.multi_source_code);
							sqlCommand.Parameters.AddWithValue("name_source_code" + i, item.name_source_code == null ? (object)DBNull.Value  : item.name_source_code);
							sqlCommand.Parameters.AddWithValue("new_drug_descriptor_identifier" + i, item.new_drug_descriptor_identifier == null ? (object)DBNull.Value  : item.new_drug_descriptor_identifier);
							sqlCommand.Parameters.AddWithValue("representative_gpi_flag" + i, item.representative_gpi_flag == null ? (object)DBNull.Value  : item.representative_gpi_flag);
							sqlCommand.Parameters.AddWithValue("representative_kdc_flag" + i, item.representative_kdc_flag == null ? (object)DBNull.Value  : item.representative_kdc_flag);
							sqlCommand.Parameters.AddWithValue("reserve" + i, item.reserve == null ? (object)DBNull.Value  : item.reserve);
							sqlCommand.Parameters.AddWithValue("route_of_administration" + i, item.route_of_administration == null ? (object)DBNull.Value  : item.route_of_administration);
							sqlCommand.Parameters.AddWithValue("screenable_flag" + i, item.screenable_flag == null ? (object)DBNull.Value  : item.screenable_flag);
							sqlCommand.Parameters.AddWithValue("single_combination_code" + i, item.single_combination_code == null ? (object)DBNull.Value  : item.single_combination_code);
							sqlCommand.Parameters.AddWithValue("strength" + i, item.strength == null ? (object)DBNull.Value  : item.strength);
							sqlCommand.Parameters.AddWithValue("strength_unit_of_measure" + i, item.strength_unit_of_measure == null ? (object)DBNull.Value  : item.strength_unit_of_measure);
							sqlCommand.Parameters.AddWithValue("transaction_code" + i, item.transaction_code == null ? (object)DBNull.Value  : item.transaction_code);
                    }

                    sqlCommand.CommandText = query;

                    results = sqlCommand.ExecuteNonQuery();
                }

                return results;
            }

            return -1;
        }

        #endregion

        #region Custom Methods


        #endregion

        #region Helpers
        
        private static List<Infrastructure.Data.Entities.Tables.Feuil3Entity> toList(DataTable dataTable)
        {
            var list = new List<Infrastructure.Data.Entities.Tables.Feuil3Entity>(dataTable.Rows.Count);
            foreach (DataRow dataRow in dataTable.Rows)
            { list.Add(new Infrastructure.Data.Entities.Tables.Feuil3Entity(dataRow)); }
            return list;
        }
        #endregion
    }
}
