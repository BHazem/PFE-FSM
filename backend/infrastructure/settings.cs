using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Infrastructure.Data
{
    public class Settings
    {
        public static int MAX_BATCH_SIZE = 50;
        private static string _connectionString { get; set; }

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }

        public class PagingModel
        {
            public int FirstRowNumber { get; set; }
            public int RequestRows { get; set; }
        }

        public class SortingModel
        {
            public string SortFieldName { get; set; }
            public bool SortDesc { get; set; }
        }
    }
}
