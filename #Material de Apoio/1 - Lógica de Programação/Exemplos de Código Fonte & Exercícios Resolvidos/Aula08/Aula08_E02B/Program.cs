using System;

namespace Aula08_E02A
{
	class Program
	{
		static double Distancia(double x1,double y1,double x2,double y2){
			
			double distanciaTotal, distanciaX, distanciaY;
			
			//distanciaTotal = Math.Sqrt(Math.Pow(x2-x1,2) + Math.Pow(y2-y1,2));
			
			//Função para Potência
			distanciaX = Math.Pow(x2-x1,2);
			distanciaY = Math.Pow(y2-y1,2);
			
			//Função para Raiz
			distanciaTotal = Math.Sqrt(distanciaX + distanciaY);
			return distanciaTotal;
		}
		
		public static void Main(string[] args)
		{
			double x1, x2, y1, y2, x3, y3, perimetro;
			 
			Console.Write("Valor de X1:"); x1 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Valor de Y1:"); y1 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Valor de X2:"); x2 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Valor de Y2:"); y2 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Valor de X3:"); x3 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Valor de Y3:"); y3 = Convert.ToDouble(Console.ReadLine());
			
			perimetro = Distancia(x1, y1, x2, y2);
			
			perimetro = perimetro + (Distancia(x1, y1, x3, y3));
			
			perimetro = perimetro + (Distancia(x2, y2, x3, y3));
			
			Console.WriteLine("\nO perímetro é: {0}", perimetro);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}