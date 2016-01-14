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

        private void findShortestPaths(int numberOfTests)
        {
            Stopwatch testTimeStopwatch = new Stopwatch();
            Stopwatch algorithmStopwatch = new Stopwatch();

            testTimeStopwatch.Start();
            for (int i = 0; i < numberOfTests; i++)
            {
                Console.WriteLine("Algorytm Dijkstry:");
                algorithmStopwatch.Restart();
                graph.randomizeEdgesWeights();
                printPaths(Dijkstra.runAlgorithm(graph, graph.Vertices[0]));
                algorithmStopwatch.Stop();
                averageTimeDijkstra += algorithmStopwatch.ElapsedTicks;

                Console.WriteLine("Algorytm Floyda:");
                algorithmStopwatch.Restart();
                printPaths(Floyd.runAlgorithm(graph, graph.Vertices[0]));
                algorithmStopwatch.Stop();
                averageTimeFloyd += algorithmStopwatch.ElapsedTicks;
            }
            averageTimeDijkstra /= numberOfTests;
            averageTimeFloyd /= numberOfTests;
            testTimeStopwatch.Stop();
            testTime = testTimeStopwatch.ElapsedTicks;
        }
        private void printPaths(Path[] paths)
        {
            foreach (Path p in paths)
            {
                foreach (Vertex v in p.Vertices)
                {
                    Console.Write(v.Id);
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
        private void printResults()
        {
            Console.WriteLine("Sredni czas dla algorytmu Dijkstry: " + new TimeSpan(averageTimeDijkstra));
            Console.WriteLine("Sredni czas dla algorytmu Floyda: " + new TimeSpan(averageTimeFloyd));
            Console.WriteLine("Calkowity czas trwania testu: " + new TimeSpan(testTime));
        }

        public void run(string path, int numberOfTests)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            initialize(path);
            findShortestPaths(numberOfTests);
            stopwatch.Stop();

            printResults();
        }

    }
}
