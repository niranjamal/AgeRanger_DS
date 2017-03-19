using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace AgeRanger.Dao
{
    public class DBConnection
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DataDirectory}\AgeRanger.mdf;Integrated Security=True";

        public static SqlConnection NewConnection()
        {
            var connstr = "";
            if (HttpContext.Current != null)
            {
                connstr = ConnectionString.Replace("{DataDirectory}", HttpContext.Current.Server.MapPath("~/App_Data"));
            }
            else
            {
                var separator = Path.DirectorySeparatorChar;
                var currentPath = AppDomain.CurrentDomain.BaseDirectory;
                connstr = ConnectionString.Replace("{DataDirectory}", separator + "AgeRanger" + separator + "App_Data");
            }
            return new SqlConnection(connstr);
        }

    }
}