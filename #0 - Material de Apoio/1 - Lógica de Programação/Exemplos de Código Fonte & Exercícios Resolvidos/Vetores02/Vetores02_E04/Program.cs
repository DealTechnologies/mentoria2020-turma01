using System;

namespace Vetores02_E04
{
	class Program
	{
		const int TAMANHO = 15;
				
		public static void Main(string[] args)
		{			
			double[] vetor = new double[TAMANHO];
			double numero;
			int cont=0;
			
			for(int i=0; i < TAMANHO; i++)
			{
				Console.Write("Informe o valor no índice {0}: ", i);
				vetor[i] = Convert.ToDouble(Console.ReadLine());
			}
			
			Console.Write("\nInforme o valor a ser encontrado: ");
			numero = Convert.ToDouble(Console.ReadLine());
			                         
			
			for(int i=0; i < TAMANHO; i++)
			{
				if(vetor[i] == numero)
				{
					cont++;
				}
			}
			
			if(cont > 0)
			{
				Console.WriteLine("\nO número {0} foi encontrado {1} vez(es)", numero, cont);
			}
			else
			{
				Console.WriteLine("\nO número {0} não foi encontrado", numero);
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}