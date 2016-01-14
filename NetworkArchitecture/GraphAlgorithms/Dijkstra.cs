using System;

namespace NetworkArchitecture.GraphAlgorithms
{
    static class Dijkstra
    {
        private const double infinity = double.MaxValue;
        static private Graph graph;
        static public Path[] runAlgorithm(Graph graph_, Vertex begin)
        {
            graph = graph_;
            Path[] widestPaths = new Path[graph.Vertices.Length];
            PriorityQueue.Heap<Vertex> verticesHeap = new PriorityQueue.Heap<Vertex>();

            initialize(begin);
            verticesHeap.initialise(graph.Vertices.Length);
            for (int i = 0; i < graph.Vertices.Length; i++)
            {
                verticesHeap.insertElement(new PriorityQueue.Element<Vertex>(graph.Vertices[i].CumulatedWeight, graph.Vertices[i]));
            }

            while(verticesHeap.NumberOfElements != 0)
            {
                Vertex currentVertex = verticesHeap.deleteMax().Data;
                if (currentVertex.CumulatedWeight == 0)
                    break;

                foreach(Edge e in currentVertex.EdgesOut)
                {
                    Vertex neighbor = e.End;

                    double alternate = Math.Max(neighbor.CumulatedWeight, Math.Min(currentVertex.CumulatedWeight, e.Weight));

                    if (alternate > neighbor.CumulatedWeight)
                    {
                        neighbor.CumulatedWeight = alternate;
                        neighbor.Prev = currentVertex;
                    }
                }
                sortHeap(ref verticesHeap);
            }

            for (int i = 0; i < graph.Vertices.Length; i++)
            {
                widestPaths[i] = generatePath(begin, graph.Vertices[i]);
            }

            return widestPaths;
        }
        static public Path[] runAlgorithm(Graph graph)
        {
            Path[] shortestPaths = new Path[graph.Vertices.Length * graph.Vertices.Length];

            for (int i = 0; i < graph.Vertices.Length; i++)
            {
                

                //generatePath()
            }
                
            return shortestPaths;
        }

        static private void initialize(Vertex begin)
        {

            for (int i = 0; i < graph.Vertices.Length; i++)
            {
                graph.Vertices[i].CumulatedWeight = 0;
                graph.Vertices[i].Prev = null;
            }
                
            graph.Vertices[begin.Id - 1].CumulatedWeight = infinity;

            begin.Prev = begin;
        }

        static private void sortHeap(ref PriorityQueue.Heap<Vertex> heap)
        {
            PriorityQueue.Element<Vertex>[] updatedKeys = new PriorityQueue.Element<Vertex>[heap.NumberOfElements];
            for (int i = 0; i < updatedKeys.Length; i++)
            {
                updatedKeys[i] = updateKey(heap.deleteMax());
            }
                for (int i = 0; i < updatedKeys.Length; i++)
            {
                heap.insertElement(updatedKeys[i]);
            }
        }

        static private PriorityQueue.Element<Vertex> updateKey(PriorityQueue.Element<Vertex> element)
        {
            element.Key = element.Data.CumulatedWeight;
            return element;
        }

        static private Path generatePath(Vertex begin, Vertex end)
        {
            Path path = new Path(graph.Vertices.Length);
            Vertex currentVertex = end;

            while (currentVertex != begin)
            {
                if (currentVertex == null)
                {
                    return null;
                }
                path.push(currentVertex);
                currentVertex = currentVertex.Prev;
            }
            path.push(begin);

            return path;
        }
    }
}
