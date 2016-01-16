namespace NetworkArchitecture.NetworkProject.Model
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

        private Module module;
        public Module Module
        {
            get { return module; }
        }

        private int numberOfModules;
        public int NumberOfModules
        {
            get { return numberOfModules; }
            set { numberOfModules = value; }
        }

        private double freeCapacity;
        public double FreeCapacity
        {
            get { return freeCapacity; }
        }
        public double Price
        {
            get { return numberOfModules * module.Price; }
        }
        public void resetEdge()
        {
            freeCapacity = 0;
            numberOfModules = 0;
        }
        public void addModule()
        {
            numberOfModules++;
            freeCapacity += module.Capacity;
        }
        public void flow(Demand demand)
        {
            if (freeCapacity >= demand.Capacity)
            {
                freeCapacity -= demand.Capacity;
            }
            else
            {
                addModule();
                flow(demand);
            }
        }
        public Edge(int id, Vertex begin, Vertex end, double capacity, double price)
        {
            this.id = id;
            this.begin = begin;
            this.end = end;
            this.module = new Module(capacity, price);
        }
        //public Edge(Edge source)
        //{
        //    this.id = source.id;
        //    this.begin = source.begin;
        //    this.end = source.end;
        //    this.module = source.module;
        //    this.numberOfModules = source.numberOfModules;
        //    this.freeCapacity = source.freeCapacity;
        //}
    }
}
