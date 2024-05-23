using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TVDCalculator
{
    internal class Modify
    {
        public Modify()
        {

        }
        SqlDataAdapter dataAdapter;
        SqlCommand SqlCommand;
        public DataTable Table(String query)
        {
            DataTable dt = new DataTable();
            using(SqlConnection sqlConnection = Connection.GetSqlConnection()) 
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dt);
                sqlConnection.Close();
            }
            return dt;
        }
        public void Command(string query)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand(query, sqlConnection);
                SqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

    }
}
