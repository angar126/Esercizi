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

            //Secondo esercizio

            int X = 40;
            int A = 40;
            int B = 1;

            

            Func<int,int,int> somma = (x, y) => {  return x + y; };

            Predicate<int> isMaggiore = (x) =>
            {
                return x > X;
            };

            Action action = () =>
            {
                bool res = isMaggiore(somma(A, B));
                if (res) Console.WriteLine("Risultato positivo!");
            };

            action();
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
