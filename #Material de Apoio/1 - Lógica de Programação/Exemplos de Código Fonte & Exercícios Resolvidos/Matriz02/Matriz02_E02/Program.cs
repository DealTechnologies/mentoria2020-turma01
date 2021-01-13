using System;

namespace Matriz02_E01
{
	class Program
	{
		const int linhas = 7;
		const int colunas = 5;
		
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
		
		static void ImprimirColunas(double[,] matriz)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(j==2)
					{
						Console.Write("{0,4}",matriz[i,j]);
					}
				}
				Console.WriteLine();
			}
		}
		
		public static void Main(string[] args)
		{
			double[,] matriz = new double[linhas,colunas];
			
			Console.Write("Informe os índices da matriz:\n");
			LerMatriz(matriz);
			
			ImprimirColunas(matriz);
			
			Console.ReadKey(true);
		}
	}
}