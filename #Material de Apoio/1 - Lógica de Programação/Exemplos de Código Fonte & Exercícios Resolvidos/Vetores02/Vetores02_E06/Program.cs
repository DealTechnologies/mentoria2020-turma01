using System;

namespace Vetores02_E06
{
	class Program
	{
		const int TAMANHO = 20;
		
		static double Media(double[] notas)
		{
			double media = 0;
			
			for(int i=0; i < TAMANHO; i++)
			{
				media = media + notas[i];
			}
			
			media = media / TAMANHO;
			return media;
		}
		
		static int Aprovados(double[] notas)
		{
			int cont = 0;
			
			for(int i=0; i < TAMANHO; i++)
			{
				if(notas[i] >= 60)
				{
					cont++;
				}
			}
			return cont;
		}
		
		static int Reprovados(double[] notas)
		{
			int cont = 0;
			
			for(int i=0; i < TAMANHO; i++)
			{
				if(notas[i] < 60)
				{
					cont++;
				}
			}
			return cont;
		}
		
		public static void Main(string[] args)
		{
			double[] notas = new double[TAMANHO];
			double media;
			int aprovados=0, reprovados=0;
			
			for(int i=0; i < TAMANHO; i++)
			{
				Console.Write("Informe a nota do {0}° aluno: ", i+1);
				notas[i] = Convert.ToInt32(Console.ReadLine());
			}
			
			media = Media(notas);
			aprovados = Aprovados(notas);
			reprovados = Reprovados(notas);
			
			Console.WriteLine("\nA média de notas é: {0:N2}", media);
			Console.WriteLine("Número de alunos aprovados: {0}", aprovados);
			Console.WriteLine("Número de alunos reprovados: {0}", reprovados);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}