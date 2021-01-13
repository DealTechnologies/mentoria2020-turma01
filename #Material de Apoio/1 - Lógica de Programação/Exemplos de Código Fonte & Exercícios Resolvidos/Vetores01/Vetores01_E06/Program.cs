using System;

namespace Vetores01_E06
{
	class Program
	{
		const int TAMANHO = 4;
		
		static int IdadeAlunos(int[] vetor)
		{
			double media = 0;
			int acimaMedia = 0;
			
			for (int i = 0; i < TAMANHO; i++)
			{
				media = media + vetor[i];
				//Console.WriteLine("Soma: {0}\n", media);
			}
			
			media = media / TAMANHO;
			Console.Write("\nMédia: {0}", media);
			
			for (int i = 0; i < TAMANHO; i++)
			{
				if(vetor[i]>media)
				{
					acimaMedia++;
				}
			}
			return acimaMedia;
		}
		
		public static void Main(string[] args)
		{
			int[] vetor = new int[TAMANHO];
			int acimaMedia;
			
			for (int i = 0; i < TAMANHO; i++)
			{
				Console.Write("Informe o valor da posição {0}: ", i);
				vetor[i] =  Convert.ToInt32(Console.ReadLine());
			}
			
			acimaMedia = IdadeAlunos(vetor);
			Console.WriteLine("\nO número de alunos acima da média é: {0}", acimaMedia);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}