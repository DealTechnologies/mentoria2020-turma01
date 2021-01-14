using System;

namespace exercico3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1, n2;
            int soma, subtracao, divisao, multiplicacao;

            Console.WriteLine("Didite primeiro valor:");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Didite segundo valor:");
            n2 = Convert.ToInt32(Console.ReadLine());
            soma = n1 + n2;
            subtracao = n1 - n2;
            divisao = n1 / n2;
            multiplicacao = n1 * n2;
            Console.WriteLine("soma {0}",soma);
            Console.WriteLine("subtração {0}", subtracao);
            Console.WriteLine("multiplicação {0}", multiplicacao);
            Console.WriteLine("divisao {0}", divisao);

        }
    }
}
