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

        public List<city> GeCities()
        {
            List<city> list = new List<city>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from world.city", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new city()
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            CountryCode = reader["CountryCode"].ToString(),
                            District = reader["District"].ToString(),
                            Population = Convert.ToInt32(reader["Population"])
                        });
                    }
                }
            }

            return list;
        }
    }
}
