using System;

namespace Ventores01_E08
{
	class Program
	{
		const int TAMANHO = 20;
		
		static void MenorValor(int[] vetor)
		{
			int menor = vetor[0];
			int indice=0;
			
			for(int i=0; i<TAMANHO; i++)
			{
				if(vetor[i]<menor)
				{
					menor = vetor[i];
					indice = i;
				}
			}
			
			Console.WriteLine("\nO menor valor é {0} no índice {1}", menor, indice);
		}		
		
		public static void Main(string[] args)
		{
			int[] vetor = new int[TAMANHO];
			
			for(int i=0; i<TAMANHO; i++)
			{
				Console.Write("Informe o valor na posição {0}: ", i);
				vetor[i] = Convert.ToInt32(Console.ReadLine());
			}
			
			MenorValor(vetor);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}