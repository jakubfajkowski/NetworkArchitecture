namespace NetworkArchitecture.NetworkProject.Model
{
    class Demand
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Vertex begin;
        public Vertex Begin
        {
            get { return begin; }
            set { begin = value; }
        }

        private Vertex end;
        public Vertex End
        {
            get { return end; }
            set { end = value; }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Demand(int id, Vertex begin, Vertex end, double weight)
        {
            this.id = id;
            this.begin = begin;
            this.end = end;
            this.weight = weight;
        }
    }
}
