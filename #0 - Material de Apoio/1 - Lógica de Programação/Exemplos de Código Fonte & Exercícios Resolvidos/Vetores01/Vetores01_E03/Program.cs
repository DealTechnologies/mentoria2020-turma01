using System;

namespace Vetores01_E03
{
	class Program
	{
		const int TAMANHO = 10;
		
		public static void Main(string[] args)
		{
			int[] vetor = new int[TAMANHO];
			double media = 0;
			int acimaMedia = 0;
			
			for (int i = 0; i < TAMANHO; i++)
			{
				Console.Write("Informe o valor da posição {0}: ", i);
				vetor[i] =  Convert.ToInt32(Console.ReadLine());
				
				media = media + vetor[i];
				//Console.Write("Soma: {0}\n", media);
			}
			
			media = media/TAMANHO;
			Console.Write("\nMédia: {0:N2}", media);
			
			for (int i = 0; i < TAMANHO; i++)
			{
				if(vetor[i]>media)
				{
					acimaMedia++;
				}
			}
			
			Console.WriteLine("\nO número de alunos acima da média é: {0}", acimaMedia);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}