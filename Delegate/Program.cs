using System;

namespace Delegate
{
    internal class Program
    {
        public delegate int SommaFunc (int a, int b);
        public delegate void Matrioska (SommaFunc func);
        static void Main(string[] args)
        {
            //creazione delegate somma 
            SommaFunc resSomma = Somma;
            //prova
            int result = resSomma (1, 2);
            // matrioska
            Matrioska matrioska = Run;
            matrioska(resSomma);

        }
        static int Somma(int a, int b)
        {
            return a + b;
        }

        static void Run(SommaFunc func)
        {
            int result = func(1, 2);
            AltraFunzione(result);
        }

        static void AltraFunzione(int res)
        {
            Console.WriteLine($"Risultato: {res}");
        }

    }
    
}
