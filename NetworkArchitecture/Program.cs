using System;
using System.IO;

namespace NetworkArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Algorytmy grafowe:\n");
            Console.WriteLine("Podaj nazwe lub sciezke do pliku: ");
            string path = "siec_input.txt";//Console.ReadLine();

            Console.WriteLine("Podaj liczbe testow: ");
            //int numberOfTests = 10;//int.Parse(Console.ReadLine());
            //GraphAlgorithms.Test.run(path, numberOfTests);
            NetworkProject.NetworkConstructor.run(path);
        }
    }
}
