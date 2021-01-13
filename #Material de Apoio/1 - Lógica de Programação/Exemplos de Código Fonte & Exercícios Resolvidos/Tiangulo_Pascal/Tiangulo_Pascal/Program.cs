using System;

namespace Triangulo_Pascal
{
	class Program
	{	
		static void ImprimirMatriz(double[,] matriz, int numero)
		{
			int linhas = numero;
			int colunas = numero;
			
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(matriz[i,j]==0)
					{
						Console.Write(" ");
					}
					else
					{
						Console.Write(" {0,4}",matriz[i,j]);
					}
				}				
				Console.WriteLine();
			}
		}
		
		static void Ordenar1(double[,] matriz, int numero)
		{
			int linhas = numero;
			int colunas = numero;
			int ultimo = linhas-1;
			
			Console.WriteLine("\nPrimeiro Modo:");
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(i==0 || j==0)
					{
						matriz[i,j]=1;						
					}
				}
			}
			
			for(int i=1; i<linhas; i++)
			{
				for(int j=1;j<ultimo;j++)
				{
					matriz[i,j] = matriz[i-1, j-1] + matriz[i,j-1];
				}
				ultimo--;
			}
		}
		
		static void Ordenar2(double[,] matriz, int numero)
		{
			int linhas = numero;
			int colunas = numero;
			int ultimo = numero-1;
			
			Console.WriteLine("\nSegundo Modo:");
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(i==0 || j==0)
					{
						matriz[i,j]=1;						
					}
				}
			}
			
			for(int i=1; i<linhas; i++)
			{
				for(int j=1;j<ultimo;j++)
				{
					matriz[i,j] = matriz[i-1, j] + matriz[i,j-1];
				}
				ultimo--;
			}
		}
		
		
		public static void Main(string[] args)
		{
			int numero;
						
			Console.Write("Informe o número de linhas e colunas: ");
			numero = Convert.ToInt32(Console.ReadLine());
			
			double[,] matriz = new double[numero,numero];			
			
			Ordenar1(matriz, numero);
			
			ImprimirMatriz(matriz, numero);
			
			Ordenar2(matriz, numero);
			
			ImprimirMatriz(matriz, numero);
			
			Console.ReadKey(true);
		}
	}
}