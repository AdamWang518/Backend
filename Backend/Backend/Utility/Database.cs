using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Utility
{
    public class Database
    {
        SqlConnection sqlConnection;
        public Database()
        {
            String connectionString = @"Persist Security Info=False;Integrated Security=true; Initial Catalog = Final_Project; Server = localhost";
            this.sqlConnection = new SqlConnection(connectionString);
            this.sqlConnection.Open();
        }

        public List<T> Query<T>(String sql)
        {
           return this.sqlConnection.Query<T>(sql).ToList();
        }

        public int NoQuery(String sql)
        {
            SqlCommand command = new SqlCommand(sql, this.sqlConnection);
            return command.ExecuteNonQuery();
        }
    }
}