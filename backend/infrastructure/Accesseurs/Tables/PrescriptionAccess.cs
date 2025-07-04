using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Infrastructure.Data.Access.Tables
{

    public class PrescriptionAccess
    {

        #region Default Methods
        public static Infrastructure.Data.Entities.Tables.PrescriptionEntity Get(int id_prescription)
        {
            var dataTable = new DataTable();
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Prescription] WHERE [ID_prescription]=@Id";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", id_prescription); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }

            if (dataTable.Rows.Count > 0)
            {
                return new Infrastructure.Data.Entities.Tables.PrescriptionEntity(dataTable.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static List<Infrastructure.Data.Entities.Tables.PrescriptionEntity> Get()
        {  
            var dataTable = new DataTable();     
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Prescription]";
                var sqlCommand = new SqlCommand(query, sqlConnection); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.PrescriptionEntity>();
            }
        }
        public static List<Infrastructure.Data.Entities.Tables.PrescriptionEntity> Get(List<int> ids)
        {
            if(ids != null && ids.Count > 0)
            {
                int maxQueryNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE ; 
                List<Infrastructure.Data.Entities.Tables.PrescriptionEntity> results = null;
                if(ids.Count <= maxQueryNumber)
                {
                    results = get(ids);
                }else
                {
                    int batchNumber = ids.Count / maxQueryNumber;
                    results = new List<Infrastructure.Data.Entities.Tables.PrescriptionEntity>();
                    for(int i=0; i<batchNumber; i++)
                    {
                        results.AddRange(get(ids.GetRange(i * maxQueryNumber, maxQueryNumber)));
                    }
                    results.AddRange(get(ids.GetRange(batchNumber * maxQueryNumber, ids.Count-batchNumber * maxQueryNumber)));
                }
                return results;
            }
            return new List<Infrastructure.Data.Entities.Tables.PrescriptionEntity>();
        }
        private static List<Infrastructure.Data.Entities.Tables.PrescriptionEntity> get(List<int> ids)
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

                    sqlCommand.CommandText = "SELECT * FROM [Prescription] WHERE [ID_prescription] IN ("+ queryIds +")";                    
                new SqlDataAdapter(sqlCommand).Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    return toList(dataTable);
                }
                else
                {
                    return new List<Infrastructure.Data.Entities.Tables.PrescriptionEntity>();
                }
            }
            return new List<Infrastructure.Data.Entities.Tables.PrescriptionEntity>();
        }

        public static int Insert(Infrastructure.Data.Entities.Tables.PrescriptionEntity item)
        {
            int response = -1;
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                var sqlTransaction = sqlConnection.BeginTransaction();

                string query = "INSERT INTO [Prescription] ([date],[Nom_patient],[nom_pharmacie],[Email_patient])  VALUES (@date,@Nom_patient,@nom_pharmacie,@Email_patient)";

                using(var sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction))
				{

				
					sqlCommand.Parameters.AddWithValue("date",item.date == null ? (object)DBNull.Value  : item.date);
					sqlCommand.Parameters.AddWithValue("Nom_patient",item.Nom_patient == null ? (object)DBNull.Value  : item.Nom_patient);
					sqlCommand.Parameters.AddWithValue("nom_pharmacie", item.nom_pharmacie == null ? (object)DBNull.Value  : item.nom_pharmacie);
                    sqlCommand.Parameters.AddWithValue("Email_patient", item.Email_patient == null ? (object)DBNull.Value : item.Email_patient);
                    sqlCommand.ExecuteNonQuery();
                }

                using (var sqlCommand = new SqlCommand("SELECT [ID_prescription] FROM [Prescription] WHERE [ID_prescription] = @@IDENTITY", sqlConnection, sqlTransaction))
                {
                    response = int.Parse(sqlCommand.ExecuteScalar()?.ToString() ?? "-1");
                }
           
                sqlTransaction.Commit();

                return response;
            }
        }
        public static int Insert(List<Infrastructure.Data.Entities.Tables.PrescriptionEntity> items)
        {
            if (items != null && items.Count > 0)
            {
                int maxParamsNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE / 4; // Nb params per query
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
        private static int insert(List<Infrastructure.Data.Entities.Tables.PrescriptionEntity> items)
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
                        query += " INSERT INTO [Prescription] ([ID_prescription],[date],[Nom_patient],[nom_pharmacie],[Email_patient]) VALUES ( "

                            + "@ID_prescription"+ i +","
							+ "@date"+ i +","
							+ "@Nom_patient"+ i +","
							+ "@nom_pharmacie" + i + ","
                            + "@Email_patient"+i + ","
                            + "); ";

                            
							sqlCommand.Parameters.AddWithValue("ID_prescription" + i, item.ID_prescription);
							sqlCommand.Parameters.AddWithValue("date" + i, item.date == null ? (object)DBNull.Value  : item.date);
							sqlCommand.Parameters.AddWithValue("Nom_patient" + i, item.Nom_patient == null ? (object)DBNull.Value  : item.Nom_patient);
							sqlCommand.Parameters.AddWithValue("nom_pharmacie" + i, item.nom_pharmacie == null ? (object)DBNull.Value : item.nom_pharmacie);
                            sqlCommand.Parameters.AddWithValue("Email_patient" + i, item.Email_patient == null ? (object)DBNull.Value : item.Email_patient);
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
        
        private static List<Infrastructure.Data.Entities.Tables.PrescriptionEntity> toList(DataTable dataTable)
        {
            var list = new List<Infrastructure.Data.Entities.Tables.PrescriptionEntity>(dataTable.Rows.Count);
            foreach (DataRow dataRow in dataTable.Rows)
            { list.Add(new Infrastructure.Data.Entities.Tables.PrescriptionEntity(dataRow)); }
            return list;
        }
        #endregion
    }
}
