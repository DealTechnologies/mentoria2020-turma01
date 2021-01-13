using System;

namespace Vetores01_E04
{
	class Program
	{
		const int TAMANHO = 10;
		
		public static void Main(string[] args)
		{
			int[] vetor1 = new int[TAMANHO];
			int[] vetor2 = new int[TAMANHO];
			int[] vetor3 = new int[TAMANHO];
			
			for (int i = 0; i < TAMANHO; i++)
			{
				Console.Write("\nInforme o valor da posição {0} do 1° vetor: ", i);
				vetor1[i] =  Convert.ToInt32(Console.ReadLine());
				
				Console.Write("Informe o valor da posição {0} do 2° vetor: ", i);
				vetor2[i] =  Convert.ToInt32(Console.ReadLine());
				
				vetor3[i] = vetor1[i] + vetor2[i];
			}
			
			Console.Write("\nSomas: ");
			
			for (int i = 0; i < TAMANHO; i++)
			{
				Console.Write("{0}; ", vetor3[i]);
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}