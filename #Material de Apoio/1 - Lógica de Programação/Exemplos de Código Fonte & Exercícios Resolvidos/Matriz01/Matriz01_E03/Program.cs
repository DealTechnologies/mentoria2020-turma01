using System;

namespace Matriz01_E03
{
	class Program
	{
		const int linhas = 3;
		const int colunas=3;
		
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
		
		static void SomarMatriz(double[,] m1, double[,] m2)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					Console.Write("{0,4} ",m1[i,j]+m2[i,j]);
				}
				Console.WriteLine();
			}
		}
		public static void Main(string[] args)
		{
			double[,] m1 = new double[linhas,colunas];
			double[,] m2 = new double[linhas,colunas];
			
			Console.Write("Informe os índices da primeira matriz:\n");
			LerMatriz(m1);
			
			Console.Write("Informe os índices da segunda matriz:\n");
			LerMatriz(m2);
			
			Console.Write("Soma:\n");
			SomarMatriz(m1,m2);
			
			Console.ReadKey(true);
		}
	}
}