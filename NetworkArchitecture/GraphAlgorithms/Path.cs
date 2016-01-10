namespace NetworkArchitecture.GraphAlgorithms
{
    class Path
    {
        private Node[] nodes;
        public Node[] Nodes
        {
            get { return nodes; }
        }
        private int length;
        public int Length
        {
            get { return length; }
        }
        public void push(Node node)
        {
            nodes[length] = node;
            length++;
        }
        public Path(int n)
        {
            nodes = new Node[n];
            length = 0;
        }
    }
}
