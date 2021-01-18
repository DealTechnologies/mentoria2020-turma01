using System;

namespace Aula05
{
	class Program
	{
		public static void Main(string[] args)
		{
			double c, f;
			
			Console.Write("Informe a temperatura em Celsius:"); c = Convert.ToDouble(Console.ReadLine());
			
			f = (9 * c + 160) / 5;
			
			Console.WriteLine("\nA temperatura em Fahrenheit é: {0}", f);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey();
		}
	}
}