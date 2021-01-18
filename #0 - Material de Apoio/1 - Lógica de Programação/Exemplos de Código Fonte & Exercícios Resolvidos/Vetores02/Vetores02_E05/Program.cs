using System;

namespace Vetores02_E05
{
	class Program
	{
		const int TAMANHO = 4;
		
		static int Procurar(int[] vetor, int numero)
		{
			int retorno=0;
			
			for(int i=0; i < TAMANHO; i++)
			{
				//Console.Write("\nIndice {0} ", i);
				if(vetor[i] != numero)
				{
					retorno = -1;
				}
				else
				{
					retorno = i;
					break;
				}
			}			
			return retorno;
		}
		
		
				
		public static void Main(string[] args)
		{			
			int[] vetor = new int[TAMANHO];
			int numero;
			int retorno=0;
			
			for(int i=0; i < TAMANHO; i++)
			{
				Console.Write("Informe o valor no índice {0}: ", i);
				vetor[i] = Convert.ToInt32(Console.ReadLine());
			}
			
			Console.Write("\nInforme o valor a ser encontrado: ");
			numero = Convert.ToInt32(Console.ReadLine());
			
			retorno = Procurar(vetor, numero);
			
			if(retorno == -1)
			{
				Console.WriteLine("\nO número {0} não foi encontrado", numero);
			}
			else
			{
				Console.WriteLine("\nO número {0} foi encontrado no índice {1}", numero, retorno);
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}