using System;

namespace Aula09_E02
{
	class Program
	{
		static double VolumeEsfera(double raio){
			double pi = 3.14159;
			double volume;
			
			volume = 4 * pi * (Math.Pow(raio,3)) / 3;
			
			return volume;
		}
		
		public static void Main(string[] args)
		{
			double raio, volume;
			
			Console.Write("Informe o raio da esfera: ");			
			raio = Convert.ToDouble(Console.ReadLine());
			
			volume = VolumeEsfera(raio);
			Console.WriteLine("\nO volume da esfera é: {0:N2}", volume);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}