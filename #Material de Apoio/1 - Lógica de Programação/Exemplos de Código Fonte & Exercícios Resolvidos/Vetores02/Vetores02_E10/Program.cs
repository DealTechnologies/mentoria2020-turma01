using System;

namespace Vetores02_E10
{
	class Program
	{
		const int TAMANHO = 4;
		
		static void LerVetor(int[] vetor)
		{
			for(int i=0; i < TAMANHO; i++)
			{
				Console.Write("Informe o {0}° valor: ", i+1);
				vetor[i] = Convert.ToInt32(Console.ReadLine());
			}			
		}
		
		static void ImprimirVetor(int[] vetor)
		{
			for(int i=0; i < TAMANHO; i++)
			{
				Console.Write("{0}; ", vetor[i]);
			}
		}
		
		static void OrdenarVetor(int[] vetor)
		{
			int aux;
			
			for(int i=0; i < TAMANHO; i++)
 			{
				for(int j=TAMANHO-1; j>i; j--)
 				{
 					if (vetor[j] < vetor[j-1])
 					{
						aux=vetor[j];
						vetor[j] = vetor[j-1];
						vetor[j-1]=aux;
					}
				}
			}
 		}
		
		
		public static void Main(string[] args)
		{
			int[] vetor = new int[TAMANHO];
			
			LerVetor(vetor);
			
			Console.Write("\nVetor: ");
			ImprimirVetor(vetor);
			
			OrdenarVetor(vetor);
			
			Console.Write("\nOrdenado: ");
			ImprimirVetor(vetor);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}