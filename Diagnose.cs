namespace Medical
{

    public abstract class Diagnose
    {
        private int id;
        private string name;

        public string Name{get;set;}

        public int Id{get;set;}

        public Diagnose addName(string n){
            Name=n;
            return this;
        }
        public Diagnose addId(int i){
            
            Id=i;
            return this;
        }
        public Diagnose(){}
        public Diagnose(int i,string n){
            this.Id=i;
            this.Name=n;
        }
        
    }

    

}