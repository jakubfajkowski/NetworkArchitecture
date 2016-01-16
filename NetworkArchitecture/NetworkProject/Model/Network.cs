using System;
using System.Collections.Generic;

namespace NetworkArchitecture.NetworkProject.Model
{
    class Network
    {
        private Vertex[] vertices;
        public Vertex[] Vertices
        {
            get { return vertices; }
        }

        private Edge[] edges;
        public Edge[] Edges
        {
            get { return edges; }
        }

        private Demand[] demands;
        public Demand[] Demands
        {
            get { return demands; }
        }

        private string getDataFromLine(string s, int n)
        {
            string[] stringSeparator = new string[] { " = ", " " };
            return s.Replace('.', ',').Split(stringSeparator, StringSplitOptions.None)[n];
        }


        public void load(List<string> textFile)
        {
            vertices = new Vertex[int.Parse(getDataFromLine(textFile[0], 1))];
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = new Vertex(i+1);
            }
            edges = new Edge[int.Parse(getDataFromLine(textFile[1], 1))];
            for (int i = 0; i < edges.Length; i++)
            {
                int link_id = int.Parse(getDataFromLine(textFile[2 + i], 0));
                int begin_id = int.Parse(getDataFromLine(textFile[2 + i], 1));
                int end_id = int.Parse(getDataFromLine(textFile[2 + i], 2));
                double capacity = double.Parse(getDataFromLine(textFile[2 + i], 3));
                double price = double.Parse(getDataFromLine(textFile[2 + i], 4));

                edges[i] = new Edge(link_id, vertices[begin_id - 1], vertices[end_id - 1], capacity, price);
                edges[i].Begin.addEdgeOut(edges[i]);
            }
            demands = new Demand[int.Parse(getDataFromLine(textFile[2 + edges.Length], 1))];
            for (int i = 0; i < demands.Length; i++)
            {
                int demand_id = int.Parse(getDataFromLine(textFile[3 + edges.Length + i], 0));
                int begin_id = int.Parse(getDataFromLine(textFile[3 + edges.Length + i], 1));
                int end_id = int.Parse(getDataFromLine(textFile[3 + edges.Length + i], 2));
                double capacity = double.Parse(getDataFromLine(textFile[3 + edges.Length + i], 3));

                demands[i] = new Demand(demand_id, vertices[begin_id - 1], vertices[end_id - 1], capacity);
            }
        }

        public Network(Network source)
        {
            this.vertices = new Vertex[source.vertices.Length];
            for (int i = 0; i < source.vertices.Length; i++)
            {
                this.vertices[i] = new Vertex(i + 1);
            }
            this.edges = new Edge[source.edges.Length];
            for (int i = 0; i < source.edges.Length; i++)
            {
                Edge e = source.edges[i];
                this.edges[i] = new Edge(e.Id, this.vertices[e.Begin.Id - 1], this.vertices[e.End.Id - 1], e.Module.Capacity, e.Module.Price);
                this.edges[i].Begin.addEdgeOut(this.edges[i]);
            }

            this.demands = new Demand[source.demands.Length];
            for (int i = 0; i < source.demands.Length; i++)
            {
                Demand c = source.demands[i];
                this.demands[i] = new Demand(c.Id, this.vertices[c.Begin.Id - 1], this.vertices[c.End.Id - 1], c.Capacity);
            }
        }

        public Network() { }

        public double Price()
        {
            double price = 0;
            foreach (Model.Edge e in edges)
                price += e.Price;
            return price;
        }
        public void resetEdges()
        {
            foreach (Edge e in edges)
                e.resetEdge();
        }

        public void resetVertices()
        {
            foreach (Vertex v in vertices)
                v.Visited = false;
        }
    }
}
