using System;

namespace Matriz02_E01
{
	class Program
	{
		const int linhas = 3;
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
		
		static double Maior(double[,] matriz)
		{
			double maior = matriz[0,0];
			
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(maior<matriz[i,j])
					{
						maior = matriz[i,j];
					}
				}
			}
			return maior;
		}
		
		static double Menor(double[,] matriz)
		{
			double menor = matriz[0,0];
			
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(menor>matriz[i,j])
					{
						menor = matriz[i,j];
					}
				}
			}
			return menor;
		}
		
		public static void Main(string[] args)
		{
			double[,] matriz = new double[linhas,colunas];
			double menor = 0;
			double maior = 0;
			
			Console.Write("Informe os índices da matriz:\n");
			LerMatriz(matriz);
			
			maior = Maior(matriz);
			menor = Menor(matriz);
			
			Console.Write("\nMenor : {0:N2}",menor);
			Console.Write("\nMaior : {0:N2}",maior);
			
			Console.ReadKey(true);
		}
	}
}