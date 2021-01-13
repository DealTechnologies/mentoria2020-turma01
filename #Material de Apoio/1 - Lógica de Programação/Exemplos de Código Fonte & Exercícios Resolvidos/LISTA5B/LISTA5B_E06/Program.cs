using System;

namespace LISTA5B_E06
{
	class Program
	{
		public static void Main(string[] args)
		{
			int numero;
			int pares = 0;
			int impares = 0;
			double mediaPares = 0;
			double mediaGeral = 0;
			
			Console.Write("Informe um número: ");
			numero = Convert.ToInt32(Console.ReadLine());
			
			while(numero>=0){
				if(numero%2 == 0){
					mediaPares = mediaPares + numero;
					pares++;
				}
				else{
					impares++;
				}
				
				mediaGeral = mediaGeral + numero;
				
				Console.Write("Informe um número: ");
				numero = Convert.ToInt32(Console.ReadLine());
			}
			
			mediaPares = mediaPares / pares;
			mediaGeral = mediaGeral / (pares+impares);
			
			Console.WriteLine("\nQuantidade de números pares: {0}", pares);
			Console.WriteLine("Quantidade de números ímpares: {0}", impares);
			Console.WriteLine("Média dos números pares: {0}", mediaPares);
			Console.WriteLine("Média geral: {0}", mediaGeral);
			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}