namespace NetworkArchitecture.GraphAlgorithms
{
    class Node
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private double cumulatedWeight;
        public double CumulatedWeight
        {
            get { return cumulatedWeight; }
            set { cumulatedWeight = value; }
        }

        private Link[] linksOut;
        public Link[] LinksOut
        {
            get { return linksOut; }
        }

        public void addLinkOut(Link link)
        {
            Link[] tmp_links = new Link[linksOut.Length + 1];
            for (int i = 0; i < linksOut.Length; i++)
                tmp_links[i] = linksOut[i];
            tmp_links[linksOut.Length] = link;
            linksOut = tmp_links;
        }

        public Node()
        {
            this.id = 0;
            this.linksOut = new Link[0];
        }

        public Node(int id)
        {
            this.id = id;
            this.linksOut = new Link[0];
        }
    }
}
