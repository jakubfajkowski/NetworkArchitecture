using System;
using System.Collections.Generic;

namespace NetworkArchitecture.NetworkProject.Model
{
    class Vertex
    {

        private static Random generator = new Random();
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private bool visited = false;
        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }
        private Edge[] edgesOut;
        public Edge[] EdgesOut
        {
            get { return edgesOut; }
        }
        public Edge getRandomEdgeOut()
        {
            Edge randomEdgeOut;
            if (edgesOut.Length > 0 && !allVisited())
            {
                do
                {
                    int id = generator.Next(0, edgesOut.Length);
                    randomEdgeOut = edgesOut[id];

                } while (randomEdgeOut.End.Visited != false);
                return randomEdgeOut;
            }
            else return null;
        }
        private bool allVisited()
        {
            bool ifTrue = true;
            foreach (Edge e in edgesOut)
            {
                ifTrue = ifTrue & e.End.Visited;
            }
            return ifTrue;
        }
        public void addEdgeOut(Edge edge)
        {
            Edge[] tmp_edges = new Edge[edgesOut.Length + 1];
            for (int i = 0; i < edgesOut.Length; i++)
                tmp_edges[i] = edgesOut[i];
            tmp_edges[edgesOut.Length] = edge;
            edgesOut = tmp_edges;
        }

        public Vertex()
        {
            this.id = 0;
            this.edgesOut = new Edge[0];
        }

        public Vertex(int id)
        {
            this.id = id;
            this.edgesOut = new Edge[0];
        }
    }
}
