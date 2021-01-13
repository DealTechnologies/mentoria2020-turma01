using System;

namespace Aula05_E05
{
	class Program
	{
		public static void Main(string[] args)
		{
			double valor;
			
			Console.Write("Irforme o valor do produto:"); valor = Convert.ToDouble(Console.ReadLine());
			
			valor = valor * 0.75;
			
			Console.Write("\nO valor a pagar com desconto é: {0:N2}", valor);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}