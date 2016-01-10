namespace NetworkArchitecture.GraphAlgorithms
{
    class Edge
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

        public Edge(int id, Vertex begin, Vertex end)
        {
            this.id = id;
            this.begin = begin;
            this.end = end;
        }
    }
}
