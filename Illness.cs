using System.Collections.Generic;
using Microsoft.VisualBasic;
using Npgsql;

namespace Medical
{
    public class Illness : Diagnose
    {

        private List<Symptom> listSymptoms;

        public List<Symptom> ListSymptoms { get; set; }


        public Illness addListSymptoms(List<Symptom> s)
        {
            ListSymptoms = s;
            return this;
        }

        public Illness(int i, string n, List<Symptom> s) : base(i, n)
        {
            ListSymptoms = s;
        }

        public Illness(int i, string n) : base(i, n) { }

        public Illness() { }

        public static List<Illness> GetIllnessesFromDB(NpgsqlConnection connection)
        {
            //yes it is a bit long
            List<Illness> listIllness = new List<Illness>();
            //List<Symptom> listSymp=new List<Symptom>();
            connection.Open();
            using(var command=new NpgsqlCommand("select distinct nom_illness,id_illness from v_diagnoses order by id_illness;",connection))
            {
                using(var reader=command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Illness ill=new Illness();
                        ill.addName(reader.GetString(0))
                            .addId(reader.GetInt32(1));
                        listIllness.Add(ill);
                    }
                }
            }
            connection.Close();
            return listIllness;
        }
    }
}