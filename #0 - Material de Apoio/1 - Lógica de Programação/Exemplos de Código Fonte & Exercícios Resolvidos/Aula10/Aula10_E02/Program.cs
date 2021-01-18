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
			if(numero % 2 == 0){
				Console.WriteLine("\nO número é divisível por 2.");
			}
			else{
				Console.WriteLine("\nO número não é divisível por 2.");
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