using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Easy_Learn.Models
{
    public class wordModel
    {
        public string ConnectionString { get; set; }

        public wordModel(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
