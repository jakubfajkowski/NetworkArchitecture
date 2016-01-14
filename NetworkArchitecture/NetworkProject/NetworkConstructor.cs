using System.Collections.Generic;
using System.IO;

namespace NetworkArchitecture.NetworkProject
{
    class NetworkConstructor
    {
        private Model.Graph graph;

        public NetworkConstructor()
        {
            graph = new Model.Graph();
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
    }
}
