using System;

namespace exercico3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double peso;
            double altura;
            double imc;

            Console.WriteLine("Digite seu peso [ex: 83,32]:");
            peso = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite sua altura [ex: 1,78]: ");
            altura = Convert.ToDouble(Console.ReadLine());

            imc = peso / (altura * altura);
            Console.WriteLine(peso);
            Console.WriteLine(" Seu imc e {0:N2} ", imc);
        }
    }
}
