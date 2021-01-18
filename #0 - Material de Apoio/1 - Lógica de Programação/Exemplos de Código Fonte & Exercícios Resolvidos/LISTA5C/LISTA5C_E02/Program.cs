using System;

namespace LISTA5C_E02
{
	class Program
	{
		static double AreaCilindro(double raio, double altura){
			double area, pi = 3.14;
			
			area = 2*pi*raio*(altura+raio);
			return area;
		}
		
		public static void Main(string[] args)
		{
			double raio, altura, area;
						
			Console.Write("Informe o raio: ");
			raio = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe a altura: ");
			altura = Convert.ToDouble(Console.ReadLine());
			
			area = AreaCilindro(raio, altura);
			Console.WriteLine("\nA área é: {0}", area);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}