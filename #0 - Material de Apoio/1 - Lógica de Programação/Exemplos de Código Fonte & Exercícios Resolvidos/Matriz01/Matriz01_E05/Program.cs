using System;

namespace Matriz01_E05
{
	class Program
	{
		const int linhas = 5;
		const int colunas= 5;
				
		static void Imprimir(double[,] matriz)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(i==j)
					{
						Console.Write("{0,4} ", matriz[i,j]=1);
					}
					else
					{
						Console.Write("{0,4} ", matriz[i,j]=0);
					}					
				}
				Console.WriteLine();
			}
		}
		
		
		public static void Main(string[] args)
		{
			double[,] matriz = new double[linhas,colunas];
			
			Imprimir(matriz);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}