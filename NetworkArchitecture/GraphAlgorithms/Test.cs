using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NetworkArchitecture.GraphAlgorithms
{
    class Test
    {
        private Graph graph;
        private long averageTimeDijkstra;
        private long averageTimeFloyd;
        private long testTime;

        public Test()
        {
            graph = new Graph();
        }

        private void initialize(string path)
        {

            using (StreamReader streamReader = new StreamReader(path))
            {
                List<string> textFile = new List<string>();

                while (streamReader.EndOfStream == false)
                {
                    string line = streamReader.ReadLine();

                    if (!line.Contains("#"))
                    {
                        textFile.Add(line);
                    }
                }
                graph.load(textFile);
            }
        }

        private void findShortestRoutes(int numberOfTests)
        {
            Stopwatch stopwatch = new Stopwatch();
            for(int i = 0; i < numberOfTests; i++)
            {
                stopwatch.Restart();
                graph.randomizeEdgesWeights();
                printPaths(Dijkstra.runAlgorithm(graph, graph.Vertices[0]));
                stopwatch.Stop();
                averageTimeDijkstra += stopwatch.ElapsedMilliseconds;

                stopwatch.Restart();

                stopwatch.Stop();
                averageTimeFloyd += stopwatch.ElapsedMilliseconds;
            }
            averageTimeDijkstra /= numberOfTests;
            averageTimeFloyd /= numberOfTests;
        }
        private void printPaths(Path[] paths)
        {
            foreach (Path p in paths)
            {
                foreach (Vertex v in p.Vertices)
                {
                    Console.Write(v.Id);
                }
                Console.WriteLine(" min: " + p.MinWeight + " sum: " + p.SumWeight);
            }
        }
        private void printResults()
        {
            Console.WriteLine("Sredni czas dla algorytmu Dijkstry: ");
            Console.WriteLine("Sredni czas dla algorytmu Floyda: ");
            Console.WriteLine("Calkowity czas trwania testu: ");
        }

        public void run(string path, int numberOfTests)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            initialize(path);
            findShortestRoutes(numberOfTests);
            stopwatch.Stop();

            printResults();
        }

    }
}
