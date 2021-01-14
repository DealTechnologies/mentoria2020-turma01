using System;

namespace exercicio2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double valorProduto;
            double valorDesconto;

            Console.WriteLine("Insira o valor do produto");
            valorProduto = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Insira o desconto");
            valorDesconto = Convert.ToDouble(Console.ReadLine());

            valorProduto = valorProduto - valorDesconto;

            Console.WriteLine("Valor fina do produto e {0:N2}", valorProduto);
        }
    }
}
