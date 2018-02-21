using System;
using MySql.Data.MySqlClient;
using Application;

namespace Application.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            return new MySqlConnection(DBConfiguration.ConnectionString);
        }
    }
}
