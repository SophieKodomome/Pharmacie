using connect;
using System;
using Npgsql;
using System.Collections.Generic;
using Microsoft.Net.Http.Headers;

namespace Medical
{
    public class Symptom : Diagnose
    {
        private int maxPain;

        private int minPain;
        private int severity;

        private bool isASymptom=false;

        public int Severity{get;set;}
        public bool IsASymptom{get;set;}
        public Symptom addSeverity(int s)
        {
            Severity = s;
            return this;
        }

        public int MaxPain{get;set;}
        public int MinPain{get;set;}


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

        public static List<Symptom> getSymptomsFromDB(NpgsqlConnection connection)
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

        public static List<Symptom> getSymptomsForIllness(NpgsqlConnection connection,int id)
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
                            .addMaxPain(reader.GetInt32(4))
                            .addMinPain(reader.GetInt32(5))
                            .addName(reader.GetString(2))
                            .addId(reader.GetInt32(3));
                        listSymptoms.Add(s);
                    }
                }
            }

            connection.Close();
            return listSymptoms;
        }
    }
}