using connect;
using System;
using Npgsql;
using System.Collections.Generic;

namespace Medical
{
    public class Symptom : Diagnose
    {
        private int severity;

        public int Severity
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

        public Symptom addSeverity(int s)
        {
            Severity = s;
            return this;
        }

        public Symptom() { }
        public Symptom(int i, string n, int s) : base(i, n)
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
    }
}