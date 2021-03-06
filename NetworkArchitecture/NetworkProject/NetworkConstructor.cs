﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NetworkArchitecture.NetworkProject
{
    static class NetworkConstructor
    {
        static private Model.Network network;
        static private Model.Network new_network;
        static Random generator = new Random();

        static private void initialize(string path)
        {
            network = new Model.Network();

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
                network.load(textFile);
            }
        }

        static private void generateRandomPath(Model.Demand demand)
        {
            Random generator = new Random();
            Model.Vertex begin = demand.Begin;
            Model.Vertex end = demand.End;

            new_network.resetVertices();
            //Console.WriteLine("Żądanie: " + demand.Begin.Id + " " + demand.End.Id);
            //demand.Path = new Stack<Model.Edge>();
            //Model.Vertex currentVertex = begin;
            //do
            //{
            //    Model.Edge currentEdge = currentVertex.getRandomEdgeOut();
            //    if (!currentVertex.Visited && currentEdge != null)
            //    {
            //        currentVertex.Visited = true;
            //        demand.Path.Push(currentEdge);
            //        currentVertex = currentEdge.End;
            //        Console.WriteLine(currentEdge.Begin.Id + " -> " + currentEdge.End.Id);
            //    }
            //    else
            //    {
            //        currentVertex.Visited = true;
            //        Model.Vertex tmp = currentVertex;
            //        currentVertex = demand.Path.Pop().Begin;
            //        currentVertex.Visited = false;

            //        Console.WriteLine(currentVertex.Id + " <- " + tmp.Id);
            //    }


            //} while (demand.Path.Peek().End != end);
            Stack<Model.Vertex> path = new Stack<Model.Vertex>();
            demand.Path = new Stack<Model.Edge>();
            path.Push(begin);
            while (path.Peek() != end)
            {
                Model.Vertex currentVertex = path.Peek();
                Model.Edge currentEdge = currentVertex.getRandomEdgeOut();
                if (!currentVertex.Visited && currentEdge != null)
                {
                    //Console.WriteLine(currentEdge.Begin.Id + " -> " + currentEdge.End.Id);
                    demand.Path.Push(currentEdge);
                    path.Push(currentEdge.End);
                }
                else
                {
                    demand.Path.Pop();
                    path.Pop();
                    Model.Vertex tmp = path.Peek();
                    //Console.WriteLine(tmp.Id + " <- " + currentVertex.Id);
                    path.Peek().Visited = false;
                }
                currentVertex.Visited = true;
            }
        }

        

        static private void simulatedAnnealing(double T, double deltaT)
        {
            new_network = new Model.Network(network);
            while(T>0)
            {
                new_network.resetEdges();
                foreach (Model.Demand d in new_network.Demands)
                {
                    generateRandomPath(d);
                    d.flow();
                }


                double min_price = network.Price();
                if (network.Price() == 0)
                {
                    min_price = double.MaxValue;
                }
                double ap = acceptanceProbability(new_network.Price(), min_price, T);
                
                if (new_network.Price() < min_price || ap > generator.NextDouble())
                {
                    Model.Network tmp = network;
                    network = new_network;
                    new_network = tmp;
                }
                Console.Write("\rMinimalna cena sieci: " + network.Price() + "                 ");
                T -= deltaT;
            }
            
        }
        static private double acceptanceProbability(double new_price, double old_price, double T)
        {
            return Math.Exp(- (new_price - old_price) / T);
        }

        static private void printResults()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("siec_output.txt"))
            {
                file.WriteLine("KOSZT = {0}", network.Price());

                file.WriteLine("ZAPOTRZEBOWANIA = {0}", network.Demands.Length);
                foreach(Model.Demand d in network.Demands)
                {
                    file.Write("{0} ", d.Id);
                    foreach(Model.Edge e in d.Path)
                    {
                        file.Write("{0} ", e.Id);
                    }
                    file.WriteLine();
                }

                file.WriteLine("LACZA = {0}", network.Edges.Length);
                foreach (Model.Edge e in network.Edges)
                {
                    file.WriteLine("{0} {1}", e.Id, e.NumberOfModules);
                }
            }

            Console.WriteLine("\nKOSZT = {0}", network.Price());

            Console.WriteLine("ZAPOTRZEBOWANIA = {0}", network.Demands.Length);
            foreach (Model.Demand d in network.Demands)
            {
                Console.Write("{0} ", d.Id);
                foreach (Model.Edge e in d.Path)
                {
                    Console.Write("{0} ", e.Id);
                }
                Console.WriteLine();
            }

            Console.WriteLine("LACZA = {0}", network.Edges.Length);
            foreach (Model.Edge e in network.Edges)
            {
                Console.WriteLine("{0} {1}", e.Id, e.NumberOfModules);
            }


        }

        static public void run(string path, double T, double deltaT)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            initialize(path);
            simulatedAnnealing(T, deltaT);
            stopwatch.Stop();
            printResults();
        }
    }
}
