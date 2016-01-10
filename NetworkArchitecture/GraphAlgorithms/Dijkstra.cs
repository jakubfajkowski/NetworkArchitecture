namespace NetworkArchitecture.GraphAlgorithms
{
    static class Dijkstra
    {
        
        static public Path[] runAlgorithm(Graph graph)
        {
            Path[] shortestPaths = new Path[graph.Nodes.Length * graph.Nodes.Length];
            PriorityQueue.Heap<Node> nodesHeap = new PriorityQueue.Heap<Node>();
            int[] prevId = new int[graph.Nodes.Length];

            for (int i = 0; i < graph.Nodes.Length; i++)
            {
                presetCumulatedWeights(graph, graph.Nodes[i].Id);
                nodesHeap.initialise(graph.Nodes.Length);
                for (int j = 0; j < graph.Nodes.Length; j++)
                {
                    nodesHeap.insertElement(new PriorityQueue.Element<Node>(graph.Nodes[j].CumulatedWeight, graph.Nodes[j]));
                }

                while (heap.Size != 0)
                {
                    Node currentNode = nodesHeap.deleteMax().Data;
                    for (int j = 0; j < currentNode.LinksOut.Length; j++)
                    {
                        Link currentLink = currentNode.LinksOut[j];
                        double potentialNewCumulatedWeight = currentNode.CumulatedWeight + currentLink.Weight;

                        if (potentialNewCumulatedWeight > currentLink.End.CumulatedWeight)
                        {
                            currentLink.End.CumulatedWeight = potentialNewCumulatedWeight;
                            prevId[currentLink.End.Id - 1] = currentNode.Id;
                        }
                            
                    }
                }
            }
                
            return shortestPaths;
        }

        static private void presetCumulatedWeights(Graph graph, int beginId)
        {
            for (int i = 0; i < graph.Nodes.Length; i++)
                graph.Nodes[i].CumulatedWeight = 0;
        }

        static private Path[] generatePaths(int[] prevId)
        {
            Path[] shortestPaths = new Path[graph.Nodes.Length];

            
        }
    }
}
