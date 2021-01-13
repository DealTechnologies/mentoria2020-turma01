using System;

namespace Matriz02_E07
{
	class Program
	{
		const int linhas = 10;
		const int colunas = 3;
		const int TAMvetor = 10;
		
		static void LerVetor(double[] vetor)
		{
			for(int i=0; i<linhas; i++)
			{
				Console.Write("Digite o índice [{0}]: ",i);
				vetor[i] = Convert.ToDouble(Console.ReadLine());
			}
		}
		
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
		
		static void OrdenarMatriz(double[,] matriz, double[] vetor1, double[] vetor2, double[] vetor3)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(j==0)
					{
						matriz[i,j] = vetor1[j];
					}
					else
					{
						if(j==1)
						{
							matriz[i,j] = vetor2[j];
						}
						else
						{
							matriz[i,j] = vetor3[j];
						}
					}
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
			double[] vetor1 = new double[TAMvetor];
			double[] vetor2 = new double[TAMvetor];
			double[] vetor3 = new double[TAMvetor];
			
			Console.Write("\nPrimeiro Vetor:\n");
			LerVetor(vetor1);
			
			Console.Write("\nSegundo Vetor:\n");
			LerVetor(vetor2);
			
			Console.Write("\nTerceiro Vetor:\n");
			LerVetor(vetor3);
			
			OrdenarMatriz(matriz, vetor1, vetor2, vetor3);
			
			Console.Write("\nMatriz:\n");
			ImprimirMatriz(matriz);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}