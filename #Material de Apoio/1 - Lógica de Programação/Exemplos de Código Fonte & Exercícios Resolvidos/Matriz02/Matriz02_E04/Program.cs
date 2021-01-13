using System;

namespace Matriz02_E04
{
	class Program
	{
		const int linhas = 6;
		const int colunas = 3;
		
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
		
		static void SepararMatriz(double[,] matriz1, double[,] matriz2, double[,] matriz3)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(i<3)
					{
						matriz2[i,j] = matriz1[i,j];
					}
					else
					{
						matriz3[i,j] = matriz1[i,j];
					}
				}
			}
		}
		
		public static void Main(string[] args)
		{
			double[,] matriz1 = new double[linhas,colunas];
			double[,] matriz2 = new double[linhas,colunas];
			double[,] matriz3 = new double[linhas,colunas];
			
			Console.Write("Informe os índices da matriz:\n");
			LerMatriz(matriz1);
			
			SepararMatriz(matriz1, matriz2, matriz3);
			
			Console.Write("Primeira matriz:\n");
			ImprimirMatriz(matriz1);
			
			Console.Write("\nSegunda matriz:\n");
			ImprimirMatriz(matriz2);
			
			Console.Write("\nTerceira matriz:\n");
			ImprimirMatriz(matriz3);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}