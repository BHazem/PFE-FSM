using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Infrastructure.Data.Access.Tables
{

    public class DrugPharmacyAccess
    {

        #region Default Methods
        public static List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity> Get(int id_drug)
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [DrugPharmacy] WHERE [ID_drug]=@id_drug";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id_drug", id_drug);

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

        public static List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity> Get()
        {  
            var dataTable = new DataTable();     
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [DrugPharmacy]";
                var sqlCommand = new SqlCommand(query, sqlConnection); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
            }
        }
        public static List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity> Get(List<int> ids)
        {
            if(ids != null && ids.Count > 0)
            {
                int maxQueryNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE ; 
                List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity> results = null;
                if(ids.Count <= maxQueryNumber)
                {
                    results = get(ids);
                }else
                {
                    int batchNumber = ids.Count / maxQueryNumber;
                    results = new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
                    for(int i=0; i<batchNumber; i++)
                    {
                        results.AddRange(get(ids.GetRange(i * maxQueryNumber, maxQueryNumber)));
                    }
                    results.AddRange(get(ids.GetRange(batchNumber * maxQueryNumber, ids.Count-batchNumber * maxQueryNumber)));
                }
                return results;
            }
            return new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
        }
        private static List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity> get(List<int> ids)
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
                        queryIds += "@ids" + i + ",";
                        sqlCommand.Parameters.AddWithValue("ids" + i, ids[i]);
                    }
                    queryIds = queryIds.TrimEnd(',');

                    sqlCommand.CommandText = "SELECT * FROM [DrugPharmacy] WHERE [ID_drug] IN ("+ queryIds +")";                    
                new SqlDataAdapter(sqlCommand).Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    return toList(dataTable);
                }
                else
                {
                    return new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
                }
            }
            return new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>();
        }

        public static int Insert(Infrastructure.Data.Entities.Tables.DrugPharmacyEntity item)
        {
            int response = -1;
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                var sqlTransaction = sqlConnection.BeginTransaction();

                string query = "INSERT INTO [DrugPharmacy] ([cash_price],[coupon],[delivery_type],[ID_drug],[ID_pharmacy],[timeframe])  VALUES (@cash_price,@coupon,@delivery_type,@ID_drug,@ID_pharmacy,@timeframe)";

                using(var sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction))
				{
					sqlCommand.Parameters.AddWithValue("cash_price", item.cash_price);
					sqlCommand.Parameters.AddWithValue("coupon",item.coupon == null ? (object)DBNull.Value  : item.coupon);
					sqlCommand.Parameters.AddWithValue("delivery_type",item.delivery_type == null ? (object)DBNull.Value  : item.delivery_type);
					sqlCommand.Parameters.AddWithValue("ID_drug",item.ID_drug );
					sqlCommand.Parameters.AddWithValue("ID_pharmacy",item.ID_pharmacy);
					sqlCommand.Parameters.AddWithValue("timeframe",item.timeframe == null ? (object)DBNull.Value  : item.timeframe);

                    sqlCommand.ExecuteNonQuery();
                }

                using (var sqlCommand = new SqlCommand("SELECT [ID_drugpharmacy] FROM [DrugPharmacy] WHERE [ID_drugpharmacy] = @@IDENTITY", sqlConnection, sqlTransaction))
                {
                    response = int.Parse(sqlCommand.ExecuteScalar()?.ToString() ?? "-1");
                }
           
                sqlTransaction.Commit();

                return response;
            }
        }
        public static int Insert(List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity> items)
        {
            if (items != null && items.Count > 0)
            {
                int maxParamsNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE / 9; // Nb params per query
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
        private static int insert(List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity> items)
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
                        query += " INSERT INTO [DrugPharmacy] ([cash_price],[coupon],[delivery_type],[ID_drug],[ID_pharmacy],[timeframe]) VALUES ( "

							+ "@cash_price"+ i +","
							+ "@coupon"+ i +","
							+ "@delivery_type"+ i +","
							+ "@ID_drug"+ i +","
							+ "@ID_pharmacy"+ i +","
							+ "@timeframe"+ i 
                            + "); ";

                            
							sqlCommand.Parameters.AddWithValue("cash_price" + i, item.cash_price);
							sqlCommand.Parameters.AddWithValue("coupon" + i, item.coupon == null ? (object)DBNull.Value  : item.coupon);
							sqlCommand.Parameters.AddWithValue("delivery_type" + i, item.delivery_type == null ? (object)DBNull.Value  : item.delivery_type);
							sqlCommand.Parameters.AddWithValue("ID_drug" + i, item.ID_drug );
							sqlCommand.Parameters.AddWithValue("ID_pharmacy" + i, item.ID_pharmacy);
							sqlCommand.Parameters.AddWithValue("timeframe" + i, item.timeframe == null ? (object)DBNull.Value  : item.timeframe);
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
        public static Infrastructure.Data.Entities.Tables.DrugPharmacyEntity GetDrugPharmacy(int id_drug, int id_pharmacy)
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [DrugPharmacy] WHERE [ID_drug]=@id_drug AND [ID_pharmacy]=@id_pharmacy";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id_drug", id_drug);
                sqlCommand.Parameters.AddWithValue("id_pharmacy", id_pharmacy);

                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }

            if (dataTable.Rows.Count > 0)
            {
                return new Infrastructure.Data.Entities.Tables.DrugPharmacyEntity(dataTable.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Helpers

        private static List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity> toList(DataTable dataTable)
        {
            var list = new List<Infrastructure.Data.Entities.Tables.DrugPharmacyEntity>(dataTable.Rows.Count);
            foreach (DataRow dataRow in dataTable.Rows)
            { list.Add(new Infrastructure.Data.Entities.Tables.DrugPharmacyEntity(dataRow)); }
            return list;
        }
        #endregion
    }
}
