using System;

namespace Vetores02_E01
{
	class Program
	{
		const int TAMANHO = 4;
		
		public static void Main(string[] args)
		{
			double[] vetor = new double[TAMANHO];
			int escalar;
			
			Console.Write("Informe o escalar: ");
			escalar = Convert.ToInt32(Console.ReadLine());
			
			for(int i=0; i<TAMANHO; i++)
			{
				Console.Write("Informe o valor na índice {0}: ", i);
				vetor[i] = Convert.ToInt32(Console.ReadLine());
			}
			
			Console.Write("\nVetor: ");
				
			for(int i=0; i<TAMANHO; i++)
			{
				vetor[i] = vetor[i] * escalar;
				Console.Write("{0:N2}; ", vetor[i]);
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}