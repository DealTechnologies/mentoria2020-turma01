using System;

namespace Matriz01_E06
{
	class Program
	{
		const int linhas = 3;
		const int colunas=3;
		
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
		
		static double SomarMatriz(double[,] matriz)
		{
			double soma = 0;
			
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					soma = soma + matriz[i,j];
				}
			}
			return soma;
		}
		public static void Main(string[] args)
		{
			double[,] matriz = new double[linhas,colunas];
			double soma;
			
			Console.Write("Informe os índices da matriz:\n");
			LerMatriz(matriz);
			
			soma = SomarMatriz(matriz);			
			Console.Write("Soma: {0}", soma);
			
			Console.ReadKey(true);
		}
	}
}