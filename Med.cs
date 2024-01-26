using System.Collections.Generic;

namespace Medical
{
    public class Med : Diagnose
    {

        private List<Illness> listIllness;
        private int effectiveness;

        public List<Illness> ListIllness { get; set; }
        public int Effectiveness { get; set; }

        public Med addListIllness(List<Illness> il)
        {
            ListIllness = il;
            return this;
        }

        public Med addEffectiveness(int e){
            Effectiveness=e;
            return this;
        }

        public Med(int i, string n, int e) : base(i, n)
        {
            Effectiveness = e;
        }
        public Med(int i, string n, List<Illness> il, int e) : base(i, n)
        {
            ListIllness = il;
            Effectiveness = e;
        }
        
        public Med(){}
    }
}