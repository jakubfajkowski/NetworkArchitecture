namespace NetworkArchitecture.GraphAlgorithms
{
    class Path
    {
        private Vertex[] vertices;
        public Vertex[] Vertices
        {
            get
            {
                Vertex[] existingVertices = new Vertex[length];
                for (int i = 0; i < length; i++)
                {
                    existingVertices[i] = vertices[length - 1 - i];
                }
                return existingVertices;
            }
        }
 
        private double minWeight;
        public double MinWeight
        {
            get { return minWeight; }
        }

        private double sumWeight;
        public double SumWeight
        {
            get { return sumWeight; }
        }

        private int length;
        public int Length
        {
            get { return length; }
        }

        public void push(Vertex vertex)
        {
            vertices[length++] = vertex;
            sumWeight += vertex.CumulatedWeight;
            for (int i = 0; i < length; i++)
            {
                if (vertices[i].CumulatedWeight < minWeight)
                    minWeight = vertices[i].CumulatedWeight;
            }
        }
        public Path(int n)
        {
            vertices = new Vertex[n];
            length = 0;
            sumWeight = 0;
            minWeight = 0;
        }
    }
}
