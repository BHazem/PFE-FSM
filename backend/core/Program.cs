using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class Program
    {
        public static void Initiate(string databaseConnectionString)
        {
            setDatabaseConnectionString(databaseConnectionString);
        }

        private static void setDatabaseConnectionString(string connectionString)
        {
            Infrastructure.Data.Settings.SetConnectionString(connectionString);
        }

    }
}
