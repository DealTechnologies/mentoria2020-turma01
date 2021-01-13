using System;

namespace Aula10_E01
{
	class Program
	{
		static int LerTecladoInt(){
			int x;
			x = Convert.ToInt32(Console.ReadLine());
			return x;
		}
		
		static void MaiorMenorIgual(int n1, int n2){
			if(n1>n2){
				Console.WriteLine("\nO primeiro número é maior!");
			}
			else{
				if(n1<n2){
					Console.WriteLine("\nO primeiro número é menor!");
				}
				else{
					Console.WriteLine("\nOs números são iguais!");
				}
			}
		}
		
		public static void Main(string[] args)
		{
			int n1, n2;
						
			Console.Write("Informe o primeiro número: ");
			n1 = LerTecladoInt();
					
			Console.Write("Informe o segundo número : ");
			n2 = LerTecladoInt();
			
			MaiorMenorIgual(n1, n2);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}