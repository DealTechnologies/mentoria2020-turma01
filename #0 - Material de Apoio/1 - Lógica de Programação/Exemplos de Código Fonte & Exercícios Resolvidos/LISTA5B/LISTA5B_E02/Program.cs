using System;

namespace LISTA5B_E02
{
	class Program
	{
		public static void Main(string[] args)
		{
			int n1, n2;
			
			Console.Write("Digite o primero número: ");
			n1 = Convert.ToInt32(Console.ReadLine());
			
			Console.Write("Digite o segundo número: ");
			n2 = Convert.ToInt32(Console.ReadLine());
			
			if(n1%n2 == 0){
				Console.WriteLine("\nDIVISÍVEL");
			}
			else{
				Console.WriteLine("\nNÃO DIVISÍVEL");
			}			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}