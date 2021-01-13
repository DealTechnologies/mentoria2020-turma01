using System;

namespace Matriz02_E05
{
	class Program
	{
		const int linhas = 5;
		const int colunas = 10;
		
		static void LerMatriz(char[,] matriz)
		{
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					Console.Write("Digite o índice [{0},{1}]: ",i,j); 
					matriz[i,j] = Convert.ToChar(Console.ReadLine());
					
				}
				Console.WriteLine();
			}
		}
		
		static int ContarLetraA(char[,] matriz)
		{
			int cont=0;
			
			for(int i=0; i<linhas; i++)
			{
				for(int j=0;j<colunas;j++)
				{
					if(matriz[i,j]=='a' || matriz[i,j]=='A')
					{
						cont++;
					}
				}
			}
			return cont;
		}
		
		public static void Main(string[] args)
		{
			char[,] matriz = new char[linhas,colunas];
			int cont;
			
			Console.Write("Informe os índices da matriz:\n");
			LerMatriz(matriz);
			
			cont = ContarLetraA(matriz);
			Console.Write("Quantidade de letras A/a na matriz é: {0}", cont);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}