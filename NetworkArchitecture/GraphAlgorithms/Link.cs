namespace NetworkArchitecture.GraphAlgorithms
{
    class Link
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Node begin;
        public Node Begin
        {
            get { return begin; }
            set { begin = value; }
        }

        private Node end;
        public Node End
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

        public Link(int id, Node begin, Node end)
        {
            this.id = id;
            this.begin = begin;
            this.end = end;
        }
    }
}
