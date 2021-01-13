using System;

namespace Vetores01_E07
{
	class Program
	{
		const int TAMANHO = 20;
		
		public static void Main(string[] args)
		{
			int[] vetor = new int[TAMANHO];
			int menor, indice=0;
			
			for(int i=0; i<TAMANHO; i++)
			{
				Console.Write("Informe o valor na posição {0}: ", i);
				vetor[i] = Convert.ToInt32(Console.ReadLine());
			}
			
			menor = vetor[0];
			
			for(int i=0; i<TAMANHO; i++)
			{
				if(vetor[i]<menor)
				{
					menor = vetor[i];
					indice = i;
				}
			}
			
			Console.WriteLine("\nO menor valor é {0} no índice {1}", menor, indice);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}