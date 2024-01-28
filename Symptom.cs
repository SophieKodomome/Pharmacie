using connect;
using System;
using Npgsql;
using System.Collections.Generic;

namespace Medical
{
    public class Symptom : Diagnose
    {
        private int maxPain;

        private int minPain;
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

        public int MaxPain
        {
            get { return maxPain; }
            set
            {
                if (value <= 10)
                {
                    maxPain = value;
                }
                else
                {
                    throw new Exception("max pain can't go higher than 10");
                }
            }
        }
        public int MinPain
        {
            get { return minPain; }
            set
            {
                if (value > 0)
                {
                    minPain = value;
                }
                else
                {
                    throw new Exception("min pain can't go lower than 0");
                }
            }
        }

        public Symptom addMaxPain(int m)
        {
            MaxPain = m;
            return this;
        }

        public Symptom addMinPain(int m)
        {
            MinPain = m;
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

        public List<Symptom> getSymptomsForIllness(NpgsqlConnection connection,int id)
        {
            List<Symptom> listSymptoms = new List<Symptom>();

            connection.Open();

            using (var command = new NpgsqlCommand("SELECT * from v_diagnoses where id_illness="+id+";", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Symptom s = new Symptom();
                        s
                            .addMaxPain(reader.GetInt32(5))
                            .addMinPain(reader.GetInt32(6))
                            .addName(reader.GetString(2))
                            .addId(reader.GetInt32(4));
                        listSymptoms.Add(s);
                    }
                }
            }

            connection.Close();
            return listSymptoms;
        }
    }
}