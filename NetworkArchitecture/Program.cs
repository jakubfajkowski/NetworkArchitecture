using System;
using System.IO;

namespace NetworkArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphAlgorithms.Test test = new GraphAlgorithms.Test();

            Console.WriteLine("Algorytmy grafowe:\n");
            Console.WriteLine("Podaj nazwe lub sciezke do pliku: ");
            string path = "graf_input.txt";//Console.ReadLine();

            Console.WriteLine("Podaj liczbe testow: ");
            int numberOfTests = 1;//int.Parse(Console.ReadLine());
            test.run(path, numberOfTests);
        }
    }
}
