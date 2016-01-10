using System;

namespace NetworkArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphAlgorithms.Test test = new GraphAlgorithms.Test();

            Console.WriteLine("Algorytmy grafowe:\n");
            Console.WriteLine("Podaj nazwe lub sciezke do pliku: ");
            string path = Console.ReadLine();
            Console.WriteLine("Podaj liczbe testow: ");
            int numberOfTests = int.Parse(Console.ReadLine());
            test.run(path, numberOfTests);
        }
    }
}
