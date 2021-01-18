using System;

namespace Aula10_E02
{
	class Program
	{
		static int LerTecladoInt(){
			int x;
			x = Convert.ToInt32(Console.ReadLine());
			return x;
		}

		static void Divisivel(int numero){
			if((numero % 2 == 0) && (numero % 3 == 0)){
				if((numero % 5 != 0)){
					Console.WriteLine("\nO número é divisível por 2 e 3 simultâneamente e não é divisível por 5!");
				}
				else{
					Console.WriteLine("\nO número é divisível por 2, 3 e 5 simultâneamente.");
				}
			}
			else{
				Console.WriteLine("\nO número não é divisível por 2 e 3 simultâneamente.");
			}
		}
		
		
		public static void Main(string[] args)
		{
			int numero;
			
			Console.Write("Informe um número: ");
			numero = LerTecladoInt();
			
			Divisivel(numero);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}