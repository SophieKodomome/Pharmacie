using System.Collections.Generic;

namespace Medical
{
    public class Illness : Diagnose
    {

        private List<Symptom> listSymptoms;
        private List<Med> listMeds;

        public List<Symptom> ListSymptoms { get; set; }
        public List<Med> ListMeds { get; set; }

        public Illness addListSymptoms(List<Symptom> s)
        {
            ListSymptoms = s;
            return this;
        }

        public Illness addListMeds(List<Med> m)
        {
            ListMeds = m;
            return this;
        }
        public Illness(int i, string n, List<Symptom> s) : base(i, n)
        {
            ListSymptoms = s;
        }

        public Illness(int i, string n, List<Med> m) : base(i, n)
        {
            ListMeds= m;
        }
    }
}