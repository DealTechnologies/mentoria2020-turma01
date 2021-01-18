using System;

namespace Matriz01_E07
{
	class Program
	{
		const int linhas = 3;
		const int colunas=3;
		
		static void LerVetor(double[] vetor)
		{
			for(int i=0;i<colunas;i++)
			{
				Console.Write("Digite o índice [{0}]: ",i); 
				vetor[i] = Convert.ToDouble(Console.ReadLine());					
			}
			Console.WriteLine();
		}		
		
		static void LerMatriz(double[,] m1)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					Console.Write("Digite o índice [{0},{1}]: ",i,j); 
					m1[i,j] = Convert.ToDouble(Console.ReadLine());
					
				}
				Console.WriteLine();
			}
		}
		
		static void MultiplicarMatriz(double[] vetor, double[,] matriz)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					//Console.Write("{0,4} ", vetor[i] * matriz[i,j]);
				}
				Console.WriteLine();
			}			
		}
		
		public static void Main(string[] args)
		{
			double[] vetor = new double[colunas];
			double[,] matriz = new double[linhas,colunas];
			
			Console.Write("Informe os índices do vetor:\n");
			LerVetor(vetor);
			
			Console.Write("Informe os índices da matriz:\n");
			LerMatriz(matriz);
			
			Console.Write("Multiplicação:\n");
			MultiplicarMatriz(vetor,matriz);
			
			Console.ReadKey(true);
		}
	}
}