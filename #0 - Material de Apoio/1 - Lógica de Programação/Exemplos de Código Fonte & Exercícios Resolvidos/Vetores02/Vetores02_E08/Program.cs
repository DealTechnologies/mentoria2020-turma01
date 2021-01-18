using System;

namespace Vetores02_E08
{
	class Program
	{
		const int TAMANHO = 4;
		
		static void LerVetor(int[] vetor)
		{
			for(int i=0; i < TAMANHO; i++)
			{
				Console.Write("{0}: ", i);
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
		
		public static void Main(string[] args)
		{
			int[] gabarito = new int[TAMANHO];
			int[] aposta = new int[TAMANHO];
			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}