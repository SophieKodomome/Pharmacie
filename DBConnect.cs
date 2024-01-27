using Microsoft.EntityFrameworkCore;
using System;
using Npgsql;

namespace connect
{

    public class DBConnect
    {
        private string test;
        String connectionString;

        public string Test { get; set; }
        public string ConnectionString {get;set;}
        public DBConnect()
        {
            Init_Connection();
        }

        private void Init_Connection()
        {
            ConnectionString="Host=localhost;Port=5432;Database=pharmacie;Username=pharmacie;Password=pharmacie;";

            using var connection = new NpgsqlConnection(ConnectionString);

            try
            {
                connection.Open();
                Test = "Connected to PostgreSQL!";
                //Console.WriteLine("Connected to PostgreSQL!");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error: {ex.Message}" );
                Test = $"Error: {ex.Message}";
            }
            finally
            {
                connection.Close();
            }
        }
    }
}