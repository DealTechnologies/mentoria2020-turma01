using System;

namespace Aula12_E05
{
	class Program
	{
		public static void Main(string[] args)
		{
			int divisor = 50;
			double s = 0;
			
			for(int i=1; i<=25; i++){
				s += Math.Pow(2,i)/divisor;
				divisor = divisor-2;
			}
			
			Console.WriteLine("O valor de s é: {0:N2}", s);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}