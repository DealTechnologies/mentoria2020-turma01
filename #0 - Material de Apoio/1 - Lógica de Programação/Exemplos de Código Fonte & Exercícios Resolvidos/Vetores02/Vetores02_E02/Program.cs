using System;

namespace Vetores02_E02
{
	class Program
	{
		const int TAMANHO = 10;
		
		static void ImprimirPares()
		{
			int[] vetor = new int[TAMANHO];
			
			for(int i=0; i<TAMANHO; i++)
			{
				Console.Write("Informe o valor na índice {0}: ", i);
				vetor[i] = Convert.ToInt32(Console.ReadLine());
			}
			
			Console.Write("\nVetor: ");
			for(int i=0; i<TAMANHO; i++)
			{
				if(i % 2 == 0)
				{
					Console.Write("{0}; ", vetor[i]);
				}
			}
		}		
		
		public static void Main(string[] args)
		{
			ImprimirPares();
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}