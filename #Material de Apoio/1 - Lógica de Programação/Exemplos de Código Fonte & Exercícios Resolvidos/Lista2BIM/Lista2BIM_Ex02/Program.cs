using System;

namespace Lista2BIM_Ex02
{
	class Program
	{
		const int linhas = 5;
		const int colunas = 5;
		
		static void LerMatriz(double[,] matriz)
		{
			for(int i=0; i < linhas; i++)
			{
				for(int j=0; j < colunas; j++)
				{
					Console.Write("Indice[{0},{1}]: ", i,j);
					matriz[i,j] = Convert.ToDouble(Console.ReadLine());
				}
				Console.WriteLine();
			}
		}
		
		static void ImprimirMatriz(double[,] matriz)
		{
			for(int i=0; i < linhas; i++)
			{
				for(int j=0; j < colunas; j++)
				{
					Console.Write("{0,4}", matriz[i,j]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		
		static void InverterMatriz(double[,] matriz)
		{
			double auxiliar;
			
			for(int i=0; i < linhas; i++)
			{
				for(int j=0; j < colunas; j++)
				{
					if(i==j)
					{						
						auxiliar = matriz[i,j];
						matriz[i,j] = matriz[i,4-i];
						matriz[i,4-i] = auxiliar;
					}
				}
			}
		}
		
		
		public static void Main(string[] args)
		{
			double[,] matriz = new double[linhas,colunas];
			
			LerMatriz(matriz);
			Console.WriteLine(" Matriz:");	
			ImprimirMatriz(matriz);
			
			InverterMatriz(matriz);
			Console.WriteLine(" Matriz Invertida:");
			ImprimirMatriz(matriz);
			
			Console.Write("\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}