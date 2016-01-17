using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NetworkArchitecture.GraphAlgorithms
{
    static class Test
    {
        static private Graph graph;
        static private long averageTimeDijkstra;
        static private long averageTimeFloyd;
        static private long testTime;

        static private void initialize(string path)
        {
            graph = new Graph();
            using (StreamReader streamReader = new StreamReader(path))
            {
                List<string> textFile = new List<string>();

                while (streamReader.EndOfStream == false)
                {
                    string line = streamReader.ReadLine();

                    if (!line.Contains("#") && line != "")
                    {
                        textFile.Add(line);
                    }
                }
                graph.load(textFile);
            }
        }

        static private void findShortestPaths(int numberOfTests)
        {
            Stopwatch testTimeStopwatch = new Stopwatch();
            Stopwatch algorithmStopwatch = new Stopwatch();

            testTimeStopwatch.Start();
            for (int i = 0; i < numberOfTests; i++)
            {
                //Console.WriteLine("Algorytm Dijkstry:");
                graph.randomizeEdgesWeights();
                algorithmStopwatch.Restart();
                Dijkstra.runAlgorithm(graph);//printPaths(Dijkstra.runAlgorithm(graph));
                algorithmStopwatch.Stop();
                averageTimeDijkstra += algorithmStopwatch.ElapsedTicks;


                //Console.WriteLine("Algorytm Dijkstry od:");
                //graph.randomizeEdgesWeights();
                //algorithmStopwatch.Restart();
                //printPaths(Dijkstra.runAlgorithm(graph, graph.Vertices[0]));
                //algorithmStopwatch.Stop();
                //averageTimeDijkstra += algorithmStopwatch.ElapsedTicks;

                //Console.WriteLine("Algorytm Dijkstry od do:");
                //graph.randomizeEdgesWeights();
                //algorithmStopwatch.Restart();
                //printPaths(Dijkstra.runAlgorithm(graph, graph.Vertices[0], graph.Vertices[1]));
                //algorithmStopwatch.Stop();
                //averageTimeDijkstra += algorithmStopwatch.ElapsedTicks;


                //Console.WriteLine("Algorytm Floyda:");
                graph.randomizeEdgesWeights();
                algorithmStopwatch.Restart();
                Floyd.runAlgorithm(graph);//printPaths(Floyd.runAlgorithm(graph));
                algorithmStopwatch.Stop();
                averageTimeFloyd += algorithmStopwatch.ElapsedTicks;

                //Console.WriteLine("Algorytm Floyda od:");
                //graph.randomizeEdgesWeights();
                //algorithmStopwatch.Restart();
                //printPaths(Floyd.runAlgorithm(graph, graph.Vertices[4]));
                //algorithmStopwatch.Stop();
                //averageTimeFloyd += algorithmStopwatch.ElapsedTicks;

                //Console.WriteLine("Algorytm Floyda od do:");
                //graph.randomizeEdgesWeights();
                //algorithmStopwatch.Restart();
                //printPaths(Floyd.runAlgorithm(graph, graph.Vertices[4], graph.Vertices[3]));
                //algorithmStopwatch.Stop();
                //averageTimeFloyd += algorithmStopwatch.ElapsedTicks;
            }
            averageTimeDijkstra /= numberOfTests;
            averageTimeFloyd /= numberOfTests;
            testTimeStopwatch.Stop();
            testTime = testTimeStopwatch.ElapsedTicks;
        }
        static private void printPaths(Path[] paths)
        {
            foreach (Path p in paths)
            {
                if (p != null)
                {
                    foreach (Vertex v in p.Vertices)
                    {
                        Console.Write(v.Id + " ");
                    }
                    Console.WriteLine();
                    //if (p.MinWeight == double.MaxValue)
                    //{
                    //    Console.WriteLine(" min: infinity" + " sum: " + p.SumWeight);
                    //}
                    //else
                    //{
                    //    Console.WriteLine(" min: " + p.MinWeight + " sum: " + p.SumWeight);
                    //}
                }
            }
        }

        static private void printPaths(Path[,] paths)
        {
            foreach (Path p in paths)
            {
                if (p != null)
                {
                    foreach (Vertex v in p.Vertices)
                    {
                        Console.Write(v.Id + " ");
                    }
                    Console.WriteLine();
                    //if (p.MinWeight == double.MaxValue)
                    //{
                    //    Console.WriteLine(" min: infinity" + " sum: " + p.SumWeight);
                    //}
                    //else
                    //{
                    //    Console.WriteLine(" min: " + p.MinWeight + " sum: " + p.SumWeight);
                    //}
                }
            }
        }

        static private void printResults()
        {
            Console.WriteLine("Średni czas dla algorytmu Dijkstry: " + new TimeSpan(averageTimeDijkstra));
            Console.WriteLine("Średni czas dla algorytmu Floyda: " + new TimeSpan(averageTimeFloyd));
            Console.WriteLine("Całkowity czas trwania testu: " + new TimeSpan(testTime));
        }

        static public void run(string path, int numberOfTests)
        {
            initialize(path);
            findShortestPaths(numberOfTests);
            printResults();
        }
        static public void generateGraph(int n)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("graf_input.txt"))
            {
                file.WriteLine("WEZLY = {0}", n);
                file.WriteLine("LACZA = {0}", n * (n-1));
                int id = 1;
                for(int i = 0; i<n; i++)              
                    for (int j = 0; j<n; j++)
                         if (i != j) file.WriteLine("{0} {1} {2}", id++, i + 1, j + 1);
            }    
        }
            
    }
}
