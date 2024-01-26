using System.Collections.Generic;

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

        public Illness(int i, string n) : base(i, n){}

        public Illness(){}
    }
}