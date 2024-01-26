using Microsoft.EntityFrameworkCore;
using System;
using Npgsql;

namespace connect
{

    public class DBConnect
    {

        public DBConnect()
        {
            String connectionString = "Host=localhost;Username=pharmacie;Password=pharmacie;Database=pharmacie";

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