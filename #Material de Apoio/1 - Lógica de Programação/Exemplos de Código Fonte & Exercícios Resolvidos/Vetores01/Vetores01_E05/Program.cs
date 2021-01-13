using System;

namespace Vetores01_E05
{
	class Program
	{
		const int TAMANHO = 10;
		
		static void Ler(int[] vetor1, int[] vetor2, int[] vetor3)
		{
			for (int i = 0; i < TAMANHO; i++)
			{
				Console.Write("\nInforme o valor da posição {0} do 1° vetor: ", i);
				vetor1[i] =  Convert.ToInt32(Console.ReadLine());
				
				Console.Write("Informe o valor da posição {0} do 2° vetor: ", i);
				vetor2[i] =  Convert.ToInt32(Console.ReadLine());
				
				vetor3[i] = vetor1[i] + vetor2[i];
			}
		}
		
		static void Imprimir(int[] vetor3)
		{
			Console.Write("\nSomas: ");
			
			for (int i = 0; i < TAMANHO; i++)
			{
				Console.Write("{0}; ", vetor3[i]);
			}
		}
		
		public static void Main(string[] args)
		{
			int[] vetor1 = new int[TAMANHO];
			int[] vetor2 = new int[TAMANHO];
			int[] vetor3 = new int[TAMANHO];			
		
			Ler(vetor1, vetor2, vetor3);
			Imprimir(vetor3);		
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}