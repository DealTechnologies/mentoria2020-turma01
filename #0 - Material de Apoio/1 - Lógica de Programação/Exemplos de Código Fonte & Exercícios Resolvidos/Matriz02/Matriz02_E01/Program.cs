using System;

namespace Matriz02_E01
{
	class Program
	{
		const int linhas = 3;
		const int colunas = 4;
		
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
		
		static void MultiplicarMatriz(double[,] matriz, double escalar)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					matriz[i,j] = matriz[i,j] * escalar;
				}
			}
		}
		
		static void ImprimirMatriz(double[,] matriz)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					Console.Write("{0,4}",matriz[i,j]);
				}
				Console.WriteLine();
			}
		}
		
		public static void Main(string[] args)
		{
			double[,] matriz = new double[linhas,colunas];
			double escalar;
			
			Console.Write("Informe a escalar: ");
			escalar = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("\nInforme os índices da matriz:\n");
			LerMatriz(matriz);
			
			MultiplicarMatriz(matriz,escalar);
			ImprimirMatriz(matriz);
			
			Console.ReadKey(true);
		}
	}
}