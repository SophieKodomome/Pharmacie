using System.Collections.Generic;
using Npgsql;

namespace Medical
{
    public class Med : Diagnose
    {

        private int idIllness;
        private int effectiveness;

        public int IdIllness { get; set; }
        public int Effectiveness { get; set; }

        public Med addIdIllness(int i)
        {
            IdIllness = i;
            return this;
        }

        public Med addEfficiency(int e)
        {
            Effectiveness = e;
            return this;
        }

        public Med() { }

        public Med getMedFromDB(NpgsqlConnection connection,int index)
        {
            Med med = new Med();

            connection.Open();
            using (var command = new NpgsqlCommand("select meds,id_meds,id_illness,efficiency from v_meds where id_illness="+index+" order by efficiency desc limit 1;",connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        med
                            .addIdIllness(reader.GetInt32(2))
                            .addEfficiency(reader.GetInt32(3))
                            .addName(reader.GetString(0))
                            .addId(reader.GetInt32(1));
                    }
                }
            }
            connection.Close();
            return med;
        }
    }
}