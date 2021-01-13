using System;

namespace Aula04
{
	class Program
	{
		public static void Main(string[] args)
		{
			double raio, area;
			
			Console.Write("Informe o raio do círculo:");
			
			raio = Convert.ToDouble(Console.ReadLine());
			
			area = 3.14159 * raio * raio;
			
			Console.WriteLine("A área do círculo é: {0}", area);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey();
		}
	}
}