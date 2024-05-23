using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TVDCalculator
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manch\source\repos\TVDCalculator\TVD.mdf;Integrated Security=True";
        public static SqlConnection GetSqlConnection() 
        {
            return new SqlConnection(stringConnection);
        }
    }
}
