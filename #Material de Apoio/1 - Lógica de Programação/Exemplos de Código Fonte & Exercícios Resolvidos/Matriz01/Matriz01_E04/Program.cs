using System;

namespace Matriz01_E04
{
	class Program
	{
		const int linhas = 10;
		const int colunas=10;
		
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
		
		static void Imprimir(double[,] matriz)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					Console.Write("{0,4} ",matriz[j,i]);
					
				}
				Console.WriteLine();
			}
		}
		
		
		public static void Main(string[] args)
		{
			double[,] matriz = new double[linhas,colunas];
			
			Console.Write("Informe os índices da matriz:\n");
			LerMatriz(matriz);
			
			Imprimir(matriz);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}