using System;
using System.Collections.Generic;

namespace NetworkArchitecture.GraphAlgorithms
{
    class Graph
    {
        private Node[] nodes;
        public Node[] Nodes
        {
            get { return nodes; }
        }

        private Link[] links;
        public Link[] Links
        {
            get { return links; }
        }

        
        private string getDataFromLine(string s, int n)
        {
            string[] stringSeparator = new string[] { " = ", " " };

            return s.Split(stringSeparator, StringSplitOptions.None)[n];
        }


        public void load(List<string> textFile)
        {
            nodes = new Node[int.Parse(getDataFromLine(textFile[0], 1))];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node(i+1);
            }
            links = new Link[int.Parse(getDataFromLine(textFile[1], 1))];
            for (int i = 0; i < links.Length; i++)
            {
                int link_id = int.Parse(getDataFromLine(textFile[2 + i], 0));
                int begin_id = int.Parse(getDataFromLine(textFile[2 + i], 1));
                int end_id = int.Parse(getDataFromLine(textFile[2 + i], 2));

                links[i] = new Link(link_id, nodes[begin_id - 1], nodes[end_id - 1]);
                links[i].Begin.addLinkOut(links[i]);
            }
        }

        public void randomizeLinksWeights()
        {
            Random generator = new Random();
            for (int i = 0; i < links.Length; i++)
            {
                double randomWeight = generator.NextDouble();
                links[i].Weight = randomWeight;
            }
        }
    }
}
