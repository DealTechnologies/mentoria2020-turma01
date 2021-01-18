using System;

namespace Aula06
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("{0,-10} {1,9}", "Produto", "Preço");
			Console.WriteLine("{0,-10} {1,9:N2}", "Coca-Cola", 5.25);
			Console.WriteLine("{0,-10} {1,9:N2}", "Pão", 0.5);
			Console.WriteLine("{0,-10} {1,9:N2}", "Mortadela", 20);
			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}