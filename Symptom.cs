using connect;
using System;
using Npgsql;
using System.Collections.Generic;

namespace Medical
{
    public class Symptom : Diagnose
    {
        private double severity;

        public double Severity
        {
            get { return severity; }
            set
            {
                if (value <= 10)
                {
                    severity = value;
                }
                else
                {
                    throw new Exception("illness's severity can't go higher than 10");
                }
            }
        }

        public Symptom addSeverity(double s)
        {
            Severity = s;
            return this;
        }

        public Symptom() { }
        public Symptom(int i, string n, double s) : base(i, n)
        {
            Severity = s;
        }

        public List<Symptom> getSymptomsFromDB(NpgsqlConnection connection)
        {
            List<Symptom> listSymptoms = new List<Symptom>();

            connection.Open();

            using (var command = new NpgsqlCommand("SELECT * FROM Symptoms", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Symptom s = new Symptom();
                        s.addId(reader.GetInt32(0)).addName(reader.GetString(1));
                        listSymptoms.Add(s);
                    }
                }
            }

            connection.Close();
            return listSymptoms;
        }

/*        public void createLog_Symptoms(NpgsqlConnection connection)
        {

            string query = "CREATE TABLE Log_symptoms(id_Symptom int,FOREIGN KEY (id_Symptom) References symptoms(id),severity integer check (severity<=100));";

            try
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table created successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void insertSymptomtoLog(NpgsqlConnection connection)
        {
            string query = "INSERT INTO Log_symptoms VALUES (" + this.Id +","+ this.Severity+");";
            try
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }*/
    }
}