using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Infrastructure.Data.Access.Tables
{

    public class Feuil1Access
    {

        #region Default Methods
        public static Infrastructure.Data.Entities.Tables.Feuil1Entity Get(float activemacrate)
        {
            var dataTable = new DataTable();
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Feuil1] WHERE [ActiveMacRate]=@Id";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", activemacrate); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }

            if (dataTable.Rows.Count > 0)
            {
                return new Infrastructure.Data.Entities.Tables.Feuil1Entity(dataTable.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static List<Infrastructure.Data.Entities.Tables.Feuil1Entity> Get()
        {  
            var dataTable = new DataTable();     
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Feuil1]";
                var sqlCommand = new SqlCommand(query, sqlConnection); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.Feuil1Entity>();
            }
        }
        public static List<Infrastructure.Data.Entities.Tables.Feuil1Entity> Get(List<float> ids)
        {
            if(ids != null && ids.Count > 0)
            {
                int maxQueryNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE ; 
                List<Infrastructure.Data.Entities.Tables.Feuil1Entity> results = null;
                if(ids.Count <= maxQueryNumber)
                {
                    results = get(ids);
                }else
                {
                    int batchNumber = ids.Count / maxQueryNumber;
                    results = new List<Infrastructure.Data.Entities.Tables.Feuil1Entity>();
                    for(int i=0; i<batchNumber; i++)
                    {
                        results.AddRange(get(ids.GetRange(i * maxQueryNumber, maxQueryNumber)));
                    }
                    results.AddRange(get(ids.GetRange(batchNumber * maxQueryNumber, ids.Count-batchNumber * maxQueryNumber)));
                }
                return results;
            }
            return new List<Infrastructure.Data.Entities.Tables.Feuil1Entity>();
        }
        private static List<Infrastructure.Data.Entities.Tables.Feuil1Entity> get(List<float> ids)
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

                    sqlCommand.CommandText = "SELECT * FROM [Feuil1] WHERE [ActiveMacRate] IN ("+ queryIds +")";                    
                new SqlDataAdapter(sqlCommand).Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    return toList(dataTable);
                }
                else
                {
                    return new List<Infrastructure.Data.Entities.Tables.Feuil1Entity>();
                }
            }
            return new List<Infrastructure.Data.Entities.Tables.Feuil1Entity>();
        }

        public static int Insert(Infrastructure.Data.Entities.Tables.Feuil1Entity item)
        {
            int response = -1;
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                var sqlTransaction = sqlConnection.BeginTransaction();

                string query = "INSERT INTO [Feuil1] ([ActiveMacRate],[ActiveRateMacId],[BrandName],[ClassName],[Coupon],[DDI],[Delivery],[DrugGpiId],[DrugId],[Expr1],[Gpi],[Gpi4],[LowestPrice],[MacFlag],[MacPrice],[Name],[PharmacyId],[PriceToPay],[Rate],[TherapeuticClassId],[Timeframe],[Type])  VALUES (@ActiveMacRate,@ActiveRateMacId,@BrandName,@ClassName,@Coupon,@DDI,@Delivery,@DrugGpiId,@DrugId,@Expr1,@Gpi,@Gpi4,@LowestPrice,@MacFlag,@MacPrice,@Name,@PharmacyId,@PriceToPay,@Rate,@TherapeuticClassId,@Timeframe,@Type)";

                using(var sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction))
				{

					sqlCommand.Parameters.AddWithValue("ActiveMacRate",item.ActiveMacRate);
					sqlCommand.Parameters.AddWithValue("ActiveRateMacId",item.ActiveRateMacId == null ? (object)DBNull.Value  : item.ActiveRateMacId);
					sqlCommand.Parameters.AddWithValue("BrandName",item.BrandName == null ? (object)DBNull.Value  : item.BrandName);
					sqlCommand.Parameters.AddWithValue("ClassName",item.ClassName == null ? (object)DBNull.Value  : item.ClassName);
					sqlCommand.Parameters.AddWithValue("Coupon",item.Coupon == null ? (object)DBNull.Value  : item.Coupon);
					sqlCommand.Parameters.AddWithValue("DDI",item.DDI == null ? (object)DBNull.Value  : item.DDI);
					sqlCommand.Parameters.AddWithValue("Delivery",item.Delivery == null ? (object)DBNull.Value  : item.Delivery);
					sqlCommand.Parameters.AddWithValue("DrugGpiId",item.DrugGpiId == null ? (object)DBNull.Value  : item.DrugGpiId);
					sqlCommand.Parameters.AddWithValue("DrugId",item.DrugId == null ? (object)DBNull.Value  : item.DrugId);
					sqlCommand.Parameters.AddWithValue("Expr1",item.Expr1 == null ? (object)DBNull.Value  : item.Expr1);
					sqlCommand.Parameters.AddWithValue("Gpi",item.Gpi == null ? (object)DBNull.Value  : item.Gpi);
					sqlCommand.Parameters.AddWithValue("Gpi4",item.Gpi4 == null ? (object)DBNull.Value  : item.Gpi4);
					sqlCommand.Parameters.AddWithValue("LowestPrice",item.LowestPrice == null ? (object)DBNull.Value  : item.LowestPrice);
					sqlCommand.Parameters.AddWithValue("MacFlag",item.MacFlag == null ? (object)DBNull.Value  : item.MacFlag);
					sqlCommand.Parameters.AddWithValue("MacPrice",item.MacPrice == null ? (object)DBNull.Value  : item.MacPrice);
					sqlCommand.Parameters.AddWithValue("Name",item.Name == null ? (object)DBNull.Value  : item.Name);
					sqlCommand.Parameters.AddWithValue("PharmacyId",item.PharmacyId == null ? (object)DBNull.Value  : item.PharmacyId);
					sqlCommand.Parameters.AddWithValue("PriceToPay",item.PriceToPay == null ? (object)DBNull.Value  : item.PriceToPay);
					sqlCommand.Parameters.AddWithValue("Rate",item.Rate == null ? (object)DBNull.Value  : item.Rate);
					sqlCommand.Parameters.AddWithValue("TherapeuticClassId",item.TherapeuticClassId == null ? (object)DBNull.Value  : item.TherapeuticClassId);
					sqlCommand.Parameters.AddWithValue("Timeframe",item.Timeframe == null ? (object)DBNull.Value  : item.Timeframe);
					sqlCommand.Parameters.AddWithValue("Type",item.Type == null ? (object)DBNull.Value  : item.Type);

                    sqlCommand.ExecuteNonQuery();
                }

                using (var sqlCommand = new SqlCommand("SELECT [ActiveMacRate] FROM [Feuil1] WHERE [ActiveMacRate] = @@IDENTITY", sqlConnection, sqlTransaction))
                {
                    response = int.Parse(sqlCommand.ExecuteScalar()?.ToString() ?? "-1");
                }
           
                sqlTransaction.Commit();

                return response;
            }
        }
        public static int Insert(List<Infrastructure.Data.Entities.Tables.Feuil1Entity> items)
        {
            if (items != null && items.Count > 0)
            {
                int maxParamsNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE / 22; // Nb params per query
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
        private static int insert(List<Infrastructure.Data.Entities.Tables.Feuil1Entity> items)
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
                        query += " INSERT INTO [Feuil1] ([ActiveMacRate],[ActiveRateMacId],[BrandName],[ClassName],[Coupon],[DDI],[Delivery],[DrugGpiId],[DrugId],[Expr1],[Gpi],[Gpi4],[LowestPrice],[MacFlag],[MacPrice],[Name],[PharmacyId],[PriceToPay],[Rate],[TherapeuticClassId],[Timeframe],[Type]) VALUES ( "

							+ "@ActiveMacRate"+ i +","
							+ "@ActiveRateMacId"+ i +","
							+ "@BrandName"+ i +","
							+ "@ClassName"+ i +","
							+ "@Coupon"+ i +","
							+ "@DDI"+ i +","
							+ "@Delivery"+ i +","
							+ "@DrugGpiId"+ i +","
							+ "@DrugId"+ i +","
							+ "@Expr1"+ i +","
							+ "@Gpi"+ i +","
							+ "@Gpi4"+ i +","
							+ "@LowestPrice"+ i +","
							+ "@MacFlag"+ i +","
							+ "@MacPrice"+ i +","
							+ "@Name"+ i +","
							+ "@PharmacyId"+ i +","
							+ "@PriceToPay"+ i +","
							+ "@Rate"+ i +","
							+ "@TherapeuticClassId"+ i +","
							+ "@Timeframe"+ i +","
							+ "@Type"+ i 
                            + "); ";

                            
							sqlCommand.Parameters.AddWithValue("ActiveMacRate" + i, item.ActiveMacRate);
							sqlCommand.Parameters.AddWithValue("ActiveRateMacId" + i, item.ActiveRateMacId == null ? (object)DBNull.Value  : item.ActiveRateMacId);
							sqlCommand.Parameters.AddWithValue("BrandName" + i, item.BrandName == null ? (object)DBNull.Value  : item.BrandName);
							sqlCommand.Parameters.AddWithValue("ClassName" + i, item.ClassName == null ? (object)DBNull.Value  : item.ClassName);
							sqlCommand.Parameters.AddWithValue("Coupon" + i, item.Coupon == null ? (object)DBNull.Value  : item.Coupon);
							sqlCommand.Parameters.AddWithValue("DDI" + i, item.DDI == null ? (object)DBNull.Value  : item.DDI);
							sqlCommand.Parameters.AddWithValue("Delivery" + i, item.Delivery == null ? (object)DBNull.Value  : item.Delivery);
							sqlCommand.Parameters.AddWithValue("DrugGpiId" + i, item.DrugGpiId == null ? (object)DBNull.Value  : item.DrugGpiId);
							sqlCommand.Parameters.AddWithValue("DrugId" + i, item.DrugId == null ? (object)DBNull.Value  : item.DrugId);
							sqlCommand.Parameters.AddWithValue("Expr1" + i, item.Expr1 == null ? (object)DBNull.Value  : item.Expr1);
							sqlCommand.Parameters.AddWithValue("Gpi" + i, item.Gpi == null ? (object)DBNull.Value  : item.Gpi);
							sqlCommand.Parameters.AddWithValue("Gpi4" + i, item.Gpi4 == null ? (object)DBNull.Value  : item.Gpi4);
							sqlCommand.Parameters.AddWithValue("LowestPrice" + i, item.LowestPrice == null ? (object)DBNull.Value  : item.LowestPrice);
							sqlCommand.Parameters.AddWithValue("MacFlag" + i, item.MacFlag == null ? (object)DBNull.Value  : item.MacFlag);
							sqlCommand.Parameters.AddWithValue("MacPrice" + i, item.MacPrice == null ? (object)DBNull.Value  : item.MacPrice);
							sqlCommand.Parameters.AddWithValue("Name" + i, item.Name == null ? (object)DBNull.Value  : item.Name);
							sqlCommand.Parameters.AddWithValue("PharmacyId" + i, item.PharmacyId == null ? (object)DBNull.Value  : item.PharmacyId);
							sqlCommand.Parameters.AddWithValue("PriceToPay" + i, item.PriceToPay == null ? (object)DBNull.Value  : item.PriceToPay);
							sqlCommand.Parameters.AddWithValue("Rate" + i, item.Rate == null ? (object)DBNull.Value  : item.Rate);
							sqlCommand.Parameters.AddWithValue("TherapeuticClassId" + i, item.TherapeuticClassId == null ? (object)DBNull.Value  : item.TherapeuticClassId);
							sqlCommand.Parameters.AddWithValue("Timeframe" + i, item.Timeframe == null ? (object)DBNull.Value  : item.Timeframe);
							sqlCommand.Parameters.AddWithValue("Type" + i, item.Type == null ? (object)DBNull.Value  : item.Type);
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
        public static List<Infrastructure.Data.Entities.Tables.Feuil1Entity> Getdrugs(int ddi)
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Feuil1] WHERE [DDI] = @ddi";
                var sqlCommand = new SqlCommand(query, sqlConnection);

                new SqlDataAdapter(sqlCommand).Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.Feuil1Entity>();
            }
        }
        #endregion

        #region Helpers

        private static List<Infrastructure.Data.Entities.Tables.Feuil1Entity> toList(DataTable dataTable)
        {
            var list = new List<Infrastructure.Data.Entities.Tables.Feuil1Entity>(dataTable.Rows.Count);
            foreach (DataRow dataRow in dataTable.Rows)
            { list.Add(new Infrastructure.Data.Entities.Tables.Feuil1Entity(dataRow)); }
            return list;
        }
        #endregion
    }
}
