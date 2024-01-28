using System.Collections.Generic;

namespace Medical
{
    public class Illness : Diagnose
    {

        private List<Symptom> listSymptoms;

        private int maxPain;

        private int minPain;
        public List<Symptom> ListSymptoms { get; set; }

        public int MaxPain{            
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
        public int MinPain{            
            get { return minPain; }
            set
            {
                if (value > 0)
                {
                    minPain = value;
                }
                else
                {
                    throw new Exception("max pain can't go higher than 10");
                }
            }
        }
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