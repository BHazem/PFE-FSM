using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Infrastructure.Data.Access.Tables
{

    public class Feuil2Access
    {

        #region Default Methods
        public static Infrastructure.Data.Entities.Tables.Feuil2Entity Get(float additional_hour_rate)
        {
            var dataTable = new DataTable();
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Feuil2] WHERE [Additional_Hour_Rate]=@Id";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", additional_hour_rate); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);

            }

            if (dataTable.Rows.Count > 0)
            {
                return new Infrastructure.Data.Entities.Tables.Feuil2Entity(dataTable.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static List<Infrastructure.Data.Entities.Tables.Feuil2Entity> Get()
        {  
            var dataTable = new DataTable();     
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM [Feuil2]";
                var sqlCommand = new SqlCommand(query, sqlConnection); 

                new SqlDataAdapter(sqlCommand).Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                return toList(dataTable);
            }
            else
            {
                return new List<Infrastructure.Data.Entities.Tables.Feuil2Entity>();
            }
        }
        public static List<Infrastructure.Data.Entities.Tables.Feuil2Entity> Get(List<float> ids)
        {
            if(ids != null && ids.Count > 0)
            {
                int maxQueryNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE ; 
                List<Infrastructure.Data.Entities.Tables.Feuil2Entity> results = null;
                if(ids.Count <= maxQueryNumber)
                {
                    results = get(ids);
                }else
                {
                    int batchNumber = ids.Count / maxQueryNumber;
                    results = new List<Infrastructure.Data.Entities.Tables.Feuil2Entity>();
                    for(int i=0; i<batchNumber; i++)
                    {
                        results.AddRange(get(ids.GetRange(i * maxQueryNumber, maxQueryNumber)));
                    }
                    results.AddRange(get(ids.GetRange(batchNumber * maxQueryNumber, ids.Count-batchNumber * maxQueryNumber)));
                }
                return results;
            }
            return new List<Infrastructure.Data.Entities.Tables.Feuil2Entity>();
        }
        private static List<Infrastructure.Data.Entities.Tables.Feuil2Entity> get(List<float> ids)
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

                    sqlCommand.CommandText = "SELECT * FROM [Feuil2] WHERE [Additional_Hour_Rate] IN ("+ queryIds +")";                    
                new SqlDataAdapter(sqlCommand).Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    return toList(dataTable);
                }
                else
                {
                    return new List<Infrastructure.Data.Entities.Tables.Feuil2Entity>();
                }
            }
            return new List<Infrastructure.Data.Entities.Tables.Feuil2Entity>();
        }

        public static int Insert(Infrastructure.Data.Entities.Tables.Feuil2Entity item)
        {
            int response = -1;
            using(var sqlConnection = new SqlConnection(Infrastructure.Data.Settings.GetConnectionString()))
            {
                sqlConnection.Open();
                var sqlTransaction = sqlConnection.BeginTransaction();

                string query = "INSERT INTO [Feuil2] ([Additional_Hour_Rate],[Address1],[Address2],[AdminFee],[ArchiveDate],[ArchiveUserId],[ChainId],[ChainName],[City],[ContactEmailAddress],[ContactFirstName],[ContactLastName],[ContactPhoneNumber],[CreationDate],[CreationTime],[CreationUserId],[DispencingFee],[First_secondnd_Hour_Rate],[IsArchived],[LastEditDate],[LastEditUserId],[MacFlag],[Name],[Name1],[NCPDPProviderId],[NPI],[ParentOrgID],[ParentOrgName],[Per_Diem_Supplies],[PharmacyDetailsId],[PharmacyId],[PharmacyId1],[PhysicalLoc24HrOpFlag],[PhysicalLocProvHours],[SpecialityRetailFlag],[State],[Zip])  VALUES (@Additional_Hour_Rate,@Address1,@Address2,@AdminFee,@ArchiveDate,@ArchiveUserId,@ChainId,@ChainName,@City,@ContactEmailAddress,@ContactFirstName,@ContactLastName,@ContactPhoneNumber,@CreationDate,@CreationTime,@CreationUserId,@DispencingFee,@First_secondnd_Hour_Rate,@IsArchived,@LastEditDate,@LastEditUserId,@MacFlag,@Name,@Name1,@NCPDPProviderId,@NPI,@ParentOrgID,@ParentOrgName,@Per_Diem_Supplies,@PharmacyDetailsId,@PharmacyId,@PharmacyId1,@PhysicalLoc24HrOpFlag,@PhysicalLocProvHours,@SpecialityRetailFlag,@State,@Zip)";

                using(var sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction))
				{

					sqlCommand.Parameters.AddWithValue("Additional_Hour_Rate",item.Additional_Hour_Rate);
					sqlCommand.Parameters.AddWithValue("Address1",item.Address1 == null ? (object)DBNull.Value  : item.Address1);
					sqlCommand.Parameters.AddWithValue("Address2",item.Address2 == null ? (object)DBNull.Value  : item.Address2);
					sqlCommand.Parameters.AddWithValue("AdminFee",item.AdminFee == null ? (object)DBNull.Value  : item.AdminFee);
					sqlCommand.Parameters.AddWithValue("ArchiveDate",item.ArchiveDate == null ? (object)DBNull.Value  : item.ArchiveDate);
					sqlCommand.Parameters.AddWithValue("ArchiveUserId",item.ArchiveUserId == null ? (object)DBNull.Value  : item.ArchiveUserId);
					sqlCommand.Parameters.AddWithValue("ChainId",item.ChainId == null ? (object)DBNull.Value  : item.ChainId);
					sqlCommand.Parameters.AddWithValue("ChainName",item.ChainName == null ? (object)DBNull.Value  : item.ChainName);
					sqlCommand.Parameters.AddWithValue("City",item.City == null ? (object)DBNull.Value  : item.City);
					sqlCommand.Parameters.AddWithValue("ContactEmailAddress",item.ContactEmailAddress == null ? (object)DBNull.Value  : item.ContactEmailAddress);
					sqlCommand.Parameters.AddWithValue("ContactFirstName",item.ContactFirstName == null ? (object)DBNull.Value  : item.ContactFirstName);
					sqlCommand.Parameters.AddWithValue("ContactLastName",item.ContactLastName == null ? (object)DBNull.Value  : item.ContactLastName);
					sqlCommand.Parameters.AddWithValue("ContactPhoneNumber",item.ContactPhoneNumber == null ? (object)DBNull.Value  : item.ContactPhoneNumber);
					sqlCommand.Parameters.AddWithValue("CreationDate",item.CreationDate == null ? (object)DBNull.Value  : item.CreationDate);
					sqlCommand.Parameters.AddWithValue("CreationTime",item.CreationTime == null ? (object)DBNull.Value  : item.CreationTime);
					sqlCommand.Parameters.AddWithValue("CreationUserId",item.CreationUserId == null ? (object)DBNull.Value  : item.CreationUserId);
					sqlCommand.Parameters.AddWithValue("DispencingFee",item.DispencingFee == null ? (object)DBNull.Value  : item.DispencingFee);
					sqlCommand.Parameters.AddWithValue("First_secondnd_Hour_Rate",item.First_secondnd_Hour_Rate == null ? (object)DBNull.Value  : item.First_secondnd_Hour_Rate);
					sqlCommand.Parameters.AddWithValue("IsArchived",item.IsArchived == null ? (object)DBNull.Value  : item.IsArchived);
					sqlCommand.Parameters.AddWithValue("LastEditDate",item.LastEditDate == null ? (object)DBNull.Value  : item.LastEditDate);
					sqlCommand.Parameters.AddWithValue("LastEditUserId",item.LastEditUserId == null ? (object)DBNull.Value  : item.LastEditUserId);
					sqlCommand.Parameters.AddWithValue("MacFlag",item.MacFlag == null ? (object)DBNull.Value  : item.MacFlag);
					sqlCommand.Parameters.AddWithValue("Name",item.Name == null ? (object)DBNull.Value  : item.Name);
					sqlCommand.Parameters.AddWithValue("Name1",item.Name1 == null ? (object)DBNull.Value  : item.Name1);
					sqlCommand.Parameters.AddWithValue("NCPDPProviderId",item.NCPDPProviderId == null ? (object)DBNull.Value  : item.NCPDPProviderId);
					sqlCommand.Parameters.AddWithValue("NPI",item.NPI == null ? (object)DBNull.Value  : item.NPI);
					sqlCommand.Parameters.AddWithValue("ParentOrgID",item.ParentOrgID == null ? (object)DBNull.Value  : item.ParentOrgID);
					sqlCommand.Parameters.AddWithValue("ParentOrgName",item.ParentOrgName == null ? (object)DBNull.Value  : item.ParentOrgName);
					sqlCommand.Parameters.AddWithValue("Per_Diem_Supplies",item.Per_Diem_Supplies == null ? (object)DBNull.Value  : item.Per_Diem_Supplies);
					sqlCommand.Parameters.AddWithValue("PharmacyDetailsId",item.PharmacyDetailsId == null ? (object)DBNull.Value  : item.PharmacyDetailsId);
					sqlCommand.Parameters.AddWithValue("PharmacyId",item.PharmacyId == null ? (object)DBNull.Value  : item.PharmacyId);
					sqlCommand.Parameters.AddWithValue("PharmacyId1",item.PharmacyId1 == null ? (object)DBNull.Value  : item.PharmacyId1);
					sqlCommand.Parameters.AddWithValue("PhysicalLoc24HrOpFlag",item.PhysicalLoc24HrOpFlag == null ? (object)DBNull.Value  : item.PhysicalLoc24HrOpFlag);
					sqlCommand.Parameters.AddWithValue("PhysicalLocProvHours",item.PhysicalLocProvHours == null ? (object)DBNull.Value  : item.PhysicalLocProvHours);
					sqlCommand.Parameters.AddWithValue("SpecialityRetailFlag",item.SpecialityRetailFlag == null ? (object)DBNull.Value  : item.SpecialityRetailFlag);
					sqlCommand.Parameters.AddWithValue("State",item.State == null ? (object)DBNull.Value  : item.State);
					sqlCommand.Parameters.AddWithValue("Zip",item.Zip == null ? (object)DBNull.Value  : item.Zip);

                    sqlCommand.ExecuteNonQuery();
                }

                using (var sqlCommand = new SqlCommand("SELECT [Additional_Hour_Rate] FROM [Feuil2] WHERE [Additional_Hour_Rate] = @@IDENTITY", sqlConnection, sqlTransaction))
                {
                    response = int.Parse(sqlCommand.ExecuteScalar()?.ToString() ?? "-1");
                }
           
                sqlTransaction.Commit();

                return response;
            }
        }
        public static int Insert(List<Infrastructure.Data.Entities.Tables.Feuil2Entity> items)
        {
            if (items != null && items.Count > 0)
            {
                int maxParamsNumber = Infrastructure.Data.Settings.MAX_BATCH_SIZE / 37; // Nb params per query
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
        private static int insert(List<Infrastructure.Data.Entities.Tables.Feuil2Entity> items)
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
                        query += " INSERT INTO [Feuil2] ([Additional_Hour_Rate],[Address1],[Address2],[AdminFee],[ArchiveDate],[ArchiveUserId],[ChainId],[ChainName],[City],[ContactEmailAddress],[ContactFirstName],[ContactLastName],[ContactPhoneNumber],[CreationDate],[CreationTime],[CreationUserId],[DispencingFee],[First_secondnd_Hour_Rate],[IsArchived],[LastEditDate],[LastEditUserId],[MacFlag],[Name],[Name1],[NCPDPProviderId],[NPI],[ParentOrgID],[ParentOrgName],[Per_Diem_Supplies],[PharmacyDetailsId],[PharmacyId],[PharmacyId1],[PhysicalLoc24HrOpFlag],[PhysicalLocProvHours],[SpecialityRetailFlag],[State],[Zip]) VALUES ( "

							+ "@Additional_Hour_Rate"+ i +","
							+ "@Address1"+ i +","
							+ "@Address2"+ i +","
							+ "@AdminFee"+ i +","
							+ "@ArchiveDate"+ i +","
							+ "@ArchiveUserId"+ i +","
							+ "@ChainId"+ i +","
							+ "@ChainName"+ i +","
							+ "@City"+ i +","
							+ "@ContactEmailAddress"+ i +","
							+ "@ContactFirstName"+ i +","
							+ "@ContactLastName"+ i +","
							+ "@ContactPhoneNumber"+ i +","
							+ "@CreationDate"+ i +","
							+ "@CreationTime"+ i +","
							+ "@CreationUserId"+ i +","
							+ "@DispencingFee"+ i +","
							+ "@First_secondnd_Hour_Rate"+ i +","
							+ "@IsArchived"+ i +","
							+ "@LastEditDate"+ i +","
							+ "@LastEditUserId"+ i +","
							+ "@MacFlag"+ i +","
							+ "@Name"+ i +","
							+ "@Name1"+ i +","
							+ "@NCPDPProviderId"+ i +","
							+ "@NPI"+ i +","
							+ "@ParentOrgID"+ i +","
							+ "@ParentOrgName"+ i +","
							+ "@Per_Diem_Supplies"+ i +","
							+ "@PharmacyDetailsId"+ i +","
							+ "@PharmacyId"+ i +","
							+ "@PharmacyId1"+ i +","
							+ "@PhysicalLoc24HrOpFlag"+ i +","
							+ "@PhysicalLocProvHours"+ i +","
							+ "@SpecialityRetailFlag"+ i +","
							+ "@State"+ i +","
							+ "@Zip"+ i 
                            + "); ";

                            
							sqlCommand.Parameters.AddWithValue("Additional_Hour_Rate" + i, item.Additional_Hour_Rate);
							sqlCommand.Parameters.AddWithValue("Address1" + i, item.Address1 == null ? (object)DBNull.Value  : item.Address1);
							sqlCommand.Parameters.AddWithValue("Address2" + i, item.Address2 == null ? (object)DBNull.Value  : item.Address2);
							sqlCommand.Parameters.AddWithValue("AdminFee" + i, item.AdminFee == null ? (object)DBNull.Value  : item.AdminFee);
							sqlCommand.Parameters.AddWithValue("ArchiveDate" + i, item.ArchiveDate == null ? (object)DBNull.Value  : item.ArchiveDate);
							sqlCommand.Parameters.AddWithValue("ArchiveUserId" + i, item.ArchiveUserId == null ? (object)DBNull.Value  : item.ArchiveUserId);
							sqlCommand.Parameters.AddWithValue("ChainId" + i, item.ChainId == null ? (object)DBNull.Value  : item.ChainId);
							sqlCommand.Parameters.AddWithValue("ChainName" + i, item.ChainName == null ? (object)DBNull.Value  : item.ChainName);
							sqlCommand.Parameters.AddWithValue("City" + i, item.City == null ? (object)DBNull.Value  : item.City);
							sqlCommand.Parameters.AddWithValue("ContactEmailAddress" + i, item.ContactEmailAddress == null ? (object)DBNull.Value  : item.ContactEmailAddress);
							sqlCommand.Parameters.AddWithValue("ContactFirstName" + i, item.ContactFirstName == null ? (object)DBNull.Value  : item.ContactFirstName);
							sqlCommand.Parameters.AddWithValue("ContactLastName" + i, item.ContactLastName == null ? (object)DBNull.Value  : item.ContactLastName);
							sqlCommand.Parameters.AddWithValue("ContactPhoneNumber" + i, item.ContactPhoneNumber == null ? (object)DBNull.Value  : item.ContactPhoneNumber);
							sqlCommand.Parameters.AddWithValue("CreationDate" + i, item.CreationDate == null ? (object)DBNull.Value  : item.CreationDate);
							sqlCommand.Parameters.AddWithValue("CreationTime" + i, item.CreationTime == null ? (object)DBNull.Value  : item.CreationTime);
							sqlCommand.Parameters.AddWithValue("CreationUserId" + i, item.CreationUserId == null ? (object)DBNull.Value  : item.CreationUserId);
							sqlCommand.Parameters.AddWithValue("DispencingFee" + i, item.DispencingFee == null ? (object)DBNull.Value  : item.DispencingFee);
							sqlCommand.Parameters.AddWithValue("First_secondnd_Hour_Rate" + i, item.First_secondnd_Hour_Rate == null ? (object)DBNull.Value  : item.First_secondnd_Hour_Rate);
							sqlCommand.Parameters.AddWithValue("IsArchived" + i, item.IsArchived == null ? (object)DBNull.Value  : item.IsArchived);
							sqlCommand.Parameters.AddWithValue("LastEditDate" + i, item.LastEditDate == null ? (object)DBNull.Value  : item.LastEditDate);
							sqlCommand.Parameters.AddWithValue("LastEditUserId" + i, item.LastEditUserId == null ? (object)DBNull.Value  : item.LastEditUserId);
							sqlCommand.Parameters.AddWithValue("MacFlag" + i, item.MacFlag == null ? (object)DBNull.Value  : item.MacFlag);
							sqlCommand.Parameters.AddWithValue("Name" + i, item.Name == null ? (object)DBNull.Value  : item.Name);
							sqlCommand.Parameters.AddWithValue("Name1" + i, item.Name1 == null ? (object)DBNull.Value  : item.Name1);
							sqlCommand.Parameters.AddWithValue("NCPDPProviderId" + i, item.NCPDPProviderId == null ? (object)DBNull.Value  : item.NCPDPProviderId);
							sqlCommand.Parameters.AddWithValue("NPI" + i, item.NPI == null ? (object)DBNull.Value  : item.NPI);
							sqlCommand.Parameters.AddWithValue("ParentOrgID" + i, item.ParentOrgID == null ? (object)DBNull.Value  : item.ParentOrgID);
							sqlCommand.Parameters.AddWithValue("ParentOrgName" + i, item.ParentOrgName == null ? (object)DBNull.Value  : item.ParentOrgName);
							sqlCommand.Parameters.AddWithValue("Per_Diem_Supplies" + i, item.Per_Diem_Supplies == null ? (object)DBNull.Value  : item.Per_Diem_Supplies);
							sqlCommand.Parameters.AddWithValue("PharmacyDetailsId" + i, item.PharmacyDetailsId == null ? (object)DBNull.Value  : item.PharmacyDetailsId);
							sqlCommand.Parameters.AddWithValue("PharmacyId" + i, item.PharmacyId == null ? (object)DBNull.Value  : item.PharmacyId);
							sqlCommand.Parameters.AddWithValue("PharmacyId1" + i, item.PharmacyId1 == null ? (object)DBNull.Value  : item.PharmacyId1);
							sqlCommand.Parameters.AddWithValue("PhysicalLoc24HrOpFlag" + i, item.PhysicalLoc24HrOpFlag == null ? (object)DBNull.Value  : item.PhysicalLoc24HrOpFlag);
							sqlCommand.Parameters.AddWithValue("PhysicalLocProvHours" + i, item.PhysicalLocProvHours == null ? (object)DBNull.Value  : item.PhysicalLocProvHours);
							sqlCommand.Parameters.AddWithValue("SpecialityRetailFlag" + i, item.SpecialityRetailFlag == null ? (object)DBNull.Value  : item.SpecialityRetailFlag);
							sqlCommand.Parameters.AddWithValue("State" + i, item.State == null ? (object)DBNull.Value  : item.State);
							sqlCommand.Parameters.AddWithValue("Zip" + i, item.Zip == null ? (object)DBNull.Value  : item.Zip);
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
        
        private static List<Infrastructure.Data.Entities.Tables.Feuil2Entity> toList(DataTable dataTable)
        {
            var list = new List<Infrastructure.Data.Entities.Tables.Feuil2Entity>(dataTable.Rows.Count);
            foreach (DataRow dataRow in dataTable.Rows)
            { list.Add(new Infrastructure.Data.Entities.Tables.Feuil2Entity(dataRow)); }
            return list;
        }
        #endregion
    }
}
