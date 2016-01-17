using System;
using System.Collections.Generic;

namespace NetworkArchitecture.GraphAlgorithms
{
    static class Floyd
    {

        private const double infinity = 100;//double.MaxValue;
        static private Graph graph;
        static private double[,] weights;
        static private Vertex[,] prev;


        static private void initialize()
        {
            weights = new double[graph.Vertices.Length, graph.Vertices.Length];
            prev = new Vertex[graph.Vertices.Length, graph.Vertices.Length];

            for (int i = 0; i < graph.Vertices.Length; i++)
            {
                for (int j = 0; j < graph.Vertices.Length; j++)
                {
                    weights[i, j] = infinity;
                    if (i == j) weights[i, j] = 0;

                    prev[i, j] = null;
                }
            }

            for (int i = 0; i < graph.Edges.Length; i++)
            {
                int n = graph.Edges[i].Begin.Id - 1;
                int m = graph.Edges[i].End.Id - 1;

                weights[n, m] = graph.Edges[i].Weight;
                prev[n, m] = graph.Edges[i].Begin;
            }
        }

        static private void algorithmLogic()
        {
            int len = graph.Vertices.Length;
            for (int k = 0; k < len; k++)
            {
                print(weights);
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                print(prev);
                Console.WriteLine("-----------------------------------------------------------------------");

                for (int i = 0; i < len; i++)
                    for (int j = 0; j < len; j++)
                        if (weights[i, k] + weights[k, j] < weights[i, j])
                        {
                            weights[i, j] = weights[i, k] + weights[k, j];
                            prev[i, j] = graph.Vertices[k];
                        }
            }
                
            for (int i = 0; i < len; i++)
                if (weights[i, i] < 0)
                    throw new ArgumentException("Cykle ujemne");
            print(weights);
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            print(prev);
            Console.WriteLine("-----------------------------------------------------------------------");

        }
        static private void print(double[,] arr)
        {
            var rowCount = arr.GetLength(0);
            var colCount = arr.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    Console.Write(String.Format("{0}\t", arr[row, col]));
                Console.WriteLine();
            }
        }

        static private void print(Vertex[,] arr)
        {
            var rowCount = arr.GetLength(0);
            var colCount = arr.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    if(arr[row,col] != null)
                    {
                        Console.Write(String.Format("{0}\t", arr[row, col].Id));
                    }else
                    {
                        Console.Write(String.Format("{0}\t", "-"));
                    }
                Console.WriteLine();
            }
        }

        static public Path[] runAlgorithm(Graph graph_, Vertex begin)
        {

            graph = graph_;
            Path[] shortestPaths = new Path[graph.Vertices.Length];

            initialize();

            algorithmLogic();

            int len = graph.Vertices.Length;
            for (int i = 0; i < len; i++)
            {
                shortestPaths[i] = generatePath(begin, graph.Vertices[i]);
            }
            return shortestPaths;
        }

        static public Path[] runAlgorithm(Graph graph_)
        {

            graph = graph_;
            Path[] shortestPaths = new Path[graph.Vertices.Length * graph.Vertices.Length];

            

            initialize();

            algorithmLogic();

            int len = graph.Vertices.Length;
            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++)
                {
                    shortestPaths[i * len + j] = generatePath(graph.Vertices[i], graph.Vertices[j]);
                }
            return shortestPaths;
        }


        static public Path[] runAlgorithm(Graph graph_, Vertex begin, Vertex end)
        {

            graph = graph_;
            Path[] shortestPaths = new Path[graph.Vertices.Length];

            initialize();

            algorithmLogic();

            int len = graph.Vertices.Length;
            for (int i = 0; i < len; i++)
            {
                shortestPaths[i] = generatePath(begin, end);
            }
            return shortestPaths;
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
                currentVertex = prev[begin.Id - 1, currentVertex.Id - 1];
            }
            path.push(begin);

            return path;

        }
    }
}
