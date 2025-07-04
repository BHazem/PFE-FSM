using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Infrastructure.Data.Access.Tables
{

    public class DrugPrescriptionAccess
    {

        #region Default Methods
        public static Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity Get(int id_drugprescription)
        {
            var dataTable = new DataTable();
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [DrugPrescription] WHERE [ID_drugPrescription]=@Id";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", id_drugprescription); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }

            if (dataTable.Rows.Count > 0)
            {
                return new Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity(dataTable.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity> Get()
        {  
            var dataTable = new DataTable();     
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [DrugPrescription]";
                var sqlCommand = new SqlCommand(query, sqlConnection); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity>();
            }
        }
        public static List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity> Get(List<int> ids)
        {
            if(ids != null && ids.Count > 0)
            {
                int maxQueryNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE ; 
                List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity> results = null;
                if(ids.Count <= maxQueryNumber)
                {
                    results = get(ids);
                }else
                {
                    int batchNumber = ids.Count / maxQueryNumber;
                    results = new List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity>();
                    for(int i=0; i<batchNumber; i++)
                    {
                        results.AddRange(get(ids.GetRange(i * maxQueryNumber, maxQueryNumber)));
                    }
                    results.AddRange(get(ids.GetRange(batchNumber * maxQueryNumber, ids.Count-batchNumber * maxQueryNumber)));
                }
                return results;
            }
            return new List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity>();
        }
        private static List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity> get(List<int> ids)
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

                    sqlCommand.CommandText = "SELECT * FROM [DrugPrescription] WHERE [ID_drugPrescription] IN ("+ queryIds +")";                    
                new SqlDataAdapter(sqlCommand).Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    return toList(dataTable);
                }
                else
                {
                    return new List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity>();
                }
            }
            return new List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity>();
        }

        public static int Insert(Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity item)
        {
            int response = -1;
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                var sqlTransaction = sqlConnection.BeginTransaction();

                string query = "INSERT INTO [DrugPrescription] ([ID_drugpharmacy],[ID_prescription])  VALUES (@ID_drugpharmacy,@ID_prescription)";

                using(var sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction))
				{

					sqlCommand.Parameters.AddWithValue("ID_drugpharmacy",item.ID_drugpharmacy == null ? (object)DBNull.Value  : item.ID_drugpharmacy);
					sqlCommand.Parameters.AddWithValue("ID_prescription",item.ID_prescription == null ? (object)DBNull.Value  : item.ID_prescription);

                    sqlCommand.ExecuteNonQuery();
                }

                using (var sqlCommand = new SqlCommand("SELECT [ID_drugPrescription] FROM [DrugPrescription] WHERE [ID_drugPrescription] = @@IDENTITY", sqlConnection, sqlTransaction))
                {
                    response = int.Parse(sqlCommand.ExecuteScalar()?.ToString() ?? "-1");
                }
           
                sqlTransaction.Commit();

                return response;
            }
        }
        public static int Insert(List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity> items)
        {
            if (items != null && items.Count > 0)
            {
                int maxParamsNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE / 3; // Nb params per query
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
        private static int insert(List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity> items)
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
                        query += " INSERT INTO [DrugPrescription] ([ID_drugpharmacy],[ID_prescription]) VALUES ( "

							+ "@ID_drugpharmacy"+ i +","
							+ "@ID_prescription"+ i 
                            + "); ";

                            
							sqlCommand.Parameters.AddWithValue("ID_drugpharmacy" + i, item.ID_drugpharmacy == null ? (object)DBNull.Value  : item.ID_drugpharmacy);
							sqlCommand.Parameters.AddWithValue("ID_prescription" + i, item.ID_prescription == null ? (object)DBNull.Value  : item.ID_prescription);
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
        
        private static List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity> toList(DataTable dataTable)
        {
            var list = new List<Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity>(dataTable.Rows.Count);
            foreach (DataRow dataRow in dataTable.Rows)
            { list.Add(new Infrastructure.Data.Entities.Tables.DrugPrescriptionEntity(dataRow)); }
            return list;
        }
        #endregion
    }
}
