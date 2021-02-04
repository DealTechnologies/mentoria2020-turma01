using System;

namespace produto
{
    class Program
    {
        static void Produto(double n1, double n2)
        {
            double soma, difereca, quociente, resto, produto;
            soma = n1 + n2;
            difereca = n1 - n2;
            produto = n1 * n2;
            quociente = n1 / n2;
            resto = n1 % n2;

            Console.WriteLine("A soma e: {0}",soma);
            Console.WriteLine("A diferença e: {0}",difereca);
            Console.WriteLine("O Produto e: {0}",produto);
            Console.WriteLine("A soma e: {0}",soma);
            Console.WriteLine("O resto e: {0}",resto);

            return;
        }
        static void Main(string[] args)
        {
            double n1, n2;
            Console.WriteLine("Digte um numero :");
            n1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digte outro numero :");
            n2 = Convert.ToDouble(Console.ReadLine());

            Produto(n1, n2);
        }
    }
}
