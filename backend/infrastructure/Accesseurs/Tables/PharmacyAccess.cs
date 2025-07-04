using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Infrastructure.Data.Access.Tables
{

    public class PharmacyAccess
    {

        #region Default Methods
        public static Infrastructure.Data.Entities.Tables.PharmacyEntity Get(int id_pharmacy)
        {
            var dataTable = new DataTable();
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Pharmacy] WHERE [ID_pharmacy]=@id_pharmacy";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id_pharmacy", id_pharmacy); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }

            if (dataTable.Rows.Count > 0)
            {
                return new Infrastructure.Data.Entities.Tables.PharmacyEntity(dataTable.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static List<Infrastructure.Data.Entities.Tables.PharmacyEntity> Get()
        {  
            var dataTable = new DataTable();     
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Pharmacy]";
                var sqlCommand = new SqlCommand(query, sqlConnection); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.PharmacyEntity>();
            }
        }
        public static List<Infrastructure.Data.Entities.Tables.PharmacyEntity> Get(List<int> ids)
        {
            if(ids != null && ids.Count > 0)
            {
                int maxQueryNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE ; 
                List<Infrastructure.Data.Entities.Tables.PharmacyEntity> results = null;
                if(ids.Count <= maxQueryNumber)
                {
                    results = get(ids);
                }else
                {
                    int batchNumber = ids.Count / maxQueryNumber;
                    results = new List<Infrastructure.Data.Entities.Tables.PharmacyEntity>();
                    for(int i=0; i<batchNumber; i++)
                    {
                        results.AddRange(get(ids.GetRange(i * maxQueryNumber, maxQueryNumber)));
                    }
                    results.AddRange(get(ids.GetRange(batchNumber * maxQueryNumber, ids.Count-batchNumber * maxQueryNumber)));
                }
                return results;
            }
            return new List<Infrastructure.Data.Entities.Tables.PharmacyEntity>();
        }
        private static List<Infrastructure.Data.Entities.Tables.PharmacyEntity> get(List<int> ids)
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

                    sqlCommand.CommandText = "SELECT * FROM [Pharmacy] WHERE [ID_pharmacy] IN ("+ queryIds +")";                    
                new SqlDataAdapter(sqlCommand).Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    return toList(dataTable);
                }
                else
                {
                    return new List<Infrastructure.Data.Entities.Tables.PharmacyEntity>();
                }
            }
            return new List<Infrastructure.Data.Entities.Tables.PharmacyEntity>();
        }

        public static int Insert(Infrastructure.Data.Entities.Tables.PharmacyEntity item)
        {
            int response = -1;
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                var sqlTransaction = sqlConnection.BeginTransaction();

                string query = "INSERT INTO [Pharmacy] ([ID_pharmacy],[Ncpdp_Prov_ID],[nom_pharmacy],[phone])  VALUES (@ID_pharmacy,@Ncpdp_Prov_ID,@nom_pharmacy,@phone)";

                using(var sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction))
				{

					sqlCommand.Parameters.AddWithValue("ID_pharmacy",item.ID_pharmacy);
					sqlCommand.Parameters.AddWithValue("Ncpdp_Prov_ID",item.Ncpdp_Prov_ID == null ? (object)DBNull.Value  : item.Ncpdp_Prov_ID);
					sqlCommand.Parameters.AddWithValue("nom_pharmacy",item.nom_pharmacy == null ? (object)DBNull.Value  : item.nom_pharmacy);
					sqlCommand.Parameters.AddWithValue("phone",item.phone == null ? (object)DBNull.Value  : item.phone);

                    sqlCommand.ExecuteNonQuery();
                }

                using (var sqlCommand = new SqlCommand("SELECT [ID_pharmacy] FROM [Pharmacy] WHERE [ID_pharmacy] = @@IDENTITY", sqlConnection, sqlTransaction))
                {
                    response = int.Parse(sqlCommand.ExecuteScalar()?.ToString() ?? "-1");
                }
           
                sqlTransaction.Commit();

                return response;
            }
        }
        public static int Insert(List<Infrastructure.Data.Entities.Tables.PharmacyEntity> items)
        {
            if (items != null && items.Count > 0)
            {
                int maxParamsNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE / 6; // Nb params per query
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
        private static int insert(List<Infrastructure.Data.Entities.Tables.PharmacyEntity> items)
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
                        query += " INSERT INTO [Pharmacy] ([ID_pharmacy],[Ncpdp_Prov_ID],[nom_pharmacy],[phone]) VALUES ( "

							+ "@ID_pharmacy"+ i +","
							+ "@Ncpdp_Prov_ID"+ i +","
							+ "@nom_pharmacy"+ i +","
							+ "@phone"+ i +","
                            + "); ";

                            
							sqlCommand.Parameters.AddWithValue("ID_pharmacy" + i, item.ID_pharmacy);
							sqlCommand.Parameters.AddWithValue("Ncpdp_Prov_ID" + i, item.Ncpdp_Prov_ID == null ? (object)DBNull.Value  : item.Ncpdp_Prov_ID);
							sqlCommand.Parameters.AddWithValue("nom_pharmacy" + i, item.nom_pharmacy == null ? (object)DBNull.Value  : item.nom_pharmacy);
							sqlCommand.Parameters.AddWithValue("phone" + i, item.phone == null ? (object)DBNull.Value : item.phone);
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
        
        private static List<Infrastructure.Data.Entities.Tables.PharmacyEntity> toList(DataTable dataTable)
        {
            var list = new List<Infrastructure.Data.Entities.Tables.PharmacyEntity>(dataTable.Rows.Count);
            foreach (DataRow dataRow in dataTable.Rows)
            { list.Add(new Infrastructure.Data.Entities.Tables.PharmacyEntity(dataRow)); }
            return list;
        }
        #endregion
    }
}
