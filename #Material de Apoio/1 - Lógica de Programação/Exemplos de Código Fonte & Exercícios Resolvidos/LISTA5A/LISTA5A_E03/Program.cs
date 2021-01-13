using System;

namespace LISTA5A_E03
{
	class Program
	{
		static double Volume(double raio){
			double pi = 3.1416;
			double volume;
			
			volume = (4 * pi * Math.Pow(raio,3)) / 3;
			return volume;
		}
		
		public static void Main(string[] args)
		{
			double raio, volume;
			
			Console.Write("Informe o raio: ");
			raio = Convert.ToDouble(Console.ReadLine());
			
			volume = Volume(raio);
			
			Console.WriteLine("\nO volume é: {0:N2}", volume);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}