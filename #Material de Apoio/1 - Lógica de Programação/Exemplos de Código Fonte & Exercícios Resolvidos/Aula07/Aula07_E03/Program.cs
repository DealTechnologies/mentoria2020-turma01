using System;

namespace Aula07_E03
{
	class Program
	{
		public static void Main(string[] args)
		{
			double valorProduto, valorDesconto, resultado;
			
			Console.Write("Informe o valor do produto :"); valorProduto = Convert.ToDouble(Console.ReadLine());
			Console.Write("Informe o valor do desconto:"); valorDesconto = Convert.ToDouble(Console.ReadLine());
			
			resultado = valorProduto - valorDesconto;
			
			Console.Write("\nO valor a pagar é: {0:N2}", resultado);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}