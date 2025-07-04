using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Infrastructure.Data.Access.Tables
{

    public class DrugAccess
    {

        #region Default Methods
        public static Infrastructure.Data.Entities.Tables.DrugEntity Get(int id)
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Drug] WHERE [ID_drug]=@id";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", id);

                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }
            if (dataTable.Rows.Count > 0)
            {
                return new Infrastructure.Data.Entities.Tables.DrugEntity(dataTable.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static List<Infrastructure.Data.Entities.Tables.DrugEntity> Get()
        {  
            var dataTable = new DataTable();     
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Drug]";
                var sqlCommand = new SqlCommand(query, sqlConnection); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.DrugEntity>();
            }
        }
        public static List<Infrastructure.Data.Entities.Tables.DrugEntity> Get(List<int> ids)
        {
            if(ids != null && ids.Count > 0)
            {
                int maxQueryNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE ; 
                List<Infrastructure.Data.Entities.Tables.DrugEntity> results = null;
                if(ids.Count <= maxQueryNumber)
                {
                    results = get(ids);
                }else
                {
                    int batchNumber = ids.Count / maxQueryNumber;
                    results = new List<Infrastructure.Data.Entities.Tables.DrugEntity>();
                    for(int i=0; i<batchNumber; i++)
                    {
                        results.AddRange(get(ids.GetRange(i * maxQueryNumber, maxQueryNumber)));
                    }
                    results.AddRange(get(ids.GetRange(batchNumber * maxQueryNumber, ids.Count-batchNumber * maxQueryNumber)));
                }
                return results;
            }
            return new List<Infrastructure.Data.Entities.Tables.DrugEntity>();
        }
        private static List<Infrastructure.Data.Entities.Tables.DrugEntity> get(List<int> ids)
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

                    sqlCommand.CommandText = "SELECT * FROM [Drug] WHERE [ID_drug] IN ("+ queryIds +")";                    
                new SqlDataAdapter(sqlCommand).Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    return toList(dataTable);
                }
                else
                {
                    return new List<Infrastructure.Data.Entities.Tables.DrugEntity>();
                }
            }
            return new List<Infrastructure.Data.Entities.Tables.DrugEntity>();
        }

        public static int Insert(Infrastructure.Data.Entities.Tables.DrugEntity item)
        {
            int response = -1;
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                var sqlTransaction = sqlConnection.BeginTransaction();

                string query = "INSERT INTO [Drug] ([ID_drug],[DDI],[form],[GPI14],[ID_category],[nom_drug],[strength],[strengthUnit])  VALUES (@ID_drug,@DDI,@form,@GPI14,@ID_category,@nom_drug,@strength,@strengthUnit)";

                using(var sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction))
				{

					sqlCommand.Parameters.AddWithValue("ID_drug",item.ID_drug);
					sqlCommand.Parameters.AddWithValue("DDI",item.DDI == null ? (object)DBNull.Value  : item.DDI);
					sqlCommand.Parameters.AddWithValue("form",item.form == null ? (object)DBNull.Value  : item.form);
					sqlCommand.Parameters.AddWithValue("GPI14",item.GPI14 == null ? (object)DBNull.Value  : item.GPI14);
					sqlCommand.Parameters.AddWithValue("ID_category",item.ID_category == null ? (object)DBNull.Value  : item.ID_category);
					sqlCommand.Parameters.AddWithValue("nom_drug",item.nom_drug == null ? (object)DBNull.Value  : item.nom_drug);
					sqlCommand.Parameters.AddWithValue("strength",item.strength == null ? (object)DBNull.Value  : item.strength);
                    sqlCommand.Parameters.AddWithValue("strengthUnit", item.strengthUnit == null ? (object)DBNull.Value : item.strengthUnit);

                    sqlCommand.ExecuteNonQuery();
                }

                using (var sqlCommand = new SqlCommand("SELECT [ID_drug] FROM [Drug] WHERE [ID_drug] = @@IDENTITY", sqlConnection, sqlTransaction))
                {
                    response = int.Parse(sqlCommand.ExecuteScalar()?.ToString() ?? "-1");
                }
           
                sqlTransaction.Commit();

                return response;
            }
        }
        public static int Insert(List<Infrastructure.Data.Entities.Tables.DrugEntity> items)
        {
            if (items != null && items.Count > 0)
            {
                int maxParamsNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE / 7; // Nb params per query
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
        private static int insert(List<Infrastructure.Data.Entities.Tables.DrugEntity> items)
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
                        query += " INSERT INTO [Drug] ([DDI],[form],[GPI14],[ID_category],[nom_drug],[strength],[strengthUnit]) VALUES ( "
							+ "@DDI"+ i +","
							+ "@form"+ i +","
							+ "@GPI14"+ i +","
							+ "@ID_category"+ i +","
							+ "@nom_drug"+ i +","
							+ "@strength"+ i +","
                            + "@strengthUnit" + i
                            + "); ";

                            

							sqlCommand.Parameters.AddWithValue("DDI" + i, item.DDI == null ? (object)DBNull.Value  : item.DDI);
							sqlCommand.Parameters.AddWithValue("form" + i, item.form == null ? (object)DBNull.Value  : item.form);
							sqlCommand.Parameters.AddWithValue("GPI14" + i, item.GPI14 == null ? (object)DBNull.Value  : item.GPI14);
							sqlCommand.Parameters.AddWithValue("ID_category" + i, item.ID_category == null ? (object)DBNull.Value  : item.ID_category);
							sqlCommand.Parameters.AddWithValue("nom_drug" + i, item.nom_drug == null ? (object)DBNull.Value  : item.nom_drug);
							sqlCommand.Parameters.AddWithValue("strength" + i, item.strength == null ? (object)DBNull.Value  : item.strength);
                            sqlCommand.Parameters.AddWithValue("strengthUnit" + i, item.strengthUnit == null ? (object)DBNull.Value : item.strengthUnit);
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
        public static List<Infrastructure.Data.Entities.Tables.DrugEntity> Get(string name_drug)
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Drug] WHERE [nom_drug] LIKE @name_drug";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("name_drug", name_drug + "%");

                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }
            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.DrugEntity>();
            }
        }

        public static List<Infrastructure.Data.Entities.Tables.DrugEntity> GetDrugByCategory(int id_category)
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Drug] WHERE [ID_category]=@id_category";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id_category", id_category);
                
                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Helpers

        private static List<Infrastructure.Data.Entities.Tables.DrugEntity> toList(DataTable dataTable)
        {
            var list = new List<Infrastructure.Data.Entities.Tables.DrugEntity>(dataTable.Rows.Count);
            foreach (DataRow dataRow in dataTable.Rows)
            { list.Add(new Infrastructure.Data.Entities.Tables.DrugEntity(dataRow)); }
            return list;
        }
        #endregion
    }
}
