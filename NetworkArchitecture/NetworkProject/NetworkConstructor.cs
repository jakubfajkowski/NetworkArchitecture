using System;
using System.Collections.Generic;
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

            demand.Path = new Stack<Model.Edge>();
            Model.Vertex currentVertex = begin;
            do
            {
                Model.Edge currentEdge = currentVertex.getRandomEdgeOut();
                if (!currentVertex.Visited && currentEdge != null)
                {
                    currentVertex.Visited = true;
                    demand.Path.Push(currentEdge);
                    currentVertex = currentEdge.End;
                }
                else
                {
                    currentVertex.Visited = true;
                    currentVertex = demand.Path.Pop().Begin;
                    currentVertex.Visited = false;
                }
                

            } while (demand.Path.Peek().End != end);
            //Stack<Model.Vertex> path = new Stack<Model.Vertex>();
            //path.Push(begin);
            //while(path.Peek() != end)
            //{
            //    Model.Vertex currentVertex = path.Peek();
            //    Model.Edge currentEdge = currentVertex.getRandomEdgeOut();
            //    if (!currentVertex.Visited && currentEdge != null)
            //    {
            //        path.Push(currentEdge.End);
            //    }
            //    else
            //    {
            //        path.Pop();
            //        path.Peek().Visited = false;
            //    }
            //    currentVertex.Visited = true;
            //}
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
                Console.WriteLine(new_network.Price() + "   " + network.Price());
                T -= deltaT;
            }
            
        }
        static private double acceptanceProbability(double new_price, double old_price, double T)
        {
            return Math.Exp(- (new_price - old_price) / T);
        }
        static public void run(string path)
        {
            initialize(path);
            simulatedAnnealing(1, 0.001);

        }
    }
}
