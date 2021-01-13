using System;

namespace Aula05_E04
{
	class Program
	{
		public static void Main(string[] args)
		{
			int numero, anterior, posterior;
			
			Console.Write("Informe um número:"); numero = Convert.ToInt32(Console.ReadLine());
			
			anterior = numero -1;
			posterior = numero + 1;
			
			Console.WriteLine("\nO número anterior é : {0}", anterior);
			Console.WriteLine("O número posterior é: {0}", posterior);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}