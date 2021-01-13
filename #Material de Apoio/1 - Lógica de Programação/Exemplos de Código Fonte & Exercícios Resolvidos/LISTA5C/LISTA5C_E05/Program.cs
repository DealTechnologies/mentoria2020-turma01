using System;

namespace LISTA5C_E05
{
	class Program
	{
		public static void Main(string[] args)
		{
			int numero, maior;
			
			Console.Write("Informe um número: ");
			numero = Convert.ToInt32(Console.ReadLine());
			
			maior = numero;
			
			while(maior>=numero)
			{				
				Console.Write("Informe um número: ");
				numero = Convert.ToInt32(Console.ReadLine());
				
				if(numero>=maior)
				{
					maior = numero;
				}
				else
				{
					Console.WriteLine("\nFim da operação");
					break;
				}
			}
			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}