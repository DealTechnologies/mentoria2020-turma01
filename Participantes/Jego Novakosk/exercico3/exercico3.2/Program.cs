using System;

namespace exercico3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            double volume, comprimento, largura, altura;

            Console.WriteLine("Digite o Comprimento do retangula:");
            comprimento = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite o Largura do retangula:");
            largura = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite o Altura do retangula:");
            altura = Convert.ToDouble(Console.ReadLine());

            volume = comprimento * largura * altura;
            Console.WriteLine("O volume do retangula e {0:N2}", volume);
        }
    }

}

