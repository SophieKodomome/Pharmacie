using Microsoft.EntityFrameworkCore;
using System;
using Npgsql;

namespace connect
{

    public class DBConnect
    {

        public DBConnect(string host,string user,string password,string database)
        {
            String connectionString = "Host="+host+";Username="+user+";Password="+password+";Database="+database;

            using var connection = new NpgsqlConnection(connectionString);

            try
            {
                connection.Open();

                Console.WriteLine("Connected to PostgreSQL!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }

}