using System;

namespace distancia
{
    class Program
    {
        static double Distancia(double x1, double x2, double y1, double y2)
        {
            double distX, distY, distTotal;

            distX = Math.Pow(x2 - x1, 2);
            distY = Math.Pow(y2 - y1, 2);

            distTotal = Math.Sqrt(distX + distY);

            return distTotal;
        }
        static void Main(string[] args)
        {
            double x1, x2, y1, y2, distanciaTotal;

            Console.WriteLine("Digite o valor de X1:");
            x1 = Convert.ToDouble(Console.ReadLine()); 
            Console.WriteLine("Digite o valor de X2:");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite o valor de Y1:");
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite o valor de y2:");
            y2 = Convert.ToDouble(Console.ReadLine());

            distanciaTotal = Distancia(x1, x2, y1, y2);

            Console.WriteLine("Distancia entre os pontos {0}",distanciaTotal);
        }
    }
}
