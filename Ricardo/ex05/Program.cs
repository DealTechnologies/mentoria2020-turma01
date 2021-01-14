using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            double valorProduto, novoValor;

            Console.Write("Valor do produto: R$");
            valorProduto = Convert.ToDouble(Console.ReadLine());
            novoValor = valorProduto - (valorProduto * 0.25);
            Console.Write("O novo valor do produto é R${0}.", novoValor);
            Console.ReadKey();
        }
    }
}
