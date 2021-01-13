using System;

namespace Aula07_E02
{
	class Program
	{
		public static void Main(string[] args)
		{
			double valor = 2.346728;
			
			Console.WriteLine();
			Console.WriteLine("{0:N1}", valor);
			Console.WriteLine("{0:N2}", valor);
			Console.WriteLine("{0:N3}", valor);
			Console.WriteLine("{0:N4}", valor);
			Console.WriteLine("{0:N5}", valor);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}