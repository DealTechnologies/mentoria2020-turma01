using System;

namespace Strings02_E08
{
	class Program
	{
		public static void Main(string[] args)
		{
			string s1, s2, s3;
			
			Console.Write("Informe a 1° string: ");
			s1 = Console.ReadLine();
			
			Console.Write("Informe a 2° string: ");
			s2 = Console.ReadLine();
			
			s3 = s1 + s2;
			
			Console.WriteLine("\nConcatenação 3° string: {0}", s3);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}