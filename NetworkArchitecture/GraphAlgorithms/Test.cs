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
                graph.randomizeLinksWeights();
                Dijkstra.runAlgorithm(graph);
                stopwatch.Stop();
                averageTimeDijkstra += stopwatch.ElapsedMilliseconds;

                stopwatch.Restart();

                stopwatch.Stop();
                averageTimeFloyd += stopwatch.ElapsedMilliseconds;
            }
            averageTimeDijkstra /= numberOfTests;
            averageTimeFloyd /= numberOfTests;
        }

        private void printResults()
        {
            Console.Write("Sredni czas dla algorytmu Dijkstry: ");
            Console.Write("Sredni czas dla algorytmu Floyda: ");
            Console.Write("Calkowity czas trwania testu: ");
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
