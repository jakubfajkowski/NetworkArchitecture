using System.Collections.Generic;

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

        private double capacity;
        public double Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        private Stack<Edge> path;
        public Stack<Edge> Path
        {
            get { return path; }
            set { path = value; }
        }

        public void flow()
        {
            foreach (Edge e in path)
            {
                e.flow(this);
            }
        }

        public Demand(int id, Vertex begin, Vertex end, double weight)
        {
            this.id = id;
            this.begin = begin;
            this.end = end;
            this.capacity = weight;
        }
    }
}
