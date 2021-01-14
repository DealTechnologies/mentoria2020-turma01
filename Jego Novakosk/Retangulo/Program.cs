using System;

namespace Retangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Retangulo2 ret = new Retangulo2();
            Console.WriteLine("Entre a largura do altura do retangulo:");
            ret.comprimento = Convert.ToDouble(Console.ReadLine());
            ret.largura = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Area {0}", ret.Area());
            Console.WriteLine("Perimero {0}", ret.Perimetro());
            Console.WriteLine("Diagonal {0}", ret.Diagonal());

        }
    }
}
