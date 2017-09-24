using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EschoolLibrary
{
    public static class InitializeDatabase
    {
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        public static string databaseFile = "eschool.sdf";

        private static string dbConnectionString =
            string.Format("Data Source=|DataDirectory|{0};", databaseFile);

        //TODO
        //static string connectionString

        static string connectionString = "metadata=res://*/EschoolModel.csdl|res://*/EschoolModel.ssdl|res://*/EschoolModel.msl;provider=System.Data.SqlServerCe.4.0;provider connection string='Data Source=" + dbConnectionString;
        //temporary method for conString access
        public static string MyConnection()
        {
            return dbConnectionString;
        }
    }
}
