using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Entities.Tables
{
    public class Feuil2Entity
    {
		public float? Additional_Hour_Rate { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public float? AdminFee { get; set; }
		public string ArchiveDate { get; set; }
		public string ArchiveUserId { get; set; }
		public string ChainId { get; set; }
		public string ChainName { get; set; }
		public string City { get; set; }
		public string ContactEmailAddress { get; set; }
		public string ContactFirstName { get; set; }
		public string ContactLastName { get; set; }
		public float? ContactPhoneNumber { get; set; }
		public DateTime? CreationDate { get; set; }
		public DateTime? CreationTime { get; set; }
		public float? CreationUserId { get; set; }
		public float? DispencingFee { get; set; }
		public float? First_secondnd_Hour_Rate { get; set; }
		public float? IsArchived { get; set; }
		public string LastEditDate { get; set; }
		public string LastEditUserId { get; set; }
		public float? MacFlag { get; set; }
		public string Name { get; set; }
		public string Name1 { get; set; }
		public int? NCPDPProviderId { get; set; }
		public float? NPI { get; set; }
		public string ParentOrgID { get; set; }
		public string ParentOrgName { get; set; }
		public float? Per_Diem_Supplies { get; set; }
		public float? PharmacyDetailsId { get; set; }
		public float? PharmacyId { get; set; }
		public float? PharmacyId1 { get; set; }
		public string PhysicalLoc24HrOpFlag { get; set; }
		public string PhysicalLocProvHours { get; set; }
		public float? SpecialityRetailFlag { get; set; }
		public string State { get; set; }
		public float? Zip { get; set; }

        public Feuil2Entity() { }

        public Feuil2Entity(DataRow dataRow)
        {
			Additional_Hour_Rate = (dataRow["Additional_Hour_Rate"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["Additional_Hour_Rate"]);
			Address1 = (dataRow["Address1"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Address1"]);
			Address2 = (dataRow["Address2"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Address2"]);
			AdminFee = (dataRow["AdminFee"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["AdminFee"]);
			ArchiveDate = (dataRow["ArchiveDate"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ArchiveDate"]);
			ArchiveUserId = (dataRow["ArchiveUserId"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ArchiveUserId"]);
			ChainId = (dataRow["ChainId"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ChainId"]);
			ChainName = (dataRow["ChainName"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ChainName"]);
			City = (dataRow["City"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["City"]);
			ContactEmailAddress = (dataRow["ContactEmailAddress"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ContactEmailAddress"]);
			ContactFirstName = (dataRow["ContactFirstName"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ContactFirstName"]);
			ContactLastName = (dataRow["ContactLastName"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ContactLastName"]);
			ContactPhoneNumber = (dataRow["ContactPhoneNumber"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["ContactPhoneNumber"]);
			CreationDate = (dataRow["CreationDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(dataRow["CreationDate"]);
			CreationTime = (dataRow["CreationTime"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(dataRow["CreationTime"]);
			CreationUserId = (dataRow["CreationUserId"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["CreationUserId"]);
			DispencingFee = (dataRow["DispencingFee"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["DispencingFee"]);
			First_secondnd_Hour_Rate = (dataRow["First_secondnd_Hour_Rate"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["First_secondnd_Hour_Rate"]);
			IsArchived = (dataRow["IsArchived"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["IsArchived"]);
			LastEditDate = (dataRow["LastEditDate"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["LastEditDate"]);
			LastEditUserId = (dataRow["LastEditUserId"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["LastEditUserId"]);
			MacFlag = (dataRow["MacFlag"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["MacFlag"]);
			Name = (dataRow["Name"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Name"]);
			Name1 = (dataRow["Name1"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["Name1"]);
			NCPDPProviderId = (dataRow["NCPDPProviderId"] == System.DBNull.Value) ? (int?)null : Convert.ToInt32(dataRow["NCPDPProviderId"]);
			NPI = (dataRow["NPI"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["NPI"]);
			ParentOrgID = (dataRow["ParentOrgID"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ParentOrgID"]);
			ParentOrgName = (dataRow["ParentOrgName"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["ParentOrgName"]);
			Per_Diem_Supplies = (dataRow["Per_Diem_Supplies"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["Per_Diem_Supplies"]);
			PharmacyDetailsId = (dataRow["PharmacyDetailsId"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["PharmacyDetailsId"]);
			PharmacyId = (dataRow["PharmacyId"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["PharmacyId"]);
			PharmacyId1 = (dataRow["PharmacyId1"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["PharmacyId1"]);
			PhysicalLoc24HrOpFlag = (dataRow["PhysicalLoc24HrOpFlag"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["PhysicalLoc24HrOpFlag"]);
			PhysicalLocProvHours = (dataRow["PhysicalLocProvHours"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["PhysicalLocProvHours"]);
			SpecialityRetailFlag = (dataRow["SpecialityRetailFlag"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["SpecialityRetailFlag"]);
			State = (dataRow["State"] == System.DBNull.Value) ? "" : Convert.ToString(dataRow["State"]);
			Zip = (dataRow["Zip"] == System.DBNull.Value) ? (float?)null : Convert.ToSingle(dataRow["Zip"]);
        }
    }
}

