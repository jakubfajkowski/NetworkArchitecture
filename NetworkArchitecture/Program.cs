using System;
using System.IO;

namespace NetworkArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int input = 0;
            while (input != 3)
            {
                try
                {
                    Console.WriteLine("Wybierz opcję: \n1. Algorytmy grafowe \n2. Projektowanie sieci \n3. Wyjście z programu \n");
                    string line;
                    line = Console.ReadLine();
                    if (!int.TryParse(line, out input)) continue;
                    string path;
                    switch (input)
                    {
                        case 1:
                            Console.Clear();

                            Console.WriteLine("Algorytmy grafowe:\n");
                            Console.WriteLine("Podaj nazwę lub scieżkę do pliku: ");
                            path = "graf_input.txt";//Console.ReadLine();

                            Console.WriteLine("Podaj liczbę testów: ");
                            int numberOfTests = 1;//int.Parse(Console.ReadLine());
                            GraphAlgorithms.Test.run(path, numberOfTests);
                           
                            break;
                        case 2:
                            Console.Clear();

                            Console.WriteLine("Projektowanie sieci:\n");
                            Console.WriteLine("Podaj nazwę lub scieżkę do pliku: ");
                            path = "siec_input.txt";//Console.ReadLine();

                            Console.WriteLine("Podaj T: ");
                            double T = 5;//int.Parse(Console.ReadLine());
                            Console.WriteLine("Podaj delta T: ");
                            double deltaT = 0.0001;//int.Parse(Console.ReadLine());
                            NetworkProject.NetworkConstructor.run(path, T, deltaT);
                            Console.WriteLine();

                            break;


                        default:
                            break;
                    }
                    Console.WriteLine();
                }
                catch (SystemException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    continue;
                }

            }
        }
    }
}
