using System;

namespace LISTA5C_E03
{
	class Program
	{
		public static void Main(string[] args)
		{
			double valorInicial, rendimento, numeroMeses;
			
			Console.Write("Informe o valor inicial: ");
			valorInicial = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe o percentual de rendimento: ");
			rendimento = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe o número de meses: ");
			numeroMeses = Convert.ToDouble(Console.ReadLine());
			
			for(int i=0; i<numeroMeses;i++)
			{
				valorInicial = valorInicial + ((valorInicial*rendimento)/100);
			}
			
			Console.Write("\nValor final do investimento: {0:N2}", valorInicial);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}