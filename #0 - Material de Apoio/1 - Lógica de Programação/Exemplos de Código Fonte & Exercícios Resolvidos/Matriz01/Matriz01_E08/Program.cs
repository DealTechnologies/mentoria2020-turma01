using System;

namespace Matriz01_E06
{
	class Program
	{
		const int linhas = 3;
		const int colunas= 3;
		
		static void LerMatriz(double[,] matriz)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					Console.Write("Digite o índice [{0},{1}]: ",i,j); 
					matriz[i,j] = Convert.ToDouble(Console.ReadLine());
					
				}
				Console.WriteLine();
			}
		}
		
		static void MultiplicarMatriz(double[,] matriz1, double[,] matriz2)
		{			
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					Console.Write("{0,4} ",matriz1[i,j]*matriz2[i,j]);
					
				}
				Console.WriteLine();
			}
		}
		public static void Main(string[] args)
		{
			double[,] matriz1 = new double[linhas,colunas];
			double[,] matriz2 = new double[linhas,colunas];
			
			Console.Write("Informe os índices da primeira matriz:\n");
			LerMatriz(matriz1);
			
			Console.Write("Informe os índices da segunda matriz:\n");
			LerMatriz(matriz2);
			
			Console.Write("Multiplicação:\n");
			MultiplicarMatriz(matriz1, matriz2);
			
			Console.ReadKey(true);
		}
	}
}